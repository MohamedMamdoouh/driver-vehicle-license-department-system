namespace DVLD_Project.Applications.Test_Types.Forms
{
    partial class frmEditTestType
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
            this.ctrlEditTestType1 = new DVLD_Project.Applications.Test_Types.Controls.ctrlEditTestType();
            this.SuspendLayout();
            // 
            // ctrlEditTestType1
            // 
            this.ctrlEditTestType1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlEditTestType1.Location = new System.Drawing.Point(0, 0);
            this.ctrlEditTestType1.Name = "ctrlEditTestType1";
            this.ctrlEditTestType1.Size = new System.Drawing.Size(779, 515);
            this.ctrlEditTestType1.TabIndex = 0;
            // 
            // frmEditTestType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(779, 515);
            this.Controls.Add(this.ctrlEditTestType1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmEditTestType";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit Test Type";
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.ctrlEditTestType ctrlEditTestType1;
    }
}