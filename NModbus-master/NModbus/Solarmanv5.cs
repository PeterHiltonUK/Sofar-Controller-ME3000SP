using Microsoft.VisualBasic.Logging;
using SolarManCSharp;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace NModbus
{
    //No Socket Available Error//

    // pylint: disable-next=too-many-instance-attributes (R0902)
    public class Solarmanv5
    {
        private string IP; private int SerialNumber; private int port; private int mb_slave_id; private bool verbose;
        private int? sequence_number;
        private Bytes v5_checksum;
        private byte v5_end;
        private byte v5_start;
        private Bytes v5_length;
        private Bytes v5_controlcode;
        private Bytes v5_serial;
        private Bytes v5_loggerserial;
        private Bytes v5_frametype;
        private Bytes v5_sensortype;
        private Bytes v5_deliverytime;
        private Bytes v5_powerontime;
        private Bytes v5_offsettime;
        private bool v5_error_correction=false;

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

        public Solarmanv5(string address, int serial, int Port = 8899, int MB_slave_id = 1,
            bool Verbose = true, ushort socket_timeout = 60, bool v5_error_correction = false)
        {
            //def __init__( address, serial, **kwargs):
            //Constructor//

            this.IP = address;
            this.SerialNumber = serial;
            this.port = Port;
            this.mb_slave_id = MB_slave_id;
            this.verbose = Verbose;

            /*var log = kwargs.get("logger", null);
            if (log is null)
            {
                logging.basicConfig();
                log = logging.getLogger(__name__);
            }*/

            sequence_number = null;

            /*if (verbose)
                log.setLevel("DEBUG");*/

            // Define and construct V5 request frame structure.
            v5_start = ByteHelper.ByteFromHex("A5");
            v5_length = ByteHelper.BytesFromHex("0000"); // placeholder value
            ushort test = 0x4510;

            v5_controlcode = StructConverter2.Pack(new object[] { test });
            v5_serial = ByteHelper.BytesFromHex("0000");  // placeholder value
            v5_loggerserial = StructConverter2.Pack(new object[] { (int)SerialNumber }, true, out string format);
            v5_frametype = ByteHelper.BytesFromHex("02");
            v5_sensortype = ByteHelper.BytesFromHex("0000");
            v5_deliverytime = ByteHelper.BytesFromHex("00000000");
            v5_powerontime = ByteHelper.BytesFromHex("00000000");
            v5_offsettime = ByteHelper.BytesFromHex("00000000");
            v5_checksum = ByteHelper.BytesFromHex("00");  // placeholder value
            v5_end = ByteHelper.ByteFromHex("15");

            /*  sock: socket.socket = null  // noqa
              _poll: selectors.BaseSelector = null  // noqa
              _sock_fd: int = null  // noqa
              _auto_reconnect = false
                  _data_queue: Queue = null  // noqa
              _data_wanted: Event = null  // noqa
              _reader_exit: Event = null  // noqa
              _reader_thr: Thread = null  // noqa
              _last_frame: bytes = b""
              _socket_setup(kwargs.get("socket"), kwargs.get("auto_reconnect", false))*/
        }

        //staticmethod
        public static byte _calculate_v5_frame_checksum(Bytes frame)
        {
            //Calculate checksum on all frame bytes except head, end and checksum

            // :param frame: V5 frame
            // :type frame: bytes
            // : return: Checksum value of V5 frame
            // : rtype: int

            byte checksum = 0;
            for (int i = 1; i < frame.Length - 2; i++)
                checksum += (byte)(frame[i] & ByteHelper.UShortFromHex("0xFF"));

            byte res = (byte)(checksum & ByteHelper.UShortFromHex("0xFF"));

            return res;
        }

        //def _get_next_sequence_number(self):
        public int? _get_next_sequence_number()
        {
            Random r = new Random();
            //Get the next sequence number for use in outgoing packets

            if (sequence_number is null)
                sequence_number = r.Next(1, 0xff);
            else
                sequence_number = (sequence_number + 1) & 0xFF;
            return sequence_number;
        }

        //def _v5_frame_encoder( modbus_frame):
        public Bytes _v5_frame_encoder(Bytes modbus_frame)
        {
            //Take a modbus RTU frame and encode it in a V5 data logging stick frame

            /* :param modbus_frame: Modbus RTU frame
               : type modbus_frame: bytes
               : return: V5 frame
               : rtype: bytearray*/

            Bytes v5_length = StructConverter.Pack(new object[] { (ushort)(15 + modbus_frame.Length) }, true, out string format);
            var val = _get_next_sequence_number();


            Bytes v5_serial = StructConverter.Pack(new object[] { (ushort)134 });

            //private struct.private pack("<H", _get_next_sequence_number());

            Bytes v5_header = ByteHelper.Add(new object[] {
                v5_start ,
                v5_length ,
                v5_controlcode ,
                v5_serial,
                v5_loggerserial });

            Bytes v5_payload = ByteHelper.Add(new object[]{
                v5_frametype,
                v5_sensortype,
                v5_deliverytime,
                v5_powerontime,
                v5_offsettime,
                modbus_frame});

            Bytes v5_trailer = ByteHelper.Add(new object[] { v5_checksum, v5_end });

            Bytes v5_frame = ByteHelper.Add(new object[] { v5_header, v5_payload, v5_trailer });

            var CheckSum = _calculate_v5_frame_checksum(v5_frame);

            v5_frame[v5_frame.Length - 2] = CheckSum;

            return v5_frame;
        }

        //def _v5_frame_decoder( v5_frame):
        public Bytes _v5_frame_decoder(Bytes v5_frame)
        {
            ErrorCode error_code_to_exception_map = new();
            /*Decodes a V5 data logging stick frame and returns a modbus RTU frame

            Modbus RTU frame will start at position 25 through ``len(v5_frame)-2``.

            Occasionally logger can send a spurious 'keep-alive' reply with a
            control code of ``0x4710``. These messages can either take the place of,
            or be appended to valid ``0x1510`` responses. In this case, the v5_frame
            will contain an invalid checksum.

            Validate the following:

            1) V5 start and end are correct (``0xA5`` and ``0x15`` respectively)
            2) V5 checksum is correct
            3) V5 outgoing sequence number has been echoed back to us (byte 5)
            4) V5 data logger serial number is correct (in most (all?) instances the
               reply is correct, but request can obviously be incorrect)
            5) V5 control code is correct (``0x1510``)
            6) v5_frametype contains the correct value (``0x02`` in byte 11)
            7) Modbus RTU frame length is at least 5 bytes (vast majority of RTU
               frames will be >=6 bytes, but valid 5 byte error/exception RTU frames
               are possible)*/

            /*:param v5_frame: V5 frame
                    :type v5_frame: bytes
                    : return: Modbus RTU Frame
                    : rtype: bytes
                    : raises V5FrameError: If parsing fails due to invalid V5 frame*/

            int frame_len = v5_frame.Length;

            object[] payload_len = StructConverter.Unpack("<H", (new ArraySegment<byte>(v5_frame.Bytearray, 1, 3)).ToArray());

            int frame_len_without_payload_len = 13;

            if (frame_len != (frame_len_without_payload_len + payload_len.Length))
            {
                Debug.Print("frame_len does not match payload_len.");
                if (v5_error_correction)
                    frame_len = frame_len_without_payload_len + payload_len.Length;
            }

            if (v5_frame.Bytearray[0] != (int)(v5_start)
                || (v5_frame[frame_len - 1] != (int)(v5_end)))
                MessageBox.Show("V5 frame contains invalid start or end values");

            if (v5_frame[frame_len - 2] != _calculate_v5_frame_checksum(v5_frame))
                MessageBox.Show("V5 frame contains invalid V5 checksum");

            if (v5_frame[5] != sequence_number)
                MessageBox.Show("V5 frame contains invalid sequence number");

            //if (v5_frame.Slice(7, 11) != v5_loggerserial)
            //    raise.V5FrameError("V5 frame contains incorrect data logger serial number");

            if (v5_frame.Slice(3, 5) != StructConverter.Pack(new object[] { "<H", 0x1510 }))
                MessageBox.Show("V5 frame contains incorrect control code");

            if (v5_frame[11] != (ushort)(2)) 
            MessageBox.Show("V5 frame contains invalid frametype");

            Bytes modbus_frame = v5_frame.Slice(25, frame_len - 2);

            if (modbus_frame.Length < 5)

                /*if (modbus_frame.Length > 0 && error_code_to_exception_map.get(modbus_frame[0]))
                {
                    //var err = error_code_to_exception_map.get(modbus_frame[0]);

                    MessageBox.Show("V5 Modbus EXCEPTION: {err.__name__}");
                }
                else*/
                    MessageBox.Show("V5 frame does not contain a valid Modbus RTU frame");

            return modbus_frame;
        }
    }

    internal class ErrorCode
    {
    }
}
