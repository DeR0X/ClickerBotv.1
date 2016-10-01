

using System;

namespace ClickerBot_reformed
{
    public class CPU
    {
        public static System.Diagnostics.PerformanceCounter perfCounter;
        public CPU()
        {
            perfCounter = new System.Diagnostics.PerformanceCounter();
            perfCounter.CategoryName = "Processor";
            perfCounter.CounterName = "% Processor Time";
            perfCounter.InstanceName = "_Total";
        }

        //gibt die usage der CPU zurück
        public static int GetCpuLoad()
        {
            return Convert.ToInt32(perfCounter.NextValue());
        }
    }

}
