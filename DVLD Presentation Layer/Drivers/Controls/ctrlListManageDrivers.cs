using System;
using System.Data;
using System.Windows.Forms;
using DVLD_Buisness_Layer;
using DVLD_Project.Global;
using DVLD_Project.Licenses.Forms;
using DVLD_Project.People.Forms;

namespace DVLD_Project.Drivers.Controls
{
    public partial class ctrlListManageDrivers : UserControl
    {
        public ctrlListManageDrivers()
        {
            InitializeComponent();
        }

        private DataView _dvDriversData;

        private void _FilterDriversData()
        {
            if (_dvDriversData == null)
                return;

            if (string.IsNullOrEmpty(txtFilter.Text) && cbFilter.SelectedItem.ToString() != "Created Date")
            {
                _dvDriversData.RowFilter = "";
                return;
            }

            string SelectedFilter = cbFilter.SelectedItem.ToString();
            string ValueToSearch = txtFilter.Text.Trim().Replace("'", "''");

            switch (SelectedFilter)
            {
                case "Driver ID":
                    _dvDriversData.RowFilter = $"DriverID = {ValueToSearch}";
                    break;

                case "Person ID":
                    _dvDriversData.RowFilter = $"PersonID = {ValueToSearch}";
                    break;

                case "National No":
                    _dvDriversData.RowFilter = $"NationalNo like '%{ValueToSearch}%'";
                    break;

                case "Full Name":
                    _dvDriversData.RowFilter = $"FullName like '%{ValueToSearch}%'";
                    break;

                case "Created Date":
                    DateTime SelectedDate = dtpCreatedDate.Value.Date;
                    _dvDriversData.RowFilter = $"CreatedDate >= #{SelectedDate:yyyy-MM-dd} 00:00:00# AND CreatedDate < #{SelectedDate:yyyy-MM-dd} 23:59:59#";
                    break;

                default:
                    break;
            }
        }

        private void _LimitCreatedDateFilter()
        {
            dtpCreatedDate.MinDate = DateTime.Now.AddYears(-10);
            dtpCreatedDate.MaxDate = DateTime.Now;
        }

        private void _UpdateRecordsCount()
        {
            if (_dvDriversData != null)
                lblRecords.Text = _dvDriversData.Count.ToString();
        }

        private void _FillFilterItems()
        {
            cbFilter.Items.Add("None");
            cbFilter.Items.Add("Driver ID");
            cbFilter.Items.Add("Person ID");
            cbFilter.Items.Add("National No");
            cbFilter.Items.Add("Full Name");
            cbFilter.Items.Add("Created Date");
            cbFilter.SelectedItem = "None";
        }

        private void _FillFields()
        {
            _FillFilterItems();
            _LimitCreatedDateFilter();
        }

        private void _RefreshLDLAData()
        {
            txtFilter.Clear();
            DataTable dtDriversData = clsDriver.GetAllDrivers();
            _dvDriversData = new DataView(dtDriversData);
            dgvDriversData.DataSource = _dvDriversData;
            _UpdateRecordsCount();
        }

        private void _RenameColumns_ForDGV()
        {
            if (_dvDriversData == null)
                return;

            dgvDriversData.Columns["DriverID"].HeaderText = "Driver ID";
            dgvDriversData.Columns["PersonID"].HeaderText = "Person ID";
            dgvDriversData.Columns["NationalNo"].HeaderText = "National No";
            dgvDriversData.Columns["FullName"].HeaderText = "Full Name";
            dgvDriversData.Columns["CreatedDate"].HeaderText = "Created Date";
            dgvDriversData.Columns["ActiveLicenses"].HeaderText = "Number Of Active Licenses";

            dgvDriversData.Columns["CreatedDate"].DefaultCellStyle.Format = clsFormat.ToShortDateString();
        }

        private void _HandleFilterControlsVisibilty()
        {
            txtFilter.Clear();

            if (cbFilter.SelectedItem.ToString() == "Created Date")
            {
                dtpCreatedDate.Visible = true;
                txtFilter.Visible = false;
            }

            else
            {
                txtFilter.Visible = (cbFilter.SelectedItem.ToString() != "None");
                dtpCreatedDate.Visible = false;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this?.FindForm().Close();
        }

        private void ctrlManageDrivers_Load(object sender, EventArgs e)
        {
            _FillFields();
            _RefreshLDLAData();
            _RenameColumns_ForDGV();
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilter.Clear();
            _FilterDriversData();
            _HandleFilterControlsVisibilty();
            _UpdateRecordsCount();
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            _FilterDriversData();
            _UpdateRecordsCount();
        }

        private void dtpCreatedDate_ValueChanged(object sender, EventArgs e)
        {
            _FilterDriversData();
            _UpdateRecordsCount();
        }

        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilter.SelectedItem.ToString() == "Driver ID" || cbFilter.SelectedItem.ToString() == "Person ID")
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPersonCard frm = new frmPersonCard((int)dgvDriversData.CurrentRow.Cells[1].Value);
            frm.ShowDialog();
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLicenseHistory frm = new frmLicenseHistory((string)dgvDriversData.CurrentRow.Cells["NationalNo"].Value);
            frm.ShowDialog();
        }
    }
}
