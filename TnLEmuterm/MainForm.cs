using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TnLEmuterm
{
    public partial class MainForm : Form
    {
        public string RecievedText;

        public MainForm()
        {
            InitializeComponent();

            serialPort.PortName = "SETME";
            serialPort.BaudRate = 38400;
            serialPort.DataBits = 8;
            serialPort.StopBits = System.IO.Ports.StopBits.One;
            serialPort.Parity = System.IO.Ports.Parity.None;
            serialPort.Handshake = System.IO.Ports.Handshake.XOnXOff;

            statusStrip.Text = "Device: " + serialPort.PortName;
            statusStrip.Text += "  Status: " + (serialPort.IsOpen ? "Open" : "Closed");
            statusStrip.Text += "  Baud Rate: " + serialPort.BaudRate.ToString();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void sendFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.MessageBox.Show("Not implemented yet!  Sorry!");

        }

        private void saveSessionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.MessageBox.Show("Not implemented yet!  Sorry!");

        }

        private void connectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            serialPort.Open();
            if (serialPort.IsOpen)
            {
                connectToolStripMenuItem.Enabled = false;
                disconnectToolStripMenuItem.Enabled = true;
            }
        }

        private void disconnectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (serialPort.IsOpen)
            {
                connectToolStripMenuItem.Enabled = true;
                disconnectToolStripMenuItem.Enabled = false;
            }
            serialPort.Close();
       }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Settings(serialPort).Show();

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.MessageBox.Show("TnLEmuterm\nCopyright 2013 Tod Hansmann\nwww.todandlorna.com");
        }

        private void sendJToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!serialPort.IsOpen) return;

            serialPort.Write(textSender.Text);

            // textSender.Text = "";
        }

        private void serialPort_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            RecievedText = serialPort.ReadExisting();
            this.Invoke(new EventHandler(DisplayText));
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (serialPort.IsOpen) serialPort.Close();
        }

        private void DisplayText(object sender, EventArgs e)
        {
            textTerminal.AppendText(RecievedText);
        }
    }
}
