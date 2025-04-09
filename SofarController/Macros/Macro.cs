namespace SofarController
{
    internal class Macros
    {
        public TOUData ChargeBattteryWhenSolarForecastIsLow(Sofar sofar, OptionData options, MacroData data)
        {
            long span = (data.EndTime.Ticks - data.StartTime.Ticks);

            TimeSpan chargetime = new(span);
            double period = chargetime.Hours;

            if (data.ForecastAM < data.Spare)
            {
                data.ChargeAmount = data.Spare - data.ForecastAM;
            }

            ushort chargeRate = (ushort)(data.ChargeAmount / period); // kWh / h

            sofar.SetWorkMode(WorkMode.TOU, options);

            TOUData tou = new();
            tou.StartTime = data.StartTime;
            tou.EndTime = data.EndTime;
            tou.Pow = chargeRate;
            tou.Enabled = true;
            tou.Soc = 99;

            return tou;
        }



        public void UpdateMacrodata(Sofar sofar, Solcast solcast, MacroData data)
        {
            data.BatteryPCT = sofar.Data[eData.BatteryChrgLevel];
            data.ForecastAM = solcast.ForecastAM;
            data.ForecastPM = solcast.ForecastPM;
        }
    }
}
