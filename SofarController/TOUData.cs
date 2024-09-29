namespace SofarController
{
    public class TOUData :ICloneable
    {
        private TimeOnly endTime;
        private DateOnly endDate;
        private ushort TOUPower;
        private bool enabled;
        private TimeOnly startTime;
        private DateOnly startDate;
        private ushort soc;
        double passiveDischargeRate, passiveChargeRate;

        public TimeOnly StartTime { get => startTime; set => startTime = value; }
        public TimeOnly EndTime { get => endTime; set => endTime = value; }
        public DateOnly StartDate { get => startDate; set => startDate = value; }
        public DateOnly EndDate { get => endDate; set => endDate = value; }
        public ushort Soc { get => soc; set => soc = value; }
        public ushort Pow { get => TOUPower; set => TOUPower = value; }
        public bool Enabled { get => enabled; set => enabled = value; }
        public double PassiveDischargeRate { get => passiveDischargeRate; set => passiveDischargeRate = value; }
        public double PassiveChargeRate { get => passiveChargeRate; set => passiveChargeRate = value; }

        public object Clone()
        {
            TOUData tou = new TOUData();
            tou.EndTime = endTime;
            tou.EndDate = endDate;
            tou.Pow = TOUPower;
            tou.StartTime = startTime;
            tou.soc = soc;
            tou.Enabled = enabled;
                
            return tou;
        }

        internal void Update(int i, bool enabled, string startTime, string endTime,
            string startDate, string endDate, ushort soc, ushort power)
        {
            if (DateOnly.TryParse(startDate, out DateOnly SD))
            {
                StartDate = SD;
            }
            if (DateOnly.TryParse(endDate, out DateOnly ED))
            {
                EndDate = ED;
            }

            if (TimeOnly.TryParse(startTime, out TimeOnly ST))
            {
                StartTime = ST;
            }
            if (TimeOnly.TryParse(endTime, out TimeOnly ET))
            {
                EndTime = ET;
            }
            Soc = soc;
            TOUPower = power;
            Enabled = enabled;
        }
    }
}
