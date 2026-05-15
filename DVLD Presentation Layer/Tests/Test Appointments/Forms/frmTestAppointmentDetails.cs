using System.Windows.Forms;
using DVLD_Buisness_Layer;

namespace DVLD_Project.Tests.Test_Appointments.Forms
{
    public partial class frmTestAppointmentDetails : Form
    {
        public frmTestAppointmentDetails(int LDLA_ID, int TestAppointmentID, clsTestType.enTestType TestTypeID)
        {
            InitializeComponent();
            ctrlTestAppointmentDetails1.LDLA_ID = LDLA_ID;
            ctrlTestAppointmentDetails1.TestAppointmentID = TestAppointmentID;
            ctrlTestAppointmentDetails1.TestTypeID = TestTypeID;
        }
    }
}