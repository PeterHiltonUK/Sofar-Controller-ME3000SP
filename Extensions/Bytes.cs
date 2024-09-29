using Extensions;

namespace SolarManCSharp
{
    public class Bytes
    {
        private List<byte> bytearray=new();
        private Bytes bytes;

        public Bytes(byte[] bytes)
        {
            bytearray.Clear();
            bytearray.AddRange(bytes);
        }

        public Bytes(List<byte> bytes)
        {
            bytearray.Clear();
            bytearray.AddRange(bytes);
        }

        public Bytes(int n)
        {
            for (int i = 0; i<n;i++)
                bytearray.Add(0);
        }

        public Bytes()
        {
        }

        public Bytes(Bytes bytes)
        {
            bytearray = bytes.bytearray;
        }

        public byte[] Bytearray { get => bytearray.ToArray(); set => bytearray = value.ToList(); }
        public int Length { get => bytearray.Count; }

        public bool startswith(byte v5_start, string v)
        {
            if (bytearray[0] == v5_start)
                return true;
            return false;
        }

        public bool endswith(object zeroes)
        {
            throw new NotImplementedException();
        }

        public byte this[Index i]
        {
            get { return bytearray[i]; }
            set { bytearray[i] = value; }
        }

        public Bytes Slice(int start, int end)
        {
            return new Bytes(bytearray.Slice(start, end));
        }

        public Bytes Slice2(int start, int end)
        {
            return new Bytes(bytearray.Slice(start, end));
        }

        public object hex(string v)
        {
            throw new NotImplementedException();
        }

        public bool startswith(byte v5_start)
        {
            throw new NotImplementedException();
        }

        public static implicit operator Bytes(byte[] bytes)
        {
            Bytes b = new Bytes(bytes);
            return b;
        }

        public string DisplayAsHex
        {
            get
            {
                string s = "";
                string temps = "";


                for (int i = 0; i < bytearray.Count; i++)
                {
                    if (bytearray[i] < 127)
                    {
                        temps += (char)bytearray[i];
                    }
                    else
                    {

                    }


                    if (bytearray.Count == 1)
                    {
                        s = "x" + bytearray[i].ToString("X2");
                    }
                    else if (i == 0)
                    {
                        s = s + "x" + bytearray[i].ToString("X2");
                    }
                    else
                    {
                        s = s + "," + "x" + bytearray[i].ToString("X2");
                    }
                }
                return s;
            }
        }

        public override string ToString()
        {
            return DisplayAsHex;
        }

        public static Bytes Append(Bytes msg, Bytes bytes)
        {
            List<byte> l = new List<byte>();

            l.AddRange(bytes.bytearray);
            l.AddRange(msg.bytearray);

            Bytes b = new(l.ToArray());

            return b;
        }

        public void Append(int crc)
        {
            bytearray.Append((byte)crc);
        }
    }
}