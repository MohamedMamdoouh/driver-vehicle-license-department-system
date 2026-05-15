using System;
using System.Data;
using System.Windows.Forms;
using DVLD_Buisness_Layer;
using DVLD_Project.Applications.Local_Driving_License.Forms;
using DVLD_Project.Global;
using DVLD_Project.Licenses.Forms;
using DVLD_Project.Tests.Test_Appointments.Forms;

namespace DVLD_Project.Applications.Local_Driving_License.Controls
{
    public partial class ctrlManageLDLA : UserControl
    {
        public ctrlManageLDLA()
        {
            InitializeComponent();
        }

        private DataView _dvLDLA;

        private void _FilterLocalDrivingLicenseData()
        {
            if (_dvLDLA == null)
                return;

            string SelectedFilter = cbFilterBy.SelectedItem.ToString();
            string ValueToSearch = txtFilter.Text.Trim().Replace("'", "''");

            if (string.IsNullOrEmpty(ValueToSearch))
            {
                if (cbFilterBy.SelectedItem.ToString() != "Application Date" && cbFilterBy.SelectedItem.ToString() != "Application Status")
                {
                    _dvLDLA.RowFilter = "";
                    return;
                }
            }

            switch (SelectedFilter)
            {
                case "LDLA ID":
                    _dvLDLA.RowFilter = $"LocalDrivingLicenseApplicationID = {ValueToSearch}";
                    break;

                case "Class Name":
                    _dvLDLA.RowFilter = $"ClassName like '%{ValueToSearch}%'";
                    break;

                case "National Number":
                    _dvLDLA.RowFilter = $"NationalNo like '%{ValueToSearch}%'";
                    break;

                case "Full Name":
                    _dvLDLA.RowFilter = $"FullName like '%{ValueToSearch}%'";
                    break;

                case "Application Date":
                    DateTime SelectedDate = dtpApplicationDate.Value.Date;
                    _dvLDLA.RowFilter = $"ApplicationDate >= #{SelectedDate:yyyy-MM-dd} 00:00:00# AND ApplicationDate < #{SelectedDate:yyyy-MM-dd} 23:59:59#";
                    break;

                case "Application Status":
                    _HandleApplicationStatusFilterChoice();
                    break;

                default:
                    break;
            }
        }

        private void _LimitApplicationDateFilter()
        {
            dtpApplicationDate.MinDate = DateTime.Now.AddYears(-5);
            dtpApplicationDate.MaxDate = DateTime.Now.AddYears(5);
        }

        private void _HandleApplicationStatusFilterChoice()
        {
            string SelectedFilter = cbApplicationStatus.SelectedItem.ToString();

            switch (SelectedFilter)
            {
                case "All":
                    _dvLDLA.RowFilter = "";
                    break;

                case "New":
                    _dvLDLA.RowFilter = "Status = 'New'";
                    break;

                case "Cancelled":
                    _dvLDLA.RowFilter = "Status = 'Cancelled'";
                    break;

                case "Completed":
                    _dvLDLA.RowFilter = "Status = 'Completed'";
                    break;

                default:
                    break;
            }
        }

        private void _UpdateRecordsCount()
        {
            if (_dvLDLA != null)
                lblRecords.Text = _dvLDLA.Count.ToString();
        }

        private void _FillFilterByItems()
        {
            cbFilterBy.Items.Add("None");
            cbFilterBy.Items.Add("LDLA ID");
            cbFilterBy.Items.Add("Class Name");
            cbFilterBy.Items.Add("National Number");
            cbFilterBy.Items.Add("Full Name");
            cbFilterBy.Items.Add("Application Date");
            cbFilterBy.Items.Add("Application Status");

            cbFilterBy.SelectedItem = "None";
        }

        private void _FillApplicationStatusFilter()
        {
            cbApplicationStatus.Items.Add("All");
            cbApplicationStatus.Items.Add("New");
            cbApplicationStatus.Items.Add("Cancelled");
            cbApplicationStatus.Items.Add("Completed");

            cbApplicationStatus.SelectedItem = "All";
        }

        private void _FillFields()
        {
            _FillFilterByItems();
            _FillApplicationStatusFilter();
            _LimitApplicationDateFilter();
        }

        private void _RefreshLDLAData()
        {
            txtFilter.Clear();

            DataTable dtLDLA_Data = clsLocalDrivingLicenseApplication.GetLDLAData();
            _dvLDLA = new DataView(dtLDLA_Data);
            dgvLDLA_Data.DataSource = _dvLDLA;

            _UpdateRecordsCount();
        }

