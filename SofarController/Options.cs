using Newtonsoft.Json;
using System.ComponentModel;
using Microsoft.VisualBasic;
using System.Net;
using System.Security.Policy;

namespace SofarController
{
    public partial class Options : Form
    {
        private OptionData optionData = new();

        // private string dir = AppDomain.CurrentDomain.BaseDirectory; //""; //"C:\\";
        // private string dir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        // string dir2 = "C:\\Users\\MarkA\\Desktop\\Sofar Information\\SofarController\\bin\\Debug\\net8.0-windows\\options.txt";

        public Options(OptionData options)
        {
            this.optionData = options;

            InitializeComponent();
            if (optionData is not null)
            {
                COMPORTtxt.Text = optionData.COMPort;
                IPPortTxt.Text = optionData.IPPort.ToString();
                IPAddresstxt.Text = optionData.IPAddress.ToString();
                SerialTXT.Text = optionData.SerialNo.ToString();
                SolcastAPIKey.Text=optionData.SolAPI.ToString();
                SolcastLocationCodeTXT.Text = optionData.SolLoc.ToString();
            }
            else
            {
                // string input = Interaction.InputBox("Select COM Port", "COM PORT", "COM2");
                // optionData.COMPort = input;
                // ReadWriteJson.WriteToJsonFile(dir + "\\options.txt", optionData);
            }
        }

        public OptionData GetOptions()
        {
            return optionData;
        }

        private void COMPORTtxt_Validating(object sender, CancelEventArgs e)
        {
            optionData.COMPort = COMPORTtxt.Text;
        }

        private void Options_FormClosing(object sender, FormClosingEventArgs e)
        {
            optionData.Save();
        }

        internal void ShowDialog(OptionData optiondata)
        {
            this.optionData = optiondata;
            this.ShowDialog();
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

        private void Options_Load(object sender, EventArgs e)
        {

        }

        private void SolcastLocationCodeTXT_Validating(object sender, CancelEventArgs e)
        {
            if (SolcastLocationCodeTXT.Text.Length > 5)
            {
                optionData.SolLoc = SolcastLocationCodeTXT.Text;
                SolcastLocationCodeTXT.BackColor = Color.White;
            }
            else
                SolcastLocationCodeTXT.BackColor = Color.Red;
        }

        private void SolcastAPIKey_Validating(object sender, CancelEventArgs e)
        {
            if (SolcastAPIKey.Text.Length > 5)
            {
                optionData.SolAPI = SolcastAPIKey.Text;
                SolcastAPIKey.BackColor = Color.White;
            }
            else
                SolcastAPIKey.BackColor = Color.Red;
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
        private string dir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

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

        [JsonProperty("SolcastLocation")]
        public string SolLoc = "Enter Location";

        [JsonProperty("SolcastAPIKey")]
        public string SolAPI = "Enter API Code";

        public void Read()
        {
            OptionData o = ReadWriteJson.ReadFromJsonFile<OptionData>(dir + "\\Options.txt");
            this.COMPort = o.COMPort;
            this.WIFI = o.WIFI;
            this.WorkMode = o.WorkMode;
            this.IPPort = o.IPPort;
            this.IPAddress = o.IPAddress;
            this.SerialNo = o.SerialNo;
            this.SolLoc = o.SolLoc;
            this.SolAPI = o.SolAPI;
        }

        public void Save()
        {
            ReadWriteJson.WriteToJsonFile(dir + "\\options.txt", this);
        }

        public bool FileExists()
        {
            return File.Exists(dir + "\\Options.txt");
        }
    }
}