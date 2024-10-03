using NModbus;
using NModbus.Serial;
using SolarManCSharp;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.IO.Ports;
using System.Net;
using System.Net.Sockets;

namespace SofarController
{
    public enum WorkMode
    { Auto, TOU, TIMED, PASSIVE }

    public enum eData
    {
        WorkMode,
        InverterFreq,
        BatteryChargeDischargePwr,
        BatteryCycles,
        BatteryChrgLevel,
        BatteryTemp,
        GridIOPwr,
        HouseConsumptionPwr,
        InternalIOPwr,
        PVGenerationPwr,
        EPSOutputV,
        EPSOutputPwr,
        TodayGeneratedSolarWh,
        TodaySoldSolarWh,
        TodayBoughtGridWh,
        TodayConsumptionWh,
        TotalLoadConsumptionH,
        TotalLoadConsumption,
        InverterInternalTemp,
        InverterHeatsinkTemp,
        InverterRunningState
    }

    public class Sofar : IDisposable
    {
        public ConcurrentDictionary<eData, double> Data = new();
        public WorkMode mode;
        private SerialPort port;
        private ModbusFactory factory = new ModbusFactory();
        private IModbusMaster master;

        public const ushort WorkModeAddress = 0x1200, TOUCaseAddress = 0x1207, TOUEnableAddress = 0x120F;
        public const ushort Case1 = 0, Case2 = 1, Case3 = 2, Case4 = 3;
        public const ushort Enable = 1, Disable = 0;
        public const ushort AutoMode = 0, TOUMode = 1, TimedMode = 2, PassiveMode = 3;

        public TOUData TOU1;
        public TOUData TOU2;
        public TOUData TOU3;
        public TOUData TOU4;
        public TOUData TOUPassive = new(); // Cant Read Passive mode

        public bool DataAvailable = false;

        private Socket sock;
        private IPAddress serverIP;
        private IPEndPoint serverFullAddr;

        public void UpdateTOUData(int i, OptionData options)
        {
            if (i > 0)
                ReadTimeOfUseParams(i, options);
            else
                ReadTimeOfUseParamsCase0(options);

            bool enable;

            if (TOUEnabled == 1)
            {
                enable = true;
            }
            else
            {
                enable = false;
            }

            string StartTime = StartTimeHr + ":" + StartTimeMin;
            string EndTime = EndTimeHr + ":" + EndTimeMin;

            string StartDate = StartDay + "/" + StartMonth;
            string EndDate = EndDay + "/" + EndMonth;

            switch (i)
            {
                case 0:
                    TOU1 = new();
                    TOU1.Update(i, false, "", "", "", "", 0, 0);
                    TOU1.Update(i, enable, StartTime, EndTime, StartDate, EndDate, soc, pow);
                    break;

                case 1:
                    TOU2 = new();
                    TOU2.Update(i, false, "", "", "", "", 0, 0);
                    TOU2.Update(i, enable, StartTime, EndTime, StartDate, EndDate, soc, pow);
                    break;

                case 2:
                    TOU3 = new();
                    TOU3.Update(i, false, "", "", "", "", 0, 0);
                    TOU3.Update(i, enable, StartTime, EndTime, StartDate, EndDate, soc, pow);
                    break;

                case 3:
                    TOU4 = new();
                    TOU4.Update(i, false, "", "", "", "", 0, 0);
                    TOU4.Update(i, enable, StartTime, EndTime, StartDate, EndDate, soc, pow);
                    break;
            }
        }

        public Sofar(OptionData options)
        {
            setPortOrSockets(options);
        }

