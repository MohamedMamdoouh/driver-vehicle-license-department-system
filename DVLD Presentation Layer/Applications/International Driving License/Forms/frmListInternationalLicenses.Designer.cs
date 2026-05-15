namespace DVLD_Project.Applications.International_Driving_License.Forms
{
    partial class frmListInternationalLicenses
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
            this.ctrlListIntenationalLicesneApplications1 = new DVLD_Project.Applications.International_Driving_License.Controls.ctrlListIntenationalLicesneApplications();
            this.SuspendLayout();
            // 
            // ctrlListIntenationalLicesneApplications1
            // 
            this.ctrlListIntenationalLicesneApplications1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlListIntenationalLicesneApplications1.Location = new System.Drawing.Point(0, 0);
            this.ctrlListIntenationalLicesneApplications1.Name = "ctrlListIntenationalLicesneApplications1";
            this.ctrlListIntenationalLicesneApplications1.Size = new System.Drawing.Size(980, 858);
            this.ctrlListIntenationalLicesneApplications1.TabIndex = 0;
            // 
            // frmListInternationalLicenses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(980, 858);
            this.Controls.Add(this.ctrlListIntenationalLicesneApplications1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmListInternationalLicenses";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "List International Licenses";
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.ctrlListIntenationalLicesneApplications ctrlListIntenationalLicesneApplications1;
    }
}