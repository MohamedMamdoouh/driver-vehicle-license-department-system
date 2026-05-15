namespace DVLD_Project.Applications.Local_Driving_License.Forms
{
    partial class frmLDLAAInfo
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
            this.ctrlLDLInfo1 = new DVLD_Project.Applications.Local_Driving_License.Controls.ctrlLDLAInfo();
            this.SuspendLayout();
            // 
            // ctrlLDLInfo1
            // 
            this.ctrlLDLInfo1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlLDLInfo1.LocalLicenseApplicationID = 0;
            this.ctrlLDLInfo1.Location = new System.Drawing.Point(0, 0);
            this.ctrlLDLInfo1.Name = "ctrlLDLInfo1";
            this.ctrlLDLInfo1.Size = new System.Drawing.Size(1054, 648);
            this.ctrlLDLInfo1.TabIndex = 1;
            // 
            // frmLDLAAInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1054, 648);
            this.Controls.Add(this.ctrlLDLInfo1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmLDLAAInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Local Driving License Application";
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.ctrlLDLAInfo ctrlLDLInfo1;
    }
}