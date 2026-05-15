namespace DVLD_Project.Drivers.Forms
{
    partial class frmManageDrivers
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
            this.ctrlManageDrivers1 = new DVLD_Project.Drivers.Controls.ctrlListManageDrivers();
            this.SuspendLayout();
            // 
            // ctrlManageDrivers1
            // 
            this.ctrlManageDrivers1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlManageDrivers1.Location = new System.Drawing.Point(0, 0);
            this.ctrlManageDrivers1.Name = "ctrlManageDrivers1";
            this.ctrlManageDrivers1.Size = new System.Drawing.Size(976, 856);
            this.ctrlManageDrivers1.TabIndex = 0;
            // 
            // frmManageDrivers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(976, 856);
            this.Controls.Add(this.ctrlManageDrivers1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmManageDrivers";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manage Drivers";
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.ctrlListManageDrivers ctrlManageDrivers1;
    }
}