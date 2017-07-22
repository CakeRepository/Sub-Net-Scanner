namespace Host_Subnet_Scan
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.bgWorker = new System.ComponentModel.BackgroundWorker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.progressLBL = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.StopButton = new System.Windows.Forms.Button();
            this.subnetComboBox = new System.Windows.Forms.TextBox();
            this.ScanButton = new System.Windows.Forms.Button();
            this.exportButton = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.addressIP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HostName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MacAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.progressBar1);
            this.panel1.Controls.Add(this.progressLBL);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 345);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(531, 52);
            this.panel1.TabIndex = 14;
            // 
            // progressBar1
            // 
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar1.Location = new System.Drawing.Point(0, 0);
            this.progressBar1.Maximum = 254;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(531, 52);
            this.progressBar1.TabIndex = 5;
            // 
            // progressLBL
            // 
            this.progressLBL.AutoSize = true;
            this.progressLBL.BackColor = System.Drawing.Color.Transparent;
            this.progressLBL.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.progressLBL.Location = new System.Drawing.Point(361, 20);
            this.progressLBL.Name = "progressLBL";
            this.progressLBL.Size = new System.Drawing.Size(35, 13);
            this.progressLBL.TabIndex = 10;
            this.progressLBL.Text = "label1";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.StopButton);
            this.panel2.Controls.Add(this.subnetComboBox);
            this.panel2.Controls.Add(this.ScanButton);
            this.panel2.Controls.Add(this.exportButton);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(184, 345);
            this.panel2.TabIndex = 15;
            // 
            // StopButton
            // 
            this.StopButton.AutoSize = true;
            this.StopButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.StopButton.Location = new System.Drawing.Point(0, 230);
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(184, 58);
            this.StopButton.TabIndex = 19;
            this.StopButton.Text = "Clear";
            this.StopButton.UseVisualStyleBackColor = true;
            this.StopButton.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // subnetComboBox
            // 
            this.subnetComboBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.subnetComboBox.Location = new System.Drawing.Point(0, 61);
            this.subnetComboBox.Multiline = true;
            this.subnetComboBox.Name = "subnetComboBox";
            this.subnetComboBox.Size = new System.Drawing.Size(184, 170);
            this.subnetComboBox.TabIndex = 18;
            // 
            // ScanButton
            // 
            this.ScanButton.AutoSize = true;
            this.ScanButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.ScanButton.Location = new System.Drawing.Point(0, 0);
            this.ScanButton.Name = "ScanButton";
            this.ScanButton.Size = new System.Drawing.Size(184, 61);
            this.ScanButton.TabIndex = 16;
            this.ScanButton.Text = "Scan";
            this.ScanButton.UseVisualStyleBackColor = true;
            this.ScanButton.Click += new System.EventHandler(this.ScanButton_Click_2);
            // 
            // exportButton
            // 
            this.exportButton.AutoSize = true;
            this.exportButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.exportButton.Location = new System.Drawing.Point(0, 288);
            this.exportButton.Name = "exportButton";
            this.exportButton.Size = new System.Drawing.Size(184, 57);
            this.exportButton.TabIndex = 13;
            this.exportButton.Text = "Export";
            this.exportButton.UseVisualStyleBackColor = true;
            this.exportButton.Click += new System.EventHandler(this.exportButton_Click_1);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dataGridView1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(184, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(347, 345);
            this.panel3.TabIndex = 16;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.addressIP,
            this.HostName,
            this.MacAddress,
            this.Status});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(347, 345);
            this.dataGridView1.TabIndex = 11;
            // 
            // addressIP
            // 
            this.addressIP.FillWeight = 90F;
            this.addressIP.HeaderText = "IP Address";
            this.addressIP.Name = "addressIP";
            this.addressIP.ReadOnly = true;
            this.addressIP.Width = 90;
            // 
            // HostName
            // 
            this.HostName.HeaderText = "Hostname";
            this.HostName.Name = "HostName";
            this.HostName.ReadOnly = true;
            // 
            // MacAddress
            // 
            this.MacAddress.HeaderText = "MAC Address";
            this.MacAddress.Name = "MacAddress";
            this.MacAddress.ReadOnly = true;
            // 
            // Status
            // 
            this.Status.FillWeight = 50F;
            this.Status.HeaderText = "Status";
            this.Status.MaxInputLength = 2;
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            this.Status.Width = 50;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(531, 397);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Subnet Scan";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.ComponentModel.BackgroundWorker bgWorker;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label progressLBL;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button exportButton;
        private System.Windows.Forms.Button StopButton;
        private System.Windows.Forms.TextBox subnetComboBox;
        private System.Windows.Forms.Button ScanButton;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn addressIP;
        private System.Windows.Forms.DataGridViewTextBoxColumn HostName;
        private System.Windows.Forms.DataGridViewTextBoxColumn MacAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
    }
}

