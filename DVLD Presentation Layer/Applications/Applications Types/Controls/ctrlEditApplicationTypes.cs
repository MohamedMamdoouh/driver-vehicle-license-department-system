using System;
using System.Windows.Forms;
using DVLD_Buisness_Layer;

namespace DVLD_Project.Applications_Types.Controls
{
    public partial class ctrlUpdateApplicationsTypes : UserControl
    {
        public ctrlUpdateApplicationsTypes()
        {
            InitializeComponent();
        }

        public int ApplicationTypeID;
        private clsApplicationType _ApplicationType;

        private enum enMode { AddNew, Update }
        private enMode _Mode;

        private void btnClose_Click(object sender, EventArgs e)
        {
            this?.FindForm().Close();
        }

        private bool _HandleAddNewMode()
        {
            if (_Mode == enMode.AddNew)
            {
                _ApplicationType = new clsApplicationType();
                lblHeader.Text = "Add New Application Type";
                return true;
            }

            return false;
        }

        private bool _HandleUpdateMode()
        {
            _ApplicationType = clsApplicationType.Find((clsApplication.enApplicationType)ApplicationTypeID);

            if (_ApplicationType == null)
                return false;

            lblHeader.Text = "Update Application Type";

            lblID.Text = _ApplicationType.ApplicationTypeID.ToString();
            txtTitle.Text = _ApplicationType.Title;
            txtFees.Text = _ApplicationType.Fees.ToString();

            return true;
        }

        private void _HandleAddEditApplicationType()
        {
            if (this.ApplicationTypeID == -1)
                _Mode = enMode.AddNew;

            else
                _Mode = enMode.Update;

            if (_HandleAddNewMode())
                return;

            _HandleUpdateMode();
        }

        private bool _Save()
        {
            _ApplicationType.Title = txtTitle.Text;
            _ApplicationType.Fees = Convert.ToDecimal(txtFees.Text);

            return _ApplicationType.Save();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!_ValidateInput())
            {
                MessageBox.Show("Please enter valid values", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (_Save())
            {
                MessageBox.Show("Saved successfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this?.FindForm().Close();
            }
            else
            {
                MessageBox.Show("Unable to save", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ctrlUpdateApplicationsTypes_Load(object sender, EventArgs e)
        {
            _HandleAddEditApplicationType();
        }

        private bool _ValidateInput()
        {
            if (!clsValidation.ValidateFloat(txtFees))
                return false;

            if (!clsValidation.ValidateTitle(txtTitle))
                return false;

            return true;
        }

        private void txtFees_TextChanged(object sender, EventArgs e)
        {
            clsValidation.ValidateFloat(txtFees);
        }

        private void txtTitle_TextChanged(object sender, EventArgs e)
        {
            clsValidation.ValidateTitle(txtTitle);
        }
    }
}
