using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ReadOctopus.Octopus;
using System.Windows.Forms.DataVisualization.Charting;

namespace SofarController
{
    public partial class AgileForm : Form
    {
        public AgileForm(Tarrif values)
        {
            InitializeComponent();
            PlotChart(values);
        }

        private void PlotChart(Tarrif t)
        {
            //Set the titles and axis labels
            chart1.Series.Clear();
            chart1.Titles.Clear();
            chart1.Titles.Add("Agile");
            chart1.Titles[0].Text = "Agile Tarrif";
            chart1.Titles[0].Font = new Font(FontFamily.GenericSansSerif, 16);

            Title T2 = chart1.Titles.Add("X");
            T2.Text = "Time";
            T2.Docking = Docking.Bottom;

            Title T3 = chart1.Titles.Add("Y");
            T3.Text = "Value, p/kWHr";
            T3.Docking = Docking.Left;
            T3.Font = new Font(FontFamily.GenericSansSerif, 14);
            //T3.Font.Bold = true;
            //T3.Font.Size = 14;

            Series s1 = chart1.Series.Add("Agile Value");
            s1.ChartType = SeriesChartType.Point;
            s1.IsVisibleInLegend = false;

            foreach (var item in t.results.Reverse())
            {
                result r = item;
                DataPointCollection list = s1.Points;
                double y = r.value_exc_vat;
                string x = r.date().DayOfWeek.ToString() + " " + r.date().TimeOfDay.ToString();
                list.AddXY(x, y);
            }
        }

    }
}
