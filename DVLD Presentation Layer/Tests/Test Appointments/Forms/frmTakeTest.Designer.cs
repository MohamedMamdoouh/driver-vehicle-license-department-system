namespace DVLD_Project.Tests.Test_Appointments.Forms
{
    partial class frmTakeTest
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
            this.ctrlTakeTest1 = new DVLD_Project.Tests.Test_Appointments.Controls.ctrlTakeTest();
            this.SuspendLayout();
            // 
            // ctrlTakeTest1
            // 
            this.ctrlTakeTest1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlTakeTest1.Location = new System.Drawing.Point(0, 0);
            this.ctrlTakeTest1.Name = "ctrlTakeTest1";
            this.ctrlTakeTest1.Size = new System.Drawing.Size(762, 822);
            this.ctrlTakeTest1.TabIndex = 0;
            this.ctrlTakeTest1.TestAppointmentID = 0;
            // 
            // frmTakeTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(762, 822);
            this.Controls.Add(this.ctrlTakeTest1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmTakeTest";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Take Test";
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.ctrlTakeTest ctrlTakeTest1;
    }
}