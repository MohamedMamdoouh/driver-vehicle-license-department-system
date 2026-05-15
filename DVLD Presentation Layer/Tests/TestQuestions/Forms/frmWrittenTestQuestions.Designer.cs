namespace DVLD_Project.Tests.TestQuestions.Forms
{
    partial class frmWrittenTestQuestions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmWrittenTestQuestions));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ctrlTestQuestions1 = new DVLD_Project.Tests.TestQuestions.Controls.ctrlTestQuestions();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(509, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(192, 134);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkRed;
            this.label1.Location = new System.Drawing.Point(404, 162);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(383, 39);
            this.label1.TabIndex = 2;
            this.label1.Text = "Written Test Questions";
            // 
            // ctrlTestQuestions1
            // 
            this.ctrlTestQuestions1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ctrlTestQuestions1.Location = new System.Drawing.Point(0, 194);
            this.ctrlTestQuestions1.Name = "ctrlTestQuestions1";
            this.ctrlTestQuestions1.Size = new System.Drawing.Size(1221, 460);
            this.ctrlTestQuestions1.TabIndex = 0;
            this.ctrlTestQuestions1.TestAppointmentID = 0;
            this.ctrlTestQuestions1.TestTypeID = DVLD_Buisness_Layer.clsTestType.enTestType.Unknown;
            // 
            // frmWrittenTestQuestions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1221, 654);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.ctrlTestQuestions1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmWrittenTestQuestions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Written Test Questions";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmWrittenTestQuestions_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controls.ctrlTestQuestions ctrlTestQuestions1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
    }
}