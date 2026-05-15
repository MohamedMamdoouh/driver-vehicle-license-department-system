namespace DVLD_Project.Applications.Local_Driving_License.Forms
{
    partial class frmManageLDL
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
            this.ctrlManageLocalDrivingLicense1 = new DVLD_Project.Applications.Local_Driving_License.Controls.ctrlManageLDLA();
            this.SuspendLayout();
            // 
            // ctrlManageLocalDrivingLicense1
            // 
            this.ctrlManageLocalDrivingLicense1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlManageLocalDrivingLicense1.Location = new System.Drawing.Point(0, 0);
            this.ctrlManageLocalDrivingLicense1.Name = "ctrlManageLocalDrivingLicense1";
            this.ctrlManageLocalDrivingLicense1.Size = new System.Drawing.Size(1163, 775);
            this.ctrlManageLocalDrivingLicense1.TabIndex = 0;
            // 
            // frmManageLDL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1163, 775);
            this.Controls.Add(this.ctrlManageLocalDrivingLicense1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmManageLDL";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manage Local Driving Licenses";
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.ctrlManageLDLA ctrlManageLocalDrivingLicense1;
    }
}