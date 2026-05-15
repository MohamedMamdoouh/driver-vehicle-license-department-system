namespace DVLD_Project.Users.Forms
{
    partial class frmAddNewUser
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
            this.ctrlAddNewUser1 = new DVLD_Project.Users.Controls.ctrlAddEditUser();
            this.SuspendLayout();
            // 
            // ctrlAddNewUser1
            // 
            this.ctrlAddNewUser1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ctrlAddNewUser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlAddNewUser1.Location = new System.Drawing.Point(0, 0);
            this.ctrlAddNewUser1.Name = "ctrlAddNewUser1";
            this.ctrlAddNewUser1.Size = new System.Drawing.Size(859, 975);
            this.ctrlAddNewUser1.TabIndex = 0;
            // 
            // frmAddNewUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(859, 975);
            this.Controls.Add(this.ctrlAddNewUser1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmAddNewUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add New User";
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.ctrlAddEditUser ctrlAddNewUser1;
    }
}