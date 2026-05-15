using System;
using System.ComponentModel;
using System.Windows.Forms;
using DVLD_Buisness_Layer;
using DVLD_Project.Global;

namespace DVLD_Project.Detained_Licenses.Controls
{
    public partial class ctrlDetainLicense : UserControl
    {
        public ctrlDetainLicense()
        {
            InitializeComponent();
            ctrlLocalLicenseInfoWithFilter1.LicenseSelected += ctrlDetainLicense_Load;
            ctrlLocalLicenseInfoWithFilter1.HasLicenseID += ctrlDetainLicense_Load;
        }

        public int? LicenseID { get; set; }
        private clsDetainedLicenses _DetainedLicense;
        private clsLocalLicense _LocalLicenseInfo;

        private void btnClose_Click(object sender, EventArgs e)
        {
            this?.FindForm().Close();
        }

        private void ctrlDetainLicense_Load(object sender, EventArgs e)
        {
            if (LicenseID.HasValue)
            {
                ctrlLocalLicenseInfoWithFilter1.LicenseID = LicenseID.Value;
            }

            _LocalLicenseInfo = ctrlLocalLicenseInfoWithFilter1.SelectedLicenseInfo;

            if (_LocalLicenseInfo == null)
                return;

            lblDetainDate.Text = clsFormat.ToShortDateString(DateTime.Now);
            lblCreatedBy.Text = clsUtil.CurrentUser.UserName;
            rbSpeeding.Checked = true;
            txtViolationLocation.Clear();
        }

        private void btnDetain_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to detain this license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            if (!ctrlLocalLicenseInfoWithFilter1.IsLicenseFound)
            {
                MessageBox.Show("No license found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (_LocalLicenseInfo.IsDetained)
            {
                MessageBox.Show("Your license is already detained", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(!_LocalLicenseInfo.IsActive)
            {
                MessageBox.Show("Your license is not active", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(!clsValidation.ValidateAddress(txtViolationLocation))
            {
                MessageBox.Show("Please enter a valid violation location", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _DetainedLicense = new clsDetainedLicenses();
            _DetainedLicense.LicenseID = _LocalLicenseInfo.LicenseID;
            _DetainedLicense.DetainDate = DateTime.Now;
            _DetainedLicense.FineFees = clsViolationTypes.Find((byte)_HandleViolationTypeChoice()).FineFees;
            _DetainedLicense.CreatedByUserID = clsUtil.CurrentUser.UserID;
            _DetainedLicense.IsReleased = false;
            _DetainedLicense.ReleaseDate = null;
            _DetainedLicense.ReleasedByUserID = null;
            _DetainedLicense.ReleaseApplicationID = null;
            _DetainedLicense.ViolationTypeID = _HandleViolationTypeChoice();
            _DetainedLicense.ViolationLocation = txtViolationLocation.Text;

            if(!_DetainedLicense.DetainDrivingLicense())
            {
                MessageBox.Show("Cannot detain this license!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                MessageBox.Show("The license has been detained successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this?.FindForm().Close();
            }
        }

        private clsDetainedLicenses.enViolationType _HandleViolationTypeChoice()
        {
            if (rbSpeeding.Checked)
                return clsDetainedLicenses.enViolationType.Speeding;

            else if (rbRunningRedLight.Checked)
                return clsDetainedLicenses.enViolationType.RunningRedLight;

            else if (rbIllegalParking.Checked)
                return clsDetainedLicenses.enViolationType.IllegalParking;

            else if (rbDrivingWithoutSeatbelt.Checked)
                return clsDetainedLicenses.enViolationType.DrivingWithoutSeatbelt;

            else if (rbUsingMobilePhone.Checked)
                return clsDetainedLicenses.enViolationType.UsingMobilePhone;

            else if (rbDrivingWithoutValidLicense.Checked)
                return clsDetainedLicenses.enViolationType.DrivingWithoutValidLicense;

            else if (rbFailureToYield.Checked)
                return clsDetainedLicenses.enViolationType.FailureToYield;

            else if (rbRecklessDriving.Checked)
                return clsDetainedLicenses.enViolationType.RecklessDriving;

            else if (ExpiredVehicleRegistration.Checked)
                return clsDetainedLicenses.enViolationType.ExpiredVehicleRegistration;

            else if (rbDrivingUnderInfluence.Checked)
                return clsDetainedLicenses.enViolationType.DrivingUnderInfluence;

            else if (rbDrivingWithoutLights.Checked)
                return clsDetainedLicenses.enViolationType.DrivingWithoutLights;

            else
                return clsDetainedLicenses.enViolationType.Unknown;
        }

        private void rbSpeeding_CheckedChanged(object sender, EventArgs e)
        {
            lblFineFees.Text = clsFormat.ToShortMoneyString(clsViolationTypes.Find((byte)_HandleViolationTypeChoice()).FineFees);
        }

        private void rbRunningRedLight_CheckedChanged(object sender, EventArgs e)
        {
            lblFineFees.Text = clsFormat.ToShortMoneyString(clsViolationTypes.Find((byte)_HandleViolationTypeChoice()).FineFees);
        }

        private void rbIllegalParking_CheckedChanged(object sender, EventArgs e)
        {
            lblFineFees.Text = clsFormat.ToShortMoneyString(clsViolationTypes.Find((byte)_HandleViolationTypeChoice()).FineFees);
        }

        private void rbDrivingWithoutSeatbelt_CheckedChanged(object sender, EventArgs e)
        {
            lblFineFees.Text = clsFormat.ToShortMoneyString(clsViolationTypes.Find((byte)_HandleViolationTypeChoice()).FineFees);
        }

        private void rbUsingMobilePhone_CheckedChanged(object sender, EventArgs e)
        {
            lblFineFees.Text = clsFormat.ToShortMoneyString(clsViolationTypes.Find((byte)_HandleViolationTypeChoice()).FineFees);
        }

        private void rbDrivingWithoutValidLicense_CheckedChanged(object sender, EventArgs e)
        {
            lblFineFees.Text = clsFormat.ToShortMoneyString(clsViolationTypes.Find((byte)_HandleViolationTypeChoice()).FineFees);
        }

        private void rbFailureToYield_CheckedChanged(object sender, EventArgs e)
        {
            lblFineFees.Text = clsFormat.ToShortMoneyString(clsViolationTypes.Find((byte)_HandleViolationTypeChoice()).FineFees);
        }

        private void rbRecklessDriving_CheckedChanged(object sender, EventArgs e)
        {
            lblFineFees.Text = clsFormat.ToShortMoneyString(clsViolationTypes.Find((byte)_HandleViolationTypeChoice()).FineFees);
        }

        private void ExpiredVehicleRegistration_CheckedChanged(object sender, EventArgs e)
        {
            lblFineFees.Text = clsFormat.ToShortMoneyString(clsViolationTypes.Find((byte)_HandleViolationTypeChoice()).FineFees);
        }

        private void rbDrivingUnderInfluence_CheckedChanged(object sender, EventArgs e)
        {
            lblFineFees.Text = clsFormat.ToShortMoneyString(clsViolationTypes.Find((byte)_HandleViolationTypeChoice()).FineFees);
        }

        private void rbDrivingWithoutLights_CheckedChanged(object sender, EventArgs e)
        {
            lblFineFees.Text = clsFormat.ToShortMoneyString(clsViolationTypes.Find((byte)_HandleViolationTypeChoice()).FineFees);
        }
    }
}