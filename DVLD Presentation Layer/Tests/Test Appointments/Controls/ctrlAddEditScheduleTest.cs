using System;
using DVLD_Project.Properties;
using System.Windows.Forms;
using DVLD_Buisness_Layer;
using DVLD_Project.Global;

namespace DVLD_Project.Tests.Test_Appointments.Controls
{
    public partial class ctrlScheduleTest : UserControl
    {
        private enum enMode { AddNew, Update }
        private enMode _Mode;

        private enum enCreationMode { FirstTimeSchedule = 0, RetakeTestSchedule = 1 }
        private enCreationMode _CreationMode;

        private clsApplication _Application;
        private clsTestAppointment _Appointment;
        private clsLocalDrivingLicenseApplication _LDLA;

        public int LDLA_ID { get; set; }
        public int TestAppointmentID { get; set; }

        private clsTestType.enTestType _TestTypeID;
        public clsTestType.enTestType TestTypeID
        {
            get
            {
                return _TestTypeID;
            }
            set
            {
                _TestTypeID = value;

                switch (_TestTypeID)
                {
                    case clsTestType.enTestType.VisionTest:
                        {
                            gbTestType.Text = "Vision Test";
                            pbTestTypeImage.Image = Resources.Vision;
                            break;
                        }
                    case clsTestType.enTestType.WrittenTest:
                        {
                            gbTestType.Text = "Written Test";
                            pbTestTypeImage.Image = Resources.Written;
                            break;
                        }
                    case clsTestType.enTestType.StreetTest:
                        {
                            gbTestType.Text = "Street Test";
                            pbTestTypeImage.Image = Resources.Street;
                            break;
                        }
                }
            }
        }

        public ctrlScheduleTest()
        {
            InitializeComponent();
        }


        private void _LimitDate()
        {
            DateTime Today = DateTime.Today;
            DateTime MaxDate = Today.AddMonths(3);

            if (dtpDate.Value < Today)
                dtpDate.Value = Today;

            else if (dtpDate.Value > MaxDate)
                dtpDate.Value = MaxDate;

            dtpDate.MinDate = Today;
            dtpDate.MaxDate = MaxDate;
        }

        private void _AddNewTestAppointment()
        {
            _Appointment = new clsTestAppointment();
            _LDLA = clsLocalDrivingLicenseApplication.GetLocalDrivingLicenseApplicationByLDLA_ID(LDLA_ID);

            if (_LDLA == null)
                return;

            lblLDL_ID.Text = _LDLA.LDLA_ID.ToString();
            lblLicenseClass.Text = clsLocalLicenseClass.FindByLDLA_ID(_LDLA.LDLA_ID).LicenseClassName;
            lblApplicantName.Text = _LDLA.Person.FullName;
            lblTrials.Text = clsTests.GetTotalTrialsPerTest(LDLA_ID, _TestTypeID).ToString();
            dtpDate.Value = DateTime.Now;   
            lblFees.Text = clsFormat.ToShortMoneyString(clsTestType.Find(_TestTypeID).Fees);

            _HandleRetakeTestForAddTestSchedule();
        }

        private void _HandleRetakeTestForAddTestSchedule()
        {
            if (_CreationMode == enCreationMode.RetakeTestSchedule)
            {
                _Application = new clsApplication();
                _Application.ApplicantPersonID = _LDLA.Person.ID;
                _Application.ApplicationDate = DateTime.Now;
                _Application.ApplicationTypeID = clsApplication.enApplicationType.RetakeTest;
                _Application.ApplicationStatus = clsApplication.enApplicationStatus.Completed;
                _Application.LastStatusDate = DateTime.Now;
                _Application.PaidFees = clsApplicationType.Find(clsApplication.enApplicationType.RetakeTest).Fees;
                _Application.CreatedByUserID = clsUtil.CurrentUser.UserID;

                gbRetakeTest.Enabled = true;
                lblRetakeApplicationFees.Text = clsFormat.ToShortMoneyString(_Application.PaidFees);
                lblTotalFees.Text = clsFormat.ToShortMoneyString((Convert.ToDecimal(lblFees.Text) + Convert.ToDecimal(lblRetakeApplicationFees.Text)));
            }
            else
            {
                gbRetakeTest.Enabled = false;
                lblRetakeApplicationFees.Text = "0";
                lblTotalFees.Text = lblFees.Text;
            }
        }

