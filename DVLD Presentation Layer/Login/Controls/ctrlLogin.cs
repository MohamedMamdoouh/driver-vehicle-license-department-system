using System;
using System.Windows.Forms;
using DVLD_Buisness_Layer;
using DVLD;
using DVLD_Project.Global;
using Microsoft.Win32;
using System.Diagnostics;
using System.Data.SqlClient;

namespace DVLD_Project.Users.Controls
{
    public partial class ctrlLogin : UserControl
    {
        public ctrlLogin()
        {
            InitializeComponent();
        }

        private clsUser _User;
        private byte _TrialsCount = 3;

        public event EventHandler LoginSucceded;

        private void _HandleLogin()
        {
            if (!_ValidateInput())
            {
                MessageBox.Show("Enter valid values", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (_TrialsCount == 0)
            {
                clsLogging.LogException("Account locked due to 3 failed attempts", EventLogEntryType.Warning);
                MessageBox.Show("Your account is locked due to 3 wrong attempts", "Account Locked", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this?.FindForm().Close();
                Application.Exit();
            }

            _User = clsUser.Find(txtUsername.Text.Trim(), clsCryptography.ComputeHash(txtPassword.Text.Trim()));

            if (_User == null)
            {
                _TrialsCount--;
                clsLogging.LogException("Failed sign in attempt", EventLogEntryType.Warning);
                MessageBox.Show($"Invalid username or password. You have {_TrialsCount} trial(s) remaining", "Wrong Credentials", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            else
            {
                if (!_User.IsActive)
                {
                    MessageBox.Show("User is not active", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                clsUtil.CurrentUser = _User;
                _TrialsCount = 3;
                LoginSucceded?.Invoke(this, EventArgs.Empty);
            }
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            _HandleLogin();
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check if pressed key is Enter (character code 13)
            if (e.KeyChar == (char)13)
            {
                btnSignIn.PerformClick();
            }
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = (chkShowPassword.Checked ? '\0' : '*');
        }

        private void txtUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check if pressed key is Enter (character code 13)
            if (e.KeyChar == (char)13)
            {
                btnSignIn.PerformClick();
            }
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            _ValidateInput();
        }

        private bool _ValidateInput()
        {
            if (!clsValidation.ValidateName(txtUsername))
                return false;

            return true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this?.FindForm().Close();
            Application.Exit();
        }

        private void ctrlLogin_Load(object sender, EventArgs e)
        {
            string KeyPath = @"SOFTWARE\DVLDAppInfo";

            try
            {
                using (RegistryKey Key = Registry.CurrentUser.OpenSubKey(KeyPath))
                {
                    if (Key != null)
                    {
                        txtUsername.Text = Key.GetValue("Username") as string;
                        txtPassword.Text = Key.GetValue("Password") as string;
                    }
                }
            }
            catch (SqlException ex)
            {
                clsLogging.LogException(ex.ToString(), EventLogEntryType.Error);
                throw;
            }
            catch (Exception ex)
            {
                clsLogging.LogException(ex.ToString(), EventLogEntryType.Error);
                throw;
            }
        }
    }
}
