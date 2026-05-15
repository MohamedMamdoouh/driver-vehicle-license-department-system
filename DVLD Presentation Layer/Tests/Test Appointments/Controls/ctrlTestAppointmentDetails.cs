using System;
using System.Windows.Forms;
using DVLD_Buisness_Layer;
using DVLD_Project.Global;

namespace DVLD_Project.Tests.Test_Appointments.Controls
{
    public partial class ctrlTestAppointmentDetails : UserControl
    {
        public ctrlTestAppointmentDetails()
        {
            InitializeComponent();
        }

        private clsTestAppointment _Appointment;

        public int TestAppointmentID;
        public int LDLA_ID;
        public clsTestType.enTestType TestTypeID;

        private void btnClose_Click(object sender, EventArgs e)
        {
            this?.FindForm().Close();
        }

        private void _GetAppointmentInfo()
        {
            _Appointment = clsTestAppointment.GetTestAppointmentInfoByID(TestAppointmentID);

            if (_Appointment == null)
                return;

            lblLDL_ID.Text = _Appointment.LDLA_ID.ToString();
            lblLicenseClass.Text = clsLocalLicenseClass.FindByLDLA_ID(_Appointment.LDLA_ID).LicenseClassName;
            lblApplicantName.Text = clsLocalDrivingLicenseApplication.GetLocalDrivingLicenseApplicationByLDLA_ID(LDLA_ID).Person.FullName;
            lblTrials.Text = clsTests.GetTotalTrialsPerTest(_Appointment.LDLA_ID, TestTypeID).ToString();
            lblDate.Text = clsFormat.ToShortDateString(_Appointment.AppointmentDate);
            lblFees.Text = clsFormat.ToShortMoneyString(clsTestType.Find(TestTypeID).Fees);
            lblIsPassedTest.Text = clsTests.IsPersonPassedTest(LDLA_ID, TestTypeID) ? "Yes" : "No";
            lblIsPassedAppointment.Text = clsTests.IsPersonPassedTestForThisAppointment(TestAppointmentID) ? "Yes" : "No";

            _HandleRetakeTest();
        }

        private void _HandleRetakeTest()
        {
            gbRetakeTest.Enabled = _Appointment.RetakeTestApplictionID == null ? false : true;

            if (gbRetakeTest.Enabled)
            {
                lblRetakeApplicationFees.Text =
                    clsFormat.ToShortMoneyString(clsApplication.FindApplicationByApplicationID(_Appointment.RetakeTestApplictionID.Value).PaidFees); ;

                lblTotalFees.Text = clsFormat.ToShortMoneyString((Convert.ToDecimal(lblRetakeApplicationFees.Text) + Convert.ToDecimal(lblFees.Text))); ;
            }
            else
            {
                lblRetakeApplicationFees.Text = "0";
                lblTotalFees.Text = lblFees.Text;
            }
        }

        private void ctrlAppointmentDetails_Load(object sender, EventArgs e)
        {
            _GetAppointmentInfo();
        }
    }
}
