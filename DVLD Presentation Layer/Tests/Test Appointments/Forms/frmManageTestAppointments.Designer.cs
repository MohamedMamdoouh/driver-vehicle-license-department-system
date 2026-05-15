namespace DVLD_Project.Tests.Test_Appointments.Forms
{
    partial class frmManageTestAppointments
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
            this.ctrlManageTestAppointments1 = new DVLD_Project.Tests.Test_Appointments.Controls.ctrlManageTestAppointments();
            this.SuspendLayout();
            // 
            // ctrlManageTestAppointments1
            // 
            this.ctrlManageTestAppointments1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlManageTestAppointments1.LDLA_ID = 0;
            this.ctrlManageTestAppointments1.Location = new System.Drawing.Point(0, 0);
            this.ctrlManageTestAppointments1.Name = "ctrlManageTestAppointments1";
            this.ctrlManageTestAppointments1.Size = new System.Drawing.Size(1058, 878);
            this.ctrlManageTestAppointments1.TabIndex = 0;
            // 
            // frmManageTestAppointments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1058, 878);
            this.Controls.Add(this.ctrlManageTestAppointments1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmManageTestAppointments";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manage Test Appointments";
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.ctrlManageTestAppointments ctrlManageTestAppointments1;
    }
}