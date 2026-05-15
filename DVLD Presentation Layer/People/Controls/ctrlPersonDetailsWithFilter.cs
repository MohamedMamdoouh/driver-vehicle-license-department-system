using System;
using System.Windows.Forms;
using DVLD_Buisness_Layer;
using DVLD_Project.Forms;

namespace DVLD_Project.People.Controls
{
    public partial class ctrlPersonDetailsWithFilter : UserControl
    {
        public ctrlPersonDetailsWithFilter()
        {
            InitializeComponent();

            // Subscribe to the Action/Event, be ready when I invoke you
            this.PersonSelected += ctrlPersonDetails1.GetValuesFromParentControl;
        }

        // Declare an event that passes ID and NationalNo
        public event Action<int, string> PersonSelected;

        public void OnPersonSelected(int ID = -1, string NationalNo = "")
        {
            // Fire the event and notify subscribers (ctrlPersonCard)
            PersonSelected?.Invoke(ID, NationalNo);
        }

        private enum _enFilterType { Nothing = 0, ID = 1, NationalNo = 2 };

        public bool IsPersonFound
        {
            get { return ctrlPersonDetails1.IsPersonFound; }
        }

        private bool _ShowAddPerson = true;
        public bool ShowAddPerson
        {
            get
            {
                return _ShowAddPerson;
            }
            set
            {
                _ShowAddPerson = value;
                btnAddPerson.Visible = _ShowAddPerson;
            }
        }

        private bool _EnableFilter = true;
        public bool EnableFilter
        {
            get
            {
                return _EnableFilter;
            }
            set
            {
                _EnableFilter = value;
                gbFilter.Enabled = _EnableFilter;
            }
        }

        public int PersonID
        {
            set { ctrlPersonDetails1.PersonID = value; }
            get { return ctrlPersonDetails1.PersonID; }
        }

        public string PersonNationalNo
        {
            get { return ctrlPersonDetails1.NationalNo; }
        }

        public clsPerson SelectedPersonData
        {
            get { return ctrlPersonDetails1.SelectedPersonData; }
        }

        private _enFilterType _GetFilterType()
        {
            string SelectedFilter = cbFilterBy.SelectedItem.ToString();

            switch (SelectedFilter)
            {
                case "ID":
                    return _enFilterType.ID;

                case "National Number":
                    return _enFilterType.NationalNo;

                default:
                    break;
            }

            return _enFilterType.Nothing;
        }

        private void _FillFilterItems()
        {
            cbFilterBy.Items.Add("ID");
            cbFilterBy.Items.Add("National Number");

            cbFilterBy.SelectedItem = "ID";
        }

        private void ctrlPersonCardWithFilter_Load(object sender, EventArgs e)
        {
            _FillFilterItems();
            this.BeginInvoke(new Action(() => txtFilter.Focus())); // Delay focus until the control is ready
        }

        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            frmAddEditPerson frm = new frmAddEditPerson(-1);
            frm.ShowDialog();
        }

        private void _PassPersonDataToControl()
        {
            string ValueToSearch = txtFilter.Text.Trim();

            if (_GetFilterType() == _enFilterType.ID)
            {
                int.TryParse(ValueToSearch, out int ID);
                OnPersonSelected(ID, "");
            }

            else
            {
                OnPersonSelected(-1, ValueToSearch);
            }

            _HandlePersonNotFound();
        }

        private void _HandlePersonNotFound()
        {
            if (!ctrlPersonDetails1.IsPersonFound)
            {
                MessageBox.Show("Person not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSearchPerson_Click(object sender, EventArgs e)
        {
            if (!_ValidateInput())
            {
                MessageBox.Show("Enter valid values", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _PassPersonDataToControl();
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilter.Clear();
        }

        private bool _ValidateInput()
        {
            if (_GetFilterType() == _enFilterType.NationalNo)
            {
                if (!clsValidation.ValidateNationalNo(txtFilter))
                    return false;
            }

            else
            {
                if (!clsValidation.ValidateID(txtFilter))
                    return false;
            }

            return true;
        }

        private void txtFilterBy_TextChanged(object sender, EventArgs e)
        {
            _ValidateInput();
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

            // Check if pressed key is Enter (character code 13)
            if (e.KeyChar == (char)13)
            {
                btnSearchPerson.PerformClick();
            }
        }
    }
}
