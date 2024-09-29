namespace WinFormsApp1
{
    using System.IO.Ports;
    using System.Linq;
    using System.Net;
    using System.Net.Sockets;
    using System.Runtime.CompilerServices;
    using NModbus;
    using NModbus.Logging;
    using Samples;

    public partial class Form1 : Form
    {

        private const string PrimarySerialPortName = "COM2";
        private const string SecondarySerialPortName = "COM2";
        public Form1()
        {
            InitializeComponent();

            // Driver d = new();



            using (var sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
            {

                using (SerialPort port = new SerialPort(PrimarySerialPortName))
                {
                    // configure serial port
                    port.BaudRate = 9600;
                    port.DataBits = 8;
                    port.Parity = Parity.None;
                    port.StopBits = StopBits.One;
                    port.Open();

                    var factory = new ModbusFactory();
                   // IModbusSerialMaster master = factory.CreateAsciiMaster(port);

                    byte slaveId = 1;
                    ushort startAddress = 1;
                    ushort numRegisters = 5;

                    // read five registers		
                    ushort[] registers = master.ReadHoldingRegisters(slaveId, startAddress, numRegisters);

                    for (int i = 0; i < numRegisters; i++)
                    {
                        Console.WriteLine($"Register {startAddress + i}={registers[i]}");
                    }
                }
            }
        }
    }
}
