using Newtonsoft.Json;
using System.ComponentModel;
using Microsoft.VisualBasic;
using System.Net;

namespace SofarController
{
    public partial class Options : Form
    {
        public OptionData optionData = new();

        //private string dir = AppDomain.CurrentDomain.BaseDirectory; //""; //"C:\\";
        private string dir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

        //string dir2 = "C:\\Users\\MarkA\\Desktop\\Sofar Information\\SofarController\\bin\\Debug\\net8.0-windows\\options.txt";

        public Options()
        {
            InitializeComponent();
            if (File.Exists(dir + "\\Options.txt"))
            {
                optionData = ReadWriteJson.ReadFromJsonFile<OptionData>(dir + "\\Options.txt");
                COMPORTtxt.Text = optionData.COMPort;
                IPPortTxt.Text = optionData.IPPort.ToString();
                IPAddresstxt.Text = optionData.IPAddress.ToString();
                SerialTXT.Text = optionData.SerialNo.ToString();
            }
            else
            {
                string input = Interaction.InputBox("Select COM Port", "COM PORT", "COM2");
                optionData.COMPort = input;
                ReadWriteJson.WriteToJsonFile(dir + "\\options.txt", optionData);
            }
        }

        private void COMPORTtxt_Validating(object sender, CancelEventArgs e)
        {
            optionData.COMPort = COMPORTtxt.Text;
        }

        private void Options_FormClosing(object sender, FormClosingEventArgs e)
        {
            ReadWriteJson.WriteToJsonFile(dir + "\\options.txt", optionData);
        }

        internal void ShowDialog(OptionData optiondata)
        {
            this.optionData = optiondata;
            this.ShowDialog();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void IPAddresstxt_Validating(object sender, CancelEventArgs e)
        {
            if (IPAddress.TryParse(IPAddresstxt.Text, out IPAddress address))
            {
                optionData.IPAddress = address.ToString();
                IPAddresstxt.BackColor = Color.White;
            }
            else
                IPAddresstxt.BackColor = Color.Red;
        }

        private void IPPortTxt_Validating(object sender, CancelEventArgs e)
        {
            if (int.TryParse(IPPortTxt.Text, out int p))
            {
                optionData.IPPort = p;
                IPAddresstxt.BackColor = Color.White;
            }
            else
                IPAddresstxt.BackColor = Color.Red;

        }

        private void SerialTXT_Validating(object sender, CancelEventArgs e)
        {
            if (int.TryParse(SerialTXT.Text, out int p))
            {
                optionData.SerialNo = p;
                SerialTXT.BackColor = Color.White;
            }
            else
                SerialTXT.BackColor = Color.Red;
        }

        public string COMPort
        {
            get
            {
                return COMPORTtxt.Text;
            }
            set
            {
                COMPORTtxt.Text = value;
            }
        }
    }

    public class OptionData()
    {
        [JsonProperty("COMPort")]
        public string COMPort = "COM2";

        [JsonProperty("WIFI")]
        public bool WIFI;

        [JsonProperty("WorkMode")]
        public WorkMode WorkMode;

        [JsonProperty("IPPort")]
        public int IPPort=8899;

        [JsonProperty("IPaddress")]
        public string IPAddress= "192.168.1.228";

        [JsonProperty("Serial")]
        public int SerialNo = 809805460;
    }
}