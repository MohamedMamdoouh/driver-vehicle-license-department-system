using System;
using System.Windows.Forms;
using DVLD_Buisness_Layer;
using DVLD_Project.Global;

namespace DVLD_Project.Applications.Release_Detained_License.Controls
{
    public partial class ctrlReleaseDetainedLicense : UserControl
    {
        public ctrlReleaseDetainedLicense()
        {
            InitializeComponent();
            ctrlLocalLicenseInfoWithFilter1.LicenseSelected += _LoadData;
            ctrlLocalLicenseInfoWithFilter1.HasLicenseID += _LoadData;
        }

        private clsApplicationType _ApplicationType;
        private clsDetainedLicenses _DetainedLicenseInfo;
        private clsLocalLicense _LocalLicenseInfo;
        private clsApplication _Application;
        public int? LicenseID { get; set; }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this?.FindForm().Close();
        }

        private void _LoadData(object sender, EventArgs e)
        {
            if(LicenseID.HasValue)
            {
                ctrlLocalLicenseInfoWithFilter1.LicenseID = LicenseID.Value;
            }

            _LocalLicenseInfo = ctrlLocalLicenseInfoWithFilter1.SelectedLicenseInfo;

            if(_LocalLicenseInfo == null)
                return;

            _ApplicationType = clsApplicationType.Find(clsApplication.enApplicationType.ReleaseDetainedDrivingLicsense);
            _DetainedLicenseInfo = clsDetainedLicenses.Find(_LocalLicenseInfo.LicenseID);

            if( _DetainedLicenseInfo == null)
            {
                MessageBox.Show("This license is not detained", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lblApplicationDate.Text = clsFormat.ToShortDateString(DateTime.Now);
            lblApplicationFees.Text = clsFormat.ToShortMoneyString(_ApplicationType.Fees);
            lblFineFees.Text = clsFormat.ToShortMoneyString(_DetainedLicenseInfo.FineFees);
            lblTotalFees.Text = clsFormat.ToShortMoneyString(Convert.ToDecimal(lblApplicationFees.Text) + Convert.ToDecimal(lblFineFees.Text));
            lblCreatedBy.Text = clsUtil.CurrentUser.UserName;
        }

        private void btnRelease_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to release this license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            if (!ctrlLocalLicenseInfoWithFilter1.IsLicenseFound)
            {
                MessageBox.Show("No license found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!_LocalLicenseInfo.IsDetained)
            {
                MessageBox.Show("Your license is not detained", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // First, we create an application
            _Application = new clsApplication();
            _Application.ApplicantPersonID = _LocalLicenseInfo.DriverInfo.PersonID;
            _Application.ApplicationDate = DateTime.Now;
            _Application.ApplicationTypeID = clsApplication.enApplicationType.ReleaseDetainedDrivingLicsense;
            _Application.ApplicationStatus = clsApplication.enApplicationStatus.New;
            _Application.LastStatusDate = DateTime.Now;
            _Application.PaidFees = _ApplicationType.Fees;
            _Application.CreatedByUserID = clsUtil.CurrentUser.UserID;

            if (!_Application.Save())
            {
                MessageBox.Show("Cannot save the application", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Then, we release the license
            if (!_LocalLicenseInfo.ReleaseDrivingLicense(clsUtil.CurrentUser.UserID, _Application.ApplicationID))
            {
                MessageBox.Show("Cannot release the license", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            else
            {
                MessageBox.Show("The local license has been released successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this?.FindForm().Close();
            }
        }
    }
}
