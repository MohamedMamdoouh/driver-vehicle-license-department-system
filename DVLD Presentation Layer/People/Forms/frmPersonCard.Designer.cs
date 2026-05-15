namespace DVLD_Project.People.Forms
{
    partial class frmPersonCard
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
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.ctrlPersonDetails1 = new DVLD_Project.Forms.ctrlPersonDetails();
            this.SuspendLayout();
            // 
            // ctrlPersonDetails1
            // 
            this.ctrlPersonDetails1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlPersonDetails1.Location = new System.Drawing.Point(0, 0);
            this.ctrlPersonDetails1.Name = "ctrlPersonDetails1";
            this.ctrlPersonDetails1.NationalNo = null;
            this.ctrlPersonDetails1.PersonID = 0;
            this.ctrlPersonDetails1.ShowEditPersonInfo = true;
            this.ctrlPersonDetails1.ShowHeader = false;
            this.ctrlPersonDetails1.Size = new System.Drawing.Size(831, 752);
            this.ctrlPersonDetails1.TabIndex = 0;
            // 
            // frmPersonCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(831, 752);
            this.Controls.Add(this.ctrlPersonDetails1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmPersonCard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Person Card";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ColorDialog colorDialog1;
        private DVLD_Project.Forms.ctrlPersonDetails ctrlPersonDetails1;
    }
}