using System;
using NModbus.Logging;

namespace NModbus.IO
{
    internal class EmptyTransport : ModbusTransport
    {
        public EmptyTransport(IModbusFactory modbusFactory)
            : base(modbusFactory, NullModbusLogger.Instance)
        {
        }

        public override byte[] ReadRequest()
        {
            throw new NotImplementedException();
        }

        public override IModbusMessage ReadResponse<T>()
        {
            throw new NotImplementedException();
        }

        public override byte[] BuildMessageFrame(IModbusMessage message)
        {
            throw new NotImplementedException();
        }

        public override void Write(IModbusMessage message)
        {
            throw new NotImplementedException();
        }

        internal override void OnValidateResponse(IModbusMessage request, IModbusMessage response)
        {
            throw new NotImplementedException();
        }

        public override void WriteV5Frame(IModbusMessage message)
        {
            throw new NotImplementedException();
        }

        public override IModbusMessage ReadResponseV5<T>()
        {
            throw new NotImplementedException();
        }

        public override IModbusMessage WriteResponseV5<T>(string n)
        {
            throw new NotImplementedException();
        }
    }
}