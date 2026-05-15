using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Project.Applications.Release_Detained_License.Forms
{
    public partial class frmReleaseLicense : Form
    {
        public frmReleaseLicense()
        {
            InitializeComponent();
        }

        public frmReleaseLicense(int? LicenseID)
        {
            InitializeComponent();
            ctrlReleaseDetainedLicense1.LicenseID = LicenseID;
        }
    }
}
