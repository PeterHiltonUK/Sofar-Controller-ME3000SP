namespace SolarManCSharp
{
    internal class V5FrameError(Exception Exception)
    { }

    //V5 Frame Validation Error//

    internal class NoSocketAvailableError(Exception Exception)
    { }

    //No Socket Available Error//

    // pylint: disable-next=too-many-instance-attributes (R0902)
    public class SolarmanV5
    {
        private string IP; private int SerialNumber; private int port; private int mb_slave_id; private bool verbose;
        private int?  sequence_number;
        private Bytes  v5_checksum;
        private byte  v5_end;
        private byte  v5_start;
        private Bytes  v5_length;
        private Bytes  v5_controlcode;
        private Bytes  v5_serial;
        private Bytes  v5_loggerserial;
        private Bytes  v5_frametype;
        private Bytes  v5_sensortype;
        private Bytes  v5_deliverytime;
        private Bytes  v5_powerontime;
        private Bytes  v5_offsettime;
        private bool v5_error_correction;
        private Bytes data;
        private bool exc_info;
        private Bytes _last_frame;
        private int socket_timeout;
        private bool _auto_reconnect = false;
        private bool? _sock_fd;

        public object address { get; private set; }

        /*
                The PySolarmanV5 class establishes a TCP connection to a Solarman V5 data
                logging stick and exposes methods to send/receive Modbus RTU requests and
                responses.

                For more detailed information on the Solarman V5 Protocol, see
                :doc:`solarmanv5_protocol`

                :param address: IP address or hostname of data logging stick
                :type address: str
                :param serial: Serial number of the data logging stick (not inverter!)
                :type serial: int
                :param port: TCP port to connect to data logging stick, defaults to 8899
                :type port: int, optional
                :param mb_slave_id: Inverter Modbus slave ID, defaults to 1
                :type mb_slave_id: int, optional
                :param socket_timeout: Socket timeout duration in seconds, defaults to 60
                :type socket_timeout: int, optional
                :param v5_error_correction: Enable naive error correction for V5 frames,
                defaults to false
                :type v5_error_correction: bool, optional

                .. versionadded:: v2.4.0

                :param logger: Python logging facility
                :type logger: Logger, optional
                :param socket: TCP Socket connection to data logging stick. If **socket**
                argument is provided, **address** argument is unused (however, it is
                still required as a positional argument)
                :type socket: Socket, optional
                :raises NoSocketAvailableError: If no network socket is available

                .. versionadded:: v2.5.0

                :param auto_reconnect: Activates the auto-reconnect functionality.
                PySolarmanV5 will try to keep the connection open. The default is false.
                Not compatible with custom sockets.
                :type auto_reconnect: Boolean, optional

                .. deprecated:: v2.4.0

                :param verbose: Enable verbose logging, defaults to false. Use **logger**
                instead. For compatibility purposes, **verbose**, if enabled, will
                create a logger, and set the logging level to DEBUG.
                :type verbose: bool, optional

                Basic example:
                >>> from pysolarmanv5 import PySolarmanV5
                >>> modbus = PySolarmanV5("192.168.1.10", 123456789)
                >>> print(modbus.read_input_registers(register_addr=33022, quantity=6))

                See :doc:`examples` directory for further examples.

*/

        public SolarmanV5(string address, int serial, int Port = 8899, int MB_slave_id = 1,
            bool Verbose = true, ushort socket_timeout = 60, bool v5_error_correction = false)
        {
            this.IP = address;
            this.SerialNumber = serial;
            this.port = Port;
            this.mb_slave_id = MB_slave_id;
            this.verbose = Verbose;

            sequence_number = null;

            v5_start = ByteHelper.ByteFromHex("A5");
            v5_length = ByteHelper.BytesFromHex("0000"); // placeholder value
            ushort test = 0x4510;

            v5_controlcode = StructConverter.Pack(new object[] { test });
            v5_serial = ByteHelper.BytesFromHex("0000");  // placeholder value
            v5_loggerserial = StructConverter.Pack(new object[] { (ushort)SerialNumber }, true, out string format);
            v5_frametype = ByteHelper.BytesFromHex("02");
            v5_sensortype = ByteHelper.BytesFromHex("0000");
            v5_deliverytime = ByteHelper.BytesFromHex("00000000");
            v5_powerontime = ByteHelper.BytesFromHex("00000000");
            v5_offsettime = ByteHelper.BytesFromHex("00000000");
            v5_checksum = ByteHelper.BytesFromHex("00");  // placeholder value
            v5_end = ByteHelper.ByteFromHex("15");
        }
    }
}