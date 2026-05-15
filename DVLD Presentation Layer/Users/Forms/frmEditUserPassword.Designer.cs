namespace DVLD_Project.Users.Forms
{
    partial class frmEditUserPassword
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
            this.ctrlEditUser1 = new DVLD_Project.Users.Controls.ctrlEditUserPassword();
            this.SuspendLayout();
            // 
            // ctrlEditUser1
            // 
            this.ctrlEditUser1.Location = new System.Drawing.Point(0, 0);
            this.ctrlEditUser1.Name = "ctrlEditUser1";
            this.ctrlEditUser1.Size = new System.Drawing.Size(891, 1068);
            this.ctrlEditUser1.TabIndex = 0;
            this.ctrlEditUser1.UserID = 0;
            // 
            // frmEditUserPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(930, 1015);
            this.Controls.Add(this.ctrlEditUser1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmEditUserPassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Change User Password";
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.ctrlEditUserPassword ctrlEditUser1;
    }
}