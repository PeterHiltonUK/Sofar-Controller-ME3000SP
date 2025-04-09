using System;
using System.Net.Sockets;

namespace SofarController
{
    public partial class MacroForm : Form
    {
        private MacroData macroData;

        public MacroForm(MacroData macroData)
        {
            InitializeComponent();
            this.macroData = macroData;
        }

        public void Update(MacroData data)
        {
            macroData = data;
            ForecastTxt.Text = macroData.ForecastAM.ToString();
            CapcityTxt.Text = macroData.BatteryCapacity.ToString();
            SOCTxt.Text = macroData.BatteryPCT.ToString();
            MinSOC.Text = macroData.BatteryMinimumPCT.ToString();
            SpareTxt.Text = macroData.Spare.ToString();
            StartTimeTxt.Text = macroData.StartTime.ToString();
            EndTimeTxt.Text = macroData.EndTime.ToString();
            ChargeRateTxt.Text = macroData.ChargeAmount.ToString();
        }

        private void MacroForm_Load(object sender, EventArgs e)
        {
            ForecastTxt.Text = macroData.ForecastAM.ToString("##.#");
            CapcityTxt.Text = macroData.BatteryCapacity.ToString("##.#");
            SOCTxt.Text = macroData.BatteryPCT.ToString("##.#");
            MinSOC.Text = macroData.BatteryMinimumPCT.ToString("##.#");
            SpareTxt.Text = macroData.Spare.ToString("##.#");
            StartTimeTxt.Text = macroData.StartTime.ToString();
            EndTimeTxt.Text = macroData.EndTime.ToString();
            ChargeRateTxt.Text = macroData.ChargeAmount.ToString("##.#");
        }

        private void MacroForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            macroData.ForecastAM = Convert.ToDouble(ForecastTxt.Text);
            macroData.BatteryCapacity = Convert.ToDouble(CapcityTxt.Text);
            macroData.BatteryPCT = Convert.ToDouble(SOCTxt.Text);
            macroData.BatteryMinimumPCT = Convert.ToDouble(MinSOC.Text);
            // macroData.GoStart        = new TimeOnly(StartTimeTxt.Text);
            // macroData.GoEnd         = new TimeOnly(EndTimeTxt.Text);
            // macroData.ChargeAmount = Convert.ToDouble(ChargeRateTxt.Text);
        }

        private void ForecastTxt_TextChanged(object sender, EventArgs e)
        {
            macroData.ForecastAM = Convert.ToDouble(ForecastTxt.Text);
        }

        private void CapcityTxt_TextChanged(object sender, EventArgs e)
        {
            macroData.BatteryCapacity = Convert.ToDouble(CapcityTxt.Text);
        }

        private void SOCTxt_TextChanged(object sender, EventArgs e)
        {
            macroData.BatteryPCT = Convert.ToDouble(SOCTxt.Text);
        }

        private void StartTimeTxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void EndTimeTxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void ChargeRateTxt_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(ChargeRateTxt.Text, out double res))
                macroData.ChargeAmount = res;
        }

        private void MinSOC_TextChanged(object sender, EventArgs e)
        {
            macroData.BatteryMinimumPCT = Convert.ToDouble(MinSOC.Text);
        }
    }
}