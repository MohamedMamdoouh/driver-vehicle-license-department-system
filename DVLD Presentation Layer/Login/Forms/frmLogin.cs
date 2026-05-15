using System;
using System.Windows.Forms;
using DVLD;

namespace DVLD_Project.Users.Forms
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
            ctrlLogin1.LoginSucceded += OnLoginSucceded;
        }

        private void OnLoginSucceded(object sender, EventArgs e)
        {
            this?.FindForm().Hide();
            frmMain frm = new frmMain(this);
            frm.ShowDialog();
        }
    }
}
