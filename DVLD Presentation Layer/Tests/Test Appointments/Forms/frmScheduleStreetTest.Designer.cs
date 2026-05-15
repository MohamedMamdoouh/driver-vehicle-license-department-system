namespace DVLD_Project.Tests.Test_Appointments.Forms
{
    partial class frmScheduleStreetTest
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
            this.ctrlScheduleTest1 = new DVLD_Project.Tests.Test_Appointments.Controls.ctrlScheduleTest();
            this.SuspendLayout();
            // 
            // ctrlScheduleTest1
            // 
            this.ctrlScheduleTest1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlScheduleTest1.LDLA_ID = 0;
            this.ctrlScheduleTest1.Location = new System.Drawing.Point(0, 0);
            this.ctrlScheduleTest1.Name = "ctrlScheduleTest1";
            this.ctrlScheduleTest1.Size = new System.Drawing.Size(759, 869);
            this.ctrlScheduleTest1.TabIndex = 1;
            this.ctrlScheduleTest1.TestAppointmentID = 0;
            // 
            // frmScheduleStreetTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(759, 869);
            this.Controls.Add(this.ctrlScheduleTest1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmScheduleStreetTest";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Schedule Street Test";
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.ctrlScheduleTest ctrlScheduleTest1;
    }
}