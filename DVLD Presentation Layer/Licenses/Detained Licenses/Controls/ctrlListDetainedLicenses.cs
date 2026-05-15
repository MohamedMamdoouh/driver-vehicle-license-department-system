using System;
using System.Data;
using System.Windows.Forms;
using DVLD_Buisness_Layer;
using DVLD_Project.Applications.Release_Detained_License.Forms;
using DVLD_Project.Global;
using DVLD_Project.Licenses.Detained_Licenses.Forms;
using DVLD_Project.Licenses.Forms;
using DVLD_Project.People.Forms;
namespace DVLD_Project.Licenses.Detained_Licenses.Controls
{
    public partial class ctrlListDetainedLicenses : UserControl
    {
        public ctrlListDetainedLicenses()
        {
            InitializeComponent();
        }

        private DataView _dvDetainedLicensesData;

        private void _FilterDetainedLicensesData()
        {
            if (_dvDetainedLicensesData == null)
                return;

            if (string.IsNullOrEmpty(txtFilter.Text) && cbFilter.SelectedItem.ToString() != "Is Released")
            {
                _dvDetainedLicensesData.RowFilter = "";
                return;
            }

            string SelectedFilter = cbFilter.SelectedItem.ToString();
            string ValueToSearch = txtFilter.Text.Trim().Replace("'", "''");

            switch (SelectedFilter)
            {
                case "Detain ID":
                    _dvDetainedLicensesData.RowFilter = $"DetainID = {ValueToSearch}";
                    break;

                case "License ID":
                    _dvDetainedLicensesData.RowFilter = $"LicenseID = {ValueToSearch}";
                    break;

                case "National No":
                    _dvDetainedLicensesData.RowFilter = $"NationalNo like '%{ValueToSearch}%'";
                    break;

                case "Full Name":
                    _dvDetainedLicensesData.RowFilter = $"FullName like '%{ValueToSearch}%'";
                    break;

                case "Is Released":
                    _HandleIsReleasedFilterChoice();
                    break;

                default:
                    break;
            }
        }

        private void _HandleIsReleasedFilterChoice()
        {
            string SelectedFilter = cbIsReleased.SelectedItem.ToString();

            switch (SelectedFilter)
            {
                case "All":
                    _dvDetainedLicensesData.RowFilter = "";
                    break;

                case "Released":
                    _dvDetainedLicensesData.RowFilter = "IsReleased = True";
                    break;

                case "Not Released":
                    _dvDetainedLicensesData.RowFilter = "IsReleased = False";
                    break;

                default:
                    break;
            }
        }

        private void _UpdateRecordsCount()
        {
            if (_dvDetainedLicensesData != null)
                lblRecords.Text = _dvDetainedLicensesData.Count.ToString();
        }

        private void _FillFilterItems()
        {
            cbFilter.Items.Add("None");
            cbFilter.Items.Add("Detain ID");
            cbFilter.Items.Add("License ID");
            cbFilter.Items.Add("National No");
            cbFilter.Items.Add("Full Name");
            cbFilter.Items.Add("Is Released");

            cbFilter.SelectedItem = "None";
        }

        private void _FillFields()
        {
            _FillFilterItems();
            _FillIsReleasedComboBox();
        }

        private void _FillIsReleasedComboBox()
        {
            cbIsReleased.Items.Add("All");
            cbIsReleased.Items.Add("Released");
            cbIsReleased.Items.Add("Not Released");

            cbIsReleased.SelectedItem = "All";
        }

        private void _RefreshDetainedLicensesData()
        {
            txtFilter.Clear();
            DataTable dtDetainedLicenses = clsDetainedLicenses.GetAllDetainedLicenses();
            _dvDetainedLicensesData = new DataView(dtDetainedLicenses);
            dgvDetainedLicensesData.DataSource = _dvDetainedLicensesData;
            _UpdateRecordsCount();
        }

