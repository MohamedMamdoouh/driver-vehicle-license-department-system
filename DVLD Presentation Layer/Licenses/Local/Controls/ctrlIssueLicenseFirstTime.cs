using System;
using System.Windows.Forms;
using DVLD_Buisness_Layer;
using DVLD_Project.Applications.Local_Driving_License.Forms;
using DVLD_Project.Global;

namespace DVLD_Project.Applications.Licenses
{
    public partial class ctrlIssueLicenseFirstTime : UserControl
    {
        public ctrlIssueLicenseFirstTime()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this?.FindForm().Close();
        }

        public int LDLA_ID;

        private bool _IssueLicesne()
        {
            if (!clsTests.IsPassedAllTests(LDLA_ID))
            {
                MessageBox.Show("You must pass all tests first", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            clsLocalDrivingLicenseApplication LDLA = clsLocalDrivingLicenseApplication.GetLocalDrivingLicenseApplicationByLDLA_ID(LDLA_ID);

            // Now we create the driver, if doesn't exist
            if (!clsDriver.IsDriverExistByPersonID(LDLA.Person.ID))
            {
                clsDriver Driver = new clsDriver();
                Driver.PersonID = LDLA.Person.ID;
                Driver.CreatedByUserID = clsUtil.CurrentUser.UserID;
                Driver.CreatedDate = DateTime.Now;
                Driver.AddNewDriver();
            }

            // Now we issue/add the license (for the first time)
            clsLocalLicense License = new clsLocalLicense();
            License.ApplicationID = LDLA.ApplicationID;
            License.DriverID = clsDriver.GetDriverInfoByPersonID(LDLA.Person.ID).DriverID;
            License.LicenseClassID = LDLA.LicenseClassID;
            License.IssueDate = DateTime.Now;
            License.ExpirationDate = License.IssueDate.AddYears(clsLocalLicenseClass.FindByLDLA_ID(LDLA_ID).DefaultValidityLength);
            License.Notes = string.IsNullOrEmpty(txtLicenseNotes.Text) ? null : txtLicenseNotes.Text;
            License.PaidFees = clsLocalLicenseClass.FindByLDLA_ID(LDLA_ID).ClassFees;
            License.IsActive = true;
            License.IssueReason = clsLocalLicense.enIssueReason.FirstTime;
            License.CreatedByUserID = clsUtil.CurrentUser.UserID;

            return License.IssueLocalDrivingLicense();
        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            if (_IssueLicesne())
            {
                MessageBox.Show("License has been issued successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this?.FindForm().Close();

                frmManageLDL frmLDL = new frmManageLDL();
                frmLDL.ShowDialog();
            }
            else
            {
                MessageBox.Show("Cannot issue the license", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ctrlLDLAInfo1_Load(object sender, EventArgs e)
        {
            ctrlLDLAInfo1.LocalLicenseApplicationID = LDLA_ID;
            ctrlLDLAInfo1.LoadData();
        }
    }
}
