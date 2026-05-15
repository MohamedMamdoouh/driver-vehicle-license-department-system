using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_Project.Forms;

namespace DVLD_Project.Applications.Local_Driving_License.Forms
{
    public partial class frmAddUpdateLDLA : Form
    {
        public frmAddUpdateLDLA(int LDLA_ID)
        {
            InitializeComponent();
            ctrlAddUpdateLDL1.LDLA_ID = LDLA_ID;
        }
    }
}
