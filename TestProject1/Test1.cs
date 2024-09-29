using NModbus;
using NModbus.Serial;
using SofarController;
using SolarManCSharp;
using System.IO.Ports;
using System.Net.Sockets;

namespace TestProject1
{
    [TestClass]
    public class Test1
    {
        [TestMethod]
        public void TestScript()
        {
            /*  private readonly ScriptEngine engine;
          engine = char#

              byte u = ByteHelper.UpByte(s);
              byte l = ByteHelper.LowerByte(s);

              ushort s2 = ByteHelper.UShort(l, u);*/
        }

        [TestMethod]
        public void TestBytes()
        {
            ushort s = 3000;

            byte u = ByteHelper.UpByte(s);
            byte l = ByteHelper.LowerByte(s);

            ushort s2 = ByteHelper.UShort(u, l);
        }

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

        // var res = master.ReadHoldingRegisters(1, 0x120F, 1);

        [TestMethod]
        public void TestTOUMode()
        {
            int Case = 2;
            byte Slave = 1;
            ushort WorkModeAddress = 0x1200, TOUCaseAddress = 0x1207, TOUEnableAddress = 0x120F;
            ushort Case1 = 0, Case2 = 1;
            ushort Enable = 1, Disable = 0;
            ushort AutoMode = 0, TOUMode = 1;

            ushort Starttime = ByteHelper.UShort(1, 30);
            ushort endtime = ByteHelper.UShort(4, 30);

            ushort sdate = ByteHelper.UShort(1, 1);
            ushort edate = ByteHelper.UShort(12, 31);

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

            var res0 = master.ReadHoldingRegisters(Slave, WorkModeAddress, 1)[0];  // Enable
            var res1 = master.ReadHoldingRegisters(Slave, 0x1207, 1)[0];  // Enable
            var res2 = master.ReadHoldingRegisters(Slave, 0x1208, 1)[0];  // Enable
            var res3 = master.ReadHoldingRegisters(Slave, 0x1209, 1)[0];  // Enable
            var res4 = master.ReadHoldingRegisters(Slave, 0x120A, 1)[0];  // Enable
            var res5 = master.ReadHoldingRegisters(Slave, 0x120B, 1)[0];  // Enable
            var res6 = master.ReadHoldingRegisters(Slave, 0x120C, 1)[0];  // Enable
            var res7 = master.ReadHoldingRegisters(Slave, 0x120d, 1)[0];  // Enable
            var res8 = master.ReadHoldingRegisters(Slave, 0x120e, 1)[0];  // Enable
            var res9 = master.ReadHoldingRegisters(Slave, 0x120f, 1)[0];  // Enable

            master.WriteMultipleRegisters(Slave, WorkModeAddress, [(ushort)WorkMode.TOU]);
            master.WriteMultipleRegisters(Slave, TOUCaseAddress, [0, Starttime, endtime, 90, 2500, sdate, edate, 255, 1]);//, 0, 100, 0, 1]);

            res0 = master.ReadHoldingRegisters(Slave, WorkModeAddress, 1)[0];  // Enable
            res1 = master.ReadHoldingRegisters(Slave, 0x1207, 1)[0];  // Enable
            res2 = master.ReadHoldingRegisters(Slave, 0x1208, 1)[0];  // Enable
            res3 = master.ReadHoldingRegisters(Slave, 0x1209, 1)[0];  // Enable
            res4 = master.ReadHoldingRegisters(Slave, 0x120A, 1)[0];  // Enable
            res5 = master.ReadHoldingRegisters(Slave, 0x120B, 1)[0];  // Enable
            res6 = master.ReadHoldingRegisters(Slave, 0x120C, 1)[0];  // Enable
            res7 = master.ReadHoldingRegisters(Slave, 0x120d, 1)[0];  // Enable
            res8 = master.ReadHoldingRegisters(Slave, 0x120e, 1)[0];  // Enable
            res9 = master.ReadHoldingRegisters(Slave, 0x120f, 1)[0];  // Enable

            master.WriteMultipleRegisters(Slave, TOUCaseAddress, [1, Starttime, endtime, 90, 2500, sdate, edate, 255, 1]);
            master.WriteMultipleRegisters(Slave, WorkModeAddress, [(ushort)WorkMode.TOU]);
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

            [TestMethod]
        public void TestMode()
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

            ModbusFactory factory = new();
            IModbusMaster master = factory.CreateRtuMaster(port);

            master.WriteMultipleRegisters(Slave, WorkModeAddress, [(ushort)WorkMode.Auto]); // working mode
            master.WriteMultipleRegisters(Slave, 0x1214, [(ushort)1000]);
            master.WriteMultipleRegisters(Slave, WorkModeAddress, [(ushort)WorkMode.Auto]); // working mode
        }