        private void _RenameColumns_ForDGV()
        {
            if (_dvDetainedLicensesData == null)
                return;

            dgvDetainedLicensesData.Columns["DetainID"].HeaderText = "Detain ID";
            dgvDetainedLicensesData.Columns["LicenseID"].HeaderText = "License ID";
            dgvDetainedLicensesData.Columns["DetainDate"].HeaderText = "Detain Date";
            dgvDetainedLicensesData.Columns["IsReleased"].HeaderText = "Is Released";
            dgvDetainedLicensesData.Columns["FineFees"].HeaderText = "Fine Fees";
            dgvDetainedLicensesData.Columns["ReleaseDate"].HeaderText = "Release Date";
            dgvDetainedLicensesData.Columns["NationalNo"].HeaderText = "National No";
            dgvDetainedLicensesData.Columns["FullName"].HeaderText = "Full Name";
            dgvDetainedLicensesData.Columns["ReleaseApplicationID"].HeaderText = "Release App. ID";

            dgvDetainedLicensesData.Columns["DetainDate"].DefaultCellStyle.Format = clsFormat.ToShortDateString();
            dgvDetainedLicensesData.Columns["ReleaseDate"].DefaultCellStyle.Format = clsFormat.ToShortDateString();
            dgvDetainedLicensesData.Columns["FineFees"].DefaultCellStyle.Format = clsFormat.ToShortMoneyString();
        }

        private void _HandleFilterControlsVisibilty()
        {
            txtFilter.Clear();

            if (cbFilter.SelectedItem.ToString() == "Is Released")
            {
                cbIsReleased.SelectedItem = "All";
                cbIsReleased.Visible = true;
                txtFilter.Visible = false;
            }

            else
            {
                txtFilter.Visible = (cbFilter.SelectedItem.ToString() != "None");
                cbIsReleased.Visible = false;
            }
        }

        private void ctrlListDetainedLicenses_Load(object sender, EventArgs e)
        {
            _FillFields();
            _RefreshDetainedLicensesData();
            _RenameColumns_ForDGV();
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilter.Clear();
            _FilterDetainedLicensesData();
            _HandleFilterControlsVisibilty();
            _UpdateRecordsCount();
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            _FilterDetainedLicensesData();
            _UpdateRecordsCount();
        }

        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilter.SelectedItem.ToString() == "Detain ID" || cbFilter.SelectedItem.ToString() == "License ID")
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }

        private void cbIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            _FilterDetainedLicensesData();
            _UpdateRecordsCount();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this?.FindForm().Close();
        }

        private void showPersonDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPersonCard frm = new frmPersonCard((string)dgvDetainedLicensesData.CurrentRow.Cells["NationalNo"].Value);
            frm.ShowDialog();
        }

        private void showLicenseDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLocalLicesneInfo frm = new frmLocalLicesneInfo((int)dgvDetainedLicensesData.CurrentRow.Cells["LicenseID"].Value);
            frm.ShowDialog();
        }

        private void showPersonLicesneHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLicenseHistory frm = new frmLicenseHistory((string)dgvDetainedLicensesData.CurrentRow.Cells["NationalNo"].Value);
            frm.ShowDialog();
        }

        private void releaseDetainedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReleaseLicense frm = new frmReleaseLicense((int)dgvDetainedLicensesData.CurrentRow.Cells["LicenseID"].Value);
            frm.ShowDialog();
            _RefreshDetainedLicensesData();
        }

        private void cmsDetainedLicesnes_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            releaseDetainedLicenseToolStripMenuItem.Enabled =
                clsDetainedLicenses.IsLicenseDetained((int)dgvDetainedLicensesData.CurrentRow.Cells["LicenseID"].Value);
        }

        private void btnDetainLicense_Click(object sender, EventArgs e)
        {
            frmDetainLicense frm = new frmDetainLicense();
            frm.ShowDialog();
            _RefreshDetainedLicensesData();
        }

        private void btnReleaseLicense_Click(object sender, EventArgs e)
        {
            frmReleaseLicense frm = new frmReleaseLicense();
            frm.ShowDialog();
            _RefreshDetainedLicensesData();
        }
    }
}