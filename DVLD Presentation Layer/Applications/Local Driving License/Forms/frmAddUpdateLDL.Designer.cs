namespace DVLD_Project.Applications.Local_Driving_License.Forms
{
    partial class frmAddUpdateLDLA
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
            this.ctrlAddUpdateLDL1 = new DVLD_Project.Applications.Local_Driving_License.Controls.ctrlAddUpdateLDLA();
            this.SuspendLayout();
            // 
            // ctrlAddUpdateLDL1
            // 
            this.ctrlAddUpdateLDL1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlAddUpdateLDL1.LDLA_ID = 0;
            this.ctrlAddUpdateLDL1.Location = new System.Drawing.Point(0, 0);
            this.ctrlAddUpdateLDL1.Name = "ctrlAddUpdateLDL1";
            this.ctrlAddUpdateLDL1.Size = new System.Drawing.Size(894, 1012);
            this.ctrlAddUpdateLDL1.TabIndex = 0;
            // 
            // frmAddUpdateLDL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(894, 1012);
            this.Controls.Add(this.ctrlAddUpdateLDL1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmAddUpdateLDL";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add/Update Local Driving License";
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.ctrlAddUpdateLDLA ctrlAddUpdateLDL1;
    }
}