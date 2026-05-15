namespace DVLD_Project.Users.Forms
{
    partial class frmAddEditUser
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
            this.ctrlAddEditUser1 = new DVLD_Project.Users.Controls.ctrlAddEditUser();
            this.SuspendLayout();
            // 
            // ctrlAddEditUser1
            // 
            this.ctrlAddEditUser1.BackColor = System.Drawing.SystemColors.Control;
            this.ctrlAddEditUser1.Location = new System.Drawing.Point(0, 0);
            this.ctrlAddEditUser1.Name = "ctrlAddEditUser1";
            this.ctrlAddEditUser1.Size = new System.Drawing.Size(855, 1002);
            this.ctrlAddEditUser1.TabIndex = 0;
            // 
            // frmAddEditUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(873, 979);
            this.Controls.Add(this.ctrlAddEditUser1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmAddEditUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Update User";
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.ctrlAddEditUser ctrlAddEditUser1;
    }
}