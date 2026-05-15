using System;
using System.Net.Http.Headers;
using System.Windows.Forms;
using DVLD_Buisness_Layer;
using DVLD_Project.Applications.Local_Driving_License.Forms;
using DVLD_Project.Global;
using DVLD_Project.Licenses.Forms;
using DVLD_Project.People.Forms;

namespace DVLD_Project.Applications.Local_Driving_License.Controls
{
    public partial class ctrlLDLAInfo : UserControl
    {
        public ctrlLDLAInfo()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this?.FindForm().Close();
        }

        public int LocalLicenseApplicationID { get; set; }

        private clsLocalDrivingLicenseApplication _LocalDrivingLicense;

        public void LoadData()
        {
            _LoadApplicationInfo();
        }

        private void _LoadApplicationInfo()
        {
            llShowLicenseInfo.Enabled = clsLocalLicense.IsLicenseExistByLDLA_ID(LocalLicenseApplicationID);

            _LocalDrivingLicense = clsLocalDrivingLicenseApplication.GetLocalDrivingLicenseApplicationByLDLA_ID(LocalLicenseApplicationID);

            if (_LocalDrivingLicense == null)
                return;

            if (_LocalDrivingLicense.Person.ID == -1)
            {
                llShowLicenseInfo.Enabled = false;
                return;
            }

            lblApplicationID.Text = _LocalDrivingLicense.ApplicationID.ToString();
            lblStatus.Text = _LocalDrivingLicense.ApplicationStatus.ToString();
            lblFees.Text = clsFormat.ToShortMoneyString(_LocalDrivingLicense.PaidFees);
            lblType.Text = clsApplication.GetApplicationTypeFullName(_LocalDrivingLicense.ApplicationTypeID).ToString();
            lblApplicant.Text = _LocalDrivingLicense.Person.FullName.ToString();
            lblApplicationDate.Text = clsFormat.ToShortDateString(_LocalDrivingLicense.ApplicationDate);
            lblStatusDate.Text = clsFormat.ToShortDateString(_LocalDrivingLicense.LastStatusDate);
            lblCreatedBy.Text = _LocalDrivingLicense.User.UserName;

            lblLDLA_ID.Text = _LocalDrivingLicense.LDLA_ID.ToString();
            lblLicense.Text = clsLocalLicenseClass.FindByLDLA_ID(LocalLicenseApplicationID).LicenseClassName;
            lblPassedTests.Text = clsTests.GetPassedTestsCount(_LocalDrivingLicense.LDLA_ID).ToString() + "/3";
        }

        private void ctrlLDLAInfo_Load(object sender, EventArgs e)
        {
            _LoadApplicationInfo();
        }

        private void llShowPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmPersonCard frm = new frmPersonCard(_LocalDrivingLicense.Person.ID);
            frm.ShowDialog();
        }

        private void llShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLocalLicesneInfo frm = new frmLocalLicesneInfo(LocalLicenseApplicationID);
            frm.ShowDialog();
        }

        // We use this function to get LDLA_ID from any other control that uses this control
        // to load data and show it on that other control
        public void GetValuesFromParentControlAndLoadData(int LDLA_ID)
        {
            this.LocalLicenseApplicationID = LDLA_ID;
            _LoadApplicationInfo();
        }
    }
}
