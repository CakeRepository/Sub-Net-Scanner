using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Net.NetworkInformation;
using System.Net;

namespace Host_Subnet_Scan
{

    public partial class Form1 : Form
    {
        Thread myThread = null;
        Worker wkr = new Worker();
        public Form1()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;

        }
        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
        }
        private void defaultstate()
        {
            progressLBL.Visible = false;
            progressLBL.Text = "";
            ScanButton.Enabled = true;
            ScanButton.Visible = true;
            ResumeButton.Enabled = false;
            ResumeButton.Visible = false;
            StopButton.Enabled = false;
            StopButton.Visible = true;
            ClearButton.Enabled = false;
            ClearButton.Visible = false;
        }
        private void runningstate()
        {
            progressLBL.Visible = true;
            ScanButton.Enabled = false;
            ScanButton.Visible = false;
            ResumeButton.Enabled = false;
            ResumeButton.Visible = true;
            StopButton.Enabled = true;
            StopButton.Visible = true;
            ClearButton.Enabled = false;
            ClearButton.Visible = false;
        }
        public void scan(string subnet)
        {
            Ping myPing;
            PingReply reply;
            IPAddress addr;
            IPHostEntry host;
            string macAddress;
            
            for (int i= 1; i < 255; i++)
            {
                string subnetN = "." + i.ToString();
                myPing = new Ping();
                try
                {
                    reply = myPing.Send(subnet + subnetN, 900);
                }
                catch
                {
                    
                    defaultstate();
                    break;
                }
                progressBar1.Increment(1);
                progressLBL.Text = i + "/254";
                if (reply.Status == IPStatus.Success)
                {

                    try
                    {
                        
                        addr = IPAddress.Parse(subnet + subnetN);
                        host = Dns.GetHostEntry(addr);
                        macAddress = wkr.findMacAddress(addr.ToString());
                        this.dataGridView1.Rows.Add(subnet + subnetN, host.HostName, macAddress, "UP");
                        

                    }
                    catch { }
                }
             
            }
            defaultstate();
            progressLBL.Visible = true;
            
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            defaultstate();
        }

        private void ScanButton_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            progressBar1.Value = 0;
            myThread = new Thread(() => scan(SubnetTextBox.Text));
            myThread.IsBackground = true;
            myThread.Start();
            runningstate();
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            myThread.Suspend();
            ResumeButton.Enabled = true;
            StopButton.Visible = false;
            StopButton.Enabled = false;
            ClearButton.Visible = true;
            ClearButton.Enabled = true;
        }

        private void ResumeButton_Click(object sender, EventArgs e)
        {
            ScanButton.Visible = true;
            ScanButton.Enabled = true;
            myThread.Resume();
            runningstate();
        }
        
        private void ClearButton_Click(object sender, EventArgs e)
        {
            myThread.Resume();
            myThread.Abort();
            dataGridView1.Rows.Clear();
            progressBar1.Value = 0;
            defaultstate();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Worker wkr = new Worker();
            string result = wkr.findMacAddress("192.168.0.8");
        }
        struct DataParamater
        {
            public List<IPAddress> ProductList;
            public string Filename { get; set; }
                
        }
        DataParamater _inpupParameter;
        private void bgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            if (bgWorker.IsBusy)
                return;
            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Excel Workbook|*.xls" })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    _inpupParameter.Filename = sfd.FileName;
                    _inpupParameter.ProductList = productBindingSource.Datasource as
                }
            }
        }
    }
}
