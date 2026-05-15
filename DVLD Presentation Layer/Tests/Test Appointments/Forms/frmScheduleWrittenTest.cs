using System.Windows.Forms;
using DVLD_Buisness_Layer;

namespace DVLD_Project.Tests.Test_Appointments.Forms
{
    public partial class frmScheduleWrittenTest : Form
    {
        public frmScheduleWrittenTest(int LDLA_ID, clsTestType.enTestType TestType)
        {
            InitializeComponent();
            ctrlScheduleTest1.LDLA_ID = LDLA_ID;
            ctrlScheduleTest1.TestTypeID = TestType;
            ctrlScheduleTest1.TestAppointmentID = -1;
        }
    }
}
