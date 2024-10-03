using NModbus;
using NModbus.Serial;
using SofarController;
using SolarManCSharp;
using System.Diagnostics;
using System.IO.Ports;
using System.Management;

namespace Tests
{

    [TestClass]
    public class SetModes
    {
        [TestMethod]
        public void SetAutoMode()
        {

            List<String> allPorts = new List<String>();
            foreach (String portName in System.IO.Ports.SerialPort.GetPortNames())
            {
                allPorts.Add(portName);
            }


            string[] portNames = System.IO.Ports.SerialPort.GetPortNames();
            Debug.Print("Available ports:");
            foreach (string PortAvailable in portNames)
            {
                Debug.Print(PortAvailable);
            }

            ManagementObjectCollection collection;
            using (var searcher = new ManagementObjectSearcher(@"Select * From Win32_USBHub"))
            {
                collection = searcher.Get();
                foreach (var device in collection)
                {
                    var deviceId = (string)device.GetPropertyValue("DeviceID");
                    var pnpDeviceId = (string)device.GetPropertyValue("PNPDeviceID");
                    var descr = (string)device.GetPropertyValue("Description");
                    var classCode = device.GetPropertyValue("ClassCode"); //null here
                }
            }

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
            Debug.Print(port.CDHolding.ToString());
          
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

    }
}
