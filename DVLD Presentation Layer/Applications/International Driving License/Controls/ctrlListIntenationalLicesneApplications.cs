using System;
using System.Data;
using System.Net.Http.Headers;
using System.Windows.Forms;
using DVLD_Buisness_Layer;
using DVLD_Project.Global;
using DVLD_Project.Licenses.Forms;
using DVLD_Project.Licenses.International.Forms;
using DVLD_Project.People.Forms;

namespace DVLD_Project.Applications.International_Driving_License.Controls
{
    public partial class ctrlListIntenationalLicesneApplications : UserControl
    {
        public ctrlListIntenationalLicesneApplications()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this?.FindForm().Close();
        }

        private DataView _dvInternationalLicensesData;

        private void _FilterInternationalLicensesData()
        {
            if (_dvInternationalLicensesData == null)
                return;

            if (string.IsNullOrEmpty(txtFilter.Text) && cbFilter.SelectedItem.ToString() != "Is Active")
            {
                _dvInternationalLicensesData.RowFilter = "";
                return;
            }

            string SelectedFilter = cbFilter.SelectedItem.ToString();
            string ValueToSearch = txtFilter.Text.Trim().Replace("'", "''");

            switch (SelectedFilter)
            {
                case "Inter. Licesne ID":
                    _dvInternationalLicensesData.RowFilter = $"InternationalLicenseID = {ValueToSearch}";
                    break;

                case "Application ID":
                    _dvInternationalLicensesData.RowFilter = $"ApplicationID = {ValueToSearch}";
                    break;

                case "Driver ID":
                    _dvInternationalLicensesData.RowFilter = $"DriverID = {ValueToSearch}";
                    break;

                case "Local License ID":
                    _dvInternationalLicensesData.RowFilter = $"IssuedUsingLocalLicenseID = {ValueToSearch}";
                    break;

                case "Is Active":
                    _HandleIsActiveFilterChoice();
                    break;

                default:
                    break;
            }
        }

        private void _HandleIsActiveFilterChoice()
        {
            string SelectedFilter = cbIsActive.SelectedItem.ToString();

            switch (SelectedFilter)
            {
                case "All":
                    _dvInternationalLicensesData.RowFilter = "";
                    break;

                case "Active":
                    _dvInternationalLicensesData.RowFilter = "IsActive = True";
                    break;

                case "Not Active":
                    _dvInternationalLicensesData.RowFilter = "IsActive = False";
                    break;

                default:
                    break;
            }
        }

        private void _FillIsActiveFilter()
        {
            cbIsActive.Items.Add("All");
            cbIsActive.Items.Add("Active");
            cbIsActive.Items.Add("Not Active");

            cbIsActive.SelectedItem = "All";
        }

        private void _UpdateRecordsCount()
        {
            if (_dvInternationalLicensesData == null)
                return;

            lblRecords.Text = _dvInternationalLicensesData.Count.ToString();
        }

        private void _FillFilterItems()
        {
            cbFilter.Items.Add("None");
            cbFilter.Items.Add("Inter. Licesne ID");
            cbFilter.Items.Add("Application ID");
            cbFilter.Items.Add("Driver ID");
            cbFilter.Items.Add("Local License ID");
            cbFilter.Items.Add("Is Active");

            cbFilter.SelectedItem = "None";
        }

        private void _FillFields()
        {
            _FillFilterItems();
            _FillIsActiveFilter();
        }

        private void _RefreshInternationalLicesnesData()
        {
            txtFilter.Clear();
            DataTable _dtInternationalLicensesData = clsInternationalLicense.GetAllInternationalLicenses();
            _dvInternationalLicensesData = new DataView(_dtInternationalLicensesData);
            dgvInternationalLicesnes.DataSource = _dvInternationalLicensesData;
            _UpdateRecordsCount();
        }

        private void _RenameAndAdjustColumnsFordgvInternationalLicenses()
        {
            if (_dvInternationalLicensesData == null)
                return;

            dgvInternationalLicesnes.Columns["InternationalLicenseID"].HeaderText = "Inter. License ID";
            dgvInternationalLicesnes.Columns["ApplicationID"].HeaderText = "Application ID";
            dgvInternationalLicesnes.Columns["DriverID"].HeaderText = "Driver ID";
            dgvInternationalLicesnes.Columns["IssuedUsingLocalLicenseID"].HeaderText = "Local License ID";
            dgvInternationalLicesnes.Columns["IssueDate"].HeaderText = "Issue Date";
            dgvInternationalLicesnes.Columns["ExpirationDate"].HeaderText = "Expiration Date";
            dgvInternationalLicesnes.Columns["IsActive"].HeaderText = "Is Active";

            dgvInternationalLicesnes.Columns["IssueDate"].DefaultCellStyle.Format = clsFormat.ToShortDateString();
            dgvInternationalLicesnes.Columns["ExpirationDate"].DefaultCellStyle.Format = clsFormat.ToShortDateString();
        }

        private void _HandleFilterControlsVisibilty()
        {
            txtFilter.Clear();

            if (cbFilter.SelectedItem.ToString() == "None")
            {
                cbIsActive.Visible = false;
                txtFilter.Visible = false;
            }

            else if (cbFilter.SelectedItem.ToString() == "Is Active")
            {
                cbIsActive.Visible = true;
                txtFilter.Visible = false;
            }
            else
            {
                txtFilter.Visible = true;
                cbIsActive.Visible = false;
            }
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPersonCard frm = new frmPersonCard((int)dgvInternationalLicesnes.CurrentRow.Cells[1].Value);
            frm.ShowDialog();
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLicenseHistory frm = new frmLicenseHistory((string)dgvInternationalLicesnes.CurrentRow.Cells["NationalNo"].Value);
            frm.ShowDialog();
        }

        private void ctrlListIntenationalLicesneApplications_Load(object sender, EventArgs e)
        {
            _FillFields();
            _RefreshInternationalLicesnesData();
            _RenameAndAdjustColumnsFordgvInternationalLicenses();
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            _FilterInternationalLicensesData();
            _UpdateRecordsCount();
        }

        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilter.SelectedItem.ToString() == "Inter. Licesne ID" || cbFilter.SelectedItem.ToString() == "Application ID" ||
                cbFilter.SelectedItem.ToString() == "Driver ID" || cbFilter.SelectedItem.ToString() == "Local License ID")
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilter.Clear();
            _FilterInternationalLicensesData();
            _HandleFilterControlsVisibilty();
            _UpdateRecordsCount();
        }

        private void cbIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            _FilterInternationalLicensesData();
            _UpdateRecordsCount();
        }

        private void showDetailsToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmPersonCard frm = new frmPersonCard(clsDriver.GetDriverInfoByDriverID((int)dgvInternationalLicesnes.CurrentRow.Cells["DriverID"].Value).PersonID);
            frm.ShowDialog();
        }

        private void showLicenseDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLocalLicesneInfo frm = new frmLocalLicesneInfo((int)dgvInternationalLicesnes.CurrentRow.Cells["IssuedUsingLocalLicenseID"].Value);
            frm.ShowDialog();
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

            frmLicenseHistory frm = new frmLicenseHistory
                    (clsDriver.GetDriverInfoByDriverID((int)dgvInternationalLicesnes.CurrentRow.Cells["DriverID"].Value).PersonInfo.NationalNo);

            frm.ShowDialog();
        }

        private void btnAddInternationalLicenseApplication_Click(object sender, EventArgs e)
        {
            frmIssueInternationalLicense frm = new frmIssueInternationalLicense();
            frm.ShowDialog();
        }
    }
}