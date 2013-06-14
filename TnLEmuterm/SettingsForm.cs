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
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
            
            portName.Text = Config.serialPort.PortName;
            baudRate.Text = Config.serialPort.BaudRate.ToString();
            dataBits.SelectedItem = Config.serialPort.DataBits.ToString();

            StopBits[] x = (StopBits[])(System.Enum.GetValues(typeof(StopBits)));
            // start at 1 to skip None if that's needed
            for (int i = 1; i < x.Length; i = i + 2)
            {
                this.stopBits.Items.Add(x[i].ToString());
            }
            this.stopBits.SelectedItem = Config.serialPort.StopBits.ToString();

            Parity[] y = (Parity[])(System.Enum.GetValues(typeof(Parity)));
            for (int i = 0; i < y.Length; i++)
            {
                this.parity.Items.Add(y[i].ToString());
            }
            this.parity.SelectedItem = Config.serialPort.Parity.ToString();

            clearEditorChk.Checked = Config.ClearEditor;
            shiftEnterSendChk.Checked = Config.ShiftEnterSends;

            if (Config.serialPort.IsOpen)
            {
                portName.Enabled = false;
                baudRate.Enabled = false;
                dataBits.Enabled = false;
                stopBits.Enabled = false;
                parity.Enabled = false;
            }
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


            Config.serialPort.PortName = portName.Text;
            Config.serialPort.BaudRate = temp;
            Config.serialPort.DataBits = int.Parse(dataBits.Text);
            Config.serialPort.StopBits = (StopBits)Enum.Parse(typeof(StopBits), stopBits.Text);
            Config.serialPort.Parity = (Parity)Enum.Parse(typeof(Parity), parity.Text);

            Config.ClearEditor = clearEditorChk.Checked;
            Config.ShiftEnterSends = shiftEnterSendChk.Checked;

            this.Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
