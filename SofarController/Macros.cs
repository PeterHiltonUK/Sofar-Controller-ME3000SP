using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SofarController
{
    internal class Macros
    {
        private const double BatterySize = (3.5 + 2.4) * 4 * 0.8; // 18.9 kWh
        private double BatteryPCT;
        private double Forecast;
        private double ChargeAmount;
        private TimeOnly GoStart = new(0, 30), GoEnd = new(5, 30);

        /// <summary>
        /// Run after 12pm
        /// </summary>
        /// <param name="sofar"></param>
        /// <param name="solcast"></param>
        public void ChargeBattteryWhenSolarForecastIsLow(Sofar sofar, Solcast solcast, OptionData options)
        {
            BatteryPCT = sofar.Data[eData.BatteryChrgLevel];
            Forecast = solcast.ForecastAM;
            long span = (GoEnd.Ticks - GoStart.Ticks);
            TimeSpan chargetime = new(span);
            double period = chargetime.Hours;

            if (Forecast - BatteryCapacity() > Forecast)
            {
                ChargeAmount = Forecast - BatteryCapacity() - Forecast;
            }

            ushort chargeRate = (ushort)(ChargeAmount / period); // kWh / h

            sofar.SetWorkMode(WorkMode.TOU,options);

            TOUData tou = new();
            tou.StartTime = GoStart;
            tou.EndTime = GoEnd;
            tou.Pow = chargeRate;
            tou.Enabled = true;
            tou.Soc = 99;

            sofar.WriteTimeOfUseParams(0, tou, options);
        }

        public double BatteryCapacity()
        {
            return 20 * (100 - BatteryPCT);
        }
    }
}