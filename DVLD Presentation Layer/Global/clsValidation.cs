using System;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using DVLD_Buisness_Layer;

namespace DVLD_Project
{
    public class clsValidation
    {
        private static ErrorProvider ErrorProvider1 = new ErrorProvider();

        public static bool ValidateEmail(TextBox txtBoxEmail, bool IsOptional = true)
        {
            if (string.IsNullOrEmpty(txtBoxEmail.Text))
            {
                if (IsOptional)
                    return true;

                ErrorProvider1.SetError(txtBoxEmail, "Email cannot be empty");
                return false;
            }

            string Pattern = @"^[a-zA-Z0-9.!#$%&'*+-/=?^_`{|}~]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$";

            if (!Regex.IsMatch(txtBoxEmail.Text, Pattern))
            {
                ErrorProvider1.SetError(txtBoxEmail, "Email is not valid");
                return false;
            }

            return true;
        }

        public static bool ValidateName(TextBox txtBoxName, bool IsOptional = false)
        {
            if (string.IsNullOrEmpty(txtBoxName.Text))
            {
                if (IsOptional)
                    return true;

                ErrorProvider1.SetError(txtBoxName, "Name cannot be empty");
                return false;
            }

            string Pattern = @"^(?=.*[a-zA-Z])[a-zA-Z0-9_]+$";

            if (!Regex.IsMatch(txtBoxName.Text, Pattern))
            {
                ErrorProvider1.SetError(txtBoxName, "Name can only contain letters, numbers, underscores");
                return false;
            }

            return true;
        }

        public static bool ValidateUserName(TextBox txtBoxUsername)
        {
            if (string.IsNullOrEmpty(txtBoxUsername.Text))
            {
                ErrorProvider1.SetError(txtBoxUsername, "Userame cannot be empty");
                return false;
            }

            if (txtBoxUsername.TextLength > 50)
            {
                ErrorProvider1.SetError(txtBoxUsername, "Userame cannot be more than 50 letters");
                return false;
            }

            string Pattern = @"^(?=.*[a-zA-Z])[a-zA-Z0-9_]+$";

            if (!Regex.IsMatch(txtBoxUsername.Text, Pattern))
            {
                ErrorProvider1.SetError(txtBoxUsername, "Userame can only contain letters, numbers, underscores");
                return false;
            }

            return true;
        }

        public static bool ValidateNationalNo(TextBox txtBoxNationalNo, clsPerson Person)
        {
            if (string.IsNullOrEmpty(txtBoxNationalNo.Text))
            {
                ErrorProvider1.SetError(txtBoxNationalNo, "National Number cannot be empty");
                return false;
            }

            if (txtBoxNationalNo.TextLength > 50)
            {
                ErrorProvider1.SetError(txtBoxNationalNo, "National Number cannot be more than 50 letters/digits");
                return false;
            }

            if (txtBoxNationalNo.Text.Trim() != Person.NationalNo && clsPerson.IsPersonExist(txtBoxNationalNo.Text.Trim()))
            {
                ErrorProvider1.SetError(txtBoxNationalNo, "National Number is used for another person");
                return false;
            }

            string Pattern = @"^[a-zA-Z0-9]+$";

            if (!Regex.IsMatch(txtBoxNationalNo.Text, Pattern))
            {
                ErrorProvider1.SetError(txtBoxNationalNo, "National Number can only contain letters, numbers");
                return false;
            }

            return true;
        }

        public static bool ValidateNationalNo(TextBox txtBoxNationalNo)
        {
            if (string.IsNullOrEmpty(txtBoxNationalNo.Text))
            {
                ErrorProvider1.SetError(txtBoxNationalNo, "National Number cannot be empty");
                return false;
            }

            string Pattern = @"^[a-zA-Z0-9]+$";

            if (!Regex.IsMatch(txtBoxNationalNo.Text, Pattern))
            {
                ErrorProvider1.SetError(txtBoxNationalNo, "National Number can only contain letters, numbers");
                return false;
            }

            return true;
        }

        public static bool ValidateGendorChoice(RadioButton rbMale, RadioButton rbFemale)
        {
            return (rbMale.Checked || rbFemale.Checked);
        }

