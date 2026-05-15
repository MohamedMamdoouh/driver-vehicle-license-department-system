namespace DVLD_Project.Tests.Test_Appointments.Forms
{
    partial class frmTestAppointmentDetails
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
            this.ctrlTestAppointmentDetails1 = new DVLD_Project.Tests.Test_Appointments.Controls.ctrlTestAppointmentDetails();
            this.SuspendLayout();
            // 
            // ctrlTestAppointmentDetails1
            // 
            this.ctrlTestAppointmentDetails1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlTestAppointmentDetails1.Location = new System.Drawing.Point(0, 0);
            this.ctrlTestAppointmentDetails1.Name = "ctrlTestAppointmentDetails1";
            this.ctrlTestAppointmentDetails1.Size = new System.Drawing.Size(766, 791);
            this.ctrlTestAppointmentDetails1.TabIndex = 0;
            // 
            // frmTestAppointmentDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(766, 791);
            this.Controls.Add(this.ctrlTestAppointmentDetails1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmTestAppointmentDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Test Appointment Details";
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.ctrlTestAppointmentDetails ctrlTestAppointmentDetails1;
    }
}