using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using Extensions;
using NModbus.Extensions;
using NModbus.Logging;
using NModbus.Utility;

namespace NModbus.IO
{
    /// <summary>
    ///     Refined Abstraction - http://en.wikipedia.org/wiki/Bridge_Pattern
    /// </summary>
    internal class ModbusRtuTransport : ModbusSerialTransport, IModbusRtuTransport
    {
        public const int RequestFrameStartLength = 7;

        public const int ResponseFrameStartLength = 4;

        internal ModbusRtuTransport(IStreamResource streamResource, IModbusFactory modbusFactory, IModbusLogger logger)
            : base(streamResource, modbusFactory, logger)
        {
            if (modbusFactory == null) throw new ArgumentNullException(nameof(modbusFactory));
            Debug.Assert(streamResource != null, "Argument streamResource cannot be null.");
        }



        internal int RequestBytesToRead(byte[] frameStart)
        {
            byte functionCode = frameStart[1];

            IModbusFunctionService service = ModbusFactory.GetFunctionServiceOrThrow(functionCode);
                
            return service.GetRtuRequestBytesToRead(frameStart);
        }

        internal int ResponseBytesToRead(byte[] frameStart)
        {
            byte functionCode = frameStart[1];

            if (functionCode > Modbus.ExceptionOffset)
            {
                return 1;
            }

            IModbusFunctionService service = ModbusFactory.GetFunctionServiceOrThrow(functionCode);

            return service.GetRtuResponseBytesToRead(frameStart);
        }

        public virtual byte[] Read(int count)
        {
            byte[] frameBytes = new byte[count];
            int numBytesReadTotal = 0;

            while (numBytesReadTotal != count)
            {
                Debug.Print(frameBytes.ToString());
                Debug.Print(numBytesReadTotal.ToString());
                Debug.Print(count.ToString());

                int numBytesRead = StreamResource.Read(frameBytes, numBytesReadTotal, count - numBytesReadTotal);
                
                 if (numBytesRead == 0)
                {
                    throw new IOException("Read resulted in 0 bytes returned.");
                }
                
                numBytesReadTotal += numBytesRead;
            }

            return frameBytes;
        }

        public virtual byte[] ReadV5()
        {
            //int numBytesRead = StreamResource.ReadAll(out byte[] frameBytes);
            byte[] frameBytes = new byte[34];
            int numBytesRead = StreamResource.Client.Receive(frameBytes);
            return frameBytes;
        }

        public override byte[] BuildMessageFrame(IModbusMessage message)
        {
            var messageFrame = message.MessageFrame;
            var crc = ModbusUtility.CalculateCrc(messageFrame);
            var messageBody = new MemoryStream(messageFrame.Length + crc.Length);

            messageBody.Write(messageFrame, 0, messageFrame.Length);
            messageBody.Write(crc, 0, crc.Length);

            return messageBody.ToArray();
        }

        public override bool ChecksumsMatch(IModbusMessage message, byte[] messageFrame)
        {
            ushort messageCrc = BitConverter.ToUInt16(messageFrame, messageFrame.Length - 2);
            ushort calculatedCrc = BitConverter.ToUInt16(ModbusUtility.CalculateCrc(message.MessageFrame), 0);

            return messageCrc == calculatedCrc;
        }

        public override IModbusMessage ReadResponse<T>()
        {
            byte[] frame = ReadResponse();

            Logger.LogFrameRx(frame);

            return CreateResponse<T>(frame);
        }

        private byte[] ReadResponse()
        {
            byte[] frameStart = Read(ResponseFrameStartLength);
            byte[] frameEnd = Read(ResponseBytesToRead(frameStart));
            byte[] frame = frameStart.Concat(frameEnd).ToArray();

            return frame;
        }

        private byte[] ReadResponseV5()
        {
            for (int i = 0; i < 20; i++)
            {
                if (StreamResource.Client.Available == 0)
                    Thread.Sleep(1000);
                else
                    break;
            }

            byte[] frame = ReadV5();

            if (frame == null || frame.Length < 33)
            {
            }
            else
            {
                frame = frame.Slice(25, 33);
            }

            return frame;
        }

        public byte[] WriteResponseV5()
        {

           /* for (int i = 0; i < 20; i++)
            {
                if (StreamResource.Client.Available == 0)
                    Thread.Sleep(1000);
                else
                    break;
            }*/

            byte[] frame = ReadV5();

          //  Debug.WriteLine("Response"+"[{0}]", string.Join(", ", frame));

            if (frame.Length>34)
            {
                frame = frame.Slice(34, 41);
            }
            else if(frame.Length<32)
            {
                frame = null;
            }
            else
            {
                frame = frame.Slice(25, 32);
            }

            return frame;
        }

        public override IModbusMessage ReadResponseV5<T>()
        {
            byte[] frame = ReadResponseV5();
            if(frame.Length>120)
            {
                Debugger.Break();
            }
            Logger.LogFrameRx(frame);

            return CreateResponse<T>(frame);
        }

        public override IModbusMessage WriteResponseV5<T>(string Name)
        {
            //Debug.Print(Name);
            byte[] frame = WriteResponseV5();

            Logger.LogFrameRx(frame);

            return CreateResponse<T>(frame);
        }

        public override void IgnoreResponse()
        {
            byte[] frame = ReadResponse();

            Logger.LogFrameIgnoreRx(frame);
        }

        public override byte[] ReadRequest()
        {
            byte[] frameStart = Read(RequestFrameStartLength);
            byte[] frameEnd = Read(RequestBytesToRead(frameStart));
            byte[] frame = frameStart.Concat(frameEnd).ToArray();

            Logger.LogFrameRx(frame);

            return frame;
        }
    }
}
