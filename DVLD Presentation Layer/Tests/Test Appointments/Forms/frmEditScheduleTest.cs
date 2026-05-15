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

namespace DVLD_Project.Tests.Test_Appointments.Forms
{
    public partial class frmEditScheduleTest : Form
    {
        public frmEditScheduleTest(int LDLA_ID, clsTestType.enTestType TestType, int TestAppointmentID)
        {
            InitializeComponent();
            ctrlScheduleTest1.LDLA_ID = LDLA_ID;
            ctrlScheduleTest1.TestTypeID = TestType;
            ctrlScheduleTest1.TestAppointmentID = TestAppointmentID;
        }
    }
}
