using System;
using System.Collections.Generic;
using System.Text;
using System.IO.Ports;
using System.Management;
using System.IO;
using System.Threading;
using System.Collections;
using System.Globalization;
using System.Resources;
using System.Diagnostics;

namespace ArduinoSharp
{
    public class Pins
    {
        public const byte A0 = 54, A1 = 55, A2 = 56, A3 = 57, A4 = 58, A5 = 59, A6 = 60, A7 = 61, A8 = 62, A9 = 63, A10 = 64, A11 = 65, A12 = 66, A13 = 67, A14 = 68, A15 = 69;
    }

    public class ArduinoDotNetInterface
    {
        SerialPort sp;
        public bool FlashFirmware()
        {
            if (!IsOpen)
                throw new Exception("Interface Must be open to use this feature.");
            new Flasher().Flash(ref sp);
            bool ans = ValidateDriver();
            HardResetController();
            return ans;
        }
        public static string ConnectedArduinoPort
        {
            get
            {

                string str = null;
                try
                {
                    ManagementObjectSearcher searcher =
                        new ManagementObjectSearcher("root\\CIMV2",
                        "SELECT * FROM Win32_PnPEntity");

                    foreach (ManagementObject queryObj in searcher.Get())
                    {
                        if (queryObj["Caption"] == null) continue;
                        if (queryObj["Caption"].ToString().Contains("(COM"))
                        {
                            if (queryObj["Caption"].ToString().Contains("Arduino Mega 2560"))
                            {
                                str = queryObj["Caption"].ToString();
                                str = str.Substring(str.IndexOf("(") + 1, str.IndexOf(")") - str.IndexOf("(") - 1);
                            }
                        }

                    }
                }
                catch
                {
                }
                return str;
            }
        }
        public void HardResetController()
        {
            sp.DtrEnable = false;
            sp.RtsEnable = false;

            Thread.Sleep(250);

            sp.DtrEnable = true;
            sp.RtsEnable = true;

            Thread.Sleep(2000);
        }
        public bool IsOpen { get { if (sp == null) return false; return sp.IsOpen; } }
        public void Open(string comPort)
        {
            if (sp != null) throw new Exception("Interface is already open");
            sp = new SerialPort(comPort, 115200);
            sp.WriteBufferSize = 32;
            sp.DataReceived += Sp_DataReceived;
            sp.ReadTimeout = 1000;
            sp.Open();
        }
        public void Open()
        {
            Open(ConnectedArduinoPort);
        }
        public void Close()
        {
            if (sp == null) throw new Exception("Interface is already closed");
            if (!sp.IsOpen) throw new Exception("Interface is already closed");

            sp.Close();
            sp = null;
        }
        public StringBuilder GarbageCollector = new StringBuilder();
        bool sp_DontReceive = false;
        private void Sp_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (sp_DontReceive) return;
            GarbageCollector.Append(sp.ReadExisting());
        }

        void sendCommand(string data)
        {
            sendCommand(new UTF8Encoding().GetBytes(data));
        }
        void sendCommand(byte[] data)
        {
            byte[] ans = new byte[0];
            sendCommand(data, 0, ans);
        }
        void sendCommand(string data, int expect, byte[] ans)
        {
            sendCommand(new UTF8Encoding().GetBytes(data), expect, ans);
        }
        void sendCommand(byte[] data, int expect, byte[] ans)
        {
            if (!sp.IsOpen)
                throw new Exception("Interface is closed.");
            sp_DontReceive = true;
            GarbageCollector.Append(sp.ReadExisting());
            sp.Write(new byte[] { 0xAA, 0x55 }, 0, 2);
            sp.Write(data, 0, data.Length);
            try
            {
                if (expect > 0)
                    sp.Read(ans, 0, expect);
            }
            catch (TimeoutException)
            { throw new Exception("There was an error communicating with the hardware."); }
            sp_DontReceive = false;
        }
        public void digitalWrite(byte pin, int state)
        { digitalWrite(pin, state > 0); }
        public void digitalWrite(byte pin, bool state)
        {
            var com = new byte[4];
            com[0] = (byte)'D'; com[1] = (byte)'W'; ;
            com[2] = pin;
            com[3] = state ? (byte)1 : (byte)0;
            sendCommand(com);
        }
        public void analogueWrite(byte pin, int value)
        {
            var com = new byte[5];
            com[0] = (byte)'A'; com[1] = (byte)'W'; ;
            com[2] = pin;
            com[3] = (byte)(value % 256);
            com[3] = (byte)((value >> 8) % 256);
            sendCommand(com);
        }
        public int analogRead(byte pin)
        {
            var value = new byte[2];
            sendCommand("AR" + (char)pin, 2, value);
            return BitConverter.ToUInt16(value, 0);

        }
        public int digitalRead(byte pin)
        {
            var value = new byte[1];
            sendCommand("DR" + (char)pin, 1, value);
            return value[0];

        }
        public bool ValidateDriver()
        {
            try
            {
                var value = new byte[1];
                sendCommand("VD", 1, value);
                if (value[0] == 56)
                    return true;

            }
            catch { return false; }
            return false;
        }
        public void pinMode(byte pin, int state)
        { pinMode(pin, state > 0); }
        public void pinMode(byte pin, bool state)
        {
            var com = new byte[3];
            com[0] = (byte)'P'; com[1] = (byte)'M';
            com[2] = state ? (byte)1 : (byte)0;
            sendCommand(com);

        }

    }
}
