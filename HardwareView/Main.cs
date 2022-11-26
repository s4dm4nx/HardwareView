using LibreHardwareMonitor.Hardware;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HardwareView
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        static float cpuTemp;
        // CPU Usage
        static float cpuUsage;
        // CPU Power Draw (Package)
        static float cpuPowerDrawPackage;
        // CPU Frequency
        static float cpuFrequency;
        // GPU Temperature
        static float gpuTemp;
        // GPU Usage
        static float gpuUsage;
        // GPU Core Frequency
        static float gpuCoreFrequency;
        // GPU Memory Frequency
        static float gpuMemoryFrequency;

 

        static Computer c = new Computer()
        {
            IsGpuEnabled = true,
            IsCpuEnabled = true,
            //RAMEnabled = true, // uncomment for RAM reports
            //MainboardEnabled = true, // uncomment for Motherboard reports
            //FanControllerEnabled = true, // uncomment for FAN Reports
            //HDDEnabled = true, // uncomment for HDD Report
        };
        private void Main_Load(object sender, EventArgs e)
        {

            new Thread(new ThreadStart(UpdateData)).Start();
            c.Open();
            Updater.Start();


        }

        private void Updater_Tick(object sender, EventArgs e)
        {

            CPUTemp.Text = cpuTemp.ToString() + " C";
            GPUTemp.Text = gpuTemp.ToString() + " C";

        }
        static void UpdateData()
        {
            while (true)
            {
                try
                {
                    foreach (var hardware in c.Hardware)
                    {

                        if (hardware.HardwareType == HardwareType.Cpu)
                        {
                            // only fire the update when found
                            hardware.Update();

                            // loop through the data
                            foreach (var sensor in hardware.Sensors)
                                if (sensor.SensorType == SensorType.Temperature && sensor.Name.Contains("CPU Package"))
                                {
                                    // store
                                    cpuTemp = sensor.Value.GetValueOrDefault();
                                    // print to console
                                    System.Diagnostics.Debug.WriteLine("cpuTemp: " + sensor.Value.GetValueOrDefault());

                                }
                                else if (sensor.SensorType == SensorType.Load && sensor.Name.Contains("CPU Total"))
                                {
                                    // store
                                    cpuUsage = sensor.Value.GetValueOrDefault();
                                    // print to console
                                    System.Diagnostics.Debug.WriteLine("cpuUsage: " + sensor.Value.GetValueOrDefault());

                                }
                                else if (sensor.SensorType == SensorType.Power && sensor.Name.Contains("CPU Package"))
                                {
                                    // store
                                    cpuPowerDrawPackage = sensor.Value.GetValueOrDefault();
                                    // print to console
                                    System.Diagnostics.Debug.WriteLine("CPU Power Draw - Package: " + sensor.Value.GetValueOrDefault());


                                }
                                else if (sensor.SensorType == SensorType.Clock && sensor.Name.Contains("CPU Core #1"))
                                {
                                    // store
                                    cpuFrequency = sensor.Value.GetValueOrDefault();
                                    // print to console
                                    System.Diagnostics.Debug.WriteLine("cpuFrequency: " + sensor.Value.GetValueOrDefault());
                                }
                        }


                        // Targets AMD & Nvidia GPUS
                        if (hardware.HardwareType == HardwareType.GpuAmd || hardware.HardwareType == HardwareType.GpuNvidia)
                        {
                            // only fire the update when found
                            hardware.Update();

                            // loop through the data
                            foreach (var sensor in hardware.Sensors)
                                if (sensor.SensorType == SensorType.Temperature && sensor.Name.Contains("GPU Core"))
                                {
                                    // store
                                    gpuTemp = sensor.Value.GetValueOrDefault();
                                    // print to console
                                    System.Diagnostics.Debug.WriteLine("gpuTemp: " + sensor.Value.GetValueOrDefault());
                                }
                                else if (sensor.SensorType == SensorType.Load && sensor.Name.Contains("GPU Core"))
                                {
                                    // store
                                    gpuUsage = sensor.Value.GetValueOrDefault();
                                    // print to console
                                    System.Diagnostics.Debug.WriteLine("gpuUsage: " + sensor.Value.GetValueOrDefault());
                                }
                                else if (sensor.SensorType == SensorType.Clock && sensor.Name.Contains("GPU Core"))
                                {
                                    // store
                                    gpuCoreFrequency = sensor.Value.GetValueOrDefault();
                                    // print to console
                                    System.Diagnostics.Debug.WriteLine("gpuCoreFrequency: " + sensor.Value.GetValueOrDefault());
                                }
                                else if (sensor.SensorType == SensorType.Clock && sensor.Name.Contains("GPU Memory"))
                                {
                                    // store
                                    gpuMemoryFrequency = sensor.Value.GetValueOrDefault();
                                    // print to console
                                    System.Diagnostics.Debug.WriteLine("gpuMemoryFrequency: " + sensor.Value.GetValueOrDefault());
                                }

                        }

                        // ... you can access any other system information you want here

                    }
                    Thread.Sleep(1000);
                }
                catch { }
            }
        }

        private void Background_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private void CPU_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void Main_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void GPU_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void CPUTemp_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void GPUTemp_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }

    

}
