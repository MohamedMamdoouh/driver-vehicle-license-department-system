using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Project.Licenses.Forms
{
    public partial class frmLicenseHistory : Form
    {
        public frmLicenseHistory(string NationalNo)
        {
            InitializeComponent();
            ctrlLicenseHistory1.NationalNo = NationalNo;
        }
    }
}
