using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net;
using NModbus.Data;
using NModbus.Unme.Common;

namespace NModbus.Message
{
    internal class DiagnosticsRequestResponse : AbstractModbusMessageWithData<RegisterCollection>, IModbusMessage
    {
        public DiagnosticsRequestResponse()
        {
        }

        public DiagnosticsRequestResponse(ushort subFunctionCode, byte slaveAddress, RegisterCollection data)
            : base(slaveAddress, ModbusFunctionCodes.Diagnostics)
        {
            SubFunctionCode = subFunctionCode;
            Data = data;
        }

        public override int MinimumFrameSize => 6;

        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "May implement addtional sub function codes in the future.")]
        public ushort SubFunctionCode
        {
            get => MessageImpl.SubFunctionCode.Value;
            set => MessageImpl.SubFunctionCode = value;
        }
        public byte[] V5Frame { get; set; }
        public bool V5Active { get ; set ; }
        public byte[] Modbus_Frame { get ; set  ; }
        public string VarName { get ; set ; }
        public int V5Serial { get; set; }
        public string V5IPAddress { get; set; }
        public int V5Port { get; set; }

        public override string ToString()
        {
            Debug.Assert(
                SubFunctionCode == ModbusFunctionCodes.DiagnosticsReturnQueryData,
                "Need to add support for additional sub-function.");

            return $"Diagnostics message, sub-function return query data - {Data}.";            
        }

        protected override void InitializeUnique(byte[] frame)
        {
            SubFunctionCode = (ushort)IPAddress.NetworkToHostOrder(BitConverter.ToInt16(frame, 2));
            Data = new RegisterCollection(frame.Slice(4, 2).ToArray());
        }
    }
}
