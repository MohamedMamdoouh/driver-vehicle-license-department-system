namespace DVLD
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.msAppMainMenu = new System.Windows.Forms.MenuStrip();
            this.msApplications = new System.Windows.Forms.ToolStripMenuItem();
            this.drivingLicenseServicesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newDrivingLicesneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.localLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.internationalLicesneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.renewDrivingLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.replceDamagedAndLostLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.releaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.retakeTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageApplicationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loalDrivibgToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.internationalLicenseApplicationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.detainLicensesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageDetainedLicensesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.detainLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.releaseDetainLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageApplicationsTypesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageTestTypesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.msPeople = new System.Windows.Forms.ToolStripMenuItem();
            this.msDrivers = new System.Windows.Forms.ToolStripMenuItem();
            this.msUsers = new System.Windows.Forms.ToolStripMenuItem();
            this.msAccountSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.changeUserInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changePasswrodToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.signOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.btnClose = new System.Windows.Forms.Button();
            this.msAppMainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // msAppMainMenu
            // 
            this.msAppMainMenu.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.msAppMainMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.msAppMainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.msApplications,
            this.msPeople,
            this.msDrivers,
            this.msUsers,
            this.msAccountSettings});
            this.msAppMainMenu.Location = new System.Drawing.Point(0, 0);
            this.msAppMainMenu.Name = "msAppMainMenu";
            this.msAppMainMenu.Size = new System.Drawing.Size(1274, 76);
            this.msAppMainMenu.TabIndex = 0;
            this.msAppMainMenu.Text = "App Main Menu";
            // 
            // msApplications
            // 
            this.msApplications.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.drivingLicenseServicesToolStripMenuItem,
            this.manageApplicationsToolStripMenuItem,
            this.detainLicensesToolStripMenuItem,
            this.manageApplicationsTypesToolStripMenuItem,
            this.manageTestTypesToolStripMenuItem});
            this.msApplications.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.msApplications.Image = ((System.Drawing.Image)(resources.GetObject("msApplications.Image")));
            this.msApplications.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.msApplications.Name = "msApplications";
            this.msApplications.Padding = new System.Windows.Forms.Padding(2);
            this.msApplications.Size = new System.Drawing.Size(229, 72);
            this.msApplications.Text = "Applications";
            // 
            // drivingLicenseServicesToolStripMenuItem
            // 
            this.drivingLicenseServicesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newDrivingLicesneToolStripMenuItem,
            this.renewDrivingLicenseToolStripMenuItem,
            this.toolStripSeparator1,
            this.replceDamagedAndLostLicenseToolStripMenuItem,
            this.toolStripSeparator2,
            this.releaseToolStripMenuItem,
            this.toolStripSeparator3,
            this.retakeTestToolStripMenuItem});
            this.drivingLicenseServicesToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.drivingLicenseServicesToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("drivingLicenseServicesToolStripMenuItem.Image")));
            this.drivingLicenseServicesToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.drivingLicenseServicesToolStripMenuItem.Name = "drivingLicenseServicesToolStripMenuItem";
            this.drivingLicenseServicesToolStripMenuItem.Size = new System.Drawing.Size(408, 74);
            this.drivingLicenseServicesToolStripMenuItem.Text = "Driving License Services";
            // 
            // newDrivingLicesneToolStripMenuItem
            // 
            this.newDrivingLicesneToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.localLicenseToolStripMenuItem,
            this.internationalLicesneToolStripMenuItem});
            this.newDrivingLicesneToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.newDrivingLicesneToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("newDrivingLicesneToolStripMenuItem.Image")));
            this.newDrivingLicesneToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.newDrivingLicesneToolStripMenuItem.Name = "newDrivingLicesneToolStripMenuItem";
            this.newDrivingLicesneToolStripMenuItem.Size = new System.Drawing.Size(445, 42);
            this.newDrivingLicesneToolStripMenuItem.Text = "New Driving Licesne";
            // 
            // localLicenseToolStripMenuItem
            // 
            this.localLicenseToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("localLicenseToolStripMenuItem.Image")));
            this.localLicenseToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.localLicenseToolStripMenuItem.Name = "localLicenseToolStripMenuItem";
            this.localLicenseToolStripMenuItem.Size = new System.Drawing.Size(320, 42);
            this.localLicenseToolStripMenuItem.Text = "Local License";
            this.localLicenseToolStripMenuItem.Click += new System.EventHandler(this.localLicenseToolStripMenuItem_Click);
            // 
            // internationalLicesneToolStripMenuItem
            // 
            this.internationalLicesneToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("internationalLicesneToolStripMenuItem.Image")));
            this.internationalLicesneToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.internationalLicesneToolStripMenuItem.Name = "internationalLicesneToolStripMenuItem";
            this.internationalLicesneToolStripMenuItem.Size = new System.Drawing.Size(320, 42);
            this.internationalLicesneToolStripMenuItem.Text = "International Licesne";
            this.internationalLicesneToolStripMenuItem.Click += new System.EventHandler(this.internationalLicesneToolStripMenuItem_Click);
            // 
            // renewDrivingLicenseToolStripMenuItem
            // 
            this.renewDrivingLicenseToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("renewDrivingLicenseToolStripMenuItem.Image")));
            this.renewDrivingLicenseToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.renewDrivingLicenseToolStripMenuItem.Name = "renewDrivingLicenseToolStripMenuItem";
            this.renewDrivingLicenseToolStripMenuItem.Size = new System.Drawing.Size(445, 42);
            this.renewDrivingLicenseToolStripMenuItem.Text = "Renew Driving License";
            this.renewDrivingLicenseToolStripMenuItem.Click += new System.EventHandler(this.renewDrivingLicenseToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(442, 6);
            // 
            // replceDamagedAndLostLicenseToolStripMenuItem
            // 
            this.replceDamagedAndLostLicenseToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("replceDamagedAndLostLicenseToolStripMenuItem.Image")));
            this.replceDamagedAndLostLicenseToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.replceDamagedAndLostLicenseToolStripMenuItem.Name = "replceDamagedAndLostLicenseToolStripMenuItem";
            this.replceDamagedAndLostLicenseToolStripMenuItem.Size = new System.Drawing.Size(445, 42);
            this.replceDamagedAndLostLicenseToolStripMenuItem.Text = "Replce Damaged And Lost License";
            this.replceDamagedAndLostLicenseToolStripMenuItem.Click += new System.EventHandler(this.replceDamagedAndLostLicenseToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(442, 6);
            // 
            // releaseToolStripMenuItem
            // 
            this.releaseToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("releaseToolStripMenuItem.Image")));
            this.releaseToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.releaseToolStripMenuItem.Name = "releaseToolStripMenuItem";
            this.releaseToolStripMenuItem.Size = new System.Drawing.Size(445, 42);
            this.releaseToolStripMenuItem.Text = "Release Detained License";
            this.releaseToolStripMenuItem.Click += new System.EventHandler(this.releaseToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(442, 6);
            // 
            // retakeTestToolStripMenuItem
            // 
            this.retakeTestToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("retakeTestToolStripMenuItem.Image")));
            this.retakeTestToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.retakeTestToolStripMenuItem.Name = "retakeTestToolStripMenuItem";
            this.retakeTestToolStripMenuItem.Size = new System.Drawing.Size(445, 42);
            this.retakeTestToolStripMenuItem.Text = "Retake Test";
            this.retakeTestToolStripMenuItem.Click += new System.EventHandler(this.retakeTestToolStripMenuItem_Click);
            // 
            // manageApplicationsToolStripMenuItem
            // 
            this.manageApplicationsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loalDrivibgToolStripMenuItem,
            this.internationalLicenseApplicationsToolStripMenuItem});
            this.manageApplicationsToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.manageApplicationsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("manageApplicationsToolStripMenuItem.Image")));
            this.manageApplicationsToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.manageApplicationsToolStripMenuItem.Name = "manageApplicationsToolStripMenuItem";
            this.manageApplicationsToolStripMenuItem.Size = new System.Drawing.Size(408, 74);
            this.manageApplicationsToolStripMenuItem.Text = "Manage Applications";
            // 
            // loalDrivibgToolStripMenuItem
            // 
            this.loalDrivibgToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("loalDrivibgToolStripMenuItem.Image")));
            this.loalDrivibgToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.loalDrivibgToolStripMenuItem.Name = "loalDrivibgToolStripMenuItem";
            this.loalDrivibgToolStripMenuItem.Size = new System.Drawing.Size(444, 42);
            this.loalDrivibgToolStripMenuItem.Text = "Loal Driving License Applications";
            this.loalDrivibgToolStripMenuItem.Click += new System.EventHandler(this.loalDrivibgToolStripMenuItem_Click);
            // 
            // internationalLicenseApplicationsToolStripMenuItem
            // 
            this.internationalLicenseApplicationsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("internationalLicenseApplicationsToolStripMenuItem.Image")));
            this.internationalLicenseApplicationsToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.internationalLicenseApplicationsToolStripMenuItem.Name = "internationalLicenseApplicationsToolStripMenuItem";
            this.internationalLicenseApplicationsToolStripMenuItem.Size = new System.Drawing.Size(444, 42);
            this.internationalLicenseApplicationsToolStripMenuItem.Text = "International License Applications";
            this.internationalLicenseApplicationsToolStripMenuItem.Click += new System.EventHandler(this.internationalLicenseApplicationsToolStripMenuItem_Click);
            // 
            // detainLicensesToolStripMenuItem
            // 
            this.detainLicensesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.manageDetainedLicensesToolStripMenuItem,
            this.detainLicenseToolStripMenuItem,
            this.releaseDetainLicenseToolStripMenuItem});
            this.detainLicensesToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.detainLicensesToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("detainLicensesToolStripMenuItem.Image")));
            this.detainLicensesToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.detainLicensesToolStripMenuItem.Name = "detainLicensesToolStripMenuItem";
            this.detainLicensesToolStripMenuItem.Size = new System.Drawing.Size(408, 74);
            this.detainLicensesToolStripMenuItem.Text = "Detain Licenses";
            // 
            // manageDetainedLicensesToolStripMenuItem
            // 
            this.manageDetainedLicensesToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("manageDetainedLicensesToolStripMenuItem.Image")));
            this.manageDetainedLicensesToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.manageDetainedLicensesToolStripMenuItem.Name = "manageDetainedLicensesToolStripMenuItem";
            this.manageDetainedLicensesToolStripMenuItem.Size = new System.Drawing.Size(375, 42);
            this.manageDetainedLicensesToolStripMenuItem.Text = "Manage Detained Licenses";
            this.manageDetainedLicensesToolStripMenuItem.Click += new System.EventHandler(this.manageDetainedLicensesToolStripMenuItem_Click);
            // 
            // detainLicenseToolStripMenuItem
            // 
            this.detainLicenseToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("detainLicenseToolStripMenuItem.Image")));
            this.detainLicenseToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.detainLicenseToolStripMenuItem.Name = "detainLicenseToolStripMenuItem";
            this.detainLicenseToolStripMenuItem.Size = new System.Drawing.Size(375, 42);
            this.detainLicenseToolStripMenuItem.Text = "Detain License";
            this.detainLicenseToolStripMenuItem.Click += new System.EventHandler(this.detainLicenseToolStripMenuItem_Click);
            // 
            // releaseDetainLicenseToolStripMenuItem
            // 
            this.releaseDetainLicenseToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("releaseDetainLicenseToolStripMenuItem.Image")));
            this.releaseDetainLicenseToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.releaseDetainLicenseToolStripMenuItem.Name = "releaseDetainLicenseToolStripMenuItem";
            this.releaseDetainLicenseToolStripMenuItem.Size = new System.Drawing.Size(375, 42);
            this.releaseDetainLicenseToolStripMenuItem.Text = "Release Detained License";
            this.releaseDetainLicenseToolStripMenuItem.Click += new System.EventHandler(this.releaseDetainLicenseToolStripMenuItem_Click);
            // 
            // manageApplicationsTypesToolStripMenuItem
            // 
            this.manageApplicationsTypesToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.manageApplicationsTypesToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("manageApplicationsTypesToolStripMenuItem.Image")));
            this.manageApplicationsTypesToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.manageApplicationsTypesToolStripMenuItem.Name = "manageApplicationsTypesToolStripMenuItem";
            this.manageApplicationsTypesToolStripMenuItem.Size = new System.Drawing.Size(408, 74);
            this.manageApplicationsTypesToolStripMenuItem.Text = "Manage Application Types";
            this.manageApplicationsTypesToolStripMenuItem.Click += new System.EventHandler(this.manageApplicationsTypesToolStripMenuItem_Click);
            // 
            // manageTestTypesToolStripMenuItem
            // 
            this.manageTestTypesToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.manageTestTypesToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("manageTestTypesToolStripMenuItem.Image")));
            this.manageTestTypesToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.manageTestTypesToolStripMenuItem.Name = "manageTestTypesToolStripMenuItem";
            this.manageTestTypesToolStripMenuItem.Size = new System.Drawing.Size(408, 74);
            this.manageTestTypesToolStripMenuItem.Text = "Manage Test Types";
            this.manageTestTypesToolStripMenuItem.Click += new System.EventHandler(this.manageTestTypesToolStripMenuItem_Click);
            // 
            // msPeople
            // 
            this.msPeople.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.msPeople.Image = ((System.Drawing.Image)(resources.GetObject("msPeople.Image")));
            this.msPeople.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.msPeople.Name = "msPeople";
            this.msPeople.Size = new System.Drawing.Size(171, 72);
            this.msPeople.Text = "People";
            this.msPeople.Click += new System.EventHandler(this.msPeople_Click);
            // 
            // msDrivers
            // 
            this.msDrivers.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.msDrivers.Image = ((System.Drawing.Image)(resources.GetObject("msDrivers.Image")));
            this.msDrivers.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.msDrivers.Name = "msDrivers";
            this.msDrivers.Size = new System.Drawing.Size(176, 72);
            this.msDrivers.Text = "Drivers";
            this.msDrivers.Click += new System.EventHandler(this.msDrivers_Click);
            // 
            // msUsers
            // 
            this.msUsers.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.msUsers.Image = ((System.Drawing.Image)(resources.GetObject("msUsers.Image")));
            this.msUsers.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.msUsers.Name = "msUsers";
            this.msUsers.Size = new System.Drawing.Size(156, 72);
            this.msUsers.Text = "Users";
            this.msUsers.Click += new System.EventHandler(this.msUsers_Click);
            // 
            // msAccountSettings
            // 
            this.msAccountSettings.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changeUserInfoToolStripMenuItem,
            this.changePasswrodToolStripMenuItem,
            this.signOutToolStripMenuItem});
            this.msAccountSettings.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.msAccountSettings.Image = ((System.Drawing.Image)(resources.GetObject("msAccountSettings.Image")));
            this.msAccountSettings.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.msAccountSettings.Name = "msAccountSettings";
            this.msAccountSettings.Size = new System.Drawing.Size(288, 72);
            this.msAccountSettings.Text = "Account Settings";
            // 
            // changeUserInfoToolStripMenuItem
            // 
            this.changeUserInfoToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.changeUserInfoToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("changeUserInfoToolStripMenuItem.Image")));
            this.changeUserInfoToolStripMenuItem.Name = "changeUserInfoToolStripMenuItem";
            this.changeUserInfoToolStripMenuItem.Size = new System.Drawing.Size(281, 36);
            this.changeUserInfoToolStripMenuItem.Text = "Show User Info";
            this.changeUserInfoToolStripMenuItem.Click += new System.EventHandler(this.changeUserInfoToolStripMenuItem_Click);
            // 
            // changePasswrodToolStripMenuItem
            // 
            this.changePasswrodToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.changePasswrodToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("changePasswrodToolStripMenuItem.Image")));
            this.changePasswrodToolStripMenuItem.Name = "changePasswrodToolStripMenuItem";
            this.changePasswrodToolStripMenuItem.Size = new System.Drawing.Size(281, 36);
            this.changePasswrodToolStripMenuItem.Text = "Change Passwrod";
            this.changePasswrodToolStripMenuItem.Click += new System.EventHandler(this.changePasswrodToolStripMenuItem_Click);
            // 
            // signOutToolStripMenuItem
            // 
            this.signOutToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.signOutToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("signOutToolStripMenuItem.Image")));
            this.signOutToolStripMenuItem.Name = "signOutToolStripMenuItem";
            this.signOutToolStripMenuItem.Size = new System.Drawing.Size(281, 36);
            this.signOutToolStripMenuItem.Text = "Sign Out";
            this.signOutToolStripMenuItem.Click += new System.EventHandler(this.signOutToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.toolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem1.Image")));
            this.toolStripMenuItem1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Padding = new System.Windows.Forms.Padding(5);
            this.toolStripMenuItem1.Size = new System.Drawing.Size(208, 78);
            this.toolStripMenuItem1.Text = "Applications";
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.Red;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.Location = new System.Drawing.Point(1095, 12);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(120, 48);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::DVLD_Project.Properties.Resources.wallpaper;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1274, 787);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.msAppMainMenu);
            this.MainMenuStrip = this.msAppMainMenu;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main";
            this.msAppMainMenu.ResumeLayout(false);
            this.msAppMainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip msAppMainMenu;
        private System.Windows.Forms.ToolStripMenuItem msApplications;
        private System.Windows.Forms.ToolStripMenuItem msPeople;
        private System.Windows.Forms.ToolStripMenuItem msDrivers;
        private System.Windows.Forms.ToolStripMenuItem msUsers;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem msAccountSettings;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ToolStripMenuItem changeUserInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changePasswrodToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem signOutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageApplicationsTypesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageTestTypesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem drivingLicenseServicesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newDrivingLicesneToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem localLicenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageApplicationsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loalDrivibgToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem retakeTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem internationalLicesneToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem internationalLicenseApplicationsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem renewDrivingLicenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem replceDamagedAndLostLicenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem detainLicensesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageDetainedLicensesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem detainLicenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem releaseDetainLicenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem releaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
    }
}

