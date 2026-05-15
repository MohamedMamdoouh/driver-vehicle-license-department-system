using System;
using System.Data.SqlTypes;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_Buisness_Layer;
using DVLD_Project.Global;

namespace DVLD_Project.Users.Controls
{
    public partial class ctrlAddEditUser : UserControl
    {
        public ctrlAddEditUser()
        {
            InitializeComponent();
        }

        private bool _AllowTabChange = false;
        public int UserID;
        public int PersonID;
        private enum enMode { AddNew, Update }
        private enMode _Mode;
        private clsUser _User;

        private bool _HandleAddNewMode()
        {
            if (_Mode == enMode.AddNew)
            {
                _User = new clsUser();
                lblHeader.Text = "Add New User";
                return true;
            }

            return false;
        }

        private bool _HandleUpdateMode()
        {
            _User = clsUser.Find(UserID);

            if (_User == null)
                return false;

            ctrlPersonCardWithFilter1.EnableFilter = false;
            ctrlPersonCardWithFilter1.OnPersonSelected(PersonID);

            lblHeader.Text = "Update User with ID = " + _User.UserID;
            lblUserID.Text = _User.UserID.ToString();
            txtUsername.Text = _User.UserName;
            chkIsActive.Checked = _User.IsActive;

            return true;
        }

        private void _HandleAddEditUser()
        {
            if (this.UserID == -1)
                _Mode = enMode.AddNew;

            else
                _Mode = enMode.Update;

            if (_HandleAddNewMode())
                return;

            _HandleUpdateMode();

        }

        private bool _Save()
        {
            _User.UserName = txtUsername.Text;
            _User.Password = clsCryptography.ComputeHash(txtPassword.Text.Trim());
            _User.IsActive = chkIsActive.Checked;

            // Note: this mode for the control, but User Mode still not changed
            _Mode = enMode.Update;
            return _User.Save();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (!ctrlPersonCardWithFilter1.IsPersonFound)
            {
                MessageBox.Show("Please select a person", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (clsUser.IsUserExistByPerosnID(ctrlPersonCardWithFilter1.PersonID) && (_Mode == enMode.AddNew))
            {
                MessageBox.Show("This person is already linked to a user", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (_Mode == enMode.AddNew)
            {
                // We use this to get PersonID to insert a new user in database
                _User.PersonID = ctrlPersonCardWithFilter1.PersonID;
            }

            _AllowTabChange = true;
            tcAddNewUser.SelectedTab = tpLoginInfo;
        }

        private void tcAddNewUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnNext.Visible = (tcAddNewUser.SelectedTab != tpLoginInfo);

            if (tcAddNewUser.SelectedTab == tpLoginInfo && !_AllowTabChange)
            {
                tcAddNewUser.SelectedTab = tpPersonalInfo;
                MessageBox.Show("You cannot access Login Info tab from here\nPlease use button \"Next\"", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            _AllowTabChange = false;
        }

        private bool _ValidateInput()
        {
            if (!clsValidation.ValidateUserName(txtUsername))
                return false;

            if (!clsValidation.ValidatePassword(txtPassword))
                return false;

            if (!clsValidation.ValidateConfirmPassword(txtPassword, txtConfirmPassword))
                return false;

            return true;
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            clsValidation.ValidatePassword(txtPassword);
        }

        private void txtConfirmPassword_TextChanged(object sender, EventArgs e)
        {
            clsValidation.ValidateConfirmPassword(txtPassword, txtConfirmPassword);
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowPassword.Checked)
            {
                txtPassword.PasswordChar = '\0';
                txtConfirmPassword.PasswordChar = '\0';
            }
            else
            {
                txtPassword.PasswordChar = '*';
                txtConfirmPassword.PasswordChar = '*';
            }
        }

        private void ctrlAddNewUser_Load(object sender, EventArgs e)
        {
            _HandleAddEditUser();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this?.FindForm().Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!_ValidateInput())
            {
                MessageBox.Show("Please enter valid values", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (clsUser.IsUserExistByUsername(txtUsername.Text) && _User.UserName != txtUsername.Text)
            {
                MessageBox.Show("Username already exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (_Save())
            {
                MessageBox.Show("Saved Successfully", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this?.FindForm().Close();
            }

            else
            {
                MessageBox.Show("Unable to save", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
