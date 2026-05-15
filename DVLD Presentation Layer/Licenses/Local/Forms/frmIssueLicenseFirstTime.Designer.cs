namespace DVLD_Project.Licenses.Forms
{
    partial class frmIssueLicense
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
            this.ctrlIssueLicenseFirstTime1 = new DVLD_Project.Applications.Licenses.ctrlIssueLicenseFirstTime();
            this.SuspendLayout();
            // 
            // ctrlIssueLicenseFirstTime1
            // 
            this.ctrlIssueLicenseFirstTime1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlIssueLicenseFirstTime1.Location = new System.Drawing.Point(0, 0);
            this.ctrlIssueLicenseFirstTime1.Name = "ctrlIssueLicenseFirstTime1";
            this.ctrlIssueLicenseFirstTime1.Size = new System.Drawing.Size(1054, 828);
            this.ctrlIssueLicenseFirstTime1.TabIndex = 0;
            // 
            // frmIssueLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1054, 828);
            this.Controls.Add(this.ctrlIssueLicenseFirstTime1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmIssueLicense";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Issue Driver License For The First Time";
            this.ResumeLayout(false);

        }

        #endregion

        private Applications.Licenses.ctrlIssueLicenseFirstTime ctrlIssueLicenseFirstTime1;
    }
}