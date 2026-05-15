using System;
using System.Drawing.Printing;
using System.Windows.Forms;
using DVLD_Buisness_Layer;
using DVLD_Project.Applications.International_Driving_License.Forms;
using DVLD_Project.Global;

namespace DVLD_Project.Licenses.International.Controls
{
    public partial class ctrlIssueInternationalLicense : UserControl
    {
        public ctrlIssueInternationalLicense()
        {
            InitializeComponent();
        }

        private clsApplicationType _ApplicationType;
        private clsLocalLicenseClass _LicenseClass;
        private clsApplication _Application;
        private clsInternationalLicense _InternationalLicense;
        private clsLocalLicense _LocalLicenseInfo;

        private void btnClose_Click(object sender, EventArgs e)
        {
            this?.FindForm().Close();
        }

        private bool _HandleCheckPointsOnIssueNewInternationalLicesne()
        {
            _LocalLicenseInfo = ctrlLocalLicenseInfoWithFilter1.SelectedLicenseInfo;
            _LicenseClass = clsLocalLicenseClass.FindByLicenseClassID(3);

            if (_LocalLicenseInfo == null || _LicenseClass == null)
            {
                MessageBox.Show("Could not find license data!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
               

            if (!ctrlLocalLicenseInfoWithFilter1.IsLicenseFound)
            {
                MessageBox.Show("No License found! Please find a license first", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (_LocalLicenseInfo.LicenseClassInfo.LicenseClassID != 3)
            {
                MessageBox.Show("You must have a Class 3 - Ordinary driving license to issue an international license",
                               "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!_LocalLicenseInfo.IsActive)
            {
                MessageBox.Show("Your license is not active!", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (clsInternationalLicense.IsInternationalLicenseExistByPersonID(_LocalLicenseInfo.DriverInfo.PersonID))
            {
                if (clsInternationalLicense.IsInternationalLicenseActive(_LocalLicenseInfo.DriverInfo.PersonID))
                {
                    MessageBox.Show("You already have an active international license", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            return true;
        }

        private void _IssueInternationalLicense()
        {
            if (MessageBox.Show("Are you sure you want to issue the international license?", "Confirm",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            if (!_HandleCheckPointsOnIssueNewInternationalLicesne())
                return;

            // First, we create an application
            _Application = new clsApplication();
            _Application.ApplicantPersonID = _LocalLicenseInfo.DriverInfo.PersonID;
            _Application.ApplicationDate = DateTime.Now;
            _Application.ApplicationTypeID = clsApplication.enApplicationType.NewInternationalLicense;
            _Application.ApplicationStatus = clsApplication.enApplicationStatus.New;
            _Application.LastStatusDate = DateTime.Now;
            _Application.PaidFees = _ApplicationType.Fees;
            _Application.CreatedByUserID = clsUtil.CurrentUser.UserID;

            if (!_Application.Save())
            {
                MessageBox.Show("Cannot save the application", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Then, we issue the license
            _InternationalLicense = new clsInternationalLicense();
            _InternationalLicense.ApplicationID = _Application.ApplicationID;
            _InternationalLicense.DriverID = _LocalLicenseInfo.DriverID;
            _InternationalLicense.IssuedUsingLocalLicenseID = _LocalLicenseInfo.LicenseID;
            _InternationalLicense.IssueDate = DateTime.Now;
            _InternationalLicense.ExpirationDate = DateTime.Now.AddYears(1);
            _InternationalLicense.IsActive = true;
            _InternationalLicense.CreatedByUserID = clsUtil.CurrentUser.UserID;

            if (!_InternationalLicense.IssueInternationalDrivingLicense())
            {
                MessageBox.Show("Cannot issue the license", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            else
            {
                MessageBox.Show("The international license has been issued successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this?.FindForm().Close();

                frmListInternationalLicenses frmInternational = new frmListInternationalLicenses();
                frmInternational.ShowDialog();
            }
        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            _IssueInternationalLicense();
        }

        private void ctrlIssueInternationalLicense_Load(object sender, EventArgs e)
        {
            _LoadApplicationData();
        }

        private void _LoadApplicationData()
        {
            _ApplicationType = clsApplicationType.Find(clsApplication.enApplicationType.NewInternationalLicense);

            if (_ApplicationType == null)
                return;

            lblApplicationDate.Text = clsFormat.ToShortDateString(DateTime.Now);
            lblIssueDate.Text = clsFormat.ToShortDateString(DateTime.Now);
            lblExpirationDate.Text = clsFormat.ToShortDateString(DateTime.Now.AddYears(1));
            lblFees.Text = clsFormat.ToShortMoneyString(_ApplicationType.Fees);
            lblCreatedBy.Text = clsUtil.CurrentUser?.UserName;
        }
    }
}
