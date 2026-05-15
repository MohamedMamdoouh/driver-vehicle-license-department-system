using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_Project;
using DVLD_Project.Forms;
using DVLD_Project.Licenses.International.Forms;
using DVLD_Project.People.Forms;
using DVLD_Project.Tests.TestQuestions.Forms;
using DVLD_Project.Users.Forms;

namespace DVLD
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new frmWrittenTestQuestions());
            Application.Run(new frmLogin());
        }
    }
}
