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
    public partial class frmManageTestAppointments : Form
    {
        public frmManageTestAppointments(int LDLA_ID, clsTestType.enTestType TestType)
        {
            InitializeComponent();
            ctrlManageTestAppointments1.LDLA_ID = LDLA_ID;
            ctrlManageTestAppointments1.TestTypeID = TestType;
        }
    }
}
