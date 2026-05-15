namespace DVLD_Project.Users.Forms
{
    partial class frmLogin
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
            this.ctrlLogin1 = new DVLD_Project.Users.Controls.ctrlLogin();
            this.SuspendLayout();
            // 
            // ctrlLogin1
            // 
            this.ctrlLogin1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlLogin1.Location = new System.Drawing.Point(0, 0);
            this.ctrlLogin1.Name = "ctrlLogin1";
            this.ctrlLogin1.Size = new System.Drawing.Size(855, 521);
            this.ctrlLogin1.TabIndex = 0;
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(855, 521);
            this.Controls.Add(this.ctrlLogin1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login Form";
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.ctrlLogin ctrlLogin1;
    }
}