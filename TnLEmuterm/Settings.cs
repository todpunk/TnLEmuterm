using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TnLEmuterm
{
    public partial class Settings : Form
    {
        private System.IO.Ports.SerialPort serialPort;

        public Settings(System.IO.Ports.SerialPort serialPort)
        {
            InitializeComponent();
            this.serialPort = serialPort;

            portName.Text = this.serialPort.PortName;
            baudRate.Text = this.serialPort.BaudRate.ToString();
            dataBits.SelectedItem = this.serialPort.DataBits.ToString();

            StopBits[] x = (StopBits[])(System.Enum.GetValues(typeof(StopBits)));
            // start at 1 to skip None if that's needed
            for (int i = 1; i < x.Length; i = i + 2)
            {
                this.stopBits.Items.Add(x[i].ToString());
            }
            this.stopBits.SelectedItem = this.serialPort.StopBits.ToString();

            Parity[] y = (Parity[])(System.Enum.GetValues(typeof(Parity)));
            for (int i = 0; i < y.Length; i++)
            {
                this.parity.Items.Add(y[i].ToString());
            }
            this.parity.SelectedItem = this.serialPort.Parity.ToString();

        }

        private void AcceptButton_Click(object sender, EventArgs e)
        {
            int temp;
            // Validate first before assignment
            try
            {
                int.TryParse(baudRate.Text, out temp);
            }
            catch (ArgumentException)
            {
                MessageBox.Show("BaudRate is not a valid number.");
                return;
            }


            serialPort.PortName = portName.Text;
            serialPort.BaudRate = temp;
            serialPort.DataBits = int.Parse(dataBits.Text);
            Enum.Parse(typeof(StopBits), stopBits.Text);
            Enum.Parse(typeof(Parity), parity.Text);

            this.Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
