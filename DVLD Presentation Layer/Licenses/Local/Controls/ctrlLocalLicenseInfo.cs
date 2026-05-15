using System;
using System.IO;
using System.Windows.Forms;
using DVLD_Buisness_Layer;
using DVLD_Project.Global;

namespace DVLD_Project.Licenses.Controls
{
    public partial class ctrlLocalLicenseInfo : UserControl
    {
        public ctrlLocalLicenseInfo()
        {
            InitializeComponent();
        }

        private bool _IsLicenseFound;
        public bool IsLicenseFound
        {
            get
            {
                return _IsLicenseFound;
            }
        }

        private int _LicenseID;
        public int LicenseID
        {
            get { return _LicenseID; }
            set { _LicenseID = value; }
        }

        private clsLocalLicense _LicenseInfo;
        public clsLocalLicense SelectedLicenseInfo
        {
            get
            {
                return _LicenseInfo;
            }
        }

        private void _LoadData()
        {
            _LicenseInfo = clsLocalLicense.GetLicenseInfoByID(_LicenseID);

            if (_LicenseInfo == null)
            {
                _IsLicenseFound = false;
                return;
            }

            lblClass.Text = _LicenseInfo.LicenseClassInfo.LicenseClassName;
            lblName.Text = _LicenseInfo.DriverInfo.PersonInfo.FullName;
            lblLicenseID.Text = _LicenseInfo.LicenseID.ToString();
            lblNationalNo.Text = _LicenseInfo.DriverInfo.PersonInfo.NationalNo;
            lblGendor.Text = _LicenseInfo.DriverInfo.PersonInfo.Gendor == 0 ? "Male" : "Female";
            lblIssueDate.Text = clsFormat.ToShortDateString(_LicenseInfo.IssueDate);
            lblIssueReason.Text = _LicenseInfo.GetIssueReasonText();
            lblNotes.Text = string.IsNullOrEmpty(_LicenseInfo.Notes) ? "No Notes" : _LicenseInfo.Notes;
            lblIsActive.Text = _LicenseInfo.IsActive == true ? "Yes" : "No";
            lblDateOfBirth.Text = clsFormat.ToShortDateString(_LicenseInfo.DriverInfo.PersonInfo.DateOfBirth);
            lblDriverID.Text = _LicenseInfo.DriverID.ToString();
            lblExpirationDate.Text = clsFormat.ToShortDateString(_LicenseInfo.ExpirationDate);
            lblIsDetained.Text = _LicenseInfo.IsDetained ? "Yes" : "No";

            if (string.IsNullOrEmpty(_LicenseInfo.DriverInfo.PersonInfo.ImagePath)
                                     || !File.Exists(_LicenseInfo.DriverInfo.PersonInfo.ImagePath))
            {
                if (_LicenseInfo.DriverInfo.PersonInfo.Gendor == 0)
                    pbPerosnImage.Image = Properties.Resources.Male_512;

                else
                    pbPerosnImage.Image = Properties.Resources.Female_512;
            }

            else
            {
                pbPerosnImage.ImageLocation = _LicenseInfo.DriverInfo.PersonInfo.ImagePath;
            }

            _IsLicenseFound = true;
        }

        private void ctrlLicenseInfo_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        public void LoadLicenseData(int LicenseID)
        {
            this._LicenseID = LicenseID;
            _LoadData();
        }
    }
}
