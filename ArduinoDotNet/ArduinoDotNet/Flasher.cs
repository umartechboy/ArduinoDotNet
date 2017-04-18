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
    class Flasher
    {
        public Flasher()
        {
            resouceTable.Add("ArduinoDotNet_Driver", "ArduinoDotNet_driver.hex");
            resouceTable.Add("avrdude", "avrdude.exe");
        }
        void CreateResouces()
        {
            ResourceSet resourceSet = Properties.Resources.ResourceManager.GetResourceSet(CultureInfo.CurrentUICulture, true, true);
            foreach (DictionaryEntry entry in resourceSet)
            {
                string resourceKey = entry.Key.ToString();
                string fname = resouceTable[resourceKey];
                object resource = entry.Value;
                WriteResourceToFile((byte[])resource, fname);
            }
        }
        Dictionary<string, string> resouceTable = new Dictionary<string, string>();
        void RemoveResouces()
        {
            ResourceSet resourceSet = Properties.Resources.ResourceManager.GetResourceSet(CultureInfo.CurrentUICulture, true, true);
            foreach (DictionaryEntry entry in resourceSet)
            {
                string resourceKey = entry.Key.ToString();
                string fname = resouceTable[resourceKey];
                File.Delete(fname);
            }
        }
        void WriteResourceToFile(byte[] data, string fileName)
        {
            var fs = new FileStream(fileName, FileMode.Create);
            fs.Write(data, 0, data.Length);
            fs.Flush();
            fs.Close();
        }
        public void Flash(ref SerialPort sp)
        {
            sp.Close();
            //extract the resources
            CreateResouces();
            var p = new Process();
            p.StartInfo = new ProcessStartInfo("avrdude.exe", "-p atmega2560 -b115200 -c wiring -P " + sp.PortName);
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.UseShellExecute = false; 
            p.Start();
            p.WaitForExit();

            //remove the resouces
            RemoveResouces();
            sp.Open();
        }
    }
}
