using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_Buisness_Layer;
using DVLD_Project;
using DVLD_Project.Forms;
using DVLD_Project.Global;
using DVLD_Project.People.Forms;

namespace DVLD
{
    public partial class ctrlManagePeople : UserControl
    {
        public ctrlManagePeople()
        {
            InitializeComponent();
        }

        private DataView _dvPeopleData;

        private void _LimitDateOfBirth()
        {
            dtpDateOfBirth.MinDate = DateTime.Now.AddYears(-100);
            dtpDateOfBirth.MaxDate = DateTime.Now.AddYears(-18);
        }

        private void _FilterPeopleDataUsingDateOfBirth()
        {
            if (cbFilterBy.SelectedItem.ToString() == "Date Of Birth")
            {
                DateTime SelectedDate = dtpDateOfBirth.Value.Date;
                _dvPeopleData.RowFilter = $"DateOfBirth >= #{SelectedDate:yyyy-MM-dd} 00:00:00# AND DateOfBirth < #{SelectedDate:yyyy-MM-dd} 23:59:59#";
            }
        }

        private void _FilterPeopleDataUsingTextBox()
        {
            string SelectedFilter = cbFilterBy.SelectedItem.ToString();
            string ValueToSearch = txtFilter.Text.Trim().Replace("'", "''");

            if (string.IsNullOrEmpty(ValueToSearch))
            {
                _dvPeopleData.RowFilter = "";
                return;
            }

            switch (SelectedFilter)
            {
                case "National Number":
                    _dvPeopleData.RowFilter = $"NationalNo like '%{ValueToSearch}%'";
                    break;

                case "First Name":
                    _dvPeopleData.RowFilter = $"FirstName like '%{ValueToSearch}%'";
                    break;

                case "Last Name":
                    _dvPeopleData.RowFilter = $"LastName like '%{ValueToSearch}%'";
                    break;

                case "Phone":
                    _dvPeopleData.RowFilter = $"Phone like '%{ValueToSearch}%'";
                    break;

                case "Email":
                    _dvPeopleData.RowFilter = $"Email like '%{ValueToSearch}%'";
                    break;

                case "Address":
                    _dvPeopleData.RowFilter = $"Address like '%{ValueToSearch}%'";
                    break;

                case "ID":
                    _dvPeopleData.RowFilter = $"PersonID = {Convert.ToInt32(ValueToSearch)}";
                    break;

                default:
                    break;
            }
        }

        private void _UpdateRecordsCount()
        {
            lblRecords.Text = _dvPeopleData.Count.ToString();
        }

        private void _FillFilterByItems()
        {
            cbFilterBy.Items.Add("None");
            cbFilterBy.Items.Add("ID");
            cbFilterBy.Items.Add("National Number");
            cbFilterBy.Items.Add("First Name");
            cbFilterBy.Items.Add("Last Name");
            cbFilterBy.Items.Add("Date Of Birth");
            cbFilterBy.Items.Add("Phone");
            cbFilterBy.Items.Add("Email");
            cbFilterBy.Items.Add("Address");

            cbFilterBy.SelectedItem = "None";
        }

        private void _RefreshPeopleData()
        {
            txtFilter.Clear();
            DataTable dtPeopleData = clsPerson.GetAllPeople();
            // We can make a subset of the DataTable to other DataTable. Just for your info.
            //DataTable dtSomePeopleData = dtPeopleData.DefaultView.ToTable(false, "PersonID", "FirstName", "LastName", "Email", "Phone");
            _dvPeopleData = new DataView(dtPeopleData);
            dgvPeopleData.DataSource = _dvPeopleData;
            dgvPeopleData.Columns["DateOfBirth"].DefaultCellStyle.Format =clsFormat.ToShortDateString();
        }

        private void ctrlManagePeople_Load(object sender, EventArgs e)
        {
            _RefreshPeopleData();
            _FillFilterByItems();
            _LimitDateOfBirth();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.FindForm()?.Close();
        }

        private void _HandleControlsVisibilty()
        {
            txtFilter.Clear();

            if (cbFilterBy.SelectedItem.ToString() == "Date Of Birth")
            {
                dtpDateOfBirth.Visible = true;
                txtFilter.Visible = false;
            }
            else
            {
                txtFilter.Visible = (cbFilterBy.SelectedItem.ToString() != "None");
                dtpDateOfBirth.Visible = false;
            }
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            _HandleControlsVisibilty();
            _FilterPeopleDataUsingTextBox();
            _UpdateRecordsCount();
        }

        private void txtFilterBy_TextChanged(object sender, EventArgs e)
        {
            _FilterPeopleDataUsingTextBox();
            _UpdateRecordsCount();
        }

        private void dtpDateOfBirth_ValueChanged(object sender, EventArgs e)
        {
            _FilterPeopleDataUsingDateOfBirth();
            _UpdateRecordsCount();
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int ID = (int)dgvPeopleData.CurrentRow.Cells[0].Value;
            frmPersonCard frm = new frmPersonCard(ID);
            frm.ShowDialog();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int ID = (int)dgvPeopleData.CurrentRow.Cells[0].Value;

            if (MessageBox.Show($"Do you want to delete Person with ID = {ID} ?", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                if (clsPerson.DeletePerson(ID))
                {
                    MessageBox.Show($"Person with ID = {ID} Deleted Successfully", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _RefreshPeopleData();
                }
                else
                {
                    MessageBox.Show("Cannot delete this person, there is data linked to it", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void addNewPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditPerson frm = new frmAddEditPerson(-1);
            frm.ShowDialog();
            _RefreshPeopleData();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int ID = (int)dgvPeopleData.CurrentRow.Cells[0].Value;
            frmAddEditPerson frm = new frmAddEditPerson(ID);
            frm.ShowDialog();
            _RefreshPeopleData();
        }

        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            frmAddEditPerson frm = new frmAddEditPerson(-1);
            frm.ShowDialog();
            _RefreshPeopleData();
        }

        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.SelectedItem.ToString() == "ID")
            {
                // Allow only digits
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true; // Block the key
                }
            }
        }

    }
}
