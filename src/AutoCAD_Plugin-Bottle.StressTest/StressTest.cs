namespace AutoCAD_Plugin_Bottle.StressTest
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using AutoCAD_Plugin_Bottle.Model;
    using Autodesk.AutoCAD.Runtime;
    using Microsoft.VisualBasic.Devices;

    public class StressTest
    {
        [CommandMethod("StressTest")]
        public void Test()
        {
            var maxQuantity = 40000;
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            var parameters = new Parameters();
            foreach (BottleParameterType currentParameter
                in Enum.GetValues(typeof(BottleParameterType)))
            {
                var parameter = parameters[currentParameter];
                var value = (parameter.MaxValue - parameter.MinValue) / 2;
                parameters.SetValue(currentParameter, value);
            }

            var streamWriter = new StreamWriter($"log.txt", false);
            Process currentProcess = System.Diagnostics.Process.GetCurrentProcess();
            var count = 0;
            while (count != maxQuantity)
            {
                const double gigabyteInByte = 0.000000000931322574615478515625;
                Builder.BuildBottle(parameters);
                var computerInfo = new ComputerInfo();
                var usedMemory = (computerInfo.TotalPhysicalMemory
                                  - computerInfo.AvailablePhysicalMemory)
                                 * gigabyteInByte;
                streamWriter.WriteLine(
                    $"{++count}\t{stopWatch.Elapsed:hh\\:mm\\:ss}\t{usedMemory}");
                streamWriter.Flush();
            }

            stopWatch.Stop();
            streamWriter.Close();
            streamWriter.Dispose();
            Console.Write($"End {new ComputerInfo().TotalPhysicalMemory}");
        }
    }
}
