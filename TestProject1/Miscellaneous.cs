using NModbus;
using NModbus.Serial;
using SofarController;
using SolarManCSharp;
using System.IO.Ports;
using System.Net.Sockets;

namespace Tests
{
    [TestClass]
    public class Miscellaneous
    {
        [TestMethod]
        public void TestWriteRegister()
        {
            SerialPort port = new("COM2")
            {
                // configure serial port
                BaudRate = 9600,
                DataBits = 8,
                Parity = Parity.None,
                StopBits = StopBits.One
            };
            port.Open();

            ModbusFactory factory = new();
            IModbusMaster master = factory.CreateRtuMaster(port);

            //var res = master.ReadHoldingRegisters(1, 0x1216, 1);

            var res = master.ReadHoldingRegisters(1, 0x1200, 1);
            master.WriteSingleRegister(1, 0x1200, (ushort)1);

            //master.WriteMultipleRegisters(1, 0x1200, [(ushort)0]);
            master.WriteMultipleRegisters(1, 0x1200, [(UInt16)1]);
            res = master.ReadHoldingRegisters(1, 0x1200, 1);
        }

        [TestMethod]
        public void GetDOD()
        {
            byte Slave = 1;
            ushort DODAddress = 0x10B9;
            
            SerialPort port = new("COM2")
            {
                // configure serial port
                BaudRate = 9600,
                DataBits = 8,
                Parity = Parity.None,
                StopBits = StopBits.One
            };
            port.Open();

            ModbusFactory factory = new();
            IModbusMaster master = factory.CreateRtuMaster(port);

            var res8 = master.ReadInputRegisters(Slave, DODAddress, 1);  // Enable
        }
    }
}