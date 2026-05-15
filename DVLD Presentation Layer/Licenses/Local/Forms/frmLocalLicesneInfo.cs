using System;
using System.Windows.Forms;

namespace DVLD_Project.Licenses.Forms
{
    public partial class frmLocalLicesneInfo : Form
    {
        public frmLocalLicesneInfo(int LicenseID)
        {
            InitializeComponent();
            ctrlLicenseInfo1.LicenseID = LicenseID;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
