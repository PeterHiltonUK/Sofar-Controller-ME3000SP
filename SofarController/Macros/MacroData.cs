namespace SofarController
{
    public class MacroData
    {
        public double BatteryCapacity = 18.9, BatteryPCT = 20, ForecastAM, ChargeAmount, BatteryMinimumPCT=20;
        public TimeOnly StartTime = new(1, 30), EndTime = new(5, 30);

        public double ForecastPM { get; internal set; }

        public void UpdateMacrodata(Sofar sofar, Solcast solcast)
        {
            BatteryPCT = sofar.Data[eData.BatteryChrgLevel];
            ForecastAM = solcast.ForecastAM;
            ForecastPM = solcast.ForecastPM;
        }

        public double Spare
        {
            get
            {
                double res = BatteryCapacity * (1 - (BatteryPCT/100));

                if(res < 0)
                    res = 0;

                return res;
            }
        }
    }
}
