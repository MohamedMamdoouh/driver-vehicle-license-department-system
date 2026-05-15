using System;
using System.IO;
using System.Windows.Forms;
using DVLD_Buisness_Layer;
using DVLD_Project.Global;

namespace DVLD_Project.Licenses.Controls
{
    public partial class ctrlInternationalLicenseInfo : UserControl
    {
        public ctrlInternationalLicenseInfo()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this?.FindForm().Close();
        }

        public int InternationalLicenseID { get; set; }

        private void _LoadData()
        {
            clsInternationalLicense InternationalLicenseInfo = clsInternationalLicense.GetInternationalLicesneInfoByID(InternationalLicenseID);

            if (InternationalLicenseInfo == null)
                return;

            lblClass.Text = "International License";
            lblInternationalLicenseID.Text = InternationalLicenseInfo.InternationalLicenseID.ToString();
            lblName.Text = InternationalLicenseInfo.DriverInfo.PersonInfo.FullName;
            lblNationalNo.Text = InternationalLicenseInfo.DriverInfo.PersonInfo.NationalNo;
            lblGendor.Text = InternationalLicenseInfo.DriverInfo.PersonInfo.Gendor == 0 ? "Male" : "Female";
            lblIssueDate.Text = clsFormat.ToShortDateString(InternationalLicenseInfo.IssueDate);
            lblIsActive.Text = InternationalLicenseInfo.IsActive == true ? "Yes" : "No";
            lblDateOfBirth.Text = clsFormat.ToShortDateString(InternationalLicenseInfo.DriverInfo.PersonInfo.DateOfBirth);
            lblDriverID.Text = InternationalLicenseInfo.DriverInfo.DriverID.ToString();
            lblExpirationDate.Text = clsFormat.ToShortDateString(InternationalLicenseInfo.ExpirationDate);

            if (string.IsNullOrEmpty(InternationalLicenseInfo.LocalLicenseInfo.DriverInfo.PersonInfo.ImagePath)
                                    || !File.Exists(InternationalLicenseInfo.LocalLicenseInfo.DriverInfo.PersonInfo.ImagePath))
            {
                if (InternationalLicenseInfo.LocalLicenseInfo.DriverInfo.PersonInfo.Gendor == 0)
                    pbPerosnImage.Image = Properties.Resources.Male_512;

                else
                    pbPerosnImage.Image = Properties.Resources.Female_512;
            }

            else
            {
                pbPerosnImage.ImageLocation = InternationalLicenseInfo.LocalLicenseInfo.DriverInfo.PersonInfo.ImagePath;
            }
        }

        private void ctrlInternationalLicense_Load(object sender, EventArgs e)
        {
            _LoadData();
        }
    }
}