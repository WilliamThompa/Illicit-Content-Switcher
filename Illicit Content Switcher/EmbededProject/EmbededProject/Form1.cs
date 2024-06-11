using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;
using System.Xml.Serialization;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Runtime.InteropServices;

namespace EmbededProject
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll")]
        public static extern void keybd_event(byte virtualKey, byte scanCode, uint flags, IntPtr extraInfo);

        const int KEYEVENTF_EXTENDEDKEY = 0x0001;
        const int KEYEVENTF_KEYUP = 0x0002;
        const byte VK_LWIN = 0x5B;
        const byte VK_D = 0x44;

        public delegate void d1(string indata);
        public bool check;

        SerialPort serialPort;
        public Form1()
        {
            InitializeComponent();
            check = false;
            this.FormClosed += new FormClosedEventHandler(Form1_FormClosed);
            if (serialPort == null )
            {
                serialPort = new SerialPort("COM3", 9600);
                serialPort.DataReceived += serialPort_DataReceived;
                serialPort.Open();
            }
        }

        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            throw new NotImplementedException();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            // Check if the form is being closed by ALT + F4 or other methods
            if (serialPort != null && serialPort.IsOpen)
            {
                serialPort.Write("a"); // Send reset command to Arduino
                serialPort.Close(); // Close the serial port
            }
        }

        void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {

            if(serialPort != null && serialPort.IsOpen)
            {
                serialPort.Write("a");
                serialPort.Close();
            }
        }

        private void onButton_Click(object sender, EventArgs e)
        {
            //Turn on Application
            serialPort.Write("A");
            showDesktop.Enabled = true;
            switchTab.Enabled = true;
            closeTab.Enabled = true;
            offButton.Enabled = true;
        }

        private void offButton_Click(object sender, EventArgs e)
        {
           //Turn off Application
           serialPort.Write("a");
           showDesktop.Enabled = false;
            showDesktop.Checked = false;
           switchTab.Enabled = false;
           switchTab.Checked = false;
           closeTab.Enabled = false;
            closeTab.Checked = false;
            offButton.Enabled = false;
        }

        private void PortWrite(string message)
        {
            serialPort.Write(message);
        }

        private void closeTab_CheckedChanged(object sender, EventArgs e)
        {
            if (closeTab.Checked == true)
            {
                serialPort.Write("b");
            }
        }

        private void switchTab_CheckedChanged(object sender, EventArgs e)
        {

            if(switchTab.Checked == true)
            {
                serialPort.Write("c");
            }
        }
        private void showDesktop_CheckedChanged(object sender, EventArgs e)
        {
            if (showDesktop.Checked == true)
            {
                serialPort.Write("d");
            }
        }

        private void serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string indata = serialPort.ReadExisting();
            d1 writeit = new d1(write2Form);
            Invoke(writeit, indata);
        }

        public void write2Form(string indata)
        {
            //Controls communication with data from arduino
            char firstchar;
            firstchar = indata[0];
            if(firstchar == 'z')
            {
                check = true;
                if (closeTab.Checked)
                {
                    SendKeys.Send("%{F4}");
                    closeTab.Checked = false;
                    serialPort.Write("a");
                }
                else if (switchTab.Checked)
                {
                    SendKeys.Send("%{TAB}");
                    switchTab.Checked = false;
                    serialPort.Write("A");
                }
                else if (showDesktop.Checked)
                {
                    SendWinKeyD();
                    showDesktop.Checked = false;
                    serialPort.Write("A");
                }
            }
            else if (check)
            {
                if (closeTab.Checked)
                {
                    SendKeys.Send("%{F4}");
                    closeTab.Checked = false;
                    serialPort.Write("a");
                }
                else if (switchTab.Checked)
                {
                    SendKeys.Send("%{TAB}");
                    switchTab.Checked = false;
                    serialPort.Write("A");
                }
                else if (showDesktop.Checked)
                {
                    SendWinKeyD();
                    showDesktop.Checked = false;
                    serialPort.Write("A");
                }
            }
        }


        static void SendWinKeyD()
        {
            keybd_event(VK_LWIN, 0, KEYEVENTF_EXTENDEDKEY, IntPtr.Zero); // Press Win key
            keybd_event(VK_D, 0, KEYEVENTF_EXTENDEDKEY, IntPtr.Zero); // Press D key
            keybd_event(VK_D, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, IntPtr.Zero); // Release D key                                                                                       
            keybd_event(VK_LWIN, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, IntPtr.Zero); // Release Win key
        }
    }
}
