using System;
using System.Data;
using System.Windows.Forms;
using DVLD_Buisness_Layer;
using DVLD_Project.Global;
using DVLD_Project.People.Controls;

namespace DVLD_Project.Applications.Local_Driving_License.Controls
{
    public partial class ctrlAddUpdateLDLA : UserControl
    {
        public ctrlAddUpdateLDLA()
        {
            InitializeComponent();
        }

        private enum enMode { AddNew, Update }
        private enMode _Mode;
        private bool _AllowTabChange = false;
        private clsLocalDrivingLicenseApplication _LocalDrivingLicense;
        public int LDLA_ID { get; set; }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this?.FindForm().Close();
        }

        private void _HandleAddUpdateMode()
        {
            if (this.LDLA_ID == -1)
            {
                _Mode = enMode.AddNew;
                _HandleAddNew();
                return;
            }

            else
            {
                _Mode = enMode.Update;
                _HandleUpdateMode();
            }
        }

        private void _HandleAddNew()
        {
            _LocalDrivingLicense = new clsLocalDrivingLicenseApplication();

            // Default values when add new application (to show for user)
            lblHeader.Text = "New Local Driving License Application";
            lblLDLA_ID.Text = "N/A";
            lblApplicationDate.Text = clsFormat.ToShortDateString(DateTime.Now);
            cbLicenseClass.SelectedIndex = 2;
            lblCreatedBy.Text = clsUtil.CurrentUser?.UserName ?? "N/A";
            // ComboBox index starts with 0, while ApplicationTypeID starts with 1
            lblApplicationFees.Text = clsFormat.ToShortMoneyString(clsApplicationType.Find((clsApplication.enApplicationType)(cbLicenseClass.SelectedIndex + 1)).Fees);
        }

        private void _HandleUpdateMode()
        {
            _LocalDrivingLicense = clsLocalDrivingLicenseApplication.GetLocalDrivingLicenseApplicationByLDLA_ID(LDLA_ID);
            if (_LocalDrivingLicense == null)
                return;

            ctrlPersonDetailsWithFilter1.EnableFilter = false;
            ctrlPersonDetailsWithFilter1.OnPersonSelected(_LocalDrivingLicense.Person.ID);

            lblHeader.Text = "Update Local Driving License Application";
            lblLDLA_ID.Text = _LocalDrivingLicense.LDLA_ID.ToString();
            lblApplicationDate.Text = clsFormat.ToShortDateString(_LocalDrivingLicense.ApplicationDate);
            // ComboBox index starts with 0, while ApplicationTypeID starts with 1
            cbLicenseClass.SelectedIndex = (byte)(_LocalDrivingLicense.ApplicationTypeID - 1);
            lblCreatedBy.Text = clsUtil.CurrentUser?.UserName ?? "N/A";
            lblApplicationFees.Text = clsFormat.ToShortMoneyString(_LocalDrivingLicense.PaidFees);
        }

        private void _FillLicenseClassesField()
        {
            DataTable dtLicenseClassesNames = clsLocalLicenseClass.GetAllLicenseClassesInfo();

            foreach (DataRow row in dtLicenseClassesNames.Rows)
            {
                cbLicenseClass.Items.Add(row["ClassName"]);
            }
        }

        private bool _Save()
        {
            _LocalDrivingLicense.ApplicantPersonID = ctrlPersonDetailsWithFilter1.PersonID;
            _LocalDrivingLicense.ApplicationDate = DateTime.Now;
            _LocalDrivingLicense.ApplicationTypeID = clsApplication.enApplicationType.NewLocalDrivingLicense;
            _LocalDrivingLicense.ApplicationStatus = clsApplication.enApplicationStatus.New;
            _LocalDrivingLicense.LastStatusDate = DateTime.Now;
            _LocalDrivingLicense.PaidFees = Convert.ToDecimal(lblApplicationFees.Text);
            _LocalDrivingLicense.CreatedByUserID = clsUtil.CurrentUser.UserID;
            _LocalDrivingLicense.LicenseClassID = Convert.ToByte(cbLicenseClass.SelectedIndex + 1);

            return _LocalDrivingLicense.Save();
        }

        private void tcNewLDLA_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnNext.Visible = (tcNewLDLA.SelectedTab != tpApplicationInfo);

            if (tcNewLDLA.SelectedTab == tpApplicationInfo && !_AllowTabChange)
            {
                tcNewLDLA.SelectedTab = tpPersonInfo;
                MessageBox.Show("You cannot access Application Info tab from here\nPlease use button \"Next\"", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            _AllowTabChange = false;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (!ctrlPersonDetailsWithFilter1.IsPersonFound)
            {
                MessageBox.Show("Please select a person", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _AllowTabChange = true;
            tcNewLDLA.SelectedTab = tpApplicationInfo;
        }

        private void ctrlNewLDLA_Load(object sender, EventArgs e)
        {
            _FillLicenseClassesField();
            _HandleAddUpdateMode();
        }

        private void _HandleSaveButton()
        {
            if (tcNewLDLA.SelectedTab == tpPersonInfo)
            {
                MessageBox.Show("Please go to the next page to save", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (clsLocalLicense.IsLicenseExistByPersonID(ctrlPersonDetailsWithFilter1.PersonID, (cbLicenseClass.SelectedIndex + 1)))
            {

                MessageBox.Show("Person already have a license with the same driving class,\n" +
                                "Choose diffrent driving class!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // ComboBox index starts with 0, while LicenseClassID starts with 1
            int ActiveID = clsApplication.GetActiveApplication_ForLicenseClass(ctrlPersonDetailsWithFilter1.PersonID, (byte)(cbLicenseClass.SelectedIndex + 1));

            if (ActiveID != -1)
            {
                MessageBox.Show($"There is an active application for this person\nwith the same license class, with ID = {ActiveID}",
                                  "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (_Save())
            {
                MessageBox.Show("Saved Successfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this?.FindForm().Close();
            }
            else
            {
                MessageBox.Show("Unable to save", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _HandleSaveButton();
        }

        private void cbLicenseClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblApplicationFees.Text = clsFormat.ToShortMoneyString(clsLocalLicenseClass.GetLicenseClassFees(Convert.ToByte(cbLicenseClass.SelectedIndex + 1)));
        }
    }
}