        public void setPortOrSockets(OptionData options)
        {
            if (options.WIFI)
            {
                if (port is not null)
                    port.Close();
                if (sock != null)
                    sock.Close();
                sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                serverIP = IPAddress.Parse(options.IPAddress.ToString());
                serverFullAddr = new IPEndPoint(serverIP, options.IPPort);
                sock.Connect(serverFullAddr);
                factory = new ModbusFactory();
                master = factory.CreateMaster(sock);
            }
            else
            {
                if (sock is not null)
                    sock.Close();

                port = new(options.COMPort)
                {
                    // configure serial port
                    BaudRate = 9600,
                    DataBits = 8,
                    Parity = Parity.None,
                    StopBits = StopBits.One
                };

                for (int i = 0; i < 5; i++)
                {
                    try
                    {
                        port.Open();
                        master = factory.CreateRtuMaster(port);
                        break;
                    }
                    catch
                    {
                        Thread.Sleep(5000);
                        MessageBox.Show("Port is preoccupied, will try 5 times");
                    }
                }
            }
        }

        /// <summary>
        /// Name, location, no of data, multiplier, signed
        /// </summary>
        /// <returns></returns>
        public List<Tuple<string, int, double, double, bool>> GetData(OptionData options, bool UpdateTOU)
        {
            master.V5IPAddress = options.IPAddress;
            master.V5IPPort = options.IPPort;
            master.V5SerialNo = options.SerialNo;

            List<Tuple<string, int, double, double, bool>> variables =
            [
                Tuple.Create("Work Mode", 0x1200, 0.0, 1d, false),
                Tuple.Create("Inverter Freq", 0x20c, 0.0, 1 / 100.0, false),
                Tuple.Create("Battery ChargeDischargePwr", 0x20d, 0.0, 0.01d, true),
                Tuple.Create("Battery Cycles", 0x22c, 0.0, 1d, false),
                Tuple.Create("Battery ChargeLevel", 0x210, 0.0, 1d, false),
                Tuple.Create("Battery Temp", 0x211, 0.0, 1d, false),
                Tuple.Create("Grid IO Pwr", 0x212, 0.0, 0.001d, true),
                Tuple.Create("House Consumption Pwr", 0x213, 0.0, 0.001d, false),
                Tuple.Create("Internal IO Pwr", 0x214, 0.0, 0.01d, true),
                Tuple.Create("PV Generation Pwr", 0x215, 0.0, 0.01d, false),
                Tuple.Create("EPS Output V", 0x216, 0.0, 0.1d, false),
                Tuple.Create("EPS Output Pwr", 0x217, 0.0, 1d, false),
                Tuple.Create("TodayGeneratedSolar Wh", 0x218, 0.0, 0.01d, false),
                Tuple.Create("TodaySoldSolar Wh", 0x219, 0.0, 0.01d, false),
                Tuple.Create("TodayBoughtGrid Wh", 0x21a, 0.0, 0.01d, false),
                Tuple.Create("TodayConsumption Wh", 0x21b, 0.0, 0.01d, false),
                Tuple.Create("Total Load Consumption H", 0x222, 0.0, 1d, false), // should be added, hi and low bites
                Tuple.Create("Total Load Consumption", 0x223, 0.0, 1d, false),
                Tuple.Create("Inverter Internal Temp", 0x238, 0.0, 1d, false),
                Tuple.Create("Inverter Heatsink Temp", 0x239, 0.0, 1d, false),
                Tuple.Create("Inverter Running State", 0x200, 0.0, 1d, false),
            ];

            Data.Clear();

            if (master is not null)
            {
                for (int i = 0; i < variables.Count; i++)
                {
                    //                    if (i == 8)
                    //                      Debugger.Break();

                    double val = 0;
                    try
                    {
                        val = master.ReadHoldingRegisters(variables[i].Item1, 1, (ushort)variables[i].Item2, 1, options.WIFI)[0];
                    }
                    catch
                    {
                    }

                    if (val is not 9999)
                    {
                        if (variables[i].Item5)
                        {
                            val = (Int16)val;
                        }

                        //if (i == 8)
                        //    Debugger.Break();

                        val *= variables[i].Item4;

                        Tuple<string, int, double, double, bool> v = variables[i];

                        variables[i] = Tuple.Create(v.Item1, v.Item2, val, v.Item4, v.Item5);

                        Data.TryAdd((eData)i, val);
                    }
                  /*  else
                    {
                        Tuple<string, int, double, double, bool> v = variables[i];

                        variables[i] = Tuple.Create(v.Item1, v.Item2, val, v.Item4, v.Item5);

                        Data.TryAdd((eData)i, val);
                    }*/
                }
            }

            if (UpdateTOU)
                UpdateTOUData(0, options);

            if (Data.ContainsKey(eData.WorkMode))
                mode = (WorkMode)Data[eData.WorkMode];

            DataAvailable = true;

            return variables;
        }

