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
            this.HostListBox = new System.Windows.Forms.ListBox();
            this.ScanButton = new System.Windows.Forms.Button();
            this.SubnetTextBox = new System.Windows.Forms.TextBox();
            this.StopButton = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.ResumeButton = new System.Windows.Forms.Button();
            this.ClearButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // HostListBox
            // 
            this.HostListBox.FormattingEnabled = true;
            this.HostListBox.Location = new System.Drawing.Point(13, 55);
            this.HostListBox.Name = "HostListBox";
            this.HostListBox.Size = new System.Drawing.Size(348, 160);
            this.HostListBox.TabIndex = 0;
            // 
            // ScanButton
            // 
            this.ScanButton.Location = new System.Drawing.Point(118, 13);
            this.ScanButton.Name = "ScanButton";
            this.ScanButton.Size = new System.Drawing.Size(75, 23);
            this.ScanButton.TabIndex = 1;
            this.ScanButton.Text = "Scan";
            this.ScanButton.UseVisualStyleBackColor = true;
            this.ScanButton.Click += new System.EventHandler(this.ScanButton_Click);
            // 
            // SubnetTextBox
            // 
            this.SubnetTextBox.Location = new System.Drawing.Point(12, 15);
            this.SubnetTextBox.Name = "SubnetTextBox";
            this.SubnetTextBox.Size = new System.Drawing.Size(100, 20);
            this.SubnetTextBox.TabIndex = 2;
            // 
            // StopButton
            // 
            this.StopButton.Location = new System.Drawing.Point(199, 12);
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(75, 23);
            this.StopButton.TabIndex = 3;
            this.StopButton.Text = "Pause";
            this.StopButton.UseVisualStyleBackColor = true;
            this.StopButton.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(13, 221);
            this.progressBar1.Maximum = 254;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(348, 38);
            this.progressBar1.TabIndex = 4;
            // 
            // ResumeButton
            // 
            this.ResumeButton.Location = new System.Drawing.Point(118, 12);
            this.ResumeButton.Name = "ResumeButton";
            this.ResumeButton.Size = new System.Drawing.Size(75, 23);
            this.ResumeButton.TabIndex = 5;
            this.ResumeButton.Text = "Resume";
            this.ResumeButton.UseVisualStyleBackColor = true;
            this.ResumeButton.Click += new System.EventHandler(this.ResumeButton_Click);
            // 
            // ClearButton
            // 
            this.ClearButton.Location = new System.Drawing.Point(199, 13);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(75, 23);
            this.ClearButton.TabIndex = 6;
            this.ClearButton.Text = "Clear";
            this.ClearButton.UseVisualStyleBackColor = true;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(286, 15);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(373, 271);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ClearButton);
            this.Controls.Add(this.ResumeButton);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.StopButton);
            this.Controls.Add(this.SubnetTextBox);
            this.Controls.Add(this.ScanButton);
            this.Controls.Add(this.HostListBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox HostListBox;
        private System.Windows.Forms.Button ScanButton;
        private System.Windows.Forms.TextBox SubnetTextBox;
        private System.Windows.Forms.Button StopButton;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button ResumeButton;
        private System.Windows.Forms.Button ClearButton;
        private System.Windows.Forms.Button button1;
    }
}

