using System;
using System.Windows.Forms;
using DVLD_Buisness_Layer;

namespace DVLD_Project.Tests.TestQuestions.Forms
{
    public partial class frmWrittenTestQuestions : Form
    {
        public frmWrittenTestQuestions(int TestAppointmentID)
        {
            InitializeComponent();
            ctrlTestQuestions1.TestTypeID = clsTestType.enTestType.WrittenTest;
            ctrlTestQuestions1.TestAppointmentID = TestAppointmentID;  
        }

        private void frmWrittenTestQuestions_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Do you want to exit the test? Your current score will be saved and if you failed, " +
                               "you cannot re-enter the test again unless you make another retake test application, and pay fees",
                              "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
            {
                e.Cancel = true;
                return;
            }

            // Unsubscribe, so SaveResults can't re-trigger this handler
            this.FormClosing -= frmWrittenTestQuestions_FormClosing;

            // Now save results (will not cause a recursive call)
            ctrlTestQuestions1.SaveResults();

            // No need to re-subscribe, form is closing for real
        }
    }
}
