namespace SofarController
{

    public partial class PassiveForm : Form
    {
        Sofar sofar;
        TOUData passivedata = new();
        public ushort chargeRate, dischargeRate;
        OptionData options;
        

        public PassiveForm(Sofar sofar, TOUData toupassive, OptionData options)
        {
            InitializeComponent();
            this.sofar = sofar;
            this.options = options;
        }

        private void SetCHargeRate_Click(object sender, EventArgs e)
        {
            sofar.SetChargeRate(chargeRate);
        }

        private void SetDischargRate_Click(object sender, EventArgs e)
        {
            sofar.SetDisChargeRate(dischargeRate, options);
        }

        private void ChargeRate_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (ushort.TryParse(ChargeRate.Text, out chargeRate))
            {
                ChargeRate.BackColor = Color.White;
            }
            else
            {
                ChargeRate.BackColor = Color.Red;
                e.Cancel = true;
            }
        }

        private void DischargeRate_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (ushort.TryParse(DischargeRate.Text, out dischargeRate))
            {
                DischargeRate.BackColor = Color.White;
            }
            else
            {
                DischargeRate.BackColor = Color.Red;
                e.Cancel = true;
            }
        }
    }
}