        public WorkMode GetWorkMode(OptionData options)
        {
            int val = 999;
            if (master is not null)
            {
                val = master.ReadHoldingRegisters(1, 0x1200, 1, options.WIFI)[0]; // Inverter Running State
                mode = (WorkMode)val;
            }
            return mode;
        }

        public int GetSOC()
        {
            int val = 999;
            if (master is not null)
            {
                val = master.ReadHoldingRegisters(1, 0x210, 1)[0]; // Inverter Running State
            }
            return val;
        }

        public void SetChargeRate(double ChargeRate)
        {
            if (mode == WorkMode.PASSIVE)
            {
                ushort val = (ushort)ChargeRate;
                master.WriteMultipleRegisters(1, 0x1214, [val]);
            }
            else
            {
                MessageBox.Show("Please set Passive Mode First");
            }
        }

        public double GetChargeRate()
        {
            double val = 999;
            if (mode == WorkMode.PASSIVE)
            {
                val = master.ReadHoldingRegisters(1, 0x1214, 1)[0]; // Inverter Running State
            }
            else
            {
                MessageBox.Show("Please set Passive Mode First");
            }
            return val;
        }

        public void SetPassiveStandby(OptionData options)
        {
            if (mode == WorkMode.PASSIVE)
            {
                ushort val = 0x5555;
                master.WriteMultipleRegisters(1, 0x1212, [val], options.WIFI);
            }
            else
            {
                MessageBox.Show("Please set Passive Mode First");
            }
        }

        public void SetDisChargeRate(double DischargeRate, OptionData optiosn)
        {
            if (mode == WorkMode.PASSIVE)
            {
                ushort val = (ushort)DischargeRate;
                master.WriteMultipleRegisters(1, 0x1213, [val], optiosn.WIFI);
            }
            else
            {
                MessageBox.Show("Please set Passive Mode First");
            }
        }

        public void SetWorkMode(WorkMode mode, OptionData options)
        {
            master.WriteMultipleRegisters(1, 0x1200, [(ushort)mode], options.WIFI);
        }

        public void WriteTimeOfUseParams(ushort RuleNo, TOUData data, OptionData options)
        {
            ushort Starttime = ByteHelper.UShort((byte)data.StartTime.Hour, (byte)data.StartTime.Minute);
            ushort endtime = ByteHelper.UShort((byte)data.EndTime.Hour, (byte)data.EndTime.Minute);

            ushort sdate = ByteHelper.UShort((byte)data.StartDate.Month, (byte)data.StartDate.Day);
            ushort edate = ByteHelper.UShort((byte)data.EndDate.Month, (byte)data.EndDate.Day);

            ushort en;

            if (data.Enabled)
            {
                en = 1;
            }
            else
            {
                en = 0;
            }

            master.WriteMultipleRegisters(1, 0x1207, [RuleNo], options.WIFI);
            master.WriteMultipleRegisters(1, 0x1208, [Starttime], options.WIFI); // Start time
            master.WriteMultipleRegisters(1, 0x1209, [endtime], options.WIFI); // End Time
            master.WriteMultipleRegisters(1, 0x120A, [data.Soc], options.WIFI); // MAX SOC
            master.WriteMultipleRegisters(1, 0x120B, [data.Pow], options.WIFI); // Power
            master.WriteMultipleRegisters(1, 0x120C, [sdate], options.WIFI); // Start Date
            master.WriteMultipleRegisters(1, 0x120D, [edate], options.WIFI); // End Date
            master.WriteMultipleRegisters(1, 0x120F, [en], options.WIFI); // Enabled

            //var res = master.ReadHoldingRegisters(1, 0x120f, 1,options.WIFI);
        }

