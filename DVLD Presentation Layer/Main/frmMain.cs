using System;
using System.Net.Http.Headers;
using System.Windows.Forms;
using DVLD_Project.Applications.International_Driving_License.Forms;
using DVLD_Project.Applications.Local_Driving_License.Forms;
using DVLD_Project.Applications.Release_Detained_License.Forms;
using DVLD_Project.Applications.Renew_Local_Licesne.Forms;
using DVLD_Project.Applications.Replace_For_Damaged_And_Lost_License.Forms;
using DVLD_Project.Applications.Test_Types.Forms;
using DVLD_Project.Applications_Types.Forms;
using DVLD_Project.Drivers.Forms;
using DVLD_Project.Global;
using DVLD_Project.Licenses.Detained_Licenses.Forms;
using DVLD_Project.Licenses.International.Forms;
using DVLD_Project.Users.Forms;

namespace DVLD
{
    public partial class frmMain : Form
    {
        private frmLogin _frmLogin;

        public frmMain(frmLogin frm)
        {
            InitializeComponent();
            _frmLogin = frm;

        }
        private void msPeople_Click(object sender, EventArgs e)
        {
            frmManagePeople frmManagePeople = new frmManagePeople();
            frmManagePeople.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void msUsers_Click(object sender, EventArgs e)
        {
            frmManageUsers frm = new frmManageUsers();
            frm.ShowDialog();
        }

        private void changePasswrodToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEditUserPassword frm = new frmEditUserPassword(clsUtil.CurrentUser.UserID);
            frm.ShowDialog();
        }

        private void changeUserInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUserInfo frm = new frmUserInfo(clsUtil.CurrentUser.UserID);
            frm.ShowDialog();
        }

        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsUtil.CurrentUser = null;
            _frmLogin.Show();
            this.Close(); 
        }

        private void manageApplicationsTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListApplicationTypes frm = new frmListApplicationTypes();
            frm.ShowDialog();
        }

        private void manageTestTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListTestTypes frm = new frmListTestTypes();
            frm.ShowDialog();
        }

        private void loalDrivibgToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageLDL frm = new frmManageLDL();
            frm.ShowDialog();
        }

        private void localLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdateLDLA frm = new frmAddUpdateLDLA(-1);
            frm.ShowDialog();
        }

        private void retakeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageLDL frm = new frmManageLDL();
            frm.ShowDialog();
        }

        private void msDrivers_Click(object sender, EventArgs e)
        {
            frmManageDrivers frm = new frmManageDrivers();
            frm.ShowDialog();
        }

        private void internationalLicesneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmIssueInternationalLicense frm = new frmIssueInternationalLicense();
            frm.ShowDialog();
        }

        private void internationalLicenseApplicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListInternationalLicenses frm = new frmListInternationalLicenses();
            frm.ShowDialog();
        }

        private void renewDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRenewLocalLicense frm = new frmRenewLocalLicense();
            frm.ShowDialog();
        }

        private void replceDamagedAndLostLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReplaceLicense frm = new frmReplaceLicense();
            frm.ShowDialog();
        }

        private void detainLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDetainLicense frm = new frmDetainLicense();
            frm.ShowDialog();
        }

        private void releaseDetainLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReleaseLicense frm = new frmReleaseLicense();
            frm.ShowDialog();
        }

        private void releaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReleaseLicense frm = new frmReleaseLicense();
            frm.ShowDialog();
        }

        private void manageDetainedLicensesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListDetainedLicenses frm = new frmListDetainedLicenses();
            frm.ShowDialog();
        }
    }
}