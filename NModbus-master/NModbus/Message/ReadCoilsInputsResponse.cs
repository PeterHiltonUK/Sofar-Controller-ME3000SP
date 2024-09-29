using System;
using System.Linq;
using NModbus.Data;
using NModbus.Unme.Common;

namespace NModbus.Message
{
    public class ReadCoilsInputsResponse : AbstractModbusMessageWithData<DiscreteCollection>, IModbusMessage
    {
        public ReadCoilsInputsResponse()
        {
        }

        public ReadCoilsInputsResponse(byte functionCode, byte slaveAddress, byte byteCount, DiscreteCollection data)
            : base(slaveAddress, functionCode)
        {
            ByteCount = byteCount;
            Data = data;
        }

        public byte ByteCount
        {
            get => MessageImpl.ByteCount.Value;
            set => MessageImpl.ByteCount = value;
        }

        public override int MinimumFrameSize => 3;

        public byte[] V5Frame { get; set; }
        public bool V5Active { get ; set ; }
        public byte[] Modbus_Frame { get ; set  ; }
        public string VarName { get ; set ; }
        public int V5Serial { get; set; }
        public string V5IPAddress { get; set; }
        public int V5Port { get; set; }

        public override string ToString()
        {
            string msg = $"Read {Data.Count()} {(FunctionCode == ModbusFunctionCodes.ReadInputs ? "inputs" : "coils")} - {Data}.";
            return msg;
        }

        protected override void InitializeUnique(byte[] frame)
        {
            if (frame.Length < 3 + frame[2])
            {
                throw new FormatException("Message frame data segment does not contain enough bytes.");
            }

            ByteCount = frame[2];
            Data = new DiscreteCollection(frame.Slice(3, ByteCount).ToArray());
        }
    }
}
