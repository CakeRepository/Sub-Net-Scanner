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
        NetworkManagement nm = new NetworkManagement();
        Thread myThread = null;
        Worker wkr = new Worker();
        public Form1()
        {
            InitializeComponent();

        }
        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
        }
        private void defaultstate(bool state)
        {
            exportButton.Invoke((MethodInvoker)(() => exportButton.Visible = true));
            exportButton.Invoke((MethodInvoker)(() => exportButton.Enabled = true));
            progressLBL.Invoke((MethodInvoker)(() => progressLBL.Visible = false));
            progressLBL.Invoke((MethodInvoker)(() => progressLBL.Text = ""));
            progressLBL.Invoke((MethodInvoker)(() => progressLBL.Visible = state));
            ScanButton.Invoke((MethodInvoker)(() => ScanButton.Enabled = true));
            ScanButton.Invoke((MethodInvoker)(() => ScanButton.Visible = true));
            StopButton.Invoke((MethodInvoker)(() => StopButton.Enabled = false));
            StopButton.Invoke((MethodInvoker)(() => StopButton.Visible = false));
            
        }
        private void runningstate()
        {
            progressLBL.Invoke((MethodInvoker)(() => progressLBL.Visible = true));
            ScanButton.Invoke((MethodInvoker)(() => ScanButton.Enabled = false));
            ScanButton.Invoke((MethodInvoker)(() => ScanButton.Visible = true));
            StopButton.Invoke((MethodInvoker)(() => StopButton.Enabled = true));
            StopButton.Invoke((MethodInvoker)(() => StopButton.Visible = true));
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
                    reply = myPing.Send(subnet + subnetN, 500);
                }
                catch
                {
                    defaultstate(false);
                    break;
                }
                progressBar1.Invoke((MethodInvoker)(() => progressBar1.Increment(1)));
                progressLBL.Invoke((MethodInvoker)(() => progressLBL.Text = i + "/254"));
                
                
                if (reply.Status == IPStatus.Success)
                {
                    string hosty;
                    try
                    {
                        
                        addr = IPAddress.Parse(subnet + subnetN);
                        try
                        {
                            host = Dns.GetHostEntry(addr);
                            hosty = host.HostName;
                        }
                        catch
                        {
                            hosty = " ";
                        }
                        macAddress = wkr.findMacAddress(addr.ToString());
                        this.dataGridView1.Invoke((MethodInvoker)(() => this.dataGridView1.Rows.Add(subnet + subnetN, hosty, macAddress, "UP")));
                        //this.dataGridView1.Rows.Add(subnet + subnetN, hosty, macAddress, "UP");
                    }
                    catch {}
                }
                else
                {
                    string hosty = " ";
                    addr = IPAddress.Parse(subnet + subnetN);
                    macAddress = wkr.findMacAddress(addr.ToString());
                    Console.WriteLine(macAddress);
                    if (macAddress == " ")
                    {

                    }
                    else
                        this.dataGridView1.Invoke((MethodInvoker)(() => this.dataGridView1.Rows.Add(subnet + subnetN, hosty, macAddress, "UNK")));

                }

            }
            defaultstate(true);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            defaultstate(false);
            subnetComboBoxInit();
        }

        private void subnetComboBoxInit()
        {
            string ipv4e = nm.GetLocalIPv4(NetworkInterfaceType.Ethernet);
            int i = nm.FindLast(ipv4e);
            if (i != 155)
            {
                subnetComboBox.Text = ipv4e.Substring(0, i - 1);
            }
        }

        private void ScanButton_Click_2(object sender, EventArgs e)
        {
            string ipTMP = subnetComboBox.Text;
            dataGridView1.Rows.Clear();
            progressBar1.Value = 0;
            myThread = new Thread(() => scan(ipTMP));
            myThread.IsBackground = true;
            myThread.Start();
            runningstate();

        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            myThread.Abort();
            defaultstate(false);
            progressBar1.Value = 0;
            dataGridView1.Rows.Clear();
        }

        private void exportButton_Click_1(object sender, EventArgs e)
        {
            /// <summary> 
            /// Exports the datagridview values to Excel. 
            /// </summary> 

            // Creating a Excel object. 
            Microsoft.Office.Interop.Excel._Application excel = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel._Workbook workbook = excel.Workbooks.Add(Type.Missing);

            try
            {

                Microsoft.Office.Interop.Excel._Worksheet worksheet = workbook.ActiveSheet;

                worksheet.Name = "Host Subnet Scan";



                int cellRowIndex = 1;
                int cellColumnIndex = 1;
                for (var j = 0; j < dataGridView1.Columns.Count; j++)
                {

                    worksheet.Cells[cellRowIndex, cellColumnIndex] = dataGridView1.Columns[j].HeaderText;
                    cellColumnIndex++;
                }
                cellColumnIndex = 1;
                cellRowIndex++;
                //Loop through each row and read value from each column. 
                for (var i = 0; i < dataGridView1.RowCount; i++)
                {
                    for (var j = 0; j < dataGridView1.Columns.Count; j++)
                    {
                        
                            worksheet.Cells[cellRowIndex, cellColumnIndex] = dataGridView1.Rows[i].Cells[j].Value.ToString();
                        
                        cellColumnIndex++;
                    }
                    cellColumnIndex = 1;
                    cellRowIndex++;
                }

                //Getting the location and file name of the excel to save from user. 
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = @"Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                saveDialog.FilterIndex = 2;

                if (saveDialog.ShowDialog() != System.Windows.Forms.DialogResult.OK) return;
                workbook.SaveAs(saveDialog.FileName);
                MessageBox.Show(@"Export Successful");
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                excel.Quit();
                workbook = null;
                excel = null;
            }
        }
    }
}
