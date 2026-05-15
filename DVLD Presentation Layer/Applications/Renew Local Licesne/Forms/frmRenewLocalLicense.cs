using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Project.Applications.Renew_Local_Licesne.Forms
{
    public partial class frmRenewLocalLicense : Form
    {
        public frmRenewLocalLicense()
        {
            InitializeComponent();
        }

        public frmRenewLocalLicense(int LicenseID)
        {
            InitializeComponent();
            ctrlRenewLocalLicense1.LicenseID = LicenseID;
        }
    }
}
