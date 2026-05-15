namespace DVLD_Project.Licenses.International.Forms
{
    partial class frmIssueInternationalLicense
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
            this.ctrlIssueInternationalLicense1 = new DVLD_Project.Licenses.International.Controls.ctrlIssueInternationalLicense();
            this.SuspendLayout();
            // 
            // ctrlIssueInternationalLicense1
            // 
            this.ctrlIssueInternationalLicense1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlIssueInternationalLicense1.Location = new System.Drawing.Point(0, 0);
            this.ctrlIssueInternationalLicense1.Name = "ctrlIssueInternationalLicense1";
            this.ctrlIssueInternationalLicense1.Size = new System.Drawing.Size(1022, 963);
            this.ctrlIssueInternationalLicense1.TabIndex = 0;
            // 
            // frmIssueInternationalLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1022, 963);
            this.Controls.Add(this.ctrlIssueInternationalLicense1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmIssueInternationalLicense";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Issue International License";
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.ctrlIssueInternationalLicense ctrlIssueInternationalLicense1;
    }
}