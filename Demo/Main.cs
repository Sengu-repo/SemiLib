using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Semi;

namespace Demo
{
    public partial class Main : Form
    {

        SemiManager _semiManager;

        public Main()
        {
            InitializeComponent();

            _semiManager = new SemiManager();

            _semiManager.ErrorEventHandler += ManagerErrorEventReceived;

            _semiManager.ReceivedEventHandler += MangerTextReceivedEvent;

            _semiManager.SendEventHandler += ManagerSendEvent;

            _semiManager.StatusEventHandler += ManagerStatusEvent;

        }

        public void ManagerErrorEventReceived(object sender, ErrorEventArgs args)
        {
            MessageBox.Show("Message" + args.Message, "Code:" + args.Code.ToString());
        }

        public void MangerTextReceivedEvent(object sender, ReceivedEventArgs args)
        {
            txtCosoleLog.AppendText(string.Format("{0} - Received: {1}.{2}", DateTime.Now, args.Message, Environment.NewLine));
        }

        public void ManagerSendEvent(object sender, SendEventArgs args)
        {
            txtCosoleLog.AppendText(string.Format("{0} -> Send: {1}", DateTime.Now, args.Message, Environment.NewLine));
        }

        public void ManagerStatusEvent(object sender, StatusEventArgs args)
        {
            updateConnectionStatus(args.Connected);
        }

        void updateConnectionStatus(bool value)
        {
            if (value)
            {
                this.statusConnected.Text = "Server Connect";
                this.statusConnected.ForeColor = Color.White;
                this.statusConnected.BackColor = Color.LimeGreen;
            }
            else
            {
                this.statusConnected.Text = "Server Disconnnect";
                this.statusConnected.ForeColor = Color.White;
                this.statusConnected.BackColor = Color.Red;
            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            this.connect();
        }

        bool connect()
        {
            try
            {
                string ip = txtIPAddress.Text;
                int port = Convert.ToInt32(txtPort.Text);

                if (_semiManager != null)
                {
                    _semiManager.Setup(ip, port);

                    _semiManager.Connect();
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

                return false;
            }
        }

        private void btnStandby_Click(object sender, EventArgs e)
        {
            if (_semiManager.Connected)
            {

                


               // _semiManager.SendAsyn(message, true);
            }

        }

        private void tabStatuChangeReport_Click(object sender, EventArgs e)
        {
            
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            // Process

        }

        private void btnProduction_Click(object sender, EventArgs e)
        {
            // Production

        }

        private void btnFaultClear_Click(object sender, EventArgs e)
        {
            // Fault Message Clear

        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            // Send Message to Server

            send();

        }

        void send()
        {
            if (string.IsNullOrEmpty(txtSendMsg.Text)) return;

            if (_semiManager.Connected)
            {
                string message = txtSendMsg.Text.ToString();

                _semiManager.SendAsyn(message,false);
            }

        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_semiManager != null)
            {
                if (_semiManager.Connected)
                {
                    _semiManager.Disconnect();
                }
            }
        }

        private void btnInit_Click(object sender, EventArgs e)
        {
            if (_semiManager != null)
            {
                if (_semiManager.Connected)
                {
                    Semi.Report.StatuChangeReport report = new Semi.Report.StatuChangeReport();
                    report.EqpID = "AGS-AV100-01";
                    report.CtrlMode = "Init Pressed";
                    report.ProcMode = "System Resetting";

                    Semi.Model.Header header = new Semi.Model.Header();
                    header.MachineName = "AGS-AV100";
                    header.TransactionID = "100";
                    header.UserName = "Sengu";
                    header.MessageName = Semi.Report.REPORT_TYPE.EqpStatuChangeReport.ToString();
                    header.EventTime = DateTime.Now.ToString();

                    _semiManager.SendReport(Semi.Report.REPORT_TYPE.EqpStatuChangeReport, report, header, report.EqpID);
                }
            }
        }
    }
}