        private void _RenameColumns_ForDGV()
        {
            dgvLDLA_Data.Columns["LocalDrivingLicenseApplicationID"].HeaderText = "LDLA ID";
            dgvLDLA_Data.Columns["ClassName"].HeaderText = "Class Name";
            dgvLDLA_Data.Columns["NationalNo"].HeaderText = "National No";
            dgvLDLA_Data.Columns["FullName"].HeaderText = "Full Name";
            dgvLDLA_Data.Columns["ApplicationDate"].HeaderText = "Application Date";
            dgvLDLA_Data.Columns["Status"].HeaderText = "Application Status";
            dgvLDLA_Data.Columns["PassedTestCount"].HeaderText = "Passed Tests";
        }

        private void _AdjustColumnsWidth()
        {
            dgvLDLA_Data.Columns["LocalDrivingLicenseApplicationID"].Width = 60;
            dgvLDLA_Data.Columns["ClassName"].Width = 230;
            dgvLDLA_Data.Columns["NationalNo"].Width = 80;
            dgvLDLA_Data.Columns["FullName"].Width = 330;
            dgvLDLA_Data.Columns["ApplicationDate"].Width = 170;
            dgvLDLA_Data.Columns["Status"].Width = 100;
            dgvLDLA_Data.Columns["PassedTestCount"].Width = 65;
        }

        private void _HandleControlsVisibilty()
        {
            txtFilter.Clear();

            if (cbFilterBy.SelectedItem.ToString() == "Application Date")
            {
                dtpApplicationDate.Visible = true;
                txtFilter.Visible = false;
                cbApplicationStatus.Visible = false;
            }

            else if (cbFilterBy.SelectedItem.ToString() == "Application Status")
            {
                cbApplicationStatus.Visible = true;
                dtpApplicationDate.Visible = false;
                txtFilter.Visible = false;
            }

            else
            {
                txtFilter.Visible = (cbFilterBy.SelectedItem.ToString() != "None");
                dtpApplicationDate.Visible = false;
                cbApplicationStatus.Visible = false;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this?.FindForm().Close();
        }

        private void ctrlManageLocalDrivingLicense_Load(object sender, EventArgs e)
        {
            _FillFields();
            _RefreshLDLAData();
            _RenameColumns_ForDGV();
            _AdjustColumnsWidth();
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            _FilterLocalDrivingLicenseData();
            _HandleControlsVisibilty();
            _UpdateRecordsCount();
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            _FilterLocalDrivingLicenseData();
            _UpdateRecordsCount();
        }

        private void dtpApplicationDate_ValueChanged(object sender, EventArgs e)
        {
            _FilterLocalDrivingLicenseData();
            _UpdateRecordsCount();
        }

        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.SelectedItem.ToString() == "LDLA ID")
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }

