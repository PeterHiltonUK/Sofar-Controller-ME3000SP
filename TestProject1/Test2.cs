using NModbus;
using SolarManCSharp;
using System.Diagnostics;
using System.IO.Ports;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Sockets;
using System.Text;
using static System.Net.Mime.MediaTypeNames;
using Extensions;

// https//:enlighten.enphaseenergy.com/entrez-auth-token?serial_num=122145028178
//https://Mark.Anders@Aspentech.com:Greenhouse1@entrez.enphaseenergy.com/
//curl -f -k -H 'Accept: application/json' -H 'Authorization: Bearer eyJraWQiOiI3ZDEwMDA1ZC03ODk5LTRkMGQtYmNiNC0yNDRmOThlZTE1NmIiLCJ0eXAiOiJKV1QiLCJhbGciOiJFUzI1NiJ9.eyJhdWQiOiIxMjIxNDUwMjgxNzgiLCJpc3MiOiJFbnRyZXoiLCJlbnBoYXNlVXNlciI6Im93bmVyIiwiZXhwIjoxNzU4NTU0Njg1LCJpYXQiOjE3MjcwMTg2ODUsImp0aSI6ImYyMjUyN2YwLTRkYjEtNGJkMC1iZmI4LTYwZmJmNTcwZDA1ZSIsInVzZXJuYW1lIjoibWFyay5hbmRlcnNAYXNwZW50ZWNoLmNvbSJ9.hix_jzz3prOvEjy565S3eKUCPWB_GK6vf__-4fsC4uOUsYHg9Uv8S5EIgkIgpdDBNA4MtwiQG2EIit5iHCl_ew' -X GET http://192.168.1.195/api/v1/production/inverters
//curl -f -k -H 'Accept: application/json' -H 'Authorization: Bearer eyJraWQiOiI3ZDEwMDA1ZC03ODk5LTRkMGQtYmNiNC0yNDRmOThlZTE1NmIiLCJ0eXAiOiJKV1QiLCJhbGciOiJFUzI1NiJ9.eyJhdWQiOiIxMjIxNDUwMjgxNzgiLCJpc3MiOiJFbnRyZXoiLCJlbnBoYXNlVXNlciI6Im93bmVyIiwiZXhwIjoxNzU4NTU0Njg1LCJpYXQiOjE3MjcwMTg2ODUsImp0aSI6ImYyMjUyN2YwLTRkYjEtNGJkMC1iZmI4LTYwZmJmNTcwZDA1ZSIsInVzZXJuYW1lIjoibWFyay5hbmRlcnNAYXNwZW50ZWNoLmNvbSJ9.hix_jzz3prOvEjy565S3eKUCPWB_GK6vf__-4fsC4uOUsYHg9Uv8S5EIgkIgpdDBNA4MtwiQG2EIit5iHCl_ew' -X GET http://192.168.1.195/api/v4/production/inverters
namespace TestProject1
{
    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void TestWIFIData()
        {
            var sock = new System.Net.Sockets.Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            var serverIP = IPAddress.Parse("192.168.1.228");
            var serverFullAddr = new IPEndPoint(serverIP, 8899);
            sock.Connect(serverFullAddr);

            var factory = new ModbusFactory();
            IModbusMaster master = factory.CreateMaster(sock);

            byte slaveId = 1;
            ushort startAddress = 0x210;
            ushort numInputs = 1;
            //ushort www = 0x42c80083

            ushort power, cycles;

            for (int i = 0; i < 50; i++)
            {
                Thread.Sleep(1000);
               // sock.Disconnect(true);
                //sock.Connect(serverFullAddr);
                cycles = master.ReadHoldingRegisters("Battery Cycles", slaveId, 0x22C, numInputs,true)[0];
                power = master.ReadHoldingRegisters("Battery ChargeLevel", slaveId, startAddress, numInputs, true)[0];
                var STime = master.ReadHoldingRegisters("TOU",1, 0x1208, 1, true); // Start time
                //Debug.Print(cycles.ToString());
                //Debug.Print(power.ToString());
                if (power == 0 || power > 100)
                    Debugger.Break();
            }
        }

