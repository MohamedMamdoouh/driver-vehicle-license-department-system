using System;
using System.Data;
using System.Windows.Forms;
using DVLD_Buisness_Layer;
using System.IO;
using DVLD_Project.Global;
using DVLD_Project.Properties;

namespace DVLD_Project.Controls
{
    public partial class ctrlAddEditPerson : UserControl
    {
        public ctrlAddEditPerson()
        {
            InitializeComponent();
        }

        private enum enMode { AddNew, Update };
        private enMode _Mode;
        private clsPerson _Person;
        public int ID { set; get; }

        private bool _HandleAddNewMode()
        {
            if (_Mode == enMode.AddNew)
            {
                lblMode.Text = "Add New Person";
                _Person = new clsPerson();
                return true;
            }

            return false;
        }

        private bool _HandleUpdateMode()
        {
            _Person = clsPerson.Find(ID);

            if (_Person == null)
                return false;

            lblMode.Text = "Update Person with ID = " + _Person.ID.ToString();
            lblID.Text = (ID == -1 ? "??" : _Person.ID.ToString());
            txtFirstName.Text = _Person.FirstName;
            txtSecondName.Text = _Person.SecondName;
            txtThirdName.Text = _Person.ThirdName;
            txtLastName.Text = _Person.LastName;
            txtNationalNo.Text = _Person.NationalNo;
            txtEmail.Text = _Person.Email;

            if (_Person.Gendor == clsPerson.enGendor.Male)
            {
                rbMale.Checked = true;
                rbFemale.Checked = false;
            }
            else
            {
                rbFemale.Checked = true;
                rbMale.Checked = false;
            }

            dtpDateOfBirth.Value = _Person.DateOfBirth;
            txtPhone.Text = _Person.Phone;
            cbCountries.SelectedIndex = cbCountries.Items.IndexOf(clsCountry.GetCountryName(_Person.NationalityCountryID));
            txtAddress.Text = _Person.Address;

            if (!string.IsNullOrEmpty(_Person.ImagePath) && File.Exists(_Person.ImagePath))
            {
                pbPersonImage.ImageLocation = _Person.ImagePath;
            }

            return true;
        }

        private void _LoadDataForAddEditControl()
        {
            if (this.ID == -1)
                _Mode = enMode.AddNew;

            else
                _Mode = enMode.Update;

            if (_HandleAddNewMode())
                return;

            _HandleUpdateMode();

        }

        private bool _HandlePersonImage()
        {
            if (_Person.ImagePath != pbPersonImage.ImageLocation)
            {
                if (File.Exists(_Person.ImagePath))
                    File.Delete(_Person.ImagePath);

                if (string.IsNullOrEmpty(pbPersonImage.ImageLocation))
                    return false;

                string SourceImageFile = pbPersonImage.ImageLocation.ToString();

                if (clsUtil.CopyImageToProjectImagesFolder(ref SourceImageFile))
                {
                    pbPersonImage.ImageLocation = SourceImageFile;
                    return true;
                }
                else
                {
                    MessageBox.Show("Error Copying Image File", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            return true;
        }

        private void _LoadDefaultPersonImage()
        {
            if (!string.IsNullOrEmpty(pbPersonImage.ImageLocation) && File.Exists(pbPersonImage.ImageLocation))
                return;

            pbPersonImage.Image = (rbFemale.Checked ? Resources.Female_512 : Resources.Male_512);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this?.FindForm().Close();
        }

        private void _FillCountryField()
        {
            DataTable dtCountries = clsCountry.GetAllCountries();

            foreach (DataRow row in dtCountries.Rows)
            {
                cbCountries.Items.Add(row["CountryName"]);
            }

            cbCountries.SelectedIndex = cbCountries.Items.IndexOf("Egypt");
        }

        private void ctrlAddEditPerson_Load(object sender, EventArgs e)
        {
            _LoadDataForAddEditControl();
            _LoadDefaultPersonImage();
            _HandleRemoveImageButton();
            _LimitDateOfBirth();
            _FillCountryField();
        }

        private void _LimitDateOfBirth()
        {
            dtpDateOfBirth.MinDate = DateTime.Now.AddYears(-100);
            dtpDateOfBirth.MaxDate = DateTime.Now.AddYears(-18);
        }

        private void llSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (OpenFileDialog OpenFile = new OpenFileDialog())
            {
                OpenFile.Title = "Select an Image";
                OpenFile.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";

                if (OpenFile.ShowDialog() == DialogResult.OK)
                {
                    pbPersonImage.ImageLocation = OpenFile.FileName;
                }
            }

            _HandleRemoveImageButton();
        }

        private void _HandleRemoveImageButton()
        {
            llRemoveImage.Visible = (pbPersonImage.ImageLocation != null);
        }

        private void llRemoveImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pbPersonImage.ImageLocation = null;
            _HandleRemoveImageButton();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
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

        private bool _Save()
        {
            if (!_ValidateInput())
            {
                MessageBox.Show("Please correct the errors before saving", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            _HandlePersonImage();

            _Person.FirstName = txtFirstName.Text;
            _Person.SecondName = txtSecondName.Text;
            _Person.ThirdName = txtThirdName.Text;
            _Person.LastName = txtLastName.Text;
            _Person.NationalNo = txtNationalNo.Text;
            _Person.Gendor = rbMale.Checked ? clsPerson.enGendor.Male : clsPerson.enGendor.Female;
            _Person.Email = txtEmail.Text;
            _Person.DateOfBirth = dtpDateOfBirth.Value;
            _Person.Phone = txtPhone.Text;
            _Person.NationalityCountryID = clsCountry.GetCountryID(cbCountries.SelectedItem.ToString());
            _Person.Address = txtAddress.Text;

            if (pbPersonImage.ImageLocation != null)
                _Person.ImagePath = pbPersonImage.ImageLocation;
            else
                _Person.ImagePath = null;

            // Note: this mode for the control, but Person Mode still not changed
            _Mode = enMode.Update;
            return _Person.Save();
        }

        private bool _ValidateInput()
        {
            if (!clsValidation.ValidateEmail(txtEmail))
                return false;

            if (!clsValidation.ValidateName(txtFirstName))
                return false;

            if (!clsValidation.ValidateName(txtSecondName))
                return false;

            if (!clsValidation.ValidateName(txtThirdName, true))
                return false;

            if (!clsValidation.ValidateName(txtLastName))
                return false;

            if (!clsValidation.ValidateNationalNo(txtNationalNo, _Person))
                return false;

            return true;
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            clsValidation.ValidateEmail(txtEmail, true);
        }

        private void txtFirstName_TextChanged(object sender, EventArgs e)
        {
            clsValidation.ValidateName(txtFirstName);
        }

        private void txtSecondName_TextChanged(object sender, EventArgs e)
        {
            clsValidation.ValidateName(txtSecondName);
        }

        private void txtThirdName_TextChanged(object sender, EventArgs e)
        {
            clsValidation.ValidateName(txtThirdName, true);
        }

        private void txtLastName_TextChanged(object sender, EventArgs e)
        {
            clsValidation.ValidateName(txtLastName);
        }

        private void txtNationalNo_TextChanged(object sender, EventArgs e)
        {
            clsValidation.ValidateNationalNo(txtNationalNo);    
        }

        private void rbMale_CheckedChanged(object sender, EventArgs e)
        {
            _LoadDefaultPersonImage();
        }

        private void rbFemale_CheckedChanged(object sender, EventArgs e)
        {
            _LoadDefaultPersonImage();
        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow only digits
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Block the key
            }
        }
    }
}

