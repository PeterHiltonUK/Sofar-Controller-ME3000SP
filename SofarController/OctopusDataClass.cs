using System.Diagnostics;
using System.Text.Json;

namespace ReadOctopus
{
    public class Octopus
    {
        public Octopus()
        {
        }

        public Tarrif GetTarriff()
        {
            string res = ExecuteCurl("curl -u \"sk_live_RDJRUV6t9iW8NlQ3b2ADtlmf:\" https://api.octopus.energy/v1/products/AGILE-23-12-06/electricity-tariffs/E-1R-AGILE-23-12-06-C/standard-unit-rates/\"");
            Tarrif t = (Tarrif)JsonSerializer.Deserialize(res, typeof(Tarrif));
            return t;
        }


        public class Tarrif
        {
           public int count { get; set; }
           public string next { get; set; }
           public string previous { get; set; }
           public result[] results { get; set; }
        }

        public class result
        {
            public double value_exc_vat { get; set; }
            public double value_inc_vat { get; set; }
            public string valid_from { get; set; }
            public string valid_to { get; set; }
            public string payment_method { get; set; }

            public DateTime date()
            {
                string[] splits = valid_to.Split(['T']);
                string[] date = splits[0].Split(['-']);
                int[] dateInt = new int[3];
                dateInt[0] = int.Parse(date[0]);
                dateInt[1] = int.Parse(date[1]);
                dateInt[2] = int.Parse(date[2]);

                string[] time = splits[1].Split([':', 'Z']);
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