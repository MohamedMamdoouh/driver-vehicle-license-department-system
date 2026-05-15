using System;
using System.Windows.Forms;
using DVLD_Buisness_Layer;
using System.IO;
using DVLD_Project.Properties;
using DVLD_Project.Global;

namespace DVLD_Project.Forms
{
    public partial class ctrlPersonDetails : UserControl
    {
        public bool ShowHeader { get; set; }

        public ctrlPersonDetails()
        {
            InitializeComponent();
            lblHeader.Visible = ShowHeader;
        }

        public int PersonID { get; set; }
        public string NationalNo { get; set; }

        public void ShowCloseButton(bool IsVisible)
        {
            btnClose.Visible = IsVisible;
        }

        private bool _ShowEditPersonInfo = true;
        public bool ShowEditPersonInfo
        {
            get
            {
                return _ShowEditPersonInfo;
            }
            set
            {
                _ShowEditPersonInfo = value;
                llEditPersonDetails.Visible = _ShowEditPersonInfo;
            }
        }

        bool _IsPersonFound = false;
        public bool IsPersonFound
        {
            get { return _IsPersonFound; }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this?.FindForm().Close();
        }

        private clsPerson _PersonData;
        public clsPerson SelectedPersonData
        {
            get { return _PersonData; }
        }

        private void _HandlePersonImage()
        {
            if (!string.IsNullOrEmpty(_PersonData.ImagePath) && File.Exists(_PersonData.ImagePath))
            {
                pbPersonImage.ImageLocation = _PersonData.ImagePath;
            }

            else
            {
                if (_PersonData.Gendor == clsPerson.enGendor.Female)
                {
                    pbPersonImage.Image = Resources.Female_512;
                }
                else
                {
                    pbPersonImage.Image = Resources.Male_512;
                }
            }
        }

        private bool _HandleRetrievedPersonIdentifier()
        {
            if (!string.IsNullOrEmpty(NationalNo))
            {
                _PersonData = clsPerson.Find(NationalNo);
            }

            else
            {
                _PersonData = clsPerson.Find(PersonID);
            }

            if (_PersonData == null)
            {
                _IsPersonFound = false;
                _ResetPersonData();
                return false;
            }

            else
            {
                _IsPersonFound = true;
            }

            PersonID = _PersonData.ID;
            NationalNo = _PersonData.NationalNo;

            return true;
        }

        private void _UpdatePersonData()
        {
            if (!_HandleRetrievedPersonIdentifier())
                return;

            lblPersonID.Text = _PersonData.ID.ToString();
            lblName.Text = _PersonData.FirstName + " " + _PersonData.SecondName + " "
                            + _PersonData.ThirdName + " " + _PersonData.LastName;

            lblGendor.Text = (_PersonData.Gendor == clsPerson.enGendor.Male ? "Male" : "Female");
            lblNationalNo.Text = _PersonData.NationalNo;
            lblEmail.Text = _PersonData.Email;
            lblAddress.Text = _PersonData.Address;
            lblDateOfBirth.Text = clsFormat.ToShortDateString(_PersonData.DateOfBirth);
            lblPhone.Text = _PersonData.Phone;
            lblCountry.Text = clsCountry.GetCountryName(_PersonData.NationalityCountryID);

            _HandleEditPerosnInfoButton();
            _HandlePersonImage();
        }

        public void LoadDataByPersonID(int PersonID)
        {
            this.PersonID = PersonID;
            _UpdatePersonData();
        }

        private void _HandleEditPerosnInfoButton()
        {
            llEditPersonDetails.Enabled = (lblPersonID.Text != "??");
        }

        public void ctrlPersonDetails_Load(object sender, EventArgs e)
        {
            _UpdatePersonData();
        }

        // Method that updates the control when a person is selected using 'ctrlPersonDetailsWithFilter'
        public void GetValuesFromParentControl(int ID, string NationalNo)
        {
            this.PersonID = ID;
            this.NationalNo = NationalNo;

            _UpdatePersonData();
        }

        public void GetValuesFromParentControl(int ID)
        {
            this.PersonID = ID;
            _UpdatePersonData();
        }

        private void _ResetPersonData()
        {
            llEditPersonDetails.Enabled = false;
            lblPersonID.Text = "??";
            lblName.Text = "??";
            lblGendor.Text = "??";
            lblNationalNo.Text = "??";
            lblEmail.Text = "??";
            lblAddress.Text = "??";
            lblDateOfBirth.Text = "??";
            lblPhone.Text = "??";
            lblCountry.Text = "??";
            pbPersonImage.Image = null;

            _HandleEditPerosnInfoButton();
        }

        private void llEditPersonDetails_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAddEditPerson frm = new frmAddEditPerson(_PersonData.ID);
            frm.ShowDialog();
            _UpdatePersonData();
        }
    }
}