        private void _UpdateTestAppointment()
        {
            _Appointment = clsTestAppointment.GetTestAppointmentInfoByID(TestAppointmentID);

            if (_Appointment == null)
                return;

            lblLDL_ID.Text = _Appointment.LDLA_ID.ToString();
            lblLicenseClass.Text = clsLocalLicenseClass.FindByLDLA_ID(_Appointment.LDLA_ID).LicenseClassName;
            lblApplicantName.Text = clsLocalDrivingLicenseApplication.GetLocalDrivingLicenseApplicationByLDLA_ID(LDLA_ID).Person.FullName;
            lblTrials.Text = clsTests.GetTotalTrialsPerTest(_Appointment.LDLA_ID, _TestTypeID).ToString();

            if (_Appointment.AppointmentDate < dtpDate.MinDate)
                _Appointment.AppointmentDate = dtpDate.MinDate;

            else if (_Appointment.AppointmentDate > dtpDate.MaxDate)
                _Appointment.AppointmentDate = dtpDate.MaxDate;

            dtpDate.Value = _Appointment.AppointmentDate;

            lblFees.Text = clsFormat.ToShortMoneyString(clsTestType.Find(_TestTypeID).Fees); ;

            _HandleRetakeTestForUpdateTestScedule();
        }

        private void _HandleRetakeTestForUpdateTestScedule()
        {
            gbRetakeTest.Enabled = _Appointment.RetakeTestApplictionID == null ? false : true;

            if (gbRetakeTest.Enabled)
            {
                lblRetakeApplicationFees.Text =
                    clsFormat.ToShortMoneyString(clsApplication.FindApplicationByApplicationID(_Appointment.RetakeTestApplictionID.Value).PaidFees);

                lblTotalFees.Text = clsFormat.ToShortMoneyString((Convert.ToDecimal(lblRetakeApplicationFees.Text) + Convert.ToDecimal(lblFees.Text)));
            }
            else
            {
                lblRetakeApplicationFees.Text = "0";
                lblTotalFees.Text = lblFees.Text;
            }
        }

        private void _HandleAddEditTestAppointment()
        {
            _LimitDate();

            if (clsTests.DidPersonAttendTest(LDLA_ID, (byte)TestTypeID))
            {
                _CreationMode = enCreationMode.RetakeTestSchedule;
                lblHeader.Text = "Schedule Retake Test";
            }
            else
            {
                _CreationMode = enCreationMode.FirstTimeSchedule;
                lblHeader.Text = "Schedule Test";
            }

            if (TestAppointmentID == -1)
            {
                _Mode = enMode.AddNew;
                _AddNewTestAppointment();
            }
            else
            {
                _Mode = enMode.Update;
                _UpdateTestAppointment();
            }
        }

        private bool _HandleRetakeTestOnSave()
        {
            if (_CreationMode == enCreationMode.RetakeTestSchedule)
            {
                if (!_Application.Save())
                {
                    MessageBox.Show("Cannot create application", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                _Appointment.RetakeTestApplictionID = _Application.ApplicationID;
            }

            else
            {
                _Appointment.RetakeTestApplictionID = null;
            }

            return true;
        }

        private bool _Save()
        {
            if (_Mode == enMode.AddNew)
            {
                _Appointment.TestTypeID = _TestTypeID;
                _Appointment.LDLA_ID = _LDLA.LDLA_ID;
                _Appointment.AppointmentDate = dtpDate.Value;
                _Appointment.PaidFees = Convert.ToDecimal(lblFees.Text);
                _Appointment.CreatedByUserID = clsUtil.CurrentUser.UserID;
                _Appointment.IsLocked = false;

                if (!_HandleRetakeTestOnSave())
                    return false;
            }

            else
            {
                _Appointment.AppointmentDate = dtpDate.Value;
            }

            return _Appointment.Save();
        }

        private void ctrlScheduleTest_Load(object sender, EventArgs e)
        {
            _HandleAddEditTestAppointment();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_Save())
            {
                MessageBox.Show("Appointment has been saved successfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this?.FindForm().Close();
            }

            else
            {
                MessageBox.Show("Cannot save", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this?.FindForm().Close();
        }
    }
}
