using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_Buisness_Layer;

namespace DVLD_Project.Applications.Test_Types.Forms
{
    public partial class frmEditTestType : Form
    {
        public frmEditTestType(clsTestType.enTestType ID)
        {
            InitializeComponent();
            ctrlEditTestType1.TestTypeID = ID;
        }
    }
}
