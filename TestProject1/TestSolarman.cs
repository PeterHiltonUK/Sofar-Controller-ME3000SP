using System.Diagnostics;
using System.Net.Sockets;
using System.Text;

namespace Tests
{
    [TestClass]
    public class TestSolarman
    {
        [TestMethod]
        public void V5FrameAndSocketTest()
        {
            for (int i = 0; i < 100; i++)
            {

                byte[] V5_Frame = new byte[] { 165, 26, 0, 16, 69, 195, 0, 148, 166, 68, 48, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 16, 18, 0, 0, 1, 2, 0, 0, 148, 81, 237, 21 };

                using Socket socket = new Socket(SocketType.Stream, ProtocolType.Tcp);
                socket.Connect("192.168.1.228", 8899);
                bool connected = socket.Connected;

                
                socket.Send(V5_Frame);

                // Do minimalistic buffering assuming ASCII response
                byte[] responseBytes= new byte[256];

                int bytesReceived = socket.Receive(responseBytes);

                // Convert byteCount bytes to ASCII characters using the 'responseChars' buffer as destination
                //int charCount = Encoding.ASCII.GetChars(responseBytes, 0, bytesReceived, responseChars, 0);

                for (int ii = 0; ii < responseBytes.Count(); ii++)
                {
                    // Print the contents of the 'responseChars' buffer to Console.Out
                    Debug.Print("{0}", string.Join(", ", responseBytes));
                }
            }
        }
    }
}