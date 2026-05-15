namespace DVLD_Project.Applications.Release_Detained_License.Forms
{
    partial class frmReleaseLicense
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
            this.ctrlReleaseDetainedLicense1 = new DVLD_Project.Applications.Release_Detained_License.Controls.ctrlReleaseDetainedLicense();
            this.SuspendLayout();
            // 
            // ctrlReleaseDetainedLicense1
            // 
            this.ctrlReleaseDetainedLicense1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlReleaseDetainedLicense1.Location = new System.Drawing.Point(0, 0);
            this.ctrlReleaseDetainedLicense1.Name = "ctrlReleaseDetainedLicense1";
            this.ctrlReleaseDetainedLicense1.Size = new System.Drawing.Size(1025, 929);
            this.ctrlReleaseDetainedLicense1.TabIndex = 0;
            // 
            // frmReleaseLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1025, 929);
            this.Controls.Add(this.ctrlReleaseDetainedLicense1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmReleaseLicense";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Release License";
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.ctrlReleaseDetainedLicense ctrlReleaseDetainedLicense1;
    }
}