        [TestMethod]
        public void TestModeTCP()
        {
            int Case = 2;
            byte Slave = 1;
            ushort[] res = [4];
            ushort WorkModeAddress = 0x1200, TOUCaseAddress = 0x1207, TOUEnableAddress = 0x120F;
            ushort Case1 = 0, Case2 = 1;
            ushort Enable = 1, Disable = 0;
            ushort AutoMode = 0, TOUMode = 1;

            TcpClient client = new TcpClient("192.168.1.228", 8899);

            ModbusFactory factory = new();
            IModbusMaster master = factory.CreateMaster(client);

            master.WriteMultipleRegisters(Slave, WorkModeAddress, [(ushort)WorkMode.Auto]); // working mode
            master.WriteMultipleRegisters(Slave, 0x1214, [(ushort)1000]);
            master.WriteMultipleRegisters(Slave, WorkModeAddress, [(ushort)WorkMode.Auto]); // working mode
        }

        [TestMethod]
        public void SetAutoMode()
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

            ModbusFactory factory = new();
            IModbusMaster master = factory.CreateRtuMaster(port);

            master.WriteMultipleRegisters(Slave, WorkModeAddress, [(ushort)0]); // working mode
        }

        [TestMethod]
        public void TestTimedMode()
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

            ModbusFactory factory = new();
            IModbusMaster master = factory.CreateRtuMaster(port);

            ushort TimeStart = 0;
            ushort TimeEnd = 0;

            master.WriteMultipleRegisters(Slave, 0x1201, [0, 2871, 3072, 5944, 2500, 2500]); // working mode
            master.WriteMultipleRegisters(Slave, WorkModeAddress, [(ushort)WorkMode.TIMED]); // working mode

