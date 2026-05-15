using System;
using System.Data;
using System.Windows.Forms;
using DVLD_Buisness_Layer;
using DVLD_Project.Applications.Renew_Local_Licesne.Forms;
using DVLD_Project.Global;
using DVLD_Project.Licenses.Forms;

namespace DVLD_Project.Licenses.Controls
{
    public partial class ctrlLicenseHistory : UserControl
    {
        public ctrlLicenseHistory()
        {
            InitializeComponent();
            ctrlPersonDetails1.ShowHeader = false;
        }

        public string NationalNo {  get; set; }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this?.FindForm().Close();
        }

        private void _LoadData()
        {
            int PersonID = clsPerson.GetPersonIDByNationalNo(NationalNo);

            if (PersonID == -1)
                return;

            ctrlPersonDetails1.LoadDataByPersonID(PersonID);

            DataTable dtLocalLicensesInfo = clsLocalLicense.GetAllLocalLicensesForDriver(PersonID);
            dgvLocalLicensesInfo.DataSource = dtLocalLicensesInfo;
            lblLocalLicensesHistory.Text = dtLocalLicensesInfo.Rows.Count.ToString();
            _RenameAndAdjustColumnsFor_dgvLocalLicenses();

            DataTable dtInternationalLicesnes = clsInternationalLicense.GetAllInternationalLicensesForDriver(PersonID);
            dgvIternationalLicenseInfo.DataSource = dtInternationalLicesnes;
            lblInternationlaLicensesRecords.Text = dtInternationalLicesnes.Rows.Count.ToString();
            _RenameAndAdjustColumnsFor_dgvInternationalLicesnes();
        }

        private void ctrlLicenseHistory_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void _RenameAndAdjustColumnsFor_dgvLocalLicenses()
        {
            if (dgvLocalLicensesInfo.Rows.Count == 0)
                return;

            dgvLocalLicensesInfo.Columns["LicenseID"].HeaderText = "License ID";
            dgvLocalLicensesInfo.Columns["ApplicationID"].HeaderText = "Application ID";
            dgvLocalLicensesInfo.Columns["ClassName"].HeaderText = "Class Name";
            dgvLocalLicensesInfo.Columns["IssueDate"].HeaderText = "Issue Date";
            dgvLocalLicensesInfo.Columns["ExpirationDate"].HeaderText = "Expiration Date";
            dgvLocalLicensesInfo.Columns["IsActive"].HeaderText = "Is Active";

            dgvLocalLicensesInfo.Columns["IssueDate"].DefaultCellStyle.Format = clsFormat.ToShortDateString();
            dgvLocalLicensesInfo.Columns["ExpirationDate"].DefaultCellStyle.Format = clsFormat.ToShortDateString();
        }

        private void _RenameAndAdjustColumnsFor_dgvInternationalLicesnes()
        {
            if (dgvIternationalLicenseInfo.Rows.Count == 0)
                return;

            dgvIternationalLicenseInfo.Columns["InternationalLicenseID"].HeaderText = "International License ID";
            dgvIternationalLicenseInfo.Columns["ApplicationID"].HeaderText = "Application ID";
            dgvIternationalLicenseInfo.Columns["DriverID"].HeaderText = "Driver ID";
            dgvIternationalLicenseInfo.Columns["IssueDate"].HeaderText = "Issue Date";
            dgvIternationalLicenseInfo.Columns["ExpirationDate"].HeaderText = "Expiration Date";
            dgvIternationalLicenseInfo.Columns["IsActive"].HeaderText = "Is Active";

            dgvIternationalLicenseInfo.Columns["IssueDate"].DefaultCellStyle.Format = clsFormat.ToShortDateString();
            dgvIternationalLicenseInfo.Columns["ExpirationDate"].DefaultCellStyle.Format = clsFormat.ToShortDateString();
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLocalLicesneInfo frm = new frmLocalLicesneInfo((int)dgvLocalLicensesInfo.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }

        private void showDetailsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmInternationalLicenseInfo frm = new frmInternationalLicenseInfo((int)dgvIternationalLicenseInfo.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }

        private void renewLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRenewLocalLicense frm = new frmRenewLocalLicense((int)dgvLocalLicensesInfo.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }

        private void cmsLocalLicense_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            renewLicenseToolStripMenuItem.Enabled = !(bool)dgvLocalLicensesInfo.CurrentRow.Cells["IsActive"].Value;
        }
    }
}
