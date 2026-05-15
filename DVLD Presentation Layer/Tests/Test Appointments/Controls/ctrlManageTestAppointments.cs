using System;
using System.Data;
using System.Windows.Forms;
using DVLD_Buisness_Layer;
using DVLD_Project.Tests.Test_Appointments.Forms;
using DVLD_Project.Tests.TestQuestions.Forms;

namespace DVLD_Project.Tests.Test_Appointments.Controls
{
    public partial class ctrlManageTestAppointments : UserControl
    {
        public ctrlManageTestAppointments()
        {
            InitializeComponent();
        }

        public int LDLA_ID { get; set; }
        public clsTestType.enTestType TestTypeID { get; set; }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this?.FindForm().Close();
        }

        private void _RefreshAppointmentsData()
        {
            DataTable dtAppointmentsData = clsTestAppointment.GetAllAppointmentsForTest(LDLA_ID, (byte)TestTypeID);
            dgvAppointmentsData.DataSource = dtAppointmentsData;

            _RenameColumnsFor_dgvAppointmentsData();
            _FormatContentFor_dgvAppointmentsData();

            ctrlLDLAInfo1.GetValuesFromParentControlAndLoadData(LDLA_ID);
            lblRecords.Text = dgvAppointmentsData.Rows.Count.ToString();
        }

        private void ctrlScheduleTest_Load(object sender, EventArgs e)
        {
            _RefreshAppointmentsData();
        }

        private void _RenameColumnsFor_dgvAppointmentsData()
        {
            if (dgvAppointmentsData.Rows.Count == 0)
                return;

            dgvAppointmentsData.Columns[0].HeaderText = "Test Appointment ID";
            dgvAppointmentsData.Columns[1].HeaderText = "Appointment Date";
            dgvAppointmentsData.Columns[2].HeaderText = "Paid Fees";
            dgvAppointmentsData.Columns[3].HeaderText = "Is Locked";
            dgvAppointmentsData.Columns[4].HeaderText = "Test Type Title";
        }

        private void _FormatContentFor_dgvAppointmentsData()
        {
            if (dgvAppointmentsData.Rows.Count == 0)
                return;

            dgvAppointmentsData.Columns["PaidFees"].DefaultCellStyle.Format = "N2";
        }

        private void _HandleAddAppointmentButton()
        {
            if (clsTestAppointment.IsPersonHasActiveTestAppointment(LDLA_ID, (byte)TestTypeID))
            {
                MessageBox.Show("Person already has an active test appointment for this test type, You cannot make another appointment",
                                "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (clsTests.IsPersonPassedTest(LDLA_ID, TestTypeID))
            {
                MessageBox.Show("Person already passed this test!", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            switch (TestTypeID)
            {
                case clsTestType.enTestType.VisionTest:
                    frmScheduleVisionTest frmVisionTest = new frmScheduleVisionTest(LDLA_ID, clsTestType.enTestType.VisionTest);
                    frmVisionTest.ShowDialog();
                    _RefreshAppointmentsData();
                    break;

                case clsTestType.enTestType.WrittenTest:
                    frmScheduleWrittenTest frmWrittenTest = new frmScheduleWrittenTest(LDLA_ID, clsTestType.enTestType.WrittenTest);
                    frmWrittenTest.ShowDialog();
                    _RefreshAppointmentsData();
                    break;

                case clsTestType.enTestType.StreetTest:
                    frmScheduleStreetTest frmStreetTest = new frmScheduleStreetTest(LDLA_ID, clsTestType.enTestType.StreetTest);
                    frmStreetTest.ShowDialog();
                    _RefreshAppointmentsData();
                    break;

                default:
                    break;
            }
        }

        private void btnAddAppointment_Click(object sender, EventArgs e)
        {
            _HandleAddAppointmentButton();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEditScheduleTest frm = new frmEditScheduleTest(LDLA_ID, TestTypeID, (int)dgvAppointmentsData.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _RefreshAppointmentsData();
        }

        private void cmsTests_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            editToolStripMenuItem.Enabled = !(bool)dgvAppointmentsData.CurrentRow.Cells["IsLocked"].Value;
            takeTestToolStripMenuItem.Enabled = !(bool)dgvAppointmentsData.CurrentRow.Cells["IsLocked"].Value;
        }

        private void takeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (TestTypeID == clsTestType.enTestType.WrittenTest)
            {
                frmWrittenTestQuestions frm = new frmWrittenTestQuestions((int)dgvAppointmentsData.CurrentRow.Cells[0].Value);
                frm.ShowDialog();
                _RefreshAppointmentsData();
            }

            else
            {
                frmTakeTest frm = new frmTakeTest((int)dgvAppointmentsData.CurrentRow.Cells[0].Value);
                frm.ShowDialog();
                _RefreshAppointmentsData();
            }
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTestAppointmentDetails frm = new frmTestAppointmentDetails(LDLA_ID, (int)dgvAppointmentsData.CurrentRow.Cells[0].Value, TestTypeID);
            frm.ShowDialog();
        }
    }
}
