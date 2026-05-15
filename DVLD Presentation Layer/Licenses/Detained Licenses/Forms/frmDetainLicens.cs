using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Project.Licenses.Detained_Licenses.Forms
{
    public partial class frmDetainLicense : Form
    {
        public frmDetainLicense()
        {
            InitializeComponent();
        }

        public frmDetainLicense(int? LicenseID)
        {
            InitializeComponent();
            ctrlDetainLicense1.LicenseID = LicenseID;
        }
    }
}
