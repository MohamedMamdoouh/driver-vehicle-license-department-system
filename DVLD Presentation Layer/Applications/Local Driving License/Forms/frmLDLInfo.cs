using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Project.Applications.Local_Driving_License.Forms
{
    public partial class frmLDLAAInfo : Form
    {
        public frmLDLAAInfo(int ID)
        {
            InitializeComponent();
            ctrlLDLInfo1.LocalLicenseApplicationID = ID;
        }
    }
}
