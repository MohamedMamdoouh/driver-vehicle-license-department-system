using System;
using System.Windows.Forms;
using DVLD_Buisness_Layer;

namespace DVLD_Project.Users.Controls
{
    public partial class ctrlUserInfo : UserControl
    {
        public ctrlUserInfo()
        {
            InitializeComponent();
            this.UserSelected += ctrlPersonDetails1.GetValuesFromParentControl;
            ctrlPersonDetails1.ShowCloseButton(false);
        }

        public void ShowCloseButton(bool IsVisible)
        {
            btnClose.Visible = IsVisible;
        }

        public event Action <int> UserSelected;

        private clsUser _User;

        private bool _IsUserFound = false;
        public bool IsUserFound
        { get { return _IsUserFound; } }

        private int _UserID;
        public int UserID
        {
            get { return _UserID; }
            set { _UserID = value; }
        }

        private void _GetUserInfo()
        {
            _User = clsUser.Find(_UserID);

            if (_User == null)
                return;

            _IsUserFound = true;
            UserSelected?.Invoke(_User.PersonID);

            lblUserID.Text = _User.UserID.ToString();
            lblUsername.Text = _User.UserName;
            lblIsActive.Text = (_User.IsActive == true ? "Active" : "Not Active");
        }

        private void ctrlPersonDetails1_Load(object sender, EventArgs e)
        {
            _GetUserInfo();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this?.FindForm().Close();
        }
    }
}
