using System;
using System.Windows.Forms;
using DVLD_Buisness_Layer;

namespace DVLD_Project.Licenses.Local.Controls
{
    public partial class ctrlLocalLicenseInfoWithFilter : UserControl
    {
        public ctrlLocalLicenseInfoWithFilter()
        {
            InitializeComponent();
        }

        public event EventHandler LicenseSelected;
        public event EventHandler HasLicenseID;

        public void OnLicenseSelected()
        {
            LicenseSelected?.Invoke(this, EventArgs.Empty);
        }
        public void OnHasLicenseID()
        {
            HasLicenseID?.Invoke(this, EventArgs.Empty);
        }

        private bool _IsLicenseFound = false;
        public bool IsLicenseFound
        {
            get { return _IsLicenseFound; }
        }

        public int? LicenseID { get; set; }

        public clsLocalLicense SelectedLicenseInfo
        {
            get
            {
                return ctrlLocalLicenseInfo1.SelectedLicenseInfo;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFilter.Text.Trim()))
            {
                MessageBox.Show("License ID cannot be empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ctrlLocalLicenseInfo1.LoadLicenseData(Convert.ToInt32(txtFilter.Text.Trim()));

            if (!ctrlLocalLicenseInfo1.IsLicenseFound)
            {
                MessageBox.Show("No license found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _IsLicenseFound = true;
            OnLicenseSelected();
        }

        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow only digits
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Block the key
            }

            // Check if pressed key is Enter (character code 13)
            if (e.KeyChar == (char)13)
            {
                btnSearch.PerformClick();
            }
        }

        private void ctrlLocalLicenseInfoWithFilter_Load(object sender, EventArgs e)
        {
            OnHasLicenseID();

            if (LicenseID.HasValue)
            {
                gbFilter.Enabled = false;
                txtFilter.Text = LicenseID.Value.ToString();
                ctrlLocalLicenseInfo1.LoadLicenseData(LicenseID.Value);
                _IsLicenseFound = ctrlLocalLicenseInfo1.IsLicenseFound;
                OnLicenseSelected();
            }
            else
            {
                gbFilter.Enabled = true;
            }
        }
    }
}