        private void cbApplicationStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            _FilterLocalDrivingLicenseData();
            _UpdateRecordsCount();
        }

        private void showApplicationDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLDLAAInfo frm = new frmLDLAAInfo((int)dgvLDLA_Data.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }

        private void cancelApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _HandleCancelChoice();
        }

        private void _HandleCancelChoice()
        {
            if (MessageBox.Show("Are you sure you want to cancel this application?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            clsLocalDrivingLicenseApplication LDLA_Application = clsLocalDrivingLicenseApplication.GetLocalDrivingLicenseApplicationByLDLA_ID((int)dgvLDLA_Data.CurrentRow.Cells[0].Value);
            if (LDLA_Application == null)
                return;

            if (LDLA_Application.Cancel())
            {
                MessageBox.Show("Application has been cancelled successfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _RefreshLDLAData();
            }
            else
            {
                MessageBox.Show("Error cancelling this application", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmsApplications_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            cancelApplicationToolStripMenuItem.Enabled = (dgvLDLA_Data.CurrentRow.Cells["Status"].Value.ToString() == "New");

            editApplicationToolStripMenuItem.Enabled = (dgvLDLA_Data.CurrentRow.Cells["Status"].Value.ToString() == "New"
            && !clsTestAppointment.IsPersonHasAnyTestAppointments((int)dgvLDLA_Data.CurrentRow.Cells[0].Value));

            deleteApplicationToolStripMenuItem.Enabled = (dgvLDLA_Data.CurrentRow.Cells["Status"].Value.ToString() == "Cancelled");

            scheduleTestToolStripMenuItem.Enabled = (dgvLDLA_Data.CurrentRow.Cells["Status"].Value.ToString() == "New");

            issueDrivingLicenseToolStripMenuItem.Enabled = clsTests.IsPassedAllTests((int)dgvLDLA_Data.CurrentRow.Cells[0].Value)
                && dgvLDLA_Data.CurrentRow.Cells["Status"].Value.ToString() == "New";

            showLicenseToolStripMenuItem.Enabled = clsLocalLicense.IsLicenseExistByLDLA_ID((int)dgvLDLA_Data.CurrentRow.Cells[0].Value);

            showPersonLicenseHistoryToolStripMenuItem.Enabled = clsPerson.DoesPersonHasAnyLicense((string)dgvLDLA_Data.CurrentRow.Cells["NationalNo"].Value);

            _CanPersonTakeTest();
        }

        private void _CanPersonTakeTest()
        {
            bool IsVisionPassed = clsTests.IsPersonPassedTest((int)dgvLDLA_Data.CurrentRow.Cells[0].Value, clsTestType.enTestType.VisionTest);
            bool IsWrittenPassed = clsTests.IsPersonPassedTest((int)dgvLDLA_Data.CurrentRow.Cells[0].Value, clsTestType.enTestType.WrittenTest);
            bool IsStreetPassed = clsTests.IsPersonPassedTest((int)dgvLDLA_Data.CurrentRow.Cells[0].Value, clsTestType.enTestType.StreetTest);

            if (!IsVisionPassed)
            {
                visionTestToolStripMenuItem.Enabled = true;
                writtenTestToolStripMenuItem.Enabled = false;
                streetTestToolStripMenuItem.Enabled = false;
            }
            else if (!IsWrittenPassed)
            {
                visionTestToolStripMenuItem.Enabled = false;
                writtenTestToolStripMenuItem.Enabled = true;
                streetTestToolStripMenuItem.Enabled = false;
            }
            else if (!IsStreetPassed)
            {
                visionTestToolStripMenuItem.Enabled = false;
                writtenTestToolStripMenuItem.Enabled = false;
                streetTestToolStripMenuItem.Enabled = true;
            }
            else
            {
                // All tests passed
                scheduleTestToolStripMenuItem.Enabled = false;
            }
        }

        private void deleteApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _HandleDeleteChoice();
        }

        private void _HandleDeleteChoice()
        {
            if (MessageBox.Show("Are you sure you want to delete this application?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            clsLocalDrivingLicenseApplication LDLA_Application = clsLocalDrivingLicenseApplication.GetLocalDrivingLicenseApplicationByLDLA_ID((int)dgvLDLA_Data.CurrentRow.Cells[0].Value);

            if (LDLA_Application == null)
                return;

            if (LDLA_Application.Delete())
            {
                MessageBox.Show("Application has been deleted successfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _RefreshLDLAData();
            }
            else
            {
                MessageBox.Show("Error deleting this application", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void editApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdateLDLA frm = new frmAddUpdateLDLA((int)dgvLDLA_Data.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _RefreshLDLAData();
        }

        private void btnAddLDLA_Click(object sender, EventArgs e)
        {
            frmAddUpdateLDLA frm = new frmAddUpdateLDLA(-1);
            frm.ShowDialog();
            _RefreshLDLAData();
        }

        private void visionTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageTestAppointments frm = new frmManageTestAppointments((int)dgvLDLA_Data.CurrentRow.Cells[0].Value, clsTestType.enTestType.VisionTest);
            frm.Text = "Vision Test Appointments";
            frm.ShowDialog();
            _RefreshLDLAData();
        }

        private void writtenTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageTestAppointments frm = new frmManageTestAppointments((int)dgvLDLA_Data.CurrentRow.Cells[0].Value, clsTestType.enTestType.WrittenTest);
            frm.Text = "Written Test Appointments";
            frm.ShowDialog();
            _RefreshLDLAData();
        }

        private void streetTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageTestAppointments frm = new frmManageTestAppointments((int)dgvLDLA_Data.CurrentRow.Cells[0].Value, clsTestType.enTestType.StreetTest);
            frm.Text = "Street Test Appointments";
            frm.ShowDialog();
            _RefreshLDLAData();
        }

        private void issueDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmIssueLicense frm = new frmIssueLicense((int)dgvLDLA_Data.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _RefreshLDLAData();
        }

        private void showLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLocalLicesneInfo frm = new frmLocalLicesneInfo(clsLocalLicense.GetLicenseInfoByLDLA_ID((int)dgvLDLA_Data.CurrentRow.Cells[0].Value).LicenseID);
            frm.ShowDialog();
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLicenseHistory frm = new frmLicenseHistory((string)dgvLDLA_Data.CurrentRow.Cells["NationalNo"].Value);
            frm.ShowDialog();
        }
    }
}
