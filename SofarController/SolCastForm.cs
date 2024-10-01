using System.Windows.Forms.DataVisualization.Charting;

namespace SofarController
{
    public partial class SolCastForm : Form
    {
        Solcast solcast;
        public SolCastForm(Solcast solcast)
        {
            InitializeComponent();
            this.solcast = solcast;
            PlotChart2(solcast.forecast);
            v8AMForeCast.Value = (float)solcast.ForecastAM;
            v8PMForeCast.Value = (float)solcast.ForecastPM;
        }

        private void PlotChart2(SollCastMainInfo sd)
        {
            //Set the titles and axis labels
            chart2.Series.Clear();
            chart2.Titles.Clear();
            chart2.Titles.Add("Solcast");
            chart2.Titles[0].Text = "Solcast";
            chart2.Titles[0].Font = new Font(FontFamily.GenericSansSerif, 16);

            Title T2 = chart2.Titles.Add("X");
            T2.Text = "Time";
            T2.Docking = Docking.Bottom;

            Title T3 = chart2.Titles.Add("Y");
            T3.Text = "Flux";
            T3.Docking = Docking.Left;

            Series s1 = chart2.Series.Add("Solar Forecast");
            s1.ChartType = SeriesChartType.Point;

            s1.IsVisibleInLegend = false;

            foreach (var item in sd.forecasts)
            {
                SolCastForeData r = item;
                DataPointCollection list = s1.Points;
                double y = r.pv_estimate;
                string x = r.date().DayOfWeek.ToString() + " " + r.date().TimeOfDay.ToString();
                list.AddXY(x, y);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                v8AMForeCast.Value = (float)solcast.ForecastTodayAM;
                v8PMForeCast.Value = (float)solcast.ForecastTodayPM;
            }
            else
            {
                v8AMForeCast.Value = (float)solcast.ForecastAM;
                v8PMForeCast.Value = (float)solcast.ForecastPM;
            }
        }
    }
}
