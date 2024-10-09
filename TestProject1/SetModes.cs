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
            ushort WorkModeAddress = 0x1200, TOUCaseAddress = 0x1207, TOUEnableAddress = 0x120F,
                TOUForcedChargingSartTime = 0x1208, TOUForcedChargingEndTime = 0x1209,
                TOUForcedChargingSOC = 0x120A, TOUForcedChargingPower = 0x120B,
                TOUForcedChargingStartingDate = 0x120C, TOUForcedChargingEndDate = 0x120D, 
                TOUForcedChargingDays = 0x120E;

            ushort Case1 = 0, Case2 = 1;
            ushort Enable = 1, Disable = 0;
            ushort AutoMode = 0, TOUMode = 1;

            ushort Starttime = ByteHelper.UShort(1, 30);
            ushort endtime = ByteHelper.UShort(6, 30);

            ushort sdate = ByteHelper.UShort(1, 1);
            ushort edate = ByteHelper.UShort(12, 31);
            ushort Power = 3000, SOC = 90;

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
            var res1 = master.ReadHoldingRegisters(Slave, TOUCaseAddress, 1)[0];  
            var res2 = master.ReadHoldingRegisters(Slave, TOUForcedChargingSartTime, 1)[0];  
            var res3 = master.ReadHoldingRegisters(Slave, TOUForcedChargingEndTime, 1)[0];  
            var res4 = master.ReadHoldingRegisters(Slave, TOUForcedChargingSOC, 1)[0];  
            var res5 = master.ReadHoldingRegisters(Slave, TOUForcedChargingPower, 1)[0];  
            var res6 = master.ReadHoldingRegisters(Slave, TOUForcedChargingStartingDate, 1)[0];  
            var res7 = master.ReadHoldingRegisters(Slave, TOUForcedChargingEndDate, 1)[0];  
            var res8 = master.ReadHoldingRegisters(Slave, TOUForcedChargingDays, 1)[0];  
            var res9 = master.ReadHoldingRegisters(Slave, TOUEnableAddress, 1)[0];

            master.WriteMultipleRegisters(Slave, TOUCaseAddress, [Case1]);//, 0, 100, 0, 1]);

            master.WriteMultipleRegisters(Slave, WorkModeAddress, [(ushort)WorkMode.TOU]);
            master.WriteMultipleRegisters(Slave, TOUCaseAddress, [Case1, Starttime, endtime, SOC, Power, sdate, edate, 255, 1]);//, 0, 100, 0, 1]);
            master.WriteMultipleRegisters(Slave, TOUCaseAddress, [Case1, Starttime, endtime, SOC, Power, sdate, edate, 255, 1]);//, 0, 100, 0, 1]);
            master.WriteMultipleRegisters(Slave, WorkModeAddress, [(ushort)WorkMode.TOU]);

            //master.WriteMultipleRegisters(Slave, TOUCaseAddress, [0]);
            //master.WriteMultipleRegisters(Slave, TOUCaseAddress, [1]);
            //master.WriteMultipleRegisters(Slave, TOUCaseAddress, [0]);

            res0 = master.ReadHoldingRegisters(Slave, WorkModeAddress, 1)[0];  // Enable
            res1 = master.ReadHoldingRegisters(Slave, TOUCaseAddress, 1)[0]; 
            res2 = master.ReadHoldingRegisters(Slave, TOUForcedChargingSartTime, 1)[0]; 
            res3 = master.ReadHoldingRegisters(Slave, TOUForcedChargingEndTime, 1)[0]; 
            res4 = master.ReadHoldingRegisters(Slave, TOUForcedChargingSOC, 1)[0]; 
            res5 = master.ReadHoldingRegisters(Slave, TOUForcedChargingPower, 1)[0]; 
            res6 = master.ReadHoldingRegisters(Slave, TOUForcedChargingStartingDate, 1)[0]; 
            res7 = master.ReadHoldingRegisters(Slave, TOUForcedChargingEndDate, 1)[0]; 
            res8 = master.ReadHoldingRegisters(Slave, TOUForcedChargingDays, 1)[0]; 
            res9 = master.ReadHoldingRegisters(Slave, TOUEnableAddress, 1)[0]; //enabled

            //master.WriteMultipleRegisters(Slave, TOUCaseAddress, [1, Starttime, endtime, 90, 2500, sdate, edate, 255, 1]);
            //master.WriteMultipleRegisters(Slave, WorkModeAddress, [(ushort)WorkMode.TOU]);
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
        public void TestAllRegisters ()
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
            IModbusMaster modbus = factory.CreateRtuMaster(port);

            //Debug.Print("Scanning input registers");


            /*for (ushort register_addr = 30000; register_addr <= 39999; register_addr++)
                try
                {
                    var val = modbus.ReadInputRegisters(1, register_addr, 1)[0];
                    Debug.Print("Register: {x:05}\t\tValue: {val:05} ({val:#06x})");
                }
                catch { }
            
            Debug.Print("Finished scanning input registers");*/
            Debug.Print("Scanning holding registers");
            
            for (ushort register_addr = 0x1200; register_addr <= 0x1300; register_addr++)
                try
                {
                    var val = modbus.ReadHoldingRegisters(1, register_addr, 1)[0];
                    //var val = modbus.ReadInputs(1, register_addr, 1)[0];
                    Debug.Print("Register: " + register_addr.ToString("x") + " " + val.ToString());
                }
                catch { }
            
            Debug.Print("Finished scanning holding registers");
        }
    }
}