        [TestMethod]
        public void TestPack()
        {
            var v5_controlcode = StructConverter2.Pack(new object[] { (ushort)4510 });
            var v5_controlcode2 = StructConverter.Unpack("<H", v5_controlcode.Bytearray);
            
            byte res = 0xE;
            var t = res.ToString("xE");

            string s = "4510";
            byte[] ASCIIValues = Encoding.ASCII.GetBytes("1045");

            char c1 = (char)0x45;
            byte c4 = (byte)c1;
            char c2 = (char)0x99;
            byte c3 = (byte)c2;

            byte b = StructConverter2.AscCoded(ByteHelper.UpByte(0x4510));
            byte b2 = StructConverter2.AscCoded(ByteHelper.LowerByte(0x4510));
        }


        [TestMethod]
        public void TestWIFIConrol()
        {
            using (TcpClient client = new TcpClient("192.168.1.228", 8899))
            {
                var factory = new ModbusFactory();
                
                IModbusMaster master = factory.CreateMaster(client);

                byte slaveId = 1;
                ushort startAddress = 0x1200;
                ushort numInputs = 1;
                //ushort www = 0x42c80083

                master.WriteSingleRegister(slaveId, startAddress, 1);
                ushort[] registers = master.ReadHoldingRegisters(slaveId, startAddress, numInputs);

                for (int i = 0; i < numInputs; i++)
                {
                    Console.WriteLine($"Input {(startAddress + i)}={registers[i]}");
                }
            }
        }

        [TestMethod]
        public void Options()
        {
            string dir = "C:\\Users\\MarkA\\Desktop\\Sofar Information\\SofarController\\bin\\Debug\\net8.0-windows\\options.txt"; //""; //"C:\\"

            if (File.Exists(dir))
            {
                StreamReader sr = new StreamReader(dir);

                var line = sr.ReadLine();
            }
        }

