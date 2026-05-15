namespace DVLD_Project.Licenses.Detained_Licenses.Forms
{
    partial class frmListDetainedLicenses
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
            this.ctrlListDetainedLicenses1 = new DVLD_Project.Licenses.Detained_Licenses.Controls.ctrlListDetainedLicenses();
            this.SuspendLayout();
            // 
            // ctrlListDetainedLicenses1
            // 
            this.ctrlListDetainedLicenses1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlListDetainedLicenses1.Location = new System.Drawing.Point(0, 0);
            this.ctrlListDetainedLicenses1.Name = "ctrlListDetainedLicenses1";
            this.ctrlListDetainedLicenses1.Size = new System.Drawing.Size(1155, 810);
            this.ctrlListDetainedLicenses1.TabIndex = 0;
            // 
            // frmListDetainedLicenses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1155, 810);
            this.Controls.Add(this.ctrlListDetainedLicenses1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmListDetainedLicenses";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "List Detained Licenses";
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.ctrlListDetainedLicenses ctrlListDetainedLicenses1;
    }
}