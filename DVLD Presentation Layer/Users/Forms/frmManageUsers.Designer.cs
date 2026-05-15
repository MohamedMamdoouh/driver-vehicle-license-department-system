namespace DVLD_Project.Users.Forms
{
    partial class frmManageUsers
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
            this.ctrlManageUsers1 = new DVLD_Project.Users.Controls.ctrlManageUsers();
            this.SuspendLayout();
            // 
            // ctrlManageUsers1
            // 
            this.ctrlManageUsers1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlManageUsers1.Location = new System.Drawing.Point(0, 0);
            this.ctrlManageUsers1.Name = "ctrlManageUsers1";
            this.ctrlManageUsers1.Size = new System.Drawing.Size(839, 913);
            this.ctrlManageUsers1.TabIndex = 0;
            // 
            // frmManageUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(839, 913);
            this.Controls.Add(this.ctrlManageUsers1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmManageUsers";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Manage Users";
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.ctrlManageUsers ctrlManageUsers1;
    }
}