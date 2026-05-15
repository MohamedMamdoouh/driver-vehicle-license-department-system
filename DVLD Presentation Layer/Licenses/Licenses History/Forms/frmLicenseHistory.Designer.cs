namespace DVLD_Project.Licenses.Forms
{
    partial class frmLicenseHistory
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
            this.ctrlLicenseHistory1 = new DVLD_Project.Licenses.Controls.ctrlLicenseHistory();
            this.SuspendLayout();
            // 
            // ctrlLicenseHistory1
            // 
            this.ctrlLicenseHistory1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlLicenseHistory1.Location = new System.Drawing.Point(0, 0);
            this.ctrlLicenseHistory1.Name = "ctrlLicenseHistory1";
            this.ctrlLicenseHistory1.NationalNo = null;
            this.ctrlLicenseHistory1.Size = new System.Drawing.Size(924, 1041);
            this.ctrlLicenseHistory1.TabIndex = 0;
            // 
            // frmLicenseHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(924, 1041);
            this.Controls.Add(this.ctrlLicenseHistory1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmLicenseHistory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "License History";
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.ctrlLicenseHistory ctrlLicenseHistory1;
    }
}