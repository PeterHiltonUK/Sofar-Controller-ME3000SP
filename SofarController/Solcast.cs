using System.Diagnostics;
using System.Text.Json;

namespace SofarController
{
    //SOHrZpKROlcIFi6sTmN80xW6cQXB-llJ
    public class Solcast
    {
        private DateTime LastDataSetForecast = new(), LastDataSetActual = new();
        public double ForecastAM, ForecastPM, ForecastTodayAM, ForecastTodayPM;
        public SollCastForeCastData forecast;
        //private string dir = AppDomain.CurrentDomain.BaseDirectory;
        string dir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        private string filename = "\\SolCastForeCast.dat";
        OptionData options;

        public Solcast(OptionData options)
        {
            this.options = options;

            if (!File.Exists(dir + filename))
            {
                forecast = GetSolcastForeCast();
                ReadWriteJson.WriteToJsonFile(dir + filename, forecast);
            }
            else
            {
                forecast = ReadWriteJson.ReadFromJsonFile<SollCastForeCastData>(dir + filename);

                if (forecast is null) // Needs Updating
                {
                    forecast = GetSolcastForeCast();
                    ReadWriteJson.WriteToJsonFile(dir + filename, forecast);
                }
                else
                {
                    DateTime dt = forecast.date;

                    if (dt.Day != DateTime.Now.Day) // Needs updating
                    {
                        File.SetAttributes(dir + filename, FileAttributes.Normal);
                        File.Delete(dir + filename);

                        forecast = GetSolcastForeCast();
                        ReadWriteJson.WriteToJsonFile(dir + filename, forecast);
                    }
                }
            }

            if (forecast is not null)
            {
                ForecastTodayAM = forecast.SumAMData(0);
                ForecastTodayPM = forecast.SumPMData(0);

                ForecastAM = forecast.SumAMData(1);
                ForecastPM = forecast.SumPMData(1);
            }

            this.options = options;
        }


        public SollCastForeCastData GetSolcastForeCast()
        {
            SollCastForeCastData t = new();

            var res = ExecuteCurl("curl https://api.solcast.com.au/rooftop_sites/" + options.SolLoc +"/forecasts?format=json&api_key=" + options.SolAPI);
            if (res != "")
            {
                t = (SollCastForeCastData)JsonSerializer.Deserialize(res, typeof(SollCastForeCastData));
                if(t != null)
                    t.date = DateTime.Now;
            }

            return t;
        }

