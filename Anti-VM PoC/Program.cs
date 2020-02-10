/*
    JoeFreedy AntiVM
*/

using System;
using System.Linq;
using System.Collections.Generic;

namespace AntiVM
{
    class Program
    {
        private List<float?> PowerUsage = new List<float?>();
        private OpenHardwareMonitor.Hardware.Computer computer;

        private void InitHardware()
        {
            computer = new OpenHardwareMonitor.Hardware.Computer();
            computer.CPUEnabled = true;
            computer.Open();
            return;
        }

        private void GetPowerUsage()
        {
            string SensorType;
            float? SensorValue;

            for (int i = 0; i < computer.Hardware.Count(); i++)
            {
                for (int j = 0; j < computer.Hardware[i].Sensors.Count(); j++)
                {
                    SensorType = computer.Hardware[i].Sensors[j].SensorType.ToString();
                    SensorValue = computer.Hardware[i].Sensors[j].Value;

                    if (SensorType == "Power")
                    {
                        PowerUsage.Add(SensorValue);
                    }
                }
            }

            computer.Close();
            return;
        }

        private void Results()
        {
            Boolean sandbox = true;

            foreach (float? f in PowerUsage)
            {
                Console.WriteLine("+ " + f + " P");
                if (f != 0) { sandbox = false; }
            }

            Console.WriteLine("\nBilgi !");

            if (sandbox == true)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Utanmaz VM de çalistiriyor...");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Anladim Abe");
            }

            return;
        }

        static void Main(string[] args)
        {
            Console.Title = "Anti-VM JoeFreedy";

            Program p = new Program();
            p.InitHardware();
            p.GetPowerUsage();
            p.Results();

            Console.ResetColor();
            Console.ReadLine();
        }
    }
}