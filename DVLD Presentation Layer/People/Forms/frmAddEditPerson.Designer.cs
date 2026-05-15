namespace DVLD_Project.Forms
{
    partial class frmAddEditPerson
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
            this.ctrlAddEditPerson1 = new DVLD_Project.Controls.ctrlAddEditPerson();
            this.SuspendLayout();
            // 
            // ctrlAddEditPerson1
            // 
            this.ctrlAddEditPerson1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlAddEditPerson1.ID = 0;
            this.ctrlAddEditPerson1.Location = new System.Drawing.Point(0, 0);
            this.ctrlAddEditPerson1.Name = "ctrlAddEditPerson1";
            this.ctrlAddEditPerson1.Size = new System.Drawing.Size(1088, 860);
            this.ctrlAddEditPerson1.TabIndex = 0;
            // 
            // frmAddEditPerson
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1088, 860);
            this.Controls.Add(this.ctrlAddEditPerson1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmAddEditPerson";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add/Edit Person";
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.ctrlAddEditPerson ctrlAddEditPerson1;
    }
}