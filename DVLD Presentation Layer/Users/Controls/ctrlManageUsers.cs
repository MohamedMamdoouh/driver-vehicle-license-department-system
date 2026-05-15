using System;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using DVLD_Buisness_Layer;
using DVLD_Project.Users.Forms;

namespace DVLD_Project.Users.Controls
{
    public partial class ctrlManageUsers : UserControl
    {
        public ctrlManageUsers()
        {
            InitializeComponent();
            
        }

        private DataView _dvUsersData;

        private void _FilterUsersData()
        {
            string SelectedFilter = cbFilter.SelectedItem.ToString();
            string ValueToSearch = txtFilter.Text.Trim().Replace("'", "''");

            if (string.IsNullOrEmpty(ValueToSearch) && cbFilter.SelectedItem.ToString() != "Is Active")
            {
                _dvUsersData.RowFilter = "";
                return;
            }

            switch (SelectedFilter)
            {
                case "None":
                    _dvUsersData.RowFilter = $"";
                    break;

                case "User ID":
                    _dvUsersData.RowFilter = $"UserID = {Convert.ToInt32(ValueToSearch)}";
                    break;

                case "Person ID":
                    _dvUsersData.RowFilter = $"PersonID = {Convert.ToInt32(ValueToSearch)}";
                    break;

                case "User Full Name":
                    _dvUsersData.RowFilter = $"FullName like '%{ValueToSearch}%'";
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
                    _dvUsersData.RowFilter = "";
                    break;

                case "Active":
                    _dvUsersData.RowFilter = "IsActive = True";
                    break;

                case "Not Active":
                    _dvUsersData.RowFilter = "IsActive = False";
                    break;

                default:
                    break;
            }
        }

        private void _UpdateRecordsCount()
        {
            lblRecords.Text = _dvUsersData.Count.ToString();
        }

        private void _FillFilterItems()
        {
            cbFilter.Items.Add("None");
            cbFilter.Items.Add("User ID");
            cbFilter.Items.Add("Person ID");
            cbFilter.Items.Add("User Full Name");
            cbFilter.Items.Add("Is Active");

            cbFilter.SelectedItem = "None";
        }

        private void _FillIsActiveFilter()
        {
            cbIsActive.Items.Add("All");
            cbIsActive.Items.Add("Active");
            cbIsActive.Items.Add("Not Active");

            cbIsActive.SelectedItem = "All";
        }

        private void _RefreshUsersData()
        {
            DataTable dtUsersData = clsUser.GetAllUsers();

            // We can make a subset of the DataTable to other DataTable. Just for your info.
            //DataTable dtSomeUsersData = dtUsersData.DefaultView.ToTable(false, "UserID", "FirstName", "LastName", "Email", "Phone");

            _dvUsersData = new DataView(dtUsersData);
            dgvUsersData.DataSource = _dvUsersData;
        }

        private void _HandleControlsVisibilty()
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

        private void ctrlManageUsers_Load(object sender, EventArgs e)
        {
            _RefreshUsersData();
            _FillFilterItems();
            _FillIsActiveFilter();
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.FindForm()?.Close();
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            _FilterUsersData();
            _UpdateRecordsCount();
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            _HandleControlsVisibilty();
            _FilterUsersData();
            _UpdateRecordsCount();
        }

        private void showDetailsToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            int ID = (int)dgvUsersData.CurrentRow.Cells[1].Value;
            frmUserInfo frm = new frmUserInfo(ID);
            frm.ShowDialog();
        }

        private void cbIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            _FilterUsersData();
        }

        private void addNewPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddNewUser frm = new frmAddNewUser();
            frm.ShowDialog();
            _RefreshUsersData();
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            frmAddNewUser frm = new frmAddNewUser();
            frm.ShowDialog();
            _RefreshUsersData();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int ID = (int)dgvUsersData.CurrentRow.Cells[1].Value;

            if (MessageBox.Show($"Do you want to delete User with ID = {ID} ?", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                if (clsUser.DeleteUser(ID))
                {
                    MessageBox.Show($"User with ID = {ID} Deleted Successfully", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _RefreshUsersData();
                }
                else
                {
                    MessageBox.Show("Cannot delete this User, there is data linked to it", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEditUserPassword frm = new frmEditUserPassword((int)dgvUsersData.CurrentRow.Cells[1].Value);
            frm.ShowDialog();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditUser frm = new frmAddEditUser((int)dgvUsersData.CurrentRow.Cells[1].Value, (int)dgvUsersData.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _RefreshUsersData();
        }
    }
}