        public static bool ValidatePhone(TextBox txtBoxPhone)
        {
            if (string.IsNullOrEmpty(txtBoxPhone.Text))
            {
                ErrorProvider1.SetError(txtBoxPhone, "Phone Number cannot be empty");
                return false;
            }

            if (txtBoxPhone.TextLength > 20 || txtBoxPhone.TextLength < 10)
            {
                ErrorProvider1.SetError(txtBoxPhone, "Phone Number must be between 10 and 20 digits");
                return false;
            }

            if (!txtBoxPhone.Text.All(char.IsDigit))
            {
                ErrorProvider1.SetError(txtBoxPhone, "Phone Number can only contain numbers");
                return false;
            }

            return true;
        }

        public static bool ValidateID(TextBox txtBoxID)
        {
            if (string.IsNullOrEmpty(txtBoxID.Text))
            {
                ErrorProvider1.SetError(txtBoxID, "ID cannot be empty");
                return false;
            }

            if (!txtBoxID.Text.All(char.IsDigit))
            {
                ErrorProvider1.SetError(txtBoxID, "ID can only contain numbers");
                return false;
            }

            return true;
        }

        public static bool ValidateAddress(TextBox txtBoxAddress)
        {
            if (string.IsNullOrEmpty(txtBoxAddress.Text))
            {
                ErrorProvider1.SetError(txtBoxAddress, "Address cannot be empty");
                return false;
            }

            if (txtBoxAddress.TextLength > 500)
            {
                ErrorProvider1.SetError(txtBoxAddress, "Address cannot be more than 500 letters");
                return false;
            }

            string Pattern = @"^[A-Za-z0-9\s,()-]+$";

            if (!Regex.IsMatch(txtBoxAddress.Text, Pattern))
            {
                ErrorProvider1.SetError(txtBoxAddress, "Address not valid");
                return false;
            }

            return true;
        }

        public static bool ValidatePassword(TextBox txtBoxPassword)
        {
            if (string.IsNullOrEmpty(txtBoxPassword.Text))
            {
                ErrorProvider1.SetError(txtBoxPassword, "Password cannot be empty");
                return false;
            }

            string Pattern = @"^(?=.*[A-Z])(?=.*\d)(?=.*[^A-Za-z0-9])\S{8,}$";

            if (!Regex.IsMatch(txtBoxPassword.Text, Pattern))
            {
                ErrorProvider1.SetError(txtBoxPassword, "Password must be at least 8 characters long, contain at least one uppercase letter,\n" +
                                                          "one number, one special character, and no spaces");
                return false;
            }

            return true;
        }

        public static bool ValidateConfirmPassword(TextBox txtBoxPassword, TextBox txtBoxConfirmPassword)
        {
            if (txtBoxPassword.Text != txtBoxConfirmPassword.Text)
            {
                ErrorProvider1.SetError(txtBoxPassword, "Password doesn't match");
                return false;
            }

            return true;
        }

        public static bool ValidateInteger(TextBox txtBoxInteger)
        {
            string Pattern = @"^[0-9]*$";

            if (!Regex.IsMatch(txtBoxInteger.Text, Pattern))
            {
                ErrorProvider1.SetError(txtBoxInteger, "Number not valid");
                return false;
            }

            return true;
        }

        public static bool ValidateFloat(TextBox txtBoxFloat)
        {
            string Pattern = @"^[0-9]*(?:\.[0-9]*)?$";

            if (!Regex.IsMatch(txtBoxFloat.Text, Pattern))
            {
                ErrorProvider1.SetError(txtBoxFloat, "Number is not valid");
                return false;
            }

            return true;
        }

        public static bool IsNumber(TextBox txtBoxNumber)
        {
            if (!(ValidateInteger(txtBoxNumber) || ValidateFloat(txtBoxNumber)))
            {
                ErrorProvider1.SetError(txtBoxNumber, "Number is not valid");
                return false;
            }

            return true;
        }

        public static bool ValidateTitle(TextBox txtBoxField)
        {
            if (string.IsNullOrEmpty(txtBoxField.Text))
            {
                ErrorProvider1.SetError(txtBoxField, "This field cannot be empty");
                return false;
            }

            string Pattern = @"^[a-zA-Z0-9\s.,;:!?'\""()\-_/\\]+$";

            if (!Regex.IsMatch(txtBoxField.Text, Pattern))
            {
                ErrorProvider1.SetError(txtBoxField, "This field is not valid");
                return false;
            }

            return true;
        }

    }
}
