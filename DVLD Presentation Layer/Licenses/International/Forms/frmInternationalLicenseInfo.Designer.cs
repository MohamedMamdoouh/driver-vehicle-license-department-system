namespace DVLD_Project.Licenses.Forms
{
    partial class frmInternationalLicenseInfo
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
            this.ctrlInternationalLicenseInfo1 = new DVLD_Project.Licenses.Controls.ctrlInternationalLicenseInfo();
            this.SuspendLayout();
            // 
            // ctrlInternationalLicenseInfo1
            // 
            this.ctrlInternationalLicenseInfo1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlInternationalLicenseInfo1.InternationalLicenseID = 0;
            this.ctrlInternationalLicenseInfo1.Location = new System.Drawing.Point(0, 0);
            this.ctrlInternationalLicenseInfo1.Name = "ctrlInternationalLicenseInfo1";
            this.ctrlInternationalLicenseInfo1.Size = new System.Drawing.Size(893, 884);
            this.ctrlInternationalLicenseInfo1.TabIndex = 0;
            // 
            // frmInternationalLicenseInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(893, 884);
            this.Controls.Add(this.ctrlInternationalLicenseInfo1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmInternationalLicenseInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "International License Info";
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.ctrlInternationalLicenseInfo ctrlInternationalLicenseInfo1;
    }
}