using System.Diagnostics;

namespace SofarController
{
    internal class UpdateDomotics
    {
        public void SendData(Sofar sofar, Solcast solcast)
        {
            if (sofar.Data.Count > 10)
            {
                if(sofar.Data.ContainsKey(eData.GridIOPwr))
                    ExecuteCurl("http://127.0.0.1:8080/json.htm?type=command&param=udevice&idx=1&nvalue=0&svalue=" + sofar.Data[eData.GridIOPwr]);
                if (sofar.Data.ContainsKey(eData.HouseConsumptionPwr))
                    ExecuteCurl("http://127.0.0.1:8080/json.htm?type=command&param=udevice&idx=2&nvalue=0&svalue=" + sofar.Data[eData.HouseConsumptionPwr]*1000);
                if (sofar.Data.ContainsKey(eData.InternalIOPwr))
                    ExecuteCurl("http://127.0.0.1:8080/json.htm?type=command&param=udevice&idx=3&nvalue=0&svalue=" + sofar.Data[eData.InternalIOPwr] * 1000);
                if (sofar.Data.ContainsKey(eData.PVGenerationPwr))
                    ExecuteCurl("http://127.0.0.1:8080/json.htm?type=command&param=udevice&idx=4&nvalue=0&svalue=" + sofar.Data[eData.PVGenerationPwr]*1000);
                if (sofar.Data.ContainsKey(eData.EPSOutputV))
                    ExecuteCurl("http://127.0.0.1:8080/json.htm?type=command&param=udevice&idx=5&nvalue=0&svalue=" + sofar.Data[eData.EPSOutputV]);
                if (sofar.Data.ContainsKey(eData.EPSOutputPwr))
                    ExecuteCurl("http://127.0.0.1:8080/json.htm?type=command&param=udevice&idx=6&nvalue=0&svalue=" + sofar.Data[eData.EPSOutputPwr]);
                if (sofar.Data.ContainsKey(eData.TodayGeneratedSolarWh))
                    ExecuteCurl("http://127.0.0.1:8080/json.htm?type=command&param=udevice&idx=7&nvalue=0&svalue=" + sofar.Data[eData.TodayGeneratedSolarWh]);
                if (sofar.Data.ContainsKey(eData.TodaySoldSolarWh))
                    ExecuteCurl("http://127.0.0.1:8080/json.htm?type=command&param=udevice&idx=8&nvalue=0&svalue=" + sofar.Data[eData.TodaySoldSolarWh]);
                if (sofar.Data.ContainsKey(eData.TodayBoughtGridWh))
                    ExecuteCurl("http://127.0.0.1:8080/json.htm?type=command&param=udevice&idx=9&nvalue=0&svalue=" + sofar.Data[eData.TodayBoughtGridWh]);
                if (sofar.Data.ContainsKey(eData.TodayConsumptionWh))
                    ExecuteCurl("http://127.0.0.1:8080/json.htm?type=command&param=udevice&idx=10&nvalue=0&svalue=" + sofar.Data[eData.TodayConsumptionWh]);
                if (sofar.Data.ContainsKey(eData.BatteryChargeDischargePwr))
                    ExecuteCurl("http://127.0.0.1:8080/json.htm?type=command&param=udevice&idx=11&nvalue=0&svalue=" + sofar.Data[eData.BatteryChargeDischargePwr]*1000);
                if (sofar.Data.ContainsKey(eData.BatteryCycles))
                    ExecuteCurl("http://127.0.0.1:8080/json.htm?type=command&param=udevice&idx=12&nvalue=0&svalue=" + sofar.Data[eData.BatteryCycles]);
                if (sofar.Data.ContainsKey(eData.BatteryChrgLevel))
                    ExecuteCurl("http://127.0.0.1:8080/json.htm?type=command&param=udevice&idx=13&nvalue=0&svalue=" + sofar.Data[eData.BatteryChrgLevel]);
                if (sofar.Data.ContainsKey(eData.InverterInternalTemp))
                    ExecuteCurl("http://127.0.0.1:8080/json.htm?type=command&param=udevice&idx=14&nvalue=0&svalue=" + sofar.Data[eData.InverterInternalTemp]);
                if (sofar.Data.ContainsKey(eData.InverterHeatsinkTemp))
                    ExecuteCurl("http://127.0.0.1:8080/json.htm?type=command&param=udevice&idx=15&nvalue=0&svalue=" + sofar.Data[eData.InverterHeatsinkTemp]);
                if (sofar.Data.ContainsKey(eData.InverterFreq))
                    ExecuteCurl("http://127.0.0.1:8080/json.htm?type=command&param=udevice&idx=16&nvalue=0&svalue=" + sofar.Data[eData.InverterFreq]);
                if (sofar.Data.ContainsKey(eData.InverterRunningState))
                    ExecuteCurl("http://127.0.0.1:8080/json.htm?type=command&param=udevice&idx=18&nvalue=0&svalue=" + sofar.Data[eData.InverterRunningState]);
                if (sofar.Data.ContainsKey(eData.BatteryTemp))
                    ExecuteCurl("http://127.0.0.1:8080/json.htm?type=command&param=udevice&idx=19&nvalue=0&svalue=" + sofar.Data[eData.BatteryTemp]);
                if (sofar.Data.ContainsKey(eData.TotalLoadConsumption))
                    ExecuteCurl("http://127.0.0.1:8080/json.htm?type=command&param=udevice&idx=20&nvalue=0&svalue=" + sofar.Data[eData.TotalLoadConsumption]);

                if (solcast is not null)
                    ExecuteCurl("http://127.0.0.1:8080/json.htm?type=command&param=udevice&idx=32&nvalue=0&svalue=" + ((solcast.ForecastAM + solcast.ForecastPM)*100).ToString("F2"));
            }
        }

        public static string ExecuteCurl(string curlCommand, int timeoutInSeconds = 60)
        {
            using (var proc = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "curl.exe",
                    Arguments = curlCommand.ToString(),
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    CreateNoWindow = true,
                    WorkingDirectory = Environment.SystemDirectory
                }
            })
            {
                proc.Start();

                proc.WaitForExit(timeoutInSeconds * 1);

                return proc.StandardOutput.ReadToEnd();
            }
        }
    }
}