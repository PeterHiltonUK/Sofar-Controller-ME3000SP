namespace SofarController
{
    partial class SolCastForm
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
            V8GaugeLabel v8GaugeLabel1 = new V8GaugeLabel();
            V8GaugeLabel v8GaugeLabel2 = new V8GaugeLabel();
            chart2 = new Charts.ChartControl();
            v8AMForeCast = new V8Gauge();
            v8PMForeCast = new V8Gauge();
            checkBox1 = new CheckBox();
            SuspendLayout();
            // 
            // chart2
            // 
            chart2.Dock = DockStyle.Left;
            chart2.ForeColor = Color.Black;
            chart2.Location = new Point(0, 0);
            chart2.Margin = new Padding(4, 3, 4, 3);
            chart2.Name = "chart2";
            chart2.Size = new Size(616, 505);
            chart2.TabIndex = 20;
            // 
            // v8AMForeCast
            // 
            v8AMForeCast.BaseArcColor = Color.Cyan;
            v8AMForeCast.BaseArcRadius = 75;
            v8AMForeCast.BaseArcStart = 135;
            v8AMForeCast.BaseArcSweep = 270;
            v8AMForeCast.BaseArcWidth = 2;
            v8AMForeCast.Center = new Point(100, 100);
            v8GaugeLabel1.Color = SystemColors.Info;
            v8GaugeLabel1.Name = "GaugeLabel1";
            v8GaugeLabel1.Position = new Point(50, 50);
            v8GaugeLabel1.Text = "Forecast AM, kWh";
            v8AMForeCast.GaugeLabels.Add(v8GaugeLabel1);
            v8AMForeCast.Location = new Point(660, 12);
            v8AMForeCast.MaxValue = 30F;
            v8AMForeCast.MinValue = 0F;
            v8AMForeCast.Name = "v8AMForeCast";
            v8AMForeCast.NeedleColor1 = V8GaugeNeedleColor.Blue;
            v8AMForeCast.NeedleColor2 = Color.DimGray;
            v8AMForeCast.NeedleRadius = 80;
            v8AMForeCast.NeedleType = NeedleType.Advance;
            v8AMForeCast.NeedleWidth = 2;
            v8AMForeCast.ScaleLinesInterColor = Color.IndianRed;
            v8AMForeCast.ScaleLinesInterInnerRadius = 70;
            v8AMForeCast.ScaleLinesInterOuterRadius = 75;
            v8AMForeCast.ScaleLinesInterWidth = 1;
            v8AMForeCast.ScaleLinesMajorColor = Color.BlanchedAlmond;
            v8AMForeCast.ScaleLinesMajorInnerRadius = 75;
            v8AMForeCast.ScaleLinesMajorOuterRadius = 65;
            v8AMForeCast.ScaleLinesMajorStepValue = 2F;
            v8AMForeCast.ScaleLinesMajorWidth = 2;
            v8AMForeCast.ScaleLinesMinorColor = Color.Gray;
            v8AMForeCast.ScaleLinesMinorInnerRadius = 75;
            v8AMForeCast.ScaleLinesMinorOuterRadius = 70;
            v8AMForeCast.ScaleLinesMinorTicks = 5;
            v8AMForeCast.ScaleLinesMinorWidth = 1;
            v8AMForeCast.ScaleNumbersColor = Color.FromArgb(0, 192, 192);
            v8AMForeCast.ScaleNumbersFormat = null;
            v8AMForeCast.ScaleNumbersRadius = 90;
            v8AMForeCast.ScaleNumbersRotation = 0;
            v8AMForeCast.ScaleNumbersStartScaleLine = 0;
            v8AMForeCast.ScaleNumbersStepScaleLines = 1;
            v8AMForeCast.Size = new Size(210, 180);
            v8AMForeCast.TabIndex = 42;
            v8AMForeCast.Text = "v8Gauge1";
            v8AMForeCast.Value = 0F;
            // 
            // v8PMForeCast
            // 
            v8PMForeCast.BaseArcColor = Color.Cyan;
            v8PMForeCast.BaseArcRadius = 75;
            v8PMForeCast.BaseArcStart = 135;
            v8PMForeCast.BaseArcSweep = 270;
            v8PMForeCast.BaseArcWidth = 2;
            v8PMForeCast.Center = new Point(100, 100);
            v8GaugeLabel2.Color = SystemColors.Info;
            v8GaugeLabel2.Name = "GaugeLabel1";
            v8GaugeLabel2.Position = new Point(55, 50);
            v8GaugeLabel2.Text = "Forecast PM, kWh";
            v8PMForeCast.GaugeLabels.Add(v8GaugeLabel2);
            v8PMForeCast.Location = new Point(660, 198);
            v8PMForeCast.MaxValue = 30F;
            v8PMForeCast.MinValue = 0F;
            v8PMForeCast.Name = "v8PMForeCast";
            v8PMForeCast.NeedleColor1 = V8GaugeNeedleColor.Blue;
            v8PMForeCast.NeedleColor2 = Color.DimGray;
            v8PMForeCast.NeedleRadius = 80;
            v8PMForeCast.NeedleType = NeedleType.Advance;
            v8PMForeCast.NeedleWidth = 2;
            v8PMForeCast.ScaleLinesInterColor = Color.IndianRed;
            v8PMForeCast.ScaleLinesInterInnerRadius = 70;
            v8PMForeCast.ScaleLinesInterOuterRadius = 75;
            v8PMForeCast.ScaleLinesInterWidth = 1;
            v8PMForeCast.ScaleLinesMajorColor = Color.BlanchedAlmond;
            v8PMForeCast.ScaleLinesMajorInnerRadius = 75;
            v8PMForeCast.ScaleLinesMajorOuterRadius = 65;
            v8PMForeCast.ScaleLinesMajorStepValue = 2F;
            v8PMForeCast.ScaleLinesMajorWidth = 2;
            v8PMForeCast.ScaleLinesMinorColor = Color.Gray;
            v8PMForeCast.ScaleLinesMinorInnerRadius = 75;
            v8PMForeCast.ScaleLinesMinorOuterRadius = 70;
            v8PMForeCast.ScaleLinesMinorTicks = 5;
            v8PMForeCast.ScaleLinesMinorWidth = 1;
            v8PMForeCast.ScaleNumbersColor = Color.FromArgb(0, 192, 192);
            v8PMForeCast.ScaleNumbersFormat = null;
            v8PMForeCast.ScaleNumbersRadius = 90;
            v8PMForeCast.ScaleNumbersRotation = 0;
            v8PMForeCast.ScaleNumbersStartScaleLine = 0;
            v8PMForeCast.ScaleNumbersStepScaleLines = 1;
            v8PMForeCast.Size = new Size(210, 180);
            v8PMForeCast.TabIndex = 43;
            v8PMForeCast.Text = "v8Gauge1";
            v8PMForeCast.Value = 0F;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.ForeColor = Color.FromArgb(0, 192, 0);
            checkBox1.Location = new Point(691, 420);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(134, 19);
            checkBox1.TabIndex = 45;
            checkBox1.Text = "Display Today Values";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // SolCastForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(904, 505);
            Controls.Add(checkBox1);
            Controls.Add(v8PMForeCast);
            Controls.Add(v8AMForeCast);
            Controls.Add(chart2);
            Name = "SolCastForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SolCastForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Charts.ChartControl chart2;
        private V8Gauge v8AMForeCast;
        private V8Gauge v8PMForeCast;
        private CheckBox checkBox1;
    }
}