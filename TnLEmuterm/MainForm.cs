using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TnLEmuterm
{
    public partial class MainForm : Form
    {

        public MainForm()
        {
            InitializeComponent();

            Config.serialPort.BaudRate = 38400;
            Config.serialPort.DataBits = 8;
            Config.serialPort.StopBits = System.IO.Ports.StopBits.One;
            Config.serialPort.Parity = System.IO.Ports.Parity.None;
            Config.serialPort.Handshake = System.IO.Ports.Handshake.XOnXOff;

            Config.ClearEditor = false;
            Config.ShiftEnterSends = true;

            Config.serialPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort_DataReceived);

            updateStatus();
        }

        private void updateStatus()
        {
            toolStripStatusLabel1.Text = "Device: " + Config.serialPort.PortName;
            toolStripStatusLabel1.Text += "  Status: " + (Config.serialPort.IsOpen ? "Open" : "Closed");
            toolStripStatusLabel1.Text += "  Baud Rate: " + Config.serialPort.BaudRate.ToString();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void sendText()
        {
            if (!Config.serialPort.IsOpen) return;
            Config.serialPort.Write(textSender.Text);
            if (Config.ClearEditor)
            {
                textSender.Text = "";
                textSender.Text.Trim();
            }
        }

        private void sendFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Config.serialPort.IsOpen)
            {
                MessageBox.Show("Serial Port not Open, can not send file!");
                return;
            }
            Stream file = null;


            OpenFileDialog daDialog = new OpenFileDialog();
            daDialog.Multiselect = false;
            daDialog.CheckFileExists = true;
            daDialog.ShowDialog();
            try
            {
                file = daDialog.OpenFile();
                byte[] buf = new byte[512];
                int position = 0;
                int bytesRead = 0;
                while (position < file.Length)
                {
                    bytesRead = file.Read(buf, position, 512);
                    Config.serialPort.Write(buf, 0, bytesRead);
                    position += bytesRead;
                }
            }
            catch (Exception a)
            {
                MessageBox.Show("File can not be read.  Error:\r\n" + a.Message);
                return;
            }
            finally
            {
                if (file != null)
                {
                    file.Close();
                }
            }
        }

        private void saveSessionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stream file = null;

            SaveFileDialog daDialog = new SaveFileDialog();
            daDialog.OverwritePrompt = true;
            daDialog.ShowDialog();

            try
            {
                file = daDialog.OpenFile();
                byte[] bytes = new byte[textTerminal.TextLength * sizeof(char)];
                System.Buffer.BlockCopy(textTerminal.Text.ToCharArray(), 0, bytes, 0, bytes.Length);
                file.Write(bytes, 0, textTerminal.TextLength); 
            }
            catch (Exception a)
            {
                MessageBox.Show("File can not be read.  Error:\r\n" + a.Message);
                return;
            }
            finally
            {
                if (file != null)
                {
                    file.Close();
                }
            }
           

            return;
        }

        private void connectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Config.serialPort.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Can't open SerialPort.  Error: " + ex.Message);
            }

            if (Config.serialPort.IsOpen)
            {
                connectToolStripMenuItem.Enabled = false;
                disconnectToolStripMenuItem.Enabled = true;
            }
            updateStatus();
        }

        private void disconnectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Config.serialPort.IsOpen)
            {
                connectToolStripMenuItem.Enabled = true;
                disconnectToolStripMenuItem.Enabled = false;
            }
            Config.serialPort.Close();
            updateStatus();
       }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new SettingsForm().ShowDialog();
            updateStatus();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.MessageBox.Show("TnLEmuterm\nCopyright 2013 Tod Hansmann\nwww.todandlorna.com");
        }

        private void sendJToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sendText();
        }

        private void serialPort_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            Config.RecievedText = Config.serialPort.ReadExisting();
            this.Invoke(new EventHandler(DisplayText));
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Config.serialPort.IsOpen) Config.serialPort.Close();
        }

        private void DisplayText(object sender, EventArgs e)
        {
            textTerminal.AppendText(Config.RecievedText);
        }

        private void textSender_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (Config.ShiftEnterSends && e.Shift && e.KeyCode == Keys.Return)
            {
                sendText();
            }
            else if (e.Control && e.KeyCode == Keys.A)
            {
                textSender.SelectAll();
            }
        }
    }
}
