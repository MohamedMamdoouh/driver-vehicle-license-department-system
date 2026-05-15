using System;
using System.Data;
using System.Windows.Forms;

namespace DVLD_Project.Applications_Types.Forms
{
    public partial class frmEditApplicationTypes : Form
    {
        public frmEditApplicationTypes(int ID)
        {
            InitializeComponent();
            ctrlUpdateApplicationsTypes1.ApplicationTypeID = ID;
        }
    }
}
