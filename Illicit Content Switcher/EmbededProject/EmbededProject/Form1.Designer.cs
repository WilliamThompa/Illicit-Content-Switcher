namespace EmbededProject
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
            this.components = new System.ComponentModel.Container();
            this.onButton = new System.Windows.Forms.Button();
            this.offButton = new System.Windows.Forms.Button();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.closeTab = new System.Windows.Forms.RadioButton();
            this.switchTab = new System.Windows.Forms.RadioButton();
            this.showDesktop = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // onButton
            // 
            this.onButton.Location = new System.Drawing.Point(12, 25);
            this.onButton.Name = "onButton";
            this.onButton.Size = new System.Drawing.Size(366, 62);
            this.onButton.TabIndex = 0;
            this.onButton.Text = "Turn On";
            this.onButton.UseVisualStyleBackColor = true;
            this.onButton.Click += new System.EventHandler(this.onButton_Click);
            // 
            // offButton
            // 
            this.offButton.Enabled = false;
            this.offButton.Location = new System.Drawing.Point(12, 93);
            this.offButton.Name = "offButton";
            this.offButton.Size = new System.Drawing.Size(366, 62);
            this.offButton.TabIndex = 1;
            this.offButton.Text = "Turn Off";
            this.offButton.UseVisualStyleBackColor = true;
            this.offButton.Click += new System.EventHandler(this.offButton_Click);
            // 
            // serialPort1
            // 
            this.serialPort1.PortName = "COM3";
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort_DataReceived);
            // 
            // closeTab
            // 
            this.closeTab.AutoSize = true;
            this.closeTab.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
            this.closeTab.Enabled = false;
            this.closeTab.Location = new System.Drawing.Point(138, 253);
            this.closeTab.Name = "closeTab";
            this.closeTab.Size = new System.Drawing.Size(71, 20);
            this.closeTab.TabIndex = 2;
            this.closeTab.TabStop = true;
            this.closeTab.Text = "Alt + F4";
            this.closeTab.UseVisualStyleBackColor = true;
            this.closeTab.CheckedChanged += new System.EventHandler(this.closeTab_CheckedChanged);
            // 
            // switchTab
            // 
            this.switchTab.AutoSize = true;
            this.switchTab.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
            this.switchTab.Enabled = false;
            this.switchTab.Location = new System.Drawing.Point(138, 279);
            this.switchTab.Name = "switchTab";
            this.switchTab.Size = new System.Drawing.Size(81, 20);
            this.switchTab.TabIndex = 3;
            this.switchTab.TabStop = true;
            this.switchTab.Text = "Alt + Tab";
            this.switchTab.UseVisualStyleBackColor = true;
            this.switchTab.CheckedChanged += new System.EventHandler(this.switchTab_CheckedChanged);
            // 
            // showDesktop
            // 
            this.showDesktop.AutoSize = true;
            this.showDesktop.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
            this.showDesktop.Enabled = false;
            this.showDesktop.Location = new System.Drawing.Point(138, 305);
            this.showDesktop.Name = "showDesktop";
            this.showDesktop.Size = new System.Drawing.Size(79, 20);
            this.showDesktop.TabIndex = 4;
            this.showDesktop.TabStop = true;
            this.showDesktop.Text = "Desktop";
            this.showDesktop.UseVisualStyleBackColor = true;
            this.showDesktop.CheckedChanged += new System.EventHandler(this.showDesktop_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(388, 450);
            this.Controls.Add(this.showDesktop);
            this.Controls.Add(this.switchTab);
            this.Controls.Add(this.closeTab);
            this.Controls.Add(this.offButton);
            this.Controls.Add(this.onButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button onButton;
        private System.Windows.Forms.Button offButton;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.RadioButton closeTab;
        private System.Windows.Forms.RadioButton switchTab;
        private System.Windows.Forms.RadioButton showDesktop;
    }
}

