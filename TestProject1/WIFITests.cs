using NModbus;
using SolarManCSharp;
using System.Diagnostics;
using System.IO.Ports;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Sockets;
using System.Text;

// https//:enlighten.enphaseenergy.com/entrez-auth-token?serial_num=122145028178
//https://Mark.Anders@Aspentech.com:Greenhouse1@entrez.enphaseenergy.com/
//curl -f -k -H 'Accept: application/json' -H 'Authorization: Bearer eyJraWQiOiI3ZDEwMDA1ZC03ODk5LTRkMGQtYmNiNC0yNDRmOThlZTE1NmIiLCJ0eXAiOiJKV1QiLCJhbGciOiJFUzI1NiJ9.eyJhdWQiOiIxMjIxNDUwMjgxNzgiLCJpc3MiOiJFbnRyZXoiLCJlbnBoYXNlVXNlciI6Im93bmVyIiwiZXhwIjoxNzU4NTU0Njg1LCJpYXQiOjE3MjcwMTg2ODUsImp0aSI6ImYyMjUyN2YwLTRkYjEtNGJkMC1iZmI4LTYwZmJmNTcwZDA1ZSIsInVzZXJuYW1lIjoibWFyay5hbmRlcnNAYXNwZW50ZWNoLmNvbSJ9.hix_jzz3prOvEjy565S3eKUCPWB_GK6vf__-4fsC4uOUsYHg9Uv8S5EIgkIgpdDBNA4MtwiQG2EIit5iHCl_ew' -X GET http://192.168.1.195/api/v1/production/inverters
//curl -f -k -H 'Accept: application/json' -H 'Authorization: Bearer eyJraWQiOiI3ZDEwMDA1ZC03ODk5LTRkMGQtYmNiNC0yNDRmOThlZTE1NmIiLCJ0eXAiOiJKV1QiLCJhbGciOiJFUzI1NiJ9.eyJhdWQiOiIxMjIxNDUwMjgxNzgiLCJpc3MiOiJFbnRyZXoiLCJlbnBoYXNlVXNlciI6Im93bmVyIiwiZXhwIjoxNzU4NTU0Njg1LCJpYXQiOjE3MjcwMTg2ODUsImp0aSI6ImYyMjUyN2YwLTRkYjEtNGJkMC1iZmI4LTYwZmJmNTcwZDA1ZSIsInVzZXJuYW1lIjoibWFyay5hbmRlcnNAYXNwZW50ZWNoLmNvbSJ9.hix_jzz3prOvEjy565S3eKUCPWB_GK6vf__-4fsC4uOUsYHg9Uv8S5EIgkIgpdDBNA4MtwiQG2EIit5iHCl_ew' -X GET http://192.168.1.195/api/v4/production/inverters
namespace Tests
{
    [TestClass]
    public class WIFITests
    {
        bool V5Logger = true;

        [TestMethod]
        public void TestWIFIData()
        {
            var sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            IPAddress serverIP = IPAddress.Parse("192.168.1.228");
            IPEndPoint serverFullAddr = new(serverIP, 8899);
            sock.Connect(serverFullAddr);

            var factory = new ModbusFactory();
            IModbusMaster master = factory.CreateMaster(sock);

            byte slaveId = 1;
            ushort startAddress = 0x210;
            ushort numInputs = 1;
            //ushort www = 0x42c80083

            ushort power, cycles;

            for (int i = 0; i <= 1; i++)
            {
                Thread.Sleep(1000);
               // sock.Disconnect(true);
                //sock.Connect(serverFullAddr);
                cycles = master.ReadHoldingRegisters("Battery Cycles", slaveId, 0x22C, numInputs,V5Logger)[0];
                power = master.ReadHoldingRegisters("Battery ChargeLevel", slaveId, startAddress, numInputs, V5Logger)[0];
                var STime = master.ReadHoldingRegisters("TOU",1, 0x1208, 1, V5Logger); // Start time
                //Debug.Print(cycles.ToString());
                //Debug.Print(power.ToString());
                if (power == 0 || power > 100)
                    Debugger.Break();
            }
        }

        [TestMethod]
        public void TestWIFIControl()
        {
            using (TcpClient client = new TcpClient("192.168.1.228", 8899))
            {
                var factory = new ModbusFactory();
                
                IModbusMaster master = factory.CreateMaster(client);

                byte slaveId = 1;
                ushort startAddress = 0x1200;
                ushort numInputs = 1;
                //ushort www = 0x42c80083

                master.WriteSingleRegister(slaveId, startAddress, 1); // wont work no V5Logger:)
                ushort[] registers = master.ReadHoldingRegisters(slaveId, startAddress, numInputs, V5Logger);

                for (int i = 0; i < numInputs; i++)
                {
                    Console.WriteLine($"Input {(startAddress + i)}={registers[i]}");
                }
            }
        }
    }
}
