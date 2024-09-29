using System;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.IO.Packaging;
using System.Net.Http.Headers;
using System.Security.Policy;
using System.Text;
using System.Text.Json;
using Modbus;

namespace ReadOctopus
{
    internal class Class1
    {
        // <summary>
        // curl -u "$sk_live_RDJRUV6t9iW8NlQ3b2ADtlmf:" "https://api.octopus.energy/v1/accounts/"
        // curl -u "sk_live_RDJRUV6t9iW8NlQ3b2ADtlmf:" https://api.octopus.energy/v1/products/
        // curl -u "sk_live_RDJRUV6t9iW8NlQ3b2ADtlmf:" "https://api.octopus.energy/v1/electricity-meter-points/1300013672393/meters/20J0015149/consumption/"
        // curl -u "sk_live_RDJRUV6t9iW8NlQ3b2ADtlmf:" https://api.octopus.energy/v1/products/AGILE-23-12-06/electricity-tariffs/E-1R-AGILE-23-12-06-C/standard-unit-rates/"

        //$ export BASE_URL = "https://api.octopus.energy"
        //$ export PRODUCT_CODE = "AGILE-23-12-06"
        //$ export TARIFF_CODE = "E-1R-$PRODUCT_CODE-C"
        //$ export TARIFF_URL = "$BASE_URL/v1/products/AGILE-18-02-21/electricity-tariffs/$TARIFF_CODE"

        private Process commandProcess = null;

        public Class1()
        {
            string BASE_URL = "https://api.octopus.energy";
            string PRODUCT_CODE = "AGILE-23-12-06";
            string TARIFF_CODE = "E-1R-AGILE-23-12-06-C";
            string TARIFF_URL = BASE_URL + "/v1/products/" + PRODUCT_CODE + "/electricity-tariffs/" + TARIFF_CODE; 

            string test2 = "curl -u " + TARIFF_URL + "/standard-unit-rates/ | jq '.results[:2]";
            var res = ExecuteCurl(test2);

            string test = "curl -u \"sk_live_RDJRUV6t9iW8NlQ3b2ADtlmf:\" \"https://api.octopus.energy/v1/electricity-meter-points/1300013672393/meters/20J0015149/consumption/";
            res = ExecuteCurl(test);
            Debug.Print(res);

            GetTarriff();
        }

        public void GetTarriff()
        {
            string res = ExecuteCurl("curl -u \"sk_live_RDJRUV6t9iW8NlQ3b2ADtlmf:\" https://api.octopus.energy/v1/products/AGILE-23-12-06/electricity-tariffs/E-1R-AGILE-23-12-06-C/standard-unit-rates/\"");
            Tarrif t = (Tarrif)JsonSerializer.Deserialize(res, typeof(Tarrif));
        }


        public class Tarrif
        {
           public int count { get; set; }
           public string next { get; set; }
           public string preious { get; set; }
           public result[] results { get; set; }
        }

        public class result
        {
            public double value_exc_vat { get; set; }
            public double value_inc_vat { get; set; }
            public string valid_from { get; set; }
            public string valid_to { get; set; }
            public string payment_method { get; set; }
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