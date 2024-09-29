using Microsoft.VisualStudio.TestPlatform.ObjectModel.Client;
using NModbus;
using SolarManCSharp;
using System.ComponentModel;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace TestProject1
{
    [TestClass]
    public class TestSolarman
    {
        [TestMethod]
        public void TestGetMODBUSFrame()
        {
            var sock = new System.Net.Sockets.Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            var serverIP = IPAddress.Parse("192.168.1.228");
            var serverFullAddr = new IPEndPoint(serverIP, 8899);
            sock.Connect(serverFullAddr);

            var factory = new ModbusFactory();
            IModbusMaster master = factory.CreateMaster(sock);
            byte slaveId = 1;
            ushort startAddress = 0x1200;
            ushort numInputs = 1;

            //Bytes modbusFrame = master.GetModbusFrame(slaveId, startAddress, numInputs); // checked ok
            //PySolarmanV5 V5 = new("192.168.1.228", 809805460, 8899, slaveId, false);
            //byte[] V5_Frame = V5._v5_frame_encoder(modbusFrame).Bytearray; // seems ok


           // master.WriteMultipleRegisters(slaveId, startAddress, [0], true);
            var res = master.ReadHoldingRegisters(slaveId, startAddress, 1, true);

            // byte[] V5_Frame = new byte[] { 165, 23, 0, 16, 69, 7, 0, 148, 166, 68, 48, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 3, 18, 0, 0, 4, 65, 113, 239, 21 };

            // SendRequest(V5_Frame);


            // var workmode = master.ReadHoldingRegisters(slaveId, startAddress, 1, V5_Frame);

            /*   [TestMethod]
               public void Solarman()
               {
                   PySolarmanV5 modbus = new PySolarmanV5("192.168.1.228", 809805460, 8899, 1, false);
                   Debug.Print(modbus.read_holding_registers(4608, 4).ToString());
                   modbus.write_multiple_holding_registers(4608, [0]);

                   modbus.disconnect();
               }*/
        }

        [TestMethod]
        public void SendRequest()
        {
            byte[] V5_Frame = new byte[] { 165, 23, 0, 16, 69, 7, 0, 148, 166, 68, 48, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 3, 18, 0, 0, 4, 65, 113, 239, 21 };
            byte[] V5_Frame2 = new byte[] { 165, 26, 0, 16, 69, 195, 0, 148, 166, 68, 48, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 16, 18, 0, 0, 1, 2, 0, 0, 148, 81, 237, 21 };

            using System.Net.Sockets.Socket socket = new System.Net.Sockets.Socket(SocketType.Stream, ProtocolType.Tcp);
            socket.Connect("192.168.1.228", 8899);
            bool connected = socket.Connected;

            socket.Send(V5_Frame2);
            var t = socket.Available;

            // Do minimalistic buffering assuming ASCII response
            byte[] responseBytes = new byte[256];
            char[] responseChars = new char[256];

            int bytesReceived = socket.Receive(responseBytes);

            // Convert byteCount bytes to ASCII characters using the 'responseChars' buffer as destination
            int charCount = Encoding.ASCII.GetChars(responseBytes, 0, bytesReceived, responseChars, 0);

            for (int i = 0; i < charCount; i++)
            {
                // Print the contents of the 'responseChars' buffer to Console.Out
                Debug.Print(((byte)responseChars[i]).ToString());
            }
        }

        [TestMethod]
        public void ByteConverterTest()
        {
            ByteConverter byteConverter = new ByteConverter();
            int a = 809805460;
            var res = BitConverter.GetBytes(a);

        }
    }
}