namespace DVLD_Project.Licenses.Detained_Licenses.Forms
{
    partial class frmDetainLicense
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
            this.ctrlDetainLicense1 = new DVLD_Project.Detained_Licenses.Controls.ctrlDetainLicense();
            this.SuspendLayout();
            // 
            // ctrlDetainLicense1
            // 
            this.ctrlDetainLicense1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlDetainLicense1.Location = new System.Drawing.Point(0, 0);
            this.ctrlDetainLicense1.Name = "ctrlDetainLicense1";
            this.ctrlDetainLicense1.Size = new System.Drawing.Size(1030, 1045);
            this.ctrlDetainLicense1.TabIndex = 0;
            // 
            // frmDetainLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1030, 1045);
            this.Controls.Add(this.ctrlDetainLicense1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmDetainLicense";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Detain License";
            this.ResumeLayout(false);

        }

        #endregion

        private DVLD_Project.Detained_Licenses.Controls.ctrlDetainLicense ctrlDetainLicense1;
    }
}