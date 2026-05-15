namespace DVLD_Project.Applications_Types.Forms
{
    partial class frmEditApplicationTypes
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
            this.ctrlUpdateApplicationsTypes1 = new DVLD_Project.Applications_Types.Controls.ctrlUpdateApplicationsTypes();
            this.SuspendLayout();
            // 
            // ctrlUpdateApplicationsTypes1
            // 
            this.ctrlUpdateApplicationsTypes1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlUpdateApplicationsTypes1.Location = new System.Drawing.Point(0, 0);
            this.ctrlUpdateApplicationsTypes1.Name = "ctrlUpdateApplicationsTypes1";
            this.ctrlUpdateApplicationsTypes1.Size = new System.Drawing.Size(659, 346);
            this.ctrlUpdateApplicationsTypes1.TabIndex = 0;
            // 
            // frmEditApplicationTypes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(659, 346);
            this.Controls.Add(this.ctrlUpdateApplicationsTypes1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmEditApplicationTypes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Update Application Types";
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.ctrlUpdateApplicationsTypes ctrlUpdateApplicationsTypes1;
    }
}