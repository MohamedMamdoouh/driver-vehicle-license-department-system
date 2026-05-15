namespace DVLD_Project.Applications.Renew_Local_Licesne.Forms
{
    partial class frmRenewLocalLicense
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
            this.ctrlRenewLocalLicense1 = new DVLD_Project.Applications.Renew_Local_Licesne.Controls.ctrlRenewLocalLicense();
            this.SuspendLayout();
            // 
            // ctrlRenewLocalLicense1
            // 
            this.ctrlRenewLocalLicense1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlRenewLocalLicense1.Location = new System.Drawing.Point(0, 0);
            this.ctrlRenewLocalLicense1.Name = "ctrlRenewLocalLicense1";
            this.ctrlRenewLocalLicense1.Size = new System.Drawing.Size(1022, 1056);
            this.ctrlRenewLocalLicense1.TabIndex = 0;
            // 
            // frmRenewLocalLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1022, 1056);
            this.Controls.Add(this.ctrlRenewLocalLicense1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmRenewLocalLicense";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Renew Local License";
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.ctrlRenewLocalLicense ctrlRenewLocalLicense1;
    }
}