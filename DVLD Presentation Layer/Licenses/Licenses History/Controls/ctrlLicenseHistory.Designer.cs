namespace DVLD_Project.Licenses.Controls
{
    partial class ctrlLicenseHistory
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ctrlLicenseHistory));
            this.label1 = new System.Windows.Forms.Label();
            this.tcLicenses = new System.Windows.Forms.TabControl();
            this.tpLocalLicenses = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.lblLocalLicensesHistory = new System.Windows.Forms.Label();
            this.dgvLocalLicensesInfo = new System.Windows.Forms.DataGridView();
            this.cmsLocalLicense = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.renewLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tpInternationalLicenses = new System.Windows.Forms.TabPage();
            this.dgvIternationalLicenseInfo = new System.Windows.Forms.DataGridView();
            this.cmsInternationalLicense = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showDetailsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.lblInternationlaLicensesRecords = new System.Windows.Forms.Label();
            this.gbLicenseHistory = new System.Windows.Forms.GroupBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.ctrlPersonDetails1 = new DVLD_Project.Forms.ctrlPersonDetails();
            this.tcLicenses.SuspendLayout();
            this.tpLocalLicenses.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocalLicensesInfo)).BeginInit();
            this.cmsLocalLicense.SuspendLayout();
            this.tpInternationalLicenses.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIternationalLicenseInfo)).BeginInit();
            this.cmsInternationalLicense.SuspendLayout();
            this.gbLicenseHistory.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkRed;
            this.label1.Location = new System.Drawing.Point(301, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(265, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "License History";
            // 
            // tcLicenses
            // 
            this.tcLicenses.Controls.Add(this.tpLocalLicenses);
            this.tcLicenses.Controls.Add(this.tpInternationalLicenses);
            this.tcLicenses.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcLicenses.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tcLicenses.Location = new System.Drawing.Point(3, 26);
            this.tcLicenses.Name = "tcLicenses";
            this.tcLicenses.SelectedIndex = 0;
            this.tcLicenses.Size = new System.Drawing.Size(879, 281);
            this.tcLicenses.TabIndex = 2;
            // 
            // tpLocalLicenses
            // 
            this.tpLocalLicenses.Controls.Add(this.label3);
            this.tpLocalLicenses.Controls.Add(this.lblLocalLicensesHistory);
            this.tpLocalLicenses.Controls.Add(this.dgvLocalLicensesInfo);
            this.tpLocalLicenses.Location = new System.Drawing.Point(4, 34);
            this.tpLocalLicenses.Name = "tpLocalLicenses";
            this.tpLocalLicenses.Padding = new System.Windows.Forms.Padding(3);
            this.tpLocalLicenses.Size = new System.Drawing.Size(871, 243);
            this.tpLocalLicenses.TabIndex = 1;
            this.tpLocalLicenses.Text = "Local Licenses";
            this.tpLocalLicenses.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 205);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 25);
            this.label3.TabIndex = 37;
            this.label3.Text = "#Records:";
            // 
            // lblLocalLicensesHistory
            // 
            this.lblLocalLicensesHistory.AutoSize = true;
            this.lblLocalLicensesHistory.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLocalLicensesHistory.Location = new System.Drawing.Point(122, 205);
            this.lblLocalLicensesHistory.Name = "lblLocalLicensesHistory";
            this.lblLocalLicensesHistory.Size = new System.Drawing.Size(36, 25);
            this.lblLocalLicensesHistory.TabIndex = 38;
            this.lblLocalLicensesHistory.Text = "??";
            // 
            // dgvLocalLicensesInfo
            // 
            this.dgvLocalLicensesInfo.AllowUserToAddRows = false;
            this.dgvLocalLicensesInfo.AllowUserToDeleteRows = false;
            this.dgvLocalLicensesInfo.AllowUserToOrderColumns = true;
            this.dgvLocalLicensesInfo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvLocalLicensesInfo.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvLocalLicensesInfo.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvLocalLicensesInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLocalLicensesInfo.ContextMenuStrip = this.cmsLocalLicense;
            this.dgvLocalLicensesInfo.GridColor = System.Drawing.SystemColors.Control;
            this.dgvLocalLicensesInfo.Location = new System.Drawing.Point(3, 3);
            this.dgvLocalLicensesInfo.Name = "dgvLocalLicensesInfo";
            this.dgvLocalLicensesInfo.ReadOnly = true;
            this.dgvLocalLicensesInfo.RowHeadersWidth = 62;
            this.dgvLocalLicensesInfo.RowTemplate.Height = 28;
            this.dgvLocalLicensesInfo.Size = new System.Drawing.Size(865, 188);
            this.dgvLocalLicensesInfo.TabIndex = 0;
            // 
            // cmsLocalLicense
            // 
            this.cmsLocalLicense.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.cmsLocalLicense.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showDetailsToolStripMenuItem,
            this.renewLicenseToolStripMenuItem});
            this.cmsLocalLicense.Name = "cmsLicense";
            this.cmsLocalLicense.Size = new System.Drawing.Size(280, 117);
            this.cmsLocalLicense.Opening += new System.ComponentModel.CancelEventHandler(this.cmsLocalLicense_Opening);
            // 
            // showDetailsToolStripMenuItem
            // 
            this.showDetailsToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.showDetailsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("showDetailsToolStripMenuItem.Image")));
            this.showDetailsToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.showDetailsToolStripMenuItem.Name = "showDetailsToolStripMenuItem";
            this.showDetailsToolStripMenuItem.Size = new System.Drawing.Size(279, 40);
            this.showDetailsToolStripMenuItem.Text = "Show License Details";
            this.showDetailsToolStripMenuItem.Click += new System.EventHandler(this.showDetailsToolStripMenuItem_Click);
            // 
            // renewLicenseToolStripMenuItem
            // 
            this.renewLicenseToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.renewLicenseToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("renewLicenseToolStripMenuItem.Image")));
            this.renewLicenseToolStripMenuItem.Name = "renewLicenseToolStripMenuItem";
            this.renewLicenseToolStripMenuItem.Size = new System.Drawing.Size(279, 40);
            this.renewLicenseToolStripMenuItem.Text = "Renew License";
            this.renewLicenseToolStripMenuItem.Click += new System.EventHandler(this.renewLicenseToolStripMenuItem_Click);
            // 
            // tpInternationalLicenses
            // 
            this.tpInternationalLicenses.Controls.Add(this.dgvIternationalLicenseInfo);
            this.tpInternationalLicenses.Controls.Add(this.label2);
            this.tpInternationalLicenses.Controls.Add(this.lblInternationlaLicensesRecords);
            this.tpInternationalLicenses.Location = new System.Drawing.Point(4, 34);
            this.tpInternationalLicenses.Name = "tpInternationalLicenses";
            this.tpInternationalLicenses.Padding = new System.Windows.Forms.Padding(3);
            this.tpInternationalLicenses.Size = new System.Drawing.Size(871, 243);
            this.tpInternationalLicenses.TabIndex = 2;
            this.tpInternationalLicenses.Text = "International Licenses";
            this.tpInternationalLicenses.UseVisualStyleBackColor = true;
            // 
            // dgvIternationalLicenseInfo
            // 
            this.dgvIternationalLicenseInfo.AllowUserToAddRows = false;
            this.dgvIternationalLicenseInfo.AllowUserToDeleteRows = false;
            this.dgvIternationalLicenseInfo.AllowUserToOrderColumns = true;
            this.dgvIternationalLicenseInfo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvIternationalLicenseInfo.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvIternationalLicenseInfo.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvIternationalLicenseInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIternationalLicenseInfo.ContextMenuStrip = this.cmsInternationalLicense;
            this.dgvIternationalLicenseInfo.GridColor = System.Drawing.SystemColors.Control;
            this.dgvIternationalLicenseInfo.Location = new System.Drawing.Point(3, 3);
            this.dgvIternationalLicenseInfo.Name = "dgvIternationalLicenseInfo";
            this.dgvIternationalLicenseInfo.ReadOnly = true;
            this.dgvIternationalLicenseInfo.RowHeadersWidth = 62;
            this.dgvIternationalLicenseInfo.RowTemplate.Height = 28;
            this.dgvIternationalLicenseInfo.Size = new System.Drawing.Size(865, 188);
            this.dgvIternationalLicenseInfo.TabIndex = 1;
            // 
            // cmsInternationalLicense
            // 
            this.cmsInternationalLicense.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.cmsInternationalLicense.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showDetailsToolStripMenuItem1});
            this.cmsInternationalLicense.Name = "cmsInternationalLicense";
            this.cmsInternationalLicense.Size = new System.Drawing.Size(280, 44);
            // 
            // showDetailsToolStripMenuItem1
            // 
            this.showDetailsToolStripMenuItem1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.showDetailsToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("showDetailsToolStripMenuItem1.Image")));
            this.showDetailsToolStripMenuItem1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.showDetailsToolStripMenuItem1.Name = "showDetailsToolStripMenuItem1";
            this.showDetailsToolStripMenuItem1.Size = new System.Drawing.Size(279, 40);
            this.showDetailsToolStripMenuItem1.Text = "Show License Details";
            this.showDetailsToolStripMenuItem1.Click += new System.EventHandler(this.showDetailsToolStripMenuItem1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 204);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 25);
            this.label2.TabIndex = 35;
            this.label2.Text = "#Records:";
            // 
            // lblInternationlaLicensesRecords
            // 
            this.lblInternationlaLicensesRecords.AutoSize = true;
            this.lblInternationlaLicensesRecords.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInternationlaLicensesRecords.Location = new System.Drawing.Point(122, 204);
            this.lblInternationlaLicensesRecords.Name = "lblInternationlaLicensesRecords";
            this.lblInternationlaLicensesRecords.Size = new System.Drawing.Size(36, 25);
            this.lblInternationlaLicensesRecords.TabIndex = 36;
            this.lblInternationlaLicensesRecords.Text = "??";
            // 
            // gbLicenseHistory
            // 
            this.gbLicenseHistory.Controls.Add(this.tcLicenses);
            this.gbLicenseHistory.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbLicenseHistory.Location = new System.Drawing.Point(9, 657);
            this.gbLicenseHistory.Name = "gbLicenseHistory";
            this.gbLicenseHistory.Size = new System.Drawing.Size(885, 310);
            this.gbLicenseHistory.TabIndex = 3;
            this.gbLicenseHistory.TabStop = false;
            this.gbLicenseHistory.Text = "License History";
            // 
            // btnClose
            // 
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(796, 973);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(95, 58);
            this.btnClose.TabIndex = 34;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ctrlPersonDetails1
            // 
            this.ctrlPersonDetails1.Location = new System.Drawing.Point(43, 0);
            this.ctrlPersonDetails1.Name = "ctrlPersonDetails1";
            this.ctrlPersonDetails1.NationalNo = null;
            this.ctrlPersonDetails1.PersonID = 0;
            this.ctrlPersonDetails1.ShowEditPersonInfo = true;
            this.ctrlPersonDetails1.ShowHeader = false;
            this.ctrlPersonDetails1.Size = new System.Drawing.Size(795, 651);
            this.ctrlPersonDetails1.TabIndex = 1;
            // 
            // ctrlLicenseHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.gbLicenseHistory);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ctrlPersonDetails1);
            this.Name = "ctrlLicenseHistory";
            this.Size = new System.Drawing.Size(912, 1044);
            this.Load += new System.EventHandler(this.ctrlLicenseHistory_Load);
            this.tcLicenses.ResumeLayout(false);
            this.tpLocalLicenses.ResumeLayout(false);
            this.tpLocalLicenses.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocalLicensesInfo)).EndInit();
            this.cmsLocalLicense.ResumeLayout(false);
            this.tpInternationalLicenses.ResumeLayout(false);
            this.tpInternationalLicenses.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIternationalLicenseInfo)).EndInit();
            this.cmsInternationalLicense.ResumeLayout(false);
            this.gbLicenseHistory.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private DVLD_Project.Forms.ctrlPersonDetails ctrlPersonDetails1;
        private System.Windows.Forms.TabControl tcLicenses;
        private System.Windows.Forms.TabPage tpLocalLicenses;
        private System.Windows.Forms.GroupBox gbLicenseHistory;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridView dgvLocalLicensesInfo;
        private System.Windows.Forms.TabPage tpInternationalLicenses;
        private System.Windows.Forms.DataGridView dgvIternationalLicenseInfo;
        private System.Windows.Forms.ContextMenuStrip cmsLocalLicense;
        private System.Windows.Forms.ToolStripMenuItem showDetailsToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip cmsInternationalLicense;
        private System.Windows.Forms.ToolStripMenuItem showDetailsToolStripMenuItem1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblInternationlaLicensesRecords;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblLocalLicensesHistory;
        private System.Windows.Forms.ToolStripMenuItem renewLicenseToolStripMenuItem;
    }
}
