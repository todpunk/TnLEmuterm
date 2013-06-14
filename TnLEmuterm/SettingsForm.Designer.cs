using System.IO.Ports;
namespace TnLEmuterm
{
    partial class SettingsForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.portName = new System.Windows.Forms.TextBox();
            this.baudRate = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dataBits = new System.Windows.Forms.ComboBox();
            this.stopBits = new System.Windows.Forms.ComboBox();
            this.parity = new System.Windows.Forms.ComboBox();
            this.acceptButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.clearEditorChk = new System.Windows.Forms.CheckBox();
            this.shiftEnterSendChk = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Port Name:";
            // 
            // portName
            // 
            this.portName.Location = new System.Drawing.Point(112, 6);
            this.portName.Name = "portName";
            this.portName.Size = new System.Drawing.Size(125, 20);
            this.portName.TabIndex = 1;
            // 
            // baudRate
            // 
            this.baudRate.Location = new System.Drawing.Point(112, 32);
            this.baudRate.Name = "baudRate";
            this.baudRate.Size = new System.Drawing.Size(125, 20);
            this.baudRate.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Baud Rate:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Data Bits:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Stop Bits:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 113);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Parity:";
            // 
            // dataBits
            // 
            this.dataBits.FormattingEnabled = true;
            this.dataBits.Items.AddRange(new object[] {
            "6",
            "7",
            "8",
            "9"});
            this.dataBits.Location = new System.Drawing.Point(112, 58);
            this.dataBits.Name = "dataBits";
            this.dataBits.Size = new System.Drawing.Size(125, 21);
            this.dataBits.TabIndex = 4;
            // 
            // stopBits
            // 
            this.stopBits.FormattingEnabled = true;
            this.stopBits.Location = new System.Drawing.Point(112, 84);
            this.stopBits.Name = "stopBits";
            this.stopBits.Size = new System.Drawing.Size(125, 21);
            this.stopBits.TabIndex = 4;
            // 
            // parity
            // 
            this.parity.FormattingEnabled = true;
            this.parity.Location = new System.Drawing.Point(112, 110);
            this.parity.Name = "parity";
            this.parity.Size = new System.Drawing.Size(125, 21);
            this.parity.TabIndex = 4;
            // 
            // acceptButton
            // 
            this.acceptButton.Location = new System.Drawing.Point(36, 208);
            this.acceptButton.Name = "acceptButton";
            this.acceptButton.Size = new System.Drawing.Size(75, 23);
            this.acceptButton.TabIndex = 5;
            this.acceptButton.Text = "Accept";
            this.acceptButton.UseVisualStyleBackColor = true;
            this.acceptButton.Click += new System.EventHandler(this.AcceptButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(137, 208);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 6;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // clearEditorChk
            // 
            this.clearEditorChk.AutoSize = true;
            this.clearEditorChk.Location = new System.Drawing.Point(12, 152);
            this.clearEditorChk.Name = "clearEditorChk";
            this.clearEditorChk.Size = new System.Drawing.Size(123, 17);
            this.clearEditorChk.TabIndex = 7;
            this.clearEditorChk.Text = "Clear Editor on Send";
            this.clearEditorChk.UseVisualStyleBackColor = true;
            // 
            // shiftEnterSendChk
            // 
            this.shiftEnterSendChk.AutoSize = true;
            this.shiftEnterSendChk.Location = new System.Drawing.Point(12, 179);
            this.shiftEnterSendChk.Name = "shiftEnterSendChk";
            this.shiftEnterSendChk.Size = new System.Drawing.Size(111, 17);
            this.shiftEnterSendChk.TabIndex = 7;
            this.shiftEnterSendChk.Text = "Shift+Enter Sends";
            this.shiftEnterSendChk.UseVisualStyleBackColor = true;
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(254, 242);
            this.Controls.Add(this.shiftEnterSendChk);
            this.Controls.Add(this.clearEditorChk);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.acceptButton);
            this.Controls.Add(this.parity);
            this.Controls.Add(this.stopBits);
            this.Controls.Add(this.dataBits);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.baudRate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.portName);
            this.Controls.Add(this.label1);
            this.MaximumSize = new System.Drawing.Size(270, 280);
            this.MinimumSize = new System.Drawing.Size(270, 280);
            this.Name = "Settings";
            this.Text = "Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox portName;
        private System.Windows.Forms.TextBox baudRate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox dataBits;
        private System.Windows.Forms.ComboBox stopBits;
        private System.Windows.Forms.ComboBox parity;
        private System.Windows.Forms.Button acceptButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.CheckBox clearEditorChk;
        private System.Windows.Forms.CheckBox shiftEnterSendChk;
    }
}