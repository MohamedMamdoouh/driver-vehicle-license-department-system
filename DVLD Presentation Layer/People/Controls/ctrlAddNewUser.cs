using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_Buisness_Layer;
using System.Data.SqlTypes;

namespace DVLD_Project.Users.Controls
{
    public partial class ctrlAddNewUser : UserControl
    {
        public ctrlAddNewUser()
        {
            InitializeComponent();
        }

        private bool _AllowTabChange = false;

        public int UserID;

        private enum enMode { AddNew, Update }
        private enMode _Mode;

        private clsUser _User;

        private bool _HandleAddNewMode()
        {
            if (_Mode == enMode.AddNew)
            {
                _User = new clsUser();
                _User.PersonID = ctrlPersonCardWithFilter1.PersonID;
                return true;
            }

            return false;
        }

        private bool _HandleUpdateMode()
        {
            _User = clsUser.Find(UserID);

            if (_User == null)
                return false;

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
            _User.Password = txtPassword.Text;
            _User.IsActive = chkIsActive.Checked;

            _Mode = enMode.Update;
            return _User.Save();
        }

        private void _HandleNextButton()
        {
            if (!ctrlPersonCardWithFilter1.IsPersonFound)
            {
                MessageBox.Show("Please select a person", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (clsUser.IsUserExistByPerosnID(ctrlPersonCardWithFilter1.PersonID))
            {
                MessageBox.Show("This person is already linked to a user", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _HandleAddEditUser();
            _AllowTabChange = true;
            tcAddNewUser.SelectedTab = tpLoginInfo;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            _HandleNextButton();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!_ValidateInput())
            {
                MessageBox.Show("Please enter valid values", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.FindForm().Close();
        }

        private void tcAddNewUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tcAddNewUser.SelectedTab == tpLoginInfo && !_AllowTabChange)
            {
                tcAddNewUser.SelectedTab = tpPersonalInfo;
                MessageBox.Show("You cannot access Login Info tab, please use button \"Next\"", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            _AllowTabChange = false;
        }

        private bool _ValidateInput()
        {
            if (!clsValidation.ValidateName(txtUsername))
                return false;

            if (!clsValidation.ValidatePassword(txtPassword))
                return false;

            if (!clsValidation.ValidateConfirmPassword(txtPassword, txtConfirmPassword))
                return false;

            return true;
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            clsValidation.ValidateName(txtUsername);
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
    }
}
