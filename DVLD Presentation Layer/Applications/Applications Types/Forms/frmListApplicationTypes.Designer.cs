namespace DVLD_Project.Applications_Types.Forms
{
    partial class frmListApplicationTypes
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
            this.ctrlManageApplicationsTypes1 = new DVLD_Project.Applications_Types.ctrlListApplicationTypes();
            this.SuspendLayout();
            // 
            // ctrlManageApplicationsTypes1
            // 
            this.ctrlManageApplicationsTypes1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlManageApplicationsTypes1.Location = new System.Drawing.Point(0, 0);
            this.ctrlManageApplicationsTypes1.Name = "ctrlManageApplicationsTypes1";
            this.ctrlManageApplicationsTypes1.Size = new System.Drawing.Size(939, 716);
            this.ctrlManageApplicationsTypes1.TabIndex = 0;
            // 
            // frmListApplicationTypes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(939, 716);
            this.Controls.Add(this.ctrlManageApplicationsTypes1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmListApplicationTypes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Applications Types";
            this.ResumeLayout(false);

        }

        #endregion

        private ctrlListApplicationTypes ctrlManageApplicationsTypes1;
    }
}