        [TestMethod]
        public void TestEnvoy()
        {
            //var res = ExecuteCurl("curl -u, --user Mark.Anders@Aspentech.com[:Greenhouse1] https:enlighten.enphaseenergy.com/entrez-auth-token?serial_num=122145028178");
            //string res2 = ExecuteCurl("curl https://192.168.1.195/api/v1/production/inverters");

            //var res3 = ExecuteCurl("curl -f -k -H Accept: \"application/json\" -H \" Authorization: \"Anders PV Greenhouse1\" -X GET https://192.196.1.195/api/v1/production/inverters");
            var res4 = ExecuteCurl("curl - f - k - H 'Accept: application/json' - H 'Authorization: Bearer eyJraWQiOiI3ZDEwMDA1ZC03ODk5LTRkMGQtYmNiNC0yNDRmOThlZTE1NmIiLCJ0eXAiOiJKV1QiLCJhbGciOiJFUzI1NiJ9.eyJhdWQiOiIxMjIxNDUwMjgxNzgiLCJpc3MiOiJFbnRyZXoiLCJlbnBoYXNlVXNlciI6Im93bmVyIiwiZXhwIjoxNzU4NTU0Njg1LCJpYXQiOjE3MjcwMTg2ODUsImp0aSI6ImYyMjUyN2YwLTRkYjEtNGJkMC1iZmI4LTYwZmJmNTcwZDA1ZSIsInVzZXJuYW1lIjoibWFyay5hbmRlcnNAYXNwZW50ZWNoLmNvbSJ9.hix_jzz3prOvEjy565S3eKUCPWB_GK6vf__-4fsC4uOUsYHg9Uv8S5EIgkIgpdDBNA4MtwiQG2EIit5iHCl_ew' - X GET http://192.168.1.195/api/v1/production/inverters");
            HttpClient httpClient = new HttpClient();

            //specify to use TLS 1.2 as default connection
            System.Net.ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

            httpClient.BaseAddress = new Uri("https://enlighten.enphaseenergy.com/");
            httpClient.DefaultRequestHeaders.Accept.Clear();
            string authorization = $"Mark.Anders@Aspentech.com:Greenhouse1";
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.ASCII.GetBytes(authorization)));
            //  using HttpResponseMessage response = httpClient.GetAsync("http://enlighten.enphaseenergy.com");

            var user = "Mark.Anders@Aspentech.com";
            var password = "Greenhouse1";
            var envoy_serial = "122145028178";
            var data = "Mark.Anders@Aspntech.com";

            string command = "curl - X POST http://enlighten.enphaseenergy.com/login/login.json? -F user[email]=$Mark.Anders@Aspentech.com -F user[password]=$Greenhouse1  | jq -r .session_id";

            var session_id = ExecuteCurl(command);

            //response = requests.post("https://enlighten.enphaseenergy.com/login/login.json", data = data) response_data = json.loads(response.text);
            //var data = { 'session_id': response_data['session_id'], 'serial_num': envoy_serial, 'username': user };
            //response = requests.post('https://entrez.enphaseenergy.com/tokens', json = data);
            //var token_raw = response.text;*/
        }

        private static async Task GetAsync(HttpClient httpClient)
        {
            using HttpResponseMessage response = await httpClient.GetAsync("todos/3");

            // response.EnsureSuccessStatusCode()                .WriteRequestToConsole();

            var jsonResponse = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"{jsonResponse}\n");

            // Expected output:
            //   GET https://jsonplaceholder.typicode.com/todos/3 HTTP/1.1
            //   {
            //     "userId": 1,
            //     "id": 3,
            //     "title": "fugiat veniam minus",
            //     "completed": false
            //   }
        }

        public class EnvoyData()
        {
            // "serialNumber": "482203155321",
            //"lastReportDate": 1727011306,
            //"devType": 1,
            //"lastReportWatts": 53,
            //"maxReportWatts": 182
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

        [TestMethod]
        public void SendParameters()
        {
            int Case = 2;
            byte Slave = 1;
            ushort[] res = [4];
            ushort WorkModeAddress = 0x1200, TOUCaseAddress = 0x1207, TOUEnableAddress = 0x120F;
            ushort Case1 = 0, Case2 = 1;
            ushort Enable = 1, Disable = 0;
            ushort AutoMode = 0, TOUMode = 1;

            SerialPort port = new("COM2")
            {
                // configure serial port
                BaudRate = 9600,
                DataBits = 8,
                Parity = Parity.None,
                StopBits = StopBits.One
            };
            port.Open();

            //  var machine = new ModbusMachine("1", ModbusType.Tcp, "10.10.18.251:502", addressUnits, true, 2, 0, Endian.BigEndianLsb);

            ushort TimeStart = 0;
            ushort TimeEnd = 0;
        }

        public ushort ModRTU_CRC(ushort[] buf, int len)
        {
            ushort crc = 0xFFFF;

            for (int pos = 0; pos < len; pos++)
            {
                crc ^= (ushort)buf[pos];          // XOR byte into least sig. byte of crc

                for (int i = 8; i != 0; i--)
                {    // Loop over each bit
                    if ((crc & 0x0001) != 0)
                    {      // If the LSB is set
                        crc >>= 1;                    // Shift right and XOR 0xA001
                        crc ^= 0xA001;
                    }
                    else                            // Else LSB is not set
                        crc >>= 1;                    // Just shift right
                }
            }
            /* Note, this number has low and high bytes swapped, so use it accordingly (or swap bytes -
            here is a simple example: crc =  ((crc>>8) | (crc<<8); <- simple swap, if you need it */

            return crc;
        }
    }
}
