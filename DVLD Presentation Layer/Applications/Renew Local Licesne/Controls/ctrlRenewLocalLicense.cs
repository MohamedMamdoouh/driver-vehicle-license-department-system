using System;
using System.Windows.Forms;
using DVLD_Buisness_Layer;
using DVLD_Project.Drivers.Forms;
using DVLD_Project.Global;
namespace DVLD_Project.Applications.Renew_Local_Licesne.Controls
{
    public partial class ctrlRenewLocalLicense : UserControl
    {
        public ctrlRenewLocalLicense()
        {
            InitializeComponent();
            ctrlLocalLicenseInfoWithFilter1.HasLicenseID += ctrlRenewLocalLicense_Load;
            ctrlLocalLicenseInfoWithFilter1.LicenseSelected += _LoadApplicationDate;
        }

        private int? _LicenseID;
        public int? LicenseID
        {
            get { return _LicenseID; }
            set { _LicenseID = value; }
        }

        private clsApplicationType _ApplicationType;
        private clsLocalLicense _OldLocalLicenseInfo;
        private clsLocalLicense _NewLocalLicenseInfo;
        private clsApplication _Application;

        private void btnClose_Click(object sender, EventArgs e)
        {
            this?.FindForm().Close();
        }

        private void _LoadApplicationDate(object sender, EventArgs e)
        {
            _ApplicationType = clsApplicationType.Find(clsApplication.enApplicationType.RenewDrivingLicense);
            _OldLocalLicenseInfo = ctrlLocalLicenseInfoWithFilter1.SelectedLicenseInfo;

            if (_ApplicationType == null || _OldLocalLicenseInfo == null)
                return;

            lblApplicationDate.Text = clsFormat.ToShortDateString(DateTime.Now);
            lblIssueDate.Text = clsFormat.ToShortDateString(DateTime.Now);
            lblExpirationDate.Text = clsFormat.ToShortDateString(DateTime.Now.AddYears(_OldLocalLicenseInfo.LicenseClassInfo.DefaultValidityLength));
            lblApplicationFees.Text = clsFormat.ToShortMoneyString(_ApplicationType.Fees);
            lblLicenseFees.Text = clsFormat.ToShortMoneyString(_OldLocalLicenseInfo.LicenseClassInfo.ClassFees);
            lblTotalFees.Text = clsFormat.ToShortMoneyString(Convert.ToDecimal(lblApplicationFees.Text) + Convert.ToDecimal(lblLicenseFees.Text));
            lblOldLicenseID.Text = _OldLocalLicenseInfo.LicenseID.ToString();
            lblCreatedBy.Text = clsUtil.CurrentUser?.UserName;
            txtNotes.Text = string.IsNullOrEmpty(_OldLocalLicenseInfo.Notes) ? null : _OldLocalLicenseInfo.Notes;
        }

        private void btnRenew_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to renew this license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            if (!ctrlLocalLicenseInfoWithFilter1.IsLicenseFound)
            {
                MessageBox.Show("No license found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!_OldLocalLicenseInfo.IsActive)
            {
                if (_OldLocalLicenseInfo.IsDetained)
                {
                    MessageBox.Show("Your license is detained", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if (clsPerson.DoesPersonHasAnActiveLicenseClass(_OldLocalLicenseInfo.DriverInfo.PersonID, _OldLocalLicenseInfo.LicenseClassID))
            {
                MessageBox.Show("You already have an active license", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // First, we create an application
            _Application = new clsApplication();
            _Application.ApplicantPersonID = _OldLocalLicenseInfo.DriverInfo.PersonID;
            _Application.ApplicationDate = DateTime.Now;
            _Application.ApplicationTypeID = clsApplication.enApplicationType.RenewDrivingLicense;
            _Application.ApplicationStatus = clsApplication.enApplicationStatus.New;
            _Application.LastStatusDate = DateTime.Now;
            _Application.PaidFees = _ApplicationType.Fees;
            _Application.CreatedByUserID = clsUtil.CurrentUser.UserID;

            if (!_Application.Save())
            {
                MessageBox.Show("Cannot save the application", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Then, we renew the license
            _NewLocalLicenseInfo = new clsLocalLicense();
            _NewLocalLicenseInfo.ApplicationID = _Application.ApplicationID;
            _NewLocalLicenseInfo.DriverID = _OldLocalLicenseInfo.DriverID;
            _NewLocalLicenseInfo.LicenseClassID = _OldLocalLicenseInfo.LicenseClassID;
            _NewLocalLicenseInfo.IssueDate = DateTime.Now;
            _NewLocalLicenseInfo.ExpirationDate = DateTime.Now.AddYears(_OldLocalLicenseInfo.LicenseClassInfo.DefaultValidityLength);
            _NewLocalLicenseInfo.Notes = string.IsNullOrEmpty(txtNotes.Text) ? null : txtNotes.Text;
            _NewLocalLicenseInfo.PaidFees = _OldLocalLicenseInfo.LicenseClassInfo.ClassFees;
            _NewLocalLicenseInfo.IsActive = true;
            _NewLocalLicenseInfo.IssueReason = clsLocalLicense.enIssueReason.Renew;
            _NewLocalLicenseInfo.CreatedByUserID = clsUtil.CurrentUser.UserID;

            if (!_NewLocalLicenseInfo.RenewLocalDrivingLicesne(_OldLocalLicenseInfo.LicenseID))
            {
                MessageBox.Show("Cannot renew the license", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            else
            {
                MessageBox.Show("The local license has been renewed successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this?.FindForm().Close();

                frmManageDrivers frmLocalLicense = new frmManageDrivers();
                frmLocalLicense.ShowDialog();
            }
        }

        private void ctrlRenewLocalLicense_Load(object sender, EventArgs e)
        {
            if (LicenseID.HasValue)
            {
                ctrlLocalLicenseInfoWithFilter1.LicenseID = LicenseID.Value;
            }
        }
    }
}