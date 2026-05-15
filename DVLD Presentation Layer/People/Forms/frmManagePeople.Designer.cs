namespace DVLD
{
    partial class frmManagePeople
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
            this.components = new System.ComponentModel.Container();
            this.ctrlManagePeople1 = new DVLD.ctrlManagePeople();
            this.SuspendLayout();
            // 
            // ctrlManagePeople1
            // 
            this.ctrlManagePeople1.AutoSize = true;
            this.ctrlManagePeople1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ctrlManagePeople1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctrlManagePeople1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctrlManagePeople1.Location = new System.Drawing.Point(0, 0);
            this.ctrlManagePeople1.Margin = new System.Windows.Forms.Padding(5);
            this.ctrlManagePeople1.Name = "ctrlManagePeople1";
            this.ctrlManagePeople1.Padding = new System.Windows.Forms.Padding(1);
            this.ctrlManagePeople1.Size = new System.Drawing.Size(1235, 931);
            this.ctrlManagePeople1.TabIndex = 0;
            // 
            // frmManagePeople
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1235, 931);
            this.Controls.Add(this.ctrlManagePeople1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmManagePeople";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manage People";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ctrlManagePeople ctrlManagePeople1;
    }
}