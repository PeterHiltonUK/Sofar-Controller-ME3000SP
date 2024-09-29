namespace V8GaugeDemo
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            V8GaugeLabel aGaugeLabel2 = new V8GaugeLabel();
            V8GaugeRange aGaugeRange4 = new V8GaugeRange();
            V8GaugeRange aGaugeRange5 = new V8GaugeRange();
            V8GaugeRange aGaugeRange6 = new V8GaugeRange();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.V8Gauge1 = new V8Gauge();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // trackBar1
            // 
            this.trackBar1.LargeChange = 20;
            this.trackBar1.Location = new System.Drawing.Point(15, 12);
            this.trackBar1.Maximum = 200;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBar1.Size = new System.Drawing.Size(45, 238);
            this.trackBar1.TabIndex = 1;
            this.trackBar1.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar1.ValueChanged += new System.EventHandler(this.trackBar1_ValueChanged);
            // 
            // aGauge1
            // 
            this.V8Gauge1.BackColor = System.Drawing.Color.Black;
            this.V8Gauge1.BaseArcColor = System.Drawing.Color.Gray;
            this.V8Gauge1.BaseArcRadius = 80;
            this.V8Gauge1.BaseArcStart = 135;
            this.V8Gauge1.BaseArcSweep = 270;
            this.V8Gauge1.BaseArcWidth = 2;
            this.V8Gauge1.Center = new System.Drawing.Point(100, 100);
            aGaugeLabel2.Color = System.Drawing.SystemColors.WindowText;
            aGaugeLabel2.Font = new System.Drawing.Font("Verdana", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            aGaugeLabel2.Name = "GaugeLabel1";
            aGaugeLabel2.Position = new System.Drawing.Point(85, 130);
            aGaugeLabel2.Text = "0";
            this.V8Gauge1.GaugeLabels.Add(aGaugeLabel2);
            aGaugeRange4.Color = System.Drawing.Color.Red;
            aGaugeRange4.EndValue = 200F;
            aGaugeRange4.InnerRadius = 70;
            aGaugeRange4.InRange = false;
            aGaugeRange4.Name = "AlertRange";
            aGaugeRange4.OuterRadius = 80;
            aGaugeRange4.StartValue = 160F;
            aGaugeRange5.Color = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            aGaugeRange5.EndValue = 160F;
            aGaugeRange5.InnerRadius = 70;
            aGaugeRange5.InRange = false;
            aGaugeRange5.Name = "GaugeRange3";
            aGaugeRange5.OuterRadius = 75;
            aGaugeRange5.StartValue = 0F;
            aGaugeRange6.Color = System.Drawing.Color.Lime;
            aGaugeRange6.EndValue = 160F;
            aGaugeRange6.InnerRadius = 75;
            aGaugeRange6.InRange = false;
            aGaugeRange6.Name = "GaugeRange2";
            aGaugeRange6.OuterRadius = 80;
            aGaugeRange6.StartValue = 0F;
            this.V8Gauge1.GaugeRanges.Add(aGaugeRange4);
            this.V8Gauge1.GaugeRanges.Add(aGaugeRange5);
            this.V8Gauge1.GaugeRanges.Add(aGaugeRange6);
            this.V8Gauge1.Location = new System.Drawing.Point(67, 12);
            this.V8Gauge1.MaxValue = 200F;
            this.V8Gauge1.MinValue = 0F;
            this.V8Gauge1.Name = "aGauge1";
            this.V8Gauge1.NeedleColor1 = System.Windows.Forms.V8GaugeNeedleColor.Yellow;
            this.V8Gauge1.NeedleColor2 = System.Drawing.Color.Olive;
            this.V8Gauge1.NeedleRadius = 80;
            this.V8Gauge1.NeedleType = System.Windows.Forms.NeedleType.Advance;
            this.V8Gauge1.NeedleWidth = 2;
            this.V8Gauge1.ScaleLinesInterColor = System.Drawing.Color.Black;
            this.V8Gauge1.ScaleLinesInterInnerRadius = 73;
            this.V8Gauge1.ScaleLinesInterOuterRadius = 80;
            this.V8Gauge1.ScaleLinesInterWidth = 1;
            this.V8Gauge1.ScaleLinesMajorColor = System.Drawing.Color.Black;
            this.V8Gauge1.ScaleLinesMajorInnerRadius = 70;
            this.V8Gauge1.ScaleLinesMajorOuterRadius = 80;
            this.V8Gauge1.ScaleLinesMajorStepValue = 20F;
            this.V8Gauge1.ScaleLinesMajorWidth = 2;
            this.V8Gauge1.ScaleLinesMinorColor = System.Drawing.Color.Gray;
            this.V8Gauge1.ScaleLinesMinorInnerRadius = 75;
            this.V8Gauge1.ScaleLinesMinorOuterRadius = 80;
            this.V8Gauge1.ScaleLinesMinorTicks = 9;
            this.V8Gauge1.ScaleLinesMinorWidth = 1;
            this.V8Gauge1.ScaleNumbersColor = System.Drawing.Color.Black;
            this.V8Gauge1.ScaleNumbersFormat = null;
            this.V8Gauge1.ScaleNumbersRadius = 95;
            this.V8Gauge1.ScaleNumbersRotation = 0;
            this.V8Gauge1.ScaleNumbersStartScaleLine = 0;
            this.V8Gauge1.ScaleNumbersStepScaleLines = 1;
            this.V8Gauge1.Size = new System.Drawing.Size(205, 180);
            this.V8Gauge1.TabIndex = 0;
            this.V8Gauge1.Text = "aGauge1";
            this.V8Gauge1.Value = 0F;
            this.V8Gauge1.ValueChanged += new System.EventHandler(this.aGauge1_ValueChanged);
            this.V8Gauge1.ValueInRangeChanged += new System.EventHandler<System.Windows.Forms.ValueInRangeChangedEventArgs>(this.aGauge1_ValueInRangeChanged);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(199, 198);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(47, 28);
            this.panel1.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.V8Gauge1);
            this.Name = "MainForm";
            this.Text = "GaugeDemo";
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.V8Gauge V8Gauge1;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Panel panel1;

    }
}

