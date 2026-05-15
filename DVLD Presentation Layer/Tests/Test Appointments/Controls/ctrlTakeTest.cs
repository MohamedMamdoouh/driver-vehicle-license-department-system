using System;
using System.Net.Http.Headers;
using System.Windows.Forms;
using DVLD_Buisness_Layer;
using DVLD_Project.Global;

namespace DVLD_Project.Tests.Test_Appointments.Controls
{
    public partial class ctrlTakeTest : UserControl
    {
        public ctrlTakeTest()
        {
            InitializeComponent();
        }

        public int TestAppointmentID { get; set; }

        private clsTestAppointment _TestAppointmentInfo;
        private clsTests _TestInfo;

        private void btnClose_Click(object sender, EventArgs e)
        {
            this?.FindForm().Close();
        }

        private void _LoadData()
        {
            _TestAppointmentInfo = clsTestAppointment.GetTestAppointmentInfoByID(TestAppointmentID);

            if (_TestAppointmentInfo == null)
                return;

            lblLDL_ID.Text = _TestAppointmentInfo.LDLA_ID.ToString();
            lblLicenseClass.Text = clsLocalLicenseClass.FindByLDLA_ID(_TestAppointmentInfo.LDLA_ID).LicenseClassName;
            lblApplicantName.Text = clsLocalDrivingLicenseApplication.GetLocalDrivingLicenseApplicationByLDLA_ID(_TestAppointmentInfo.LDLA_ID).Person.FullName;
            lblTrials.Text = clsTests.GetTotalTrialsPerTest(_TestAppointmentInfo.LDLA_ID, _TestAppointmentInfo.TestTypeID).ToString();
            lblDate.Text = clsFormat.ToShortDateString(_TestAppointmentInfo.AppointmentDate) ;
            lblFees.Text = clsFormat.ToShortMoneyString(_TestAppointmentInfo.PaidFees);
        }

        private bool _Save()
        {
            _TestInfo = new clsTests();

            _TestInfo.TestAppointmentID = _TestAppointmentInfo.TestAppointmentID;
            _TestInfo.TestResult = rbPass.Checked ? true : false;
            _TestInfo.Notes = string.IsNullOrEmpty(txtNotes.Text) ? "" : txtNotes.Text;
            _TestInfo.CreatedByUserID = clsUtil.CurrentUser.UserID;

            return _TestInfo.AddNewTestResult();
        }

        private void ctrlTakeTest_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to save this result? You cannot undo this change!",
                                "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            if (_Save())
            {
                MessageBox.Show("Test results have been saved successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this?.FindForm().Close();
            }
            else
            {
                MessageBox.Show("Cannot save results", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