        public SollCastForeCastData GetSolcastActual()
        {
            SollCastForeCastData? t = null;
            if (DateTime.Now.Day > LastDataSetActual.Day)
            {
                var res = ExecuteCurl("curl https://api.solcast.com.au/rooftop_sites/" + options.SolLoc +"/estimated_actuals?format=json&api_key=" + options.SolAPI);
                t = (SollCastForeCastData)JsonSerializer.Deserialize(res, typeof(SollCastForeCastData));
                LastDataSetActual = DateTime.Now;
            }
            return t;
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

    public class SollCastForeCastData
    {
        public string name { get; set; } = "";
        public DateTime date { get; set; } = new DateTime(1);

        public SollCastForeCastData()
        {
        }

        public SolCastForeCastResult[] forecasts { get; set; }

        public double SumDayData(int DayOffset)
        {
            DateTime now = DateTime.Now;
            int day = now.Day;
            int start = 0, end = 0;
            double total = 0;

            for (int i = 0; i < forecasts.Count(); i++)
            {
                if (forecasts[i].date().Day == now.Day + DayOffset)
                {
                    if (start == 0)
                        start = i;

                    if (forecasts[i].date().Day == now.Day + 1)
                    {
                        end = i;
                        break;
                    }
                }
            }

            for (int i = start; i <= end; i++)
            {
                total += forecasts[i].pv_estimate * 0.5;
            }
            return total;
        }

        public double SumAMData(int DayOffset)
        {
            DateTime now = DateTime.Now;
            int start = 0, end = 0;
            double total = 0;

            int daysinmonth = DateTime.DaysInMonth(now.Year, now.Month);
            int DayToRetrieve = now.Day + DayOffset;

            if (DateTime.Now.Day == daysinmonth && DayOffset == 0)
            {
                DayToRetrieve = daysinmonth;
            }
            else
            { 
                DayToRetrieve = 1 + DayOffset;
            }

            for (int i = 0; i < forecasts.Count(); i++)
            {
                if (forecasts[i].date().Day == DayToRetrieve)
                {
                    if (start == 0)
                        start = i;
                    if (forecasts[i].date().Hour == 12)
                    {
                        end = i;
                        break;
                    }
                }
            }

            for (int i = start; i < end; i++)
            {
                total += forecasts[i].pv_estimate * 0.5; // half hourly data
            }
            return total;
        }

        public double SumPMData(int DayOffset)
        {
            DateTime now = DateTime.Now;
            int start = 0, end = 0;
            double total = 0;

            int daysinmonth = DateTime.DaysInMonth(now.Year, now.Month);
            int DayToRetrieve = now.Day + DayOffset;

            if (DateTime.Now.Day == daysinmonth && DayOffset == 0)
            {
                DayToRetrieve = daysinmonth;
            }
            else
            {
                DayToRetrieve = 1 + DayOffset;
            }

            for (int i = 0; i < forecasts.Count(); i++)
            {
                if (forecasts[i].date().Day == DayToRetrieve)
                {
                    if (forecasts[i].date().Hour == 12)
                    {
                        if (start == 0)
                            start = i;
                    }

                    if (forecasts[i].date().Hour == 20)
                    {
                        end = i;
                        break;
                    }
                }
            }

            for (int i = start; i <= end; i++)
            {
                total += forecasts[i].pv_estimate * 0.5;
            }
            return total;
        }
    }

    public class SolCastForeCastResult
    {
        public double pv_estimate { get; set; }
        public double pv_estimate10 { get; set; }
        public double pv_estimate90 { get; set; }
        public string period_end { get; set; } = "";
        public string period { get; set; } = "";

        public DateTime date()
        {
            string[] splits = period_end.Split(new char[] { 'T' });
            string[] date = splits[0].Split(new char[] { '-' });
            int[] dateInt = new int[3];
            dateInt[0] = int.Parse(date[0]);
            dateInt[1] = int.Parse(date[1]);
            dateInt[2] = int.Parse(date[2]);

            string[] time = splits[1].Split(new char[] { ':', 'Z' });
            int[] timeInt = new int[3];
            timeInt[0] = int.Parse(time[0]);
            timeInt[1] = int.Parse(time[1]);
            timeInt[2] = (int)double.Parse(time[2]);

            DateOnly DateO = new DateOnly(dateInt[0], dateInt[1], dateInt[2]);
            TimeOnly TimeO = new TimeOnly(timeInt[0], timeInt[1], timeInt[2]);

            DateTime datetime = new DateTime(DateO, TimeO);

            return datetime;
        }
    }

    public class SolCastActualResult
    {
        public double pv_estimate { get; set; }
        public string period_end { get; set; }
        public string period { get; set; }

        public DateTime date()
        {
            string[] splits = period_end.Split(new char[] { 'T' });
            string[] date = splits[0].Split(new char[] { '-' });
            int[] dateInt = new int[3];
            dateInt[0] = int.Parse(date[0]);
            dateInt[1] = int.Parse(date[1]);
            dateInt[2] = int.Parse(date[2]);

            string[] time = splits[1].Split(new char[] { ':', 'Z' });
            int[] timeInt = new int[3];
            timeInt[0] = int.Parse(time[0]);
            timeInt[1] = int.Parse(time[1]);
            timeInt[2] = (int)double.Parse(time[2]);

            DateOnly DateO = new DateOnly(dateInt[0], dateInt[1], dateInt[2]);
            TimeOnly TimeO = new TimeOnly(timeInt[0], timeInt[1], timeInt[2]);

            DateTime datetime = new DateTime(DateO, TimeO);

            return datetime;
        }
    }
}