using System;
using System.Windows.Forms;
using DVLD_Buisness_Layer;
using DVLD_Project.Global;

namespace DVLD_Project.Applications.Replace_For_Damaged_And_Lost_License.Controls
{
    public partial class ctrlReplaceForDamagedLostLicense : UserControl
    {
        public ctrlReplaceForDamagedLostLicense()
        {
            InitializeComponent();
            ctrlLocalLicenseInfoWithFilter1.LicenseSelected += _LoadApplicationDate;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this?.FindForm().Close();
        }

        private enum enReplacementType { Damaged = 1, Lost = 2 }
        private enReplacementType _ReplacementType;

        private clsApplicationType _ApplicationType;
        private clsLocalLicense _OldLocalLicenseInfo;
        private clsLocalLicense _NewReplacedLocalLicenseInfo;
        private clsApplication _Application;

        private void _LoadApplicationDate(object sender, EventArgs e)
        {
            _ReplacementType = rbDamagedLicesne.Checked ? enReplacementType.Damaged : enReplacementType.Lost;

            if (_ReplacementType == enReplacementType.Damaged)
            {
                _ApplicationType = clsApplicationType.Find(clsApplication.enApplicationType.ReplacementForDamagedDrivingLicense);

            }
            else
            {
                _ApplicationType = clsApplicationType.Find(clsApplication.enApplicationType.ReplacementForLostDrivingLicense);
            }

            _OldLocalLicenseInfo = ctrlLocalLicenseInfoWithFilter1.SelectedLicenseInfo;

            if (_ApplicationType == null || _OldLocalLicenseInfo == null)
                return;

            lblApplicationDate.Text = clsFormat.ToShortDateString(DateTime.Now);
            lblIssueDate.Text = clsFormat.ToShortDateString(DateTime.Now);
            lblExpirationDate.Text = clsFormat.ToShortDateString(DateTime.Now.AddYears(_OldLocalLicenseInfo.LicenseClassInfo.DefaultValidityLength));
            lblApplicationFees.Text = clsFormat.ToShortMoneyString(_ApplicationType.Fees);
            lblOldLicenseID.Text = _OldLocalLicenseInfo.LicenseID.ToString();
            lblCreatedBy.Text = clsUtil.CurrentUser?.UserName;
        }

        private void btnIssueReplacement_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to replace this license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            if (!ctrlLocalLicenseInfoWithFilter1.IsLicenseFound)
            {
                MessageBox.Show("No license found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!_OldLocalLicenseInfo.IsActive)
            {
                MessageBox.Show("Your license is not active", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // First, we create an application
            _Application = new clsApplication();
            _Application.ApplicantPersonID = _OldLocalLicenseInfo.DriverInfo.PersonID;
            _Application.ApplicationDate = DateTime.Now;

            if(_ReplacementType == enReplacementType.Damaged)
            {
                _Application.ApplicationTypeID = clsApplication.enApplicationType.ReplacementForDamagedDrivingLicense;
            }
            else
            {
                _Application.ApplicationTypeID = clsApplication.enApplicationType.ReplacementForLostDrivingLicense;
            }

            _Application.ApplicationStatus = clsApplication.enApplicationStatus.New;
            _Application.LastStatusDate = DateTime.Now;
            _Application.PaidFees = _ApplicationType.Fees;
            _Application.CreatedByUserID = clsUtil.CurrentUser.UserID;

            if (!_Application.Save())
            {
                MessageBox.Show("Cannot save the application", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Then, we replace the license
            _NewReplacedLocalLicenseInfo = new clsLocalLicense();
            _NewReplacedLocalLicenseInfo.ApplicationID = _Application.ApplicationID;
            _NewReplacedLocalLicenseInfo.DriverID = _OldLocalLicenseInfo.DriverID;
            _NewReplacedLocalLicenseInfo.LicenseClassID = _OldLocalLicenseInfo.LicenseClassID;
            _NewReplacedLocalLicenseInfo.IssueDate = DateTime.Now;
            _NewReplacedLocalLicenseInfo.ExpirationDate = _OldLocalLicenseInfo.ExpirationDate;
            _NewReplacedLocalLicenseInfo.Notes = _OldLocalLicenseInfo.Notes;
            _NewReplacedLocalLicenseInfo.PaidFees = _OldLocalLicenseInfo.LicenseClassInfo.ClassFees;
            _NewReplacedLocalLicenseInfo.IsActive = true;

            if (_ReplacementType == enReplacementType.Damaged)
            {
                _NewReplacedLocalLicenseInfo.IssueReason = clsLocalLicense.enIssueReason.DamagedReplacement;
            }
            else
            {
                _NewReplacedLocalLicenseInfo.IssueReason = clsLocalLicense.enIssueReason.LostReplacement;
            }

            _NewReplacedLocalLicenseInfo.CreatedByUserID = clsUtil.CurrentUser.UserID;

            if (!_NewReplacedLocalLicenseInfo.ReplaceLocalDrivingLicense(_OldLocalLicenseInfo.LicenseID))
            {
                MessageBox.Show("Cannot replace the license", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            else
            {
                MessageBox.Show("The license has been replaced successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this?.FindForm().Close();
            }
        }

        private void rbDamagedLicesne_CheckedChanged(object sender, EventArgs e)
        {
            _LoadApplicationDate(null, null);
        }

        private void rbLostLicense_CheckedChanged(object sender, EventArgs e)
        {
            _LoadApplicationDate(null, null);
        }

        private void ctrlReplaceForDamagedLostLicense_Load(object sender, EventArgs e)
        {
            rbDamagedLicesne.Checked = true;
        }
    }
}