        private void ReadTimeOfUseParams(int i, OptionData options)
        {
            if (master is not null)
            {
                master.WriteMultipleRegisters(1, 0x1207, [(ushort)i], options.WIFI);

                var STime = master.ReadHoldingRegisters(1, 0x1208, 1, options.WIFI); // Start time
                var ETime = master.ReadHoldingRegisters(1, 0x1209, 1, options.WIFI); // End Time
                var SDate = master.ReadHoldingRegisters(1, 0x120C, 1, options.WIFI); // Start Date
                var EDate = master.ReadHoldingRegisters(1, 0x120D, 1, options.WIFI); // End Date

                enabled = (int)master.ReadHoldingRegisters(1, 0x120F, 1, options.WIFI)[0]; // Enabled

                soc = master.ReadHoldingRegisters(1, 0x120A, 1, options.WIFI)[0]; // MAX SOC
                pow = master.ReadHoldingRegisters(1, 0x120B, 1, options.WIFI)[0]; // Power

                startTimeHr = ByteHelper.UpByte(STime[0]);
                startTimeMin = ByteHelper.LowerByte(STime[0]);

                endTimeHr = ByteHelper.UpByte(ETime[0]);
                endTimeMin = ByteHelper.LowerByte(ETime[0]);

                startMonth = ByteHelper.UpByte(SDate[0]);
                startDay = ByteHelper.LowerByte(SDate[0]);

                endMonth = ByteHelper.UpByte(EDate[0]);
                endDay = ByteHelper.LowerByte(EDate[0]);

                UpdateTOUData(i, options);
            }
        }

        public void ReadTimeOfUseParamsCase0(OptionData options)
        {
            if (master is not null)
            {
                var STime = master.ReadHoldingRegisters(1, 0x1208, 1, options.WIFI); // Start time
                var ETime = master.ReadHoldingRegisters(1, 0x1209, 1, options.WIFI); // End Time
                var SDate = master.ReadHoldingRegisters(1, 0x120C, 1, options.WIFI); // Start Date
                var EDate = master.ReadHoldingRegisters(1, 0x120D, 1, options.WIFI); // End Date

                enabled = (int)master.ReadHoldingRegisters(1, 0x120F, 1, options.WIFI)[0]; // Enabled

                soc = master.ReadHoldingRegisters(1, 0x120A, 1, options.WIFI)[0]; // MAX SOC
                pow = master.ReadHoldingRegisters(1, 0x120B, 1, options.WIFI)[0]; // Power

                startTimeHr = ByteHelper.UpByte(STime[0]);
                startTimeMin = ByteHelper.LowerByte(STime[0]);

                endTimeHr = ByteHelper.UpByte(ETime[0]);
                endTimeMin = ByteHelper.LowerByte(ETime[0]);

                startMonth = ByteHelper.UpByte(SDate[0]);
                startDay = ByteHelper.LowerByte(SDate[0]);

                endMonth = ByteHelper.UpByte(EDate[0]);
                endDay = ByteHelper.LowerByte(EDate[0]);
            }
        }

        private byte startTimeHr;
        private byte startTimeMin;
        private byte endTimeHr;
        private byte endTimeMin;
        private byte startMonth;
        private byte startDay;
        private byte endMonth;
        private byte endDay;
        private ushort soc, pow;
        private int enabled;

        public byte StartTimeHr { get => startTimeHr; set => startTimeHr = value; }
        public byte StartTimeMin { get => startTimeMin; set => startTimeMin = value; }
        public byte EndTimeHr { get => endTimeHr; set => endTimeHr = value; }
        public byte EndTimeMin { get => endTimeMin; set => endTimeMin = value; }
        public byte StartMonth { get => startMonth; set => startMonth = value; }
        public byte StartDay { get => startDay; set => startDay = value; }
        public byte EndMonth { get => endMonth; set => endMonth = value; }
        public byte EndDay { get => endDay; set => endDay = value; }
        public ushort Soc { get => soc; set => soc = value; }
        public ushort Pow { get => pow; set => pow = value; }
        public int TOUEnabled { get => enabled; set => enabled = value; }

        public void Dispose()
        {
            port.Close();
            port.Dispose();
        }
    }
}