using System.ComponentModel;

namespace SofarController
{
    public partial class TOUControl : UserControl
    {
        TOUData data = new();
        public TOUControl()
        {
            InitializeComponent();
        }

        public void Update()
        {
            TOUEnabledCBX.Checked = data.Enabled;

            TOUStartDate.Text = data.StartDate.ToString();
            TOUStartTime.Text = data.StartTime.ToString();

            TOUEndDate.Text = data.EndDate.ToString();
            TOUEndTime.Text = data.EndTime.ToString();

            SOC1.Text = data.Soc.ToString();
            ChargeRate1.Text = data.Pow.ToString();


            //this.groupBox2.Text = "TOU: " + no;
        }

        public string GroupName
        {
            get { return groupBox2.Text; }
            set { groupBox2.Text = value; }
        }

        public TOUData Data { get => data; set => data = value; }

        public byte[] ParseTextToByteArray(string s)
        {
            byte[] data = new byte[2];
            string[] s1 = s.Split(new char[] { ':' });

            if (byte.TryParse(s1[0], out byte b))
            {
                data[0] = b;
            }

            if (byte.TryParse(s1[1], out byte c))
            {
                data[1] = c;
            }

            return data;
        }

        public void RetriveData()
        {
            byte[] bytes = new byte[2];

            data.StartTime = TimeOnly.Parse(TOUStartTime.Text);
            data.EndTime = TimeOnly.Parse(TOUEndTime.Text);

            data.StartDate = DateOnly.Parse(TOUStartDate.Text);
            data.EndDate = DateOnly.Parse(TOUEndDate.Text);

            data.Enabled = TOUEnabledCBX.Checked;
            data.Pow = ushort.Parse(ChargeRate1.Text);
            data.Soc = ushort.Parse(SOC1.Text);
        }

        private void TOUStartTime_Validating(object sender, CancelEventArgs e)
        {
            if (!TimeOnly.TryParse(((TextBox)sender).Text, out TimeOnly d))
            {
                ((TextBox)sender).BackColor = Color.Red;
                e.Cancel = true;
            }
            else
            {
                ((TextBox)sender).BackColor = Color.White;
                data.StartTime = d;
            }
        }

        private void TOUEndTime_Validating(object sender, CancelEventArgs e)
        {
            if (!TimeOnly.TryParse(((TextBox)sender).Text, out TimeOnly d))
            {
                ((TextBox)sender).BackColor = Color.Red;
                e.Cancel = true;
            }
            else
            {
                ((TextBox)sender).BackColor = Color.White;
                data.EndTime = d;
            }
        }

        private void TOUStartDate_Validating(object sender, CancelEventArgs e)
        {
            if (!DateOnly.TryParse(((TextBox)sender).Text, out DateOnly d))
            {
                ((TextBox)sender).BackColor = Color.Red;
                e.Cancel = true;
            }
            else
            {
                ((TextBox)sender).BackColor = Color.White;
                data.StartDate = d;
            }
        }

        private void TOUEndDate_Validating(object sender, CancelEventArgs e)
        {
            if (!DateOnly.TryParse(((TextBox)sender).Text, out DateOnly d))
            {
                ((TextBox)sender).BackColor = Color.Red;
                e.Cancel = true;
            }
            else
            {
                ((TextBox)sender).BackColor = Color.White;
                data.EndDate = d;
            }
        }

        private void SOC1_Validating(object sender, CancelEventArgs e)
        {
            if (!double.TryParse(((TextBox)sender).Text, out double d) || d > 100)
            {
                ((TextBox)sender).BackColor = Color.Red;
                e.Cancel = true;
            }
            else
            {
                ((TextBox)sender).BackColor = Color.White;
                data.Soc = (ushort)d;
            }
        }

        private void ChargeRate1_Validating(object sender, CancelEventArgs e)
        {
            if (!double.TryParse(((TextBox)sender).Text, out double d) || d > 3000)
            {
                ((TextBox)sender).BackColor = Color.Red;
                e.Cancel = true;

            }
            else
            {
                ((TextBox)sender).BackColor = Color.White;
                data.Pow = (ushort)d;
            }
        }

        private void TOUEnabledCBX_CheckedChanged(object sender, EventArgs e)
        {
            data.Enabled = TOUEnabledCBX.Checked;
        }
    }
}
