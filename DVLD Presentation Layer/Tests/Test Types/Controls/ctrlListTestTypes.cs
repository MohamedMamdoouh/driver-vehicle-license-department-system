using System;
using System.Data;
using System.Windows.Forms;
using DVLD_Buisness_Layer;
using DVLD_Project.Applications.Test_Types.Forms;

namespace DVLD_Project.Applications.Test_Types.Controls
{
    public partial class ctrlListTestTypes : UserControl
    {
        public ctrlListTestTypes()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this?.FindForm().Close();
        }

        private DataView _dvTestTypes;

        private void ctrlListTestTypes_Load(object sender, EventArgs e)
        {
            _RefreshTestTypesData();
        }

        private void _AdjustDataViewContent()
        {
            dgvTestTypes.Columns["TestTypeDescription"].Width = 450;
            dgvTestTypes.Columns["TestTypeTitle"].Width = 200;
            dgvTestTypes.Columns["TestTypeFees"].Width = 150;
        }

        private void _RefreshTestTypesData()
        {
            DataTable dtTestTypesData = clsTestType.GetAllTestTypes();
            _dvTestTypes = new DataView(dtTestTypesData);
            dgvTestTypes.DataSource = _dvTestTypes;
            lblRecords.Text = _dvTestTypes.Count.ToString();
            _AdjustDataViewContent();
        }

        private void editApplicationTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEditTestType frm = new frmEditTestType((clsTestType.enTestType)dgvTestTypes.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _RefreshTestTypesData();
        }
    }
}
