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

        EAPManager _EAPManager;

        public Main()
        {
            InitializeComponent();

            _EAPManager = new EAPManager();

            _EAPManager.ErrorEventHandler += ManagerErrorEventReceived;

            _EAPManager.ReceivedEventHandler += MangerTextReceivedEvent;

        }

        public void ManagerErrorEventReceived(object sender, ErrorEventArgs args)
        {
            MessageBox.Show("Message" + args.Message, "Code:" + args.Code.ToString());
        }

        public void MangerTextReceivedEvent(object sender, ReceivedEventArgs args)
        {
            txtCosoleLog.AppendText(string.Format("{0} - Received: {1}.{2}", DateTime.Now, args.Message, Environment.NewLine));
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

                if (_EAPManager != null)
                {
                    _EAPManager.Setup(ip, port);

                    _EAPManager.Connect();
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

                return false;
            }
        }
    }
}
