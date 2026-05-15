using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_Buisness_Layer;

namespace DVLD_Project.Applications.Test_Types.Controls
{
    public partial class ctrlEditTestType : UserControl
    {
        public ctrlEditTestType()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this?.FindForm().Close();
        }

        public clsTestType.enTestType TestTypeID;
        private clsTestType _TestType;

        private enum enMode { AddNew, Update }
        private enMode _Mode;

        private bool _HandleAddNewMode()
        {
            if (_Mode == enMode.AddNew)
            {
                _TestType = new clsTestType();
                lblHeader.Text = "Add New Test Type";
                return true;
            }

            return false;
        }

        private bool _HandleUpdateMode()
        {
            _TestType = clsTestType.Find(TestTypeID);

            if (_TestType == null)
                return false;

            lblHeader.Text = "Update Test Type";
            lblID.Text = _TestType.ID.ToString();
            txtTitle.Text = _TestType.Title;
            txtDescription.Text = _TestType.Description;
            txtFees.Text = _TestType.Fees.ToString();

            return true;
        }

        private void _HandleAddEditTestType()
        {
            if ((int)this.TestTypeID == -1)
                _Mode = enMode.AddNew;

            else
                _Mode = enMode.Update;

            if (_HandleAddNewMode())
                return;

            _HandleUpdateMode();
        }

        private bool _Save()
        {
            _TestType.Title = txtTitle.Text;
            _TestType.Description = txtDescription.Text;
            _TestType.Fees = Convert.ToDecimal(txtFees.Text);

            return _TestType.Save();
        }

        private bool _ValidateInput()
        {
            if (!clsValidation.ValidateFloat(txtFees))
                return false;

            if (!clsValidation.ValidateTitle(txtTitle))
                return false;

            if (!clsValidation.ValidateTitle(txtDescription))
                return false;

            return true;
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

        private void ctrlEditTestType_Load(object sender, EventArgs e)
        {
            _HandleAddEditTestType();
        }

        private void txtTitle_TextChanged(object sender, EventArgs e)
        {
            clsValidation.ValidateTitle(txtTitle);
        }

        private void txtDescription_TextChanged(object sender, EventArgs e)
        {
            clsValidation.ValidateTitle(txtDescription);
        }

        private void txtFees_TextChanged(object sender, EventArgs e)
        {
            clsValidation.ValidateFloat(txtFees);
        }
    }
}

