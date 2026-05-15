using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices.WindowsRuntime;
using DVLD_Buisness_Layer;
using DVLD_Project.Global;

namespace DVLD_Project.Users.Controls
{
    public partial class ctrlEditUserPassword : UserControl
    {
        public ctrlEditUserPassword()
        {
            InitializeComponent();
            ctrlUserInfo1.ShowCloseButton(false);
        }

        public int UserID
        {
            get { return ctrlUserInfo1.UserID; }
            set { ctrlUserInfo1.UserID = value; }
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

            if (clsUser.UpdateUserPassword(ctrlUserInfo1.UserID, clsCryptography.ComputeHash(txtPassword.Text.Trim()),
                clsCryptography.ComputeHash(txtOldPassword.Text.Trim())))
            {
                MessageBox.Show("Password updated successfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this?.FindForm().Close();
            }

            else
            {
                MessageBox.Show("Old password is wrong", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private bool _ValidateInput()
        {
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
                txtOldPassword.PasswordChar = '\0';
                txtPassword.PasswordChar = '\0';
                txtConfirmPassword.PasswordChar = '\0';
            }

            else
            {
                txtOldPassword.PasswordChar = '*';
                txtPassword.PasswordChar = '*';
                txtConfirmPassword.PasswordChar = '*';
            }
        }
    }
}
