namespace DVLD_Project.Applications.Test_Types.Forms
{
    partial class frmListTestTypes
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
            this.ctrlListTestTypes1 = new DVLD_Project.Applications.Test_Types.Controls.ctrlListTestTypes();
            this.SuspendLayout();
            // 
            // ctrlListTestTypes1
            // 
            this.ctrlListTestTypes1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlListTestTypes1.Location = new System.Drawing.Point(0, 0);
            this.ctrlListTestTypes1.Name = "ctrlListTestTypes1";
            this.ctrlListTestTypes1.Size = new System.Drawing.Size(1040, 763);
            this.ctrlListTestTypes1.TabIndex = 0;
            // 
            // frmListTestTypes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1040, 763);
            this.Controls.Add(this.ctrlListTestTypes1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmListTestTypes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "List Test Types";
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.ctrlListTestTypes ctrlListTestTypes1;
    }
}