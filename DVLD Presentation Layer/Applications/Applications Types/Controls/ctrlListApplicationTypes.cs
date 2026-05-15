using System;
using System.Data;
using System.Windows.Forms;
using DVLD_Buisness_Layer;
using DVLD_Project.Applications_Types.Forms;

namespace DVLD_Project.Applications_Types
{
    public partial class ctrlListApplicationTypes : UserControl
    {
        public ctrlListApplicationTypes()
        {
            InitializeComponent();
        }

        private DataView _dvApplicationTypes;

        private void _RefreshApplicationTypesData()
        {
            DataTable dtApplicationTypes = clsApplicationType.GetAllApplicationTypes();
            _dvApplicationTypes = new DataView(dtApplicationTypes);
            dgvApplicationTypes.DataSource = _dvApplicationTypes;
            lblRecords.Text = _dvApplicationTypes.Count.ToString();
        }

        private void ctrlManageApplicationsTypes_Load(object sender, EventArgs e)
        {
            _RefreshApplicationTypesData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this?.FindForm().Close();
        }

        private void editApplicationTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEditApplicationTypes frm = new frmEditApplicationTypes((int)dgvApplicationTypes.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _RefreshApplicationTypesData();
        }
    }
}
