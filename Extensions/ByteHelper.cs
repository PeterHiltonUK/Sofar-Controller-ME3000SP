using Microsoft.VisualBasic;
using System.ComponentModel;
using System.IO.Packaging;
using System.Numerics;

namespace SolarManCSharp
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

        public static string HexFromShort(ushort us)
        {
            return us.ToString("x4");
        }



        public static byte[] UShortToASCICoding(ushort us)
        {
            string s =  HexFromShort(us);
            string s1, s2;
            s1 = s.Substring(0,2);
            s2 = s.Substring(2, 2);

            byte b1 = ByteFromHex(s1);
            byte b2 = ByteFromHex(s2);

            byte[] array = new byte[2];

            array[0] = (byte)b2;
            array[1] = (byte)b1;


            return array;
        }

        public static byte Byte(string s)//double d = BitConverter.Int64BitsToDouble(0xdeadbeef);
        {
            byte b = new();
            ByteConverter byteConverter = new ByteConverter();
            if (byteConverter.CanConvertFrom(typeof(string)))
                b = (byte)byteConverter.ConvertFrom(s);
            return b;
        }

        public static ushort UShortFromHex(string Hex)
        {
            ushort bTemp = (ushort)Convert.ToInt16(Hex, 16);
            return bTemp;
        }

        public static byte ByteFromHex(string Hex)
        {
            byte b;
            b = (byte)Convert.ToByte(Hex,16);
            return b;
        }

        public static ushort ShortFromHex(string Hex)
        {
            ushort b;
            b = (ushort)Convert.ToInt16(Hex, 16);
            return b;
        }

        public static Bytes BytesFromHex(string Hex)
        {
            if(Hex.Substring(0,2)=="0x")
                Hex = Hex.Substring(2);
            int len = Hex.Length;
            int len2 = Hex.Length/2;
            Bytes b=new(len2);

            for (int i = 0; i < len; i+=2)
            {
                string s = Hex.Substring(i, 2);
                b[i/2] = (byte)ByteFromHex(s);
            }

            return b;
        }

        public static byte[] Add(object[] objects)
        {
            List<byte> bytes = new();
            int l = 0;

            for (int i = 0; i < objects.Length; i++)
            {
                switch (objects[i])
                {
                    case Bytes b:
                        l += b.Bytearray.Length;
                        break;
                    case ushort:
                        l += 2;
                        break;
                    case byte b:
                        l++;
                        break;

                    case byte[] ba:
                        l += ba.Length;
                        break;
                }
            }

            for (int i = 0; i < objects.Length; i++)
            {
                switch (objects[i])
                {
                    case Bytes b:
                        bytes.AddRange(b.Bytearray); 
                        break;
                    case ushort u:
                        bytes.Add(ByteHelper.UpByte(u));
                        bytes.Add(ByteHelper.LowerByte(u));
                        break;
                    case byte b:
                        bytes.Add(b);
                        break;
                    case byte[] ba:
                        for (int ii = 0; ii < ba.Length; ii++)
                        {
                            bytes.AddRange(ba.ToArray());
                        }
                        break;
                }
            }

            return bytes.ToArray();
        }

        public static bool GetBit(this byte b, int bitNumber)
        {
            var bit = (b & (1 << bitNumber - 1)) != 0;
            return bit;
        }

        public static byte[] ShortToASCICoding(short ss)
        {
            string s = ss.ToString();
            string s1, s2;
            s1 = s.Substring(0, 2);
            s2 = s.Substring(2, 2);

            byte b1 = ByteFromHex(s1);
            byte b2 = ByteFromHex(s2);

            char c1 = (char)b1;
            char c2 = (char)b2;

            byte[] array = new byte[2];

            array[0] = (byte)c1;
            array[1] = (byte)c2;


            return array;
        }

        internal static byte[] IntToBytes(int i)
        {
            throw new NotImplementedException();
        }
    }
}