            var res1 = master.ReadHoldingRegisters(Slave, 0x1202, 1)[0];  // Enable
        }

        [TestMethod]
        public void TestCRC()
        {
            byte[] buffer2 = new byte[] { 1, 16, 18, 1, 0, 6, 12, 0, 0, 11, 55, 12, 0, 23, 56, 9, 196, 9, 196 };

            var crc = CalculateCrc(buffer2);
        }

        public static byte[] CalculateCrc(byte[] data)
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            ushort crc = ushort.MaxValue;

            foreach (byte b in data)
            {
                byte tableIndex = (byte)(crc ^ b);
                crc >>= 8;
                crc ^= CrcTable[tableIndex];
            }

            return BitConverter.GetBytes(crc);
        }

        private static readonly ushort[] CrcTable =
{
            0X0000, 0XC0C1, 0XC181, 0X0140, 0XC301, 0X03C0, 0X0280, 0XC241,
            0XC601, 0X06C0, 0X0780, 0XC741, 0X0500, 0XC5C1, 0XC481, 0X0440,
            0XCC01, 0X0CC0, 0X0D80, 0XCD41, 0X0F00, 0XCFC1, 0XCE81, 0X0E40,
            0X0A00, 0XCAC1, 0XCB81, 0X0B40, 0XC901, 0X09C0, 0X0880, 0XC841,
            0XD801, 0X18C0, 0X1980, 0XD941, 0X1B00, 0XDBC1, 0XDA81, 0X1A40,
            0X1E00, 0XDEC1, 0XDF81, 0X1F40, 0XDD01, 0X1DC0, 0X1C80, 0XDC41,
            0X1400, 0XD4C1, 0XD581, 0X1540, 0XD701, 0X17C0, 0X1680, 0XD641,
            0XD201, 0X12C0, 0X1380, 0XD341, 0X1100, 0XD1C1, 0XD081, 0X1040,
            0XF001, 0X30C0, 0X3180, 0XF141, 0X3300, 0XF3C1, 0XF281, 0X3240,
            0X3600, 0XF6C1, 0XF781, 0X3740, 0XF501, 0X35C0, 0X3480, 0XF441,
            0X3C00, 0XFCC1, 0XFD81, 0X3D40, 0XFF01, 0X3FC0, 0X3E80, 0XFE41,
            0XFA01, 0X3AC0, 0X3B80, 0XFB41, 0X3900, 0XF9C1, 0XF881, 0X3840,
            0X2800, 0XE8C1, 0XE981, 0X2940, 0XEB01, 0X2BC0, 0X2A80, 0XEA41,
            0XEE01, 0X2EC0, 0X2F80, 0XEF41, 0X2D00, 0XEDC1, 0XEC81, 0X2C40,
            0XE401, 0X24C0, 0X2580, 0XE541, 0X2700, 0XE7C1, 0XE681, 0X2640,
            0X2200, 0XE2C1, 0XE381, 0X2340, 0XE101, 0X21C0, 0X2080, 0XE041,
            0XA001, 0X60C0, 0X6180, 0XA141, 0X6300, 0XA3C1, 0XA281, 0X6240,
            0X6600, 0XA6C1, 0XA781, 0X6740, 0XA501, 0X65C0, 0X6480, 0XA441,
            0X6C00, 0XACC1, 0XAD81, 0X6D40, 0XAF01, 0X6FC0, 0X6E80, 0XAE41,
            0XAA01, 0X6AC0, 0X6B80, 0XAB41, 0X6900, 0XA9C1, 0XA881, 0X6840,
            0X7800, 0XB8C1, 0XB981, 0X7940, 0XBB01, 0X7BC0, 0X7A80, 0XBA41,
            0XBE01, 0X7EC0, 0X7F80, 0XBF41, 0X7D00, 0XBDC1, 0XBC81, 0X7C40,
            0XB401, 0X74C0, 0X7580, 0XB541, 0X7700, 0XB7C1, 0XB681, 0X7640,
            0X7200, 0XB2C1, 0XB381, 0X7340, 0XB101, 0X71C0, 0X7080, 0XB041,
            0X5000, 0X90C1, 0X9181, 0X5140, 0X9301, 0X53C0, 0X5280, 0X9241,
            0X9601, 0X56C0, 0X5780, 0X9741, 0X5500, 0X95C1, 0X9481, 0X5440,
            0X9C01, 0X5CC0, 0X5D80, 0X9D41, 0X5F00, 0X9FC1, 0X9E81, 0X5E40,
            0X5A00, 0X9AC1, 0X9B81, 0X5B40, 0X9901, 0X59C0, 0X5880, 0X9841,
            0X8801, 0X48C0, 0X4980, 0X8941, 0X4B00, 0X8BC1, 0X8A81, 0X4A40,
            0X4E00, 0X8EC1, 0X8F81, 0X4F40, 0X8D01, 0X4DC0, 0X4C80, 0X8C41,
            0X4400, 0X84C1, 0X8581, 0X4540, 0X8701, 0X47C0, 0X4680, 0X8641,
            0X8201, 0X42C0, 0X4380, 0X8341, 0X4100, 0X81C1, 0X8081, 0X4040
        };
    }
}