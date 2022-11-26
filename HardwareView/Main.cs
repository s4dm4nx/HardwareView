using LibreHardwareMonitor.Hardware;
using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace HardwareView
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            AddMouseMoveHandler(this);
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
        static String NameFile = "location.txt";
        private void Main_Load(object sender, EventArgs e)
        {
            if (File.Exists(NameFile))
            {
                try
                {
                    string location = File.ReadAllText(NameFile);
                    string posX = location.Split(' ')[0];
                    string posY = location.Split(' ')[1];
                    this.Location = new Point(Convert.ToInt32(posX), Convert.ToInt32(posY));
                }
                catch { }
            }

            new Thread(new ThreadStart(UpdateData)).Start();
            c.Open();
            Updater.Start();


        }

        private void Updater_Tick(object sender, EventArgs e)
        {

            CPUTemp.Text = cpuTemp.ToString() + " C°";
            GPUTemp.Text = gpuTemp.ToString() + " C°";

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

        private void AddMouseMoveHandler(Control c)
        {
            c.MouseMove += MouseMoveHandler;
            c.ContextMenuStrip = contextMenuStrip1;
            if (c.Controls.Count > 0)
            {
                foreach (Control ct in c.Controls)
                    AddMouseMoveHandler(ct);
            }
        }

        public static void WriteFile(string text)
        {
            if (File.Exists(NameFile))
            {
                File.Delete(NameFile);
            }
            File.WriteAllText(NameFile, text);
        }

        private void MouseMoveHandler(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
                new Thread(() => WriteFile(getLocation())).Start();
            }
        }
        string getLocation()
        {
            return this.Location.X + " " + this.Location.Y;
        }
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

 
    }

    

}
