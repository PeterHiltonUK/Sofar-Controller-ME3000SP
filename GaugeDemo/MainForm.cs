using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace V8GaugeDemo
{
    public partial class MainForm : Form
    {
        private V8GaugeLabel label;
        private V8GaugeRange alert;
        public MainForm()
        {
            InitializeComponent();
            label = V8Gauge1.GaugeLabels.FindByName("GaugeLabel1");
            alert = V8Gauge1.GaugeRanges.FindByName("AlertRange");
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            V8Gauge1.Value = trackBar1.Value;
        }

        private void aGauge1_ValueChanged(object sender, EventArgs e)
        {
            label.Text = V8Gauge1.Value.ToString();
        }

        private void aGauge1_ValueInRangeChanged(object sender, System.Windows.Forms.ValueInRangeChangedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("InRange Event.");
            if (e.Range == alert)
            {
                panel1.BackColor = e.InRange ? Color.Red : Color.FromKnownColor(KnownColor.Control);
            }
        }
    }
}
