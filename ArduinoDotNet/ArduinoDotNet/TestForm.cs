using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ArduinoSharp
{
    public partial class TestForm : Form
    {
        public TestForm()
        {
            InitializeComponent();
        }
        ArduinoSharp.ArduinoDotNetInterface arduino = new ArduinoDotNetInterface();
        private void openB_Click(object sender, EventArgs e)
        {
            arduino.Open();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            arduino.Open();
        }

        private void digitalWrite_Click(object sender, EventArgs e)
        {
            arduino.digitalWrite(Convert.ToByte(pinTB.Text), Convert.ToByte(valueTB.Text));
        }

        private void closeB_Click(object sender, EventArgs e)
        {
            arduino.Close();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (arduino.IsOpen)
                arduino.Close();
        }

        private void analogReadB_Click(object sender, EventArgs e)
        {
            MessageBox.Show(arduino.analogRead(Convert.ToByte(pinTB.Text)).ToString());
        }

        private void digtialReadB_Click(object sender, EventArgs e)
        {
            MessageBox.Show(arduino.digitalRead(Convert.ToByte(pinTB.Text)).ToString());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (arduino.FlashFirmware())
                MessageBox.Show("Driver written successfully.");
            else MessageBox.Show("An unknown error occured during the programming process.");

        }

        private void checkDriverB_Click(object sender, EventArgs e)
        {
            if (arduino.ValidateDriver())
                MessageBox.Show("Driver present.");
            else MessageBox.Show("Driver not present");
        }
    }
}
