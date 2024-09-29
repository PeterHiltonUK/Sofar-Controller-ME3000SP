namespace SofarController
{
    public static class ByteHelper
    {
        // Low/ High byte arithmetic
        // byte upper = (byte) (number >> 8);
        // byte lower = (byte) (number & 0xff);

        public static byte[] GetBytesOrderedLowHigh(ushort toBytes)
        {
            return new[] { (byte)(toBytes & 0xFF), (byte)(toBytes >> 8) };
        }

        public static byte[] GetBytesOrderedHighLow(ushort toBytes)
        {
            return new[] { (byte)(toBytes >> 8), (byte)(toBytes & 0xFF) };
        }

        public static byte UpByte(ushort u)
        {
            byte[] a = GetBytesOrderedHighLow(u);
            return a[0];
        }

        public static byte LowerByte(ushort l)
        {
            byte[] a = GetBytesOrderedHighLow(l);
            return a[1];
        }

        public static ushort UShort(byte U, byte L)
        {
            ushort actualPort = BitConverter.ToUInt16([(byte)L, (byte)U], 0);
            return actualPort;
        }

    }
}

