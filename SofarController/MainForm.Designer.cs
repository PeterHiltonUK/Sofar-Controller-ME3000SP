namespace Controller
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            V8GaugeLabel v8GaugeLabel21 = new V8GaugeLabel();
            V8GaugeLabel v8GaugeLabel22 = new V8GaugeLabel();
            V8GaugeLabel v8GaugeLabel23 = new V8GaugeLabel();
            V8GaugeLabel v8GaugeLabel24 = new V8GaugeLabel();
            V8GaugeLabel v8GaugeLabel25 = new V8GaugeLabel();
            V8GaugeRange v8GaugeRange8 = new V8GaugeRange();
            V8GaugeLabel v8GaugeLabel26 = new V8GaugeLabel();
            V8GaugeRange v8GaugeRange9 = new V8GaugeRange();
            V8GaugeLabel v8GaugeLabel27 = new V8GaugeLabel();
            V8GaugeLabel v8GaugeLabel28 = new V8GaugeLabel();
            V8GaugeLabel v8GaugeLabel29 = new V8GaugeLabel();
            V8GaugeLabel v8GaugeLabel30 = new V8GaugeLabel();
            V8GaugeRange v8GaugeRange10 = new V8GaugeRange();
            V8GaugeLabel v8GaugeLabel31 = new V8GaugeLabel();
            V8GaugeLabel v8GaugeLabel32 = new V8GaugeLabel();
            V8GaugeRange v8GaugeRange11 = new V8GaugeRange();
            V8GaugeLabel v8GaugeLabel33 = new V8GaugeLabel();
            V8GaugeLabel v8GaugeLabel34 = new V8GaugeLabel();
            V8GaugeLabel v8GaugeLabel35 = new V8GaugeLabel();
            V8GaugeLabel v8GaugeLabel36 = new V8GaugeLabel();
            V8GaugeLabel v8GaugeLabel37 = new V8GaugeLabel();
            V8GaugeLabel v8GaugeLabel38 = new V8GaugeLabel();
            V8GaugeRange v8GaugeRange12 = new V8GaugeRange();
            V8GaugeRange v8GaugeRange13 = new V8GaugeRange();
            V8GaugeLabel v8GaugeLabel39 = new V8GaugeLabel();
            V8GaugeLabel v8GaugeLabel40 = new V8GaugeLabel();
            V8GaugeRange v8GaugeRange14 = new V8GaugeRange();
            v8GaugeSold = new V8Gauge();
            v8GaugeGridIO = new V8Gauge();
            v8GaugeInverterT = new V8Gauge();
            v8GaugeBoughtGrid = new V8Gauge();
            v8GaugeHouseConsumption = new V8Gauge();
            v8GaugeConsumed = new V8Gauge();
            v8GaugeBatteryCycles = new V8Gauge();
            v8GaugeCharge = new V8Gauge();
            v8GaugeInternalIO = new V8Gauge();
            groupBox2 = new GroupBox();
            button1 = new Button();
            button17 = new Button();
            button16 = new Button();
            button15 = new Button();
            button14 = new Button();
            button13 = new Button();
            button12 = new Button();
            v8GaugeBattery = new V8Gauge();
            v8GaugeGeneratedSolar = new V8Gauge();
            v8GaugePVPower = new V8Gauge();
            groupBox1 = new GroupBox();
            WIFICBX = new CheckBox();
            TOUMacroCBX = new CheckBox();
            TimedModeRB = new RadioButton();
            PassiveModeRB = new RadioButton();
            TOUModeRB = new RadioButton();
            AutoModeRB = new RadioButton();
            TimeLBL = new Label();
            label1 = new Label();
            button2 = new Button();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // v8GaugeSold
            // 
            v8GaugeSold.BaseArcColor = Color.Cyan;
            v8GaugeSold.BaseArcRadius = 75;
            v8GaugeSold.BaseArcStart = 135;
            v8GaugeSold.BaseArcSweep = 270;
            v8GaugeSold.BaseArcWidth = 2;
            v8GaugeSold.Center = new Point(100, 100);
            v8GaugeLabel21.Color = SystemColors.Info;
            v8GaugeLabel21.Name = "GaugeLabel1";
            v8GaugeLabel21.Position = new Point(70, 50);
            v8GaugeLabel21.Text = "Today Sold";
            v8GaugeLabel22.Color = Color.White;
            v8GaugeLabel22.Name = "GaugeLabel2";
            v8GaugeLabel22.Position = new Point(90, 65);
            v8GaugeLabel22.Text = "kWh";
            v8GaugeSold.GaugeLabels.Add(v8GaugeLabel21);
            v8GaugeSold.GaugeLabels.Add(v8GaugeLabel22);
            v8GaugeSold.Location = new Point(670, 251);
            v8GaugeSold.MaxValue = 20F;
            v8GaugeSold.MinValue = 0F;
            v8GaugeSold.Name = "v8GaugeSold";
            v8GaugeSold.NeedleColor1 = V8GaugeNeedleColor.Blue;
            v8GaugeSold.NeedleColor2 = Color.DimGray;
            v8GaugeSold.NeedleRadius = 80;
            v8GaugeSold.NeedleType = NeedleType.Advance;
            v8GaugeSold.NeedleWidth = 2;
            v8GaugeSold.ScaleLinesInterColor = Color.IndianRed;
            v8GaugeSold.ScaleLinesInterInnerRadius = 70;
            v8GaugeSold.ScaleLinesInterOuterRadius = 75;
            v8GaugeSold.ScaleLinesInterWidth = 1;
            v8GaugeSold.ScaleLinesMajorColor = Color.BlanchedAlmond;
            v8GaugeSold.ScaleLinesMajorInnerRadius = 75;
            v8GaugeSold.ScaleLinesMajorOuterRadius = 65;
            v8GaugeSold.ScaleLinesMajorStepValue = 1F;
            v8GaugeSold.ScaleLinesMajorWidth = 2;
            v8GaugeSold.ScaleLinesMinorColor = Color.Gray;
            v8GaugeSold.ScaleLinesMinorInnerRadius = 75;
            v8GaugeSold.ScaleLinesMinorOuterRadius = 70;
            v8GaugeSold.ScaleLinesMinorTicks = 5;
            v8GaugeSold.ScaleLinesMinorWidth = 1;
            v8GaugeSold.ScaleNumbersColor = Color.FromArgb(0, 192, 192);
            v8GaugeSold.ScaleNumbersFormat = null;
            v8GaugeSold.ScaleNumbersRadius = 90;
            v8GaugeSold.ScaleNumbersRotation = 0;
            v8GaugeSold.ScaleNumbersStartScaleLine = 0;
            v8GaugeSold.ScaleNumbersStepScaleLines = 1;
            v8GaugeSold.Size = new Size(210, 180);
            v8GaugeSold.TabIndex = 27;
            v8GaugeSold.Text = "v8Gauge1";
            v8GaugeSold.Value = 0F;
            // 
            // v8GaugeGridIO
            // 
            v8GaugeGridIO.BaseArcColor = Color.Cyan;
            v8GaugeGridIO.BaseArcRadius = 75;
            v8GaugeGridIO.BaseArcStart = 135;
            v8GaugeGridIO.BaseArcSweep = 270;
            v8GaugeGridIO.BaseArcWidth = 2;
            v8GaugeGridIO.Center = new Point(100, 100);
            v8GaugeLabel23.Color = SystemColors.Info;
            v8GaugeLabel23.Name = "GaugeLabel1";
            v8GaugeLabel23.Position = new Point(70, 50);
            v8GaugeLabel23.Text = "Grid IO, kW";
            v8GaugeLabel24.Color = SystemColors.WindowText;
            v8GaugeLabel24.Name = "GaugeLabel2";
            v8GaugeLabel24.Position = new Point(0, 0);
            v8GaugeLabel24.Text = "90, 130";
            v8GaugeLabel25.Color = Color.Lime;
            v8GaugeLabel25.Name = "GaugeLabel1";
            v8GaugeLabel25.Position = new Point(90, 130);
            v8GaugeLabel25.Text = "";
            v8GaugeGridIO.GaugeLabels.Add(v8GaugeLabel23);
            v8GaugeGridIO.GaugeLabels.Add(v8GaugeLabel24);
            v8GaugeGridIO.GaugeLabels.Add(v8GaugeLabel25);
            v8GaugeRange8.Color = Color.Red;
            v8GaugeRange8.EndValue = 90F;
            v8GaugeRange8.InnerRadius = 1;
            v8GaugeRange8.InRange = false;
            v8GaugeRange8.Name = "GaugeRange1";
            v8GaugeRange8.OuterRadius = 2;
            v8GaugeRange8.StartValue = 0F;
            v8GaugeGridIO.GaugeRanges.Add(v8GaugeRange8);
            v8GaugeGridIO.Location = new Point(459, 461);
            v8GaugeGridIO.MaxValue = 5F;
            v8GaugeGridIO.MinValue = -5F;
            v8GaugeGridIO.Name = "v8GaugeGridIO";
            v8GaugeGridIO.NeedleColor1 = V8GaugeNeedleColor.Blue;
            v8GaugeGridIO.NeedleColor2 = Color.DimGray;
            v8GaugeGridIO.NeedleRadius = 80;
            v8GaugeGridIO.NeedleType = NeedleType.Advance;
            v8GaugeGridIO.NeedleWidth = 2;
            v8GaugeGridIO.ScaleLinesInterColor = Color.IndianRed;
            v8GaugeGridIO.ScaleLinesInterInnerRadius = 70;
            v8GaugeGridIO.ScaleLinesInterOuterRadius = 75;
            v8GaugeGridIO.ScaleLinesInterWidth = 1;
            v8GaugeGridIO.ScaleLinesMajorColor = Color.BlanchedAlmond;
            v8GaugeGridIO.ScaleLinesMajorInnerRadius = 75;
            v8GaugeGridIO.ScaleLinesMajorOuterRadius = 65;
            v8GaugeGridIO.ScaleLinesMajorStepValue = 1F;
            v8GaugeGridIO.ScaleLinesMajorWidth = 2;
            v8GaugeGridIO.ScaleLinesMinorColor = Color.Gray;
            v8GaugeGridIO.ScaleLinesMinorInnerRadius = 75;
            v8GaugeGridIO.ScaleLinesMinorOuterRadius = 70;
            v8GaugeGridIO.ScaleLinesMinorTicks = 5;
            v8GaugeGridIO.ScaleLinesMinorWidth = 1;
            v8GaugeGridIO.ScaleNumbersColor = Color.FromArgb(0, 192, 192);
            v8GaugeGridIO.ScaleNumbersFormat = "f0";
            v8GaugeGridIO.ScaleNumbersRadius = 90;
            v8GaugeGridIO.ScaleNumbersRotation = 0;
            v8GaugeGridIO.ScaleNumbersStartScaleLine = 0;
            v8GaugeGridIO.ScaleNumbersStepScaleLines = 1;
            v8GaugeGridIO.Size = new Size(210, 180);
            v8GaugeGridIO.TabIndex = 30;
            v8GaugeGridIO.Text = "v8Gauge1";
            v8GaugeGridIO.Value = 0F;
            // 
            // v8GaugeInverterT
            // 
            v8GaugeInverterT.BaseArcColor = Color.Cyan;
            v8GaugeInverterT.BaseArcRadius = 80;
            v8GaugeInverterT.BaseArcStart = 135;
            v8GaugeInverterT.BaseArcSweep = 270;
            v8GaugeInverterT.BaseArcWidth = 2;
            v8GaugeInverterT.Center = new Point(100, 100);
            v8GaugeLabel26.Color = SystemColors.Info;
            v8GaugeLabel26.Name = "GaugeLabel1";
            v8GaugeLabel26.Position = new Point(67, 50);
            v8GaugeLabel26.Text = "Inverter Deg C";
            v8GaugeInverterT.GaugeLabels.Add(v8GaugeLabel26);
            v8GaugeRange9.Color = Color.Red;
            v8GaugeRange9.EndValue = 100F;
            v8GaugeRange9.InnerRadius = 70;
            v8GaugeRange9.InRange = true;
            v8GaugeRange9.Name = "GaugeRange1";
            v8GaugeRange9.OuterRadius = 80;
            v8GaugeRange9.StartValue = 45F;
            v8GaugeInverterT.GaugeRanges.Add(v8GaugeRange9);
            v8GaugeInverterT.Location = new Point(673, 461);
            v8GaugeInverterT.MaxValue = 100F;
            v8GaugeInverterT.MinValue = 0F;
            v8GaugeInverterT.Name = "v8GaugeInverterT";
            v8GaugeInverterT.NeedleColor1 = V8GaugeNeedleColor.Blue;
            v8GaugeInverterT.NeedleColor2 = Color.DimGray;
            v8GaugeInverterT.NeedleRadius = 80;
            v8GaugeInverterT.NeedleType = NeedleType.Advance;
            v8GaugeInverterT.NeedleWidth = 2;
            v8GaugeInverterT.ScaleLinesInterColor = Color.IndianRed;
            v8GaugeInverterT.ScaleLinesInterInnerRadius = 73;
            v8GaugeInverterT.ScaleLinesInterOuterRadius = 80;
            v8GaugeInverterT.ScaleLinesInterWidth = 1;
            v8GaugeInverterT.ScaleLinesMajorColor = Color.BlanchedAlmond;
            v8GaugeInverterT.ScaleLinesMajorInnerRadius = 70;
            v8GaugeInverterT.ScaleLinesMajorOuterRadius = 80;
            v8GaugeInverterT.ScaleLinesMajorStepValue = 10F;
            v8GaugeInverterT.ScaleLinesMajorWidth = 2;
            v8GaugeInverterT.ScaleLinesMinorColor = Color.Gray;
            v8GaugeInverterT.ScaleLinesMinorInnerRadius = 75;
            v8GaugeInverterT.ScaleLinesMinorOuterRadius = 80;
            v8GaugeInverterT.ScaleLinesMinorTicks = 9;
            v8GaugeInverterT.ScaleLinesMinorWidth = 1;
            v8GaugeInverterT.ScaleNumbersColor = Color.FromArgb(0, 192, 192);
            v8GaugeInverterT.ScaleNumbersFormat = null;
            v8GaugeInverterT.ScaleNumbersRadius = 95;
            v8GaugeInverterT.ScaleNumbersRotation = 0;
            v8GaugeInverterT.ScaleNumbersStartScaleLine = 0;
            v8GaugeInverterT.ScaleNumbersStepScaleLines = 1;
            v8GaugeInverterT.Size = new Size(205, 180);
            v8GaugeInverterT.TabIndex = 31;
            v8GaugeInverterT.Text = "v8Gauge2";
            v8GaugeInverterT.Value = 0F;
            // 
            // v8GaugeBoughtGrid
            // 
            v8GaugeBoughtGrid.BaseArcColor = Color.Cyan;
            v8GaugeBoughtGrid.BaseArcRadius = 75;
            v8GaugeBoughtGrid.BaseArcStart = 135;
            v8GaugeBoughtGrid.BaseArcSweep = 270;
            v8GaugeBoughtGrid.BaseArcWidth = 2;
            v8GaugeBoughtGrid.Center = new Point(100, 100);
            v8GaugeLabel27.Color = SystemColors.Info;
            v8GaugeLabel27.Name = "GaugeLabel1";
            v8GaugeLabel27.Position = new Point(69, 50);
            v8GaugeLabel27.Text = "Grid Bought";
            v8GaugeLabel28.Color = Color.White;
            v8GaugeLabel28.Name = "GaugeLabel2";
            v8GaugeLabel28.Position = new Point(90, 65);
            v8GaugeLabel28.Text = "kWh";
            v8GaugeBoughtGrid.GaugeLabels.Add(v8GaugeLabel27);
            v8GaugeBoughtGrid.GaugeLabels.Add(v8GaugeLabel28);
            v8GaugeBoughtGrid.Location = new Point(246, 251);
            v8GaugeBoughtGrid.MaxValue = 40F;
            v8GaugeBoughtGrid.MinValue = 0F;
            v8GaugeBoughtGrid.Name = "v8GaugeBoughtGrid";
            v8GaugeBoughtGrid.NeedleColor1 = V8GaugeNeedleColor.Blue;
            v8GaugeBoughtGrid.NeedleColor2 = Color.DimGray;
            v8GaugeBoughtGrid.NeedleRadius = 80;
            v8GaugeBoughtGrid.NeedleType = NeedleType.Advance;
            v8GaugeBoughtGrid.NeedleWidth = 2;
            v8GaugeBoughtGrid.ScaleLinesInterColor = Color.IndianRed;
            v8GaugeBoughtGrid.ScaleLinesInterInnerRadius = 70;
            v8GaugeBoughtGrid.ScaleLinesInterOuterRadius = 75;
            v8GaugeBoughtGrid.ScaleLinesInterWidth = 1;
            v8GaugeBoughtGrid.ScaleLinesMajorColor = Color.BlanchedAlmond;
            v8GaugeBoughtGrid.ScaleLinesMajorInnerRadius = 75;
            v8GaugeBoughtGrid.ScaleLinesMajorOuterRadius = 65;
            v8GaugeBoughtGrid.ScaleLinesMajorStepValue = 5F;
            v8GaugeBoughtGrid.ScaleLinesMajorWidth = 2;
            v8GaugeBoughtGrid.ScaleLinesMinorColor = Color.Gray;
            v8GaugeBoughtGrid.ScaleLinesMinorInnerRadius = 75;
            v8GaugeBoughtGrid.ScaleLinesMinorOuterRadius = 70;
            v8GaugeBoughtGrid.ScaleLinesMinorTicks = 5;
            v8GaugeBoughtGrid.ScaleLinesMinorWidth = 1;
            v8GaugeBoughtGrid.ScaleNumbersColor = Color.FromArgb(0, 192, 192);
            v8GaugeBoughtGrid.ScaleNumbersFormat = null;
            v8GaugeBoughtGrid.ScaleNumbersRadius = 90;
            v8GaugeBoughtGrid.ScaleNumbersRotation = 0;
            v8GaugeBoughtGrid.ScaleNumbersStartScaleLine = 0;
            v8GaugeBoughtGrid.ScaleNumbersStepScaleLines = 1;
            v8GaugeBoughtGrid.Size = new Size(210, 180);
            v8GaugeBoughtGrid.TabIndex = 35;
            v8GaugeBoughtGrid.Text = "v8Gauge1";
            v8GaugeBoughtGrid.Value = 0F;
            // 
            // v8GaugeHouseConsumption
            // 
            v8GaugeHouseConsumption.BaseArcColor = Color.Cyan;
            v8GaugeHouseConsumption.BaseArcRadius = 75;
            v8GaugeHouseConsumption.BaseArcStart = 135;
            v8GaugeHouseConsumption.BaseArcSweep = 270;
            v8GaugeHouseConsumption.BaseArcWidth = 2;
            v8GaugeHouseConsumption.Center = new Point(100, 100);
            v8GaugeLabel29.Color = SystemColors.Info;
            v8GaugeLabel29.Name = "GaugeLabel1";
            v8GaugeLabel29.Position = new Point(65, 50);
            v8GaugeLabel29.Text = "Consumption";
            v8GaugeLabel30.Color = SystemColors.Window;
            v8GaugeLabel30.Name = "GaugeLabel2";
            v8GaugeLabel30.Position = new Point(90, 64);
            v8GaugeLabel30.Text = "kW";
            v8GaugeHouseConsumption.GaugeLabels.Add(v8GaugeLabel29);
            v8GaugeHouseConsumption.GaugeLabels.Add(v8GaugeLabel30);
            v8GaugeRange10.Color = Color.FromArgb(192, 0, 0);
            v8GaugeRange10.EndValue = 5F;
            v8GaugeRange10.InnerRadius = 65;
            v8GaugeRange10.InRange = false;
            v8GaugeRange10.Name = "GaugeRange1";
            v8GaugeRange10.OuterRadius = 75;
            v8GaugeRange10.StartValue = 3F;
            v8GaugeHouseConsumption.GaugeRanges.Add(v8GaugeRange10);
            v8GaugeHouseConsumption.Location = new Point(30, 251);
            v8GaugeHouseConsumption.MaxValue = 5F;
            v8GaugeHouseConsumption.MinValue = 0F;
            v8GaugeHouseConsumption.Name = "v8GaugeHouseConsumption";
            v8GaugeHouseConsumption.NeedleColor1 = V8GaugeNeedleColor.Blue;
            v8GaugeHouseConsumption.NeedleColor2 = Color.DimGray;
            v8GaugeHouseConsumption.NeedleRadius = 80;
            v8GaugeHouseConsumption.NeedleType = NeedleType.Advance;
            v8GaugeHouseConsumption.NeedleWidth = 2;
            v8GaugeHouseConsumption.ScaleLinesInterColor = Color.IndianRed;
            v8GaugeHouseConsumption.ScaleLinesInterInnerRadius = 70;
            v8GaugeHouseConsumption.ScaleLinesInterOuterRadius = 75;
            v8GaugeHouseConsumption.ScaleLinesInterWidth = 1;
            v8GaugeHouseConsumption.ScaleLinesMajorColor = Color.BlanchedAlmond;
            v8GaugeHouseConsumption.ScaleLinesMajorInnerRadius = 75;
            v8GaugeHouseConsumption.ScaleLinesMajorOuterRadius = 65;
            v8GaugeHouseConsumption.ScaleLinesMajorStepValue = 0.5F;
            v8GaugeHouseConsumption.ScaleLinesMajorWidth = 2;
            v8GaugeHouseConsumption.ScaleLinesMinorColor = Color.Gray;
            v8GaugeHouseConsumption.ScaleLinesMinorInnerRadius = 75;
            v8GaugeHouseConsumption.ScaleLinesMinorOuterRadius = 70;
            v8GaugeHouseConsumption.ScaleLinesMinorTicks = 5;
            v8GaugeHouseConsumption.ScaleLinesMinorWidth = 1;
            v8GaugeHouseConsumption.ScaleNumbersColor = Color.FromArgb(0, 192, 192);
            v8GaugeHouseConsumption.ScaleNumbersFormat = null;
            v8GaugeHouseConsumption.ScaleNumbersRadius = 90;
            v8GaugeHouseConsumption.ScaleNumbersRotation = 0;
            v8GaugeHouseConsumption.ScaleNumbersStartScaleLine = 0;
            v8GaugeHouseConsumption.ScaleNumbersStepScaleLines = 1;
            v8GaugeHouseConsumption.Size = new Size(210, 180);
            v8GaugeHouseConsumption.TabIndex = 34;
            v8GaugeHouseConsumption.Text = "v8Gauge1";
            v8GaugeHouseConsumption.Value = 0F;
            // 
            // v8GaugeConsumed
            // 
            v8GaugeConsumed.BaseArcColor = Color.Cyan;
            v8GaugeConsumed.BaseArcRadius = 75;
            v8GaugeConsumed.BaseArcStart = 135;
            v8GaugeConsumed.BaseArcSweep = 270;
            v8GaugeConsumed.BaseArcWidth = 2;
            v8GaugeConsumed.Center = new Point(100, 100);
            v8GaugeLabel31.Color = SystemColors.Info;
            v8GaugeLabel31.Name = "GaugeLabel1";
            v8GaugeLabel31.Position = new Point(58, 50);
            v8GaugeLabel31.Text = "Today Consumed";
            v8GaugeConsumed.GaugeLabels.Add(v8GaugeLabel31);
            v8GaugeConsumed.Location = new Point(30, 461);
            v8GaugeConsumed.MaxValue = 20F;
            v8GaugeConsumed.MinValue = 0F;
            v8GaugeConsumed.Name = "v8GaugeConsumed";
            v8GaugeConsumed.NeedleColor1 = V8GaugeNeedleColor.Blue;
            v8GaugeConsumed.NeedleColor2 = Color.DimGray;
            v8GaugeConsumed.NeedleRadius = 80;
            v8GaugeConsumed.NeedleType = NeedleType.Advance;
            v8GaugeConsumed.NeedleWidth = 2;
            v8GaugeConsumed.ScaleLinesInterColor = Color.IndianRed;
            v8GaugeConsumed.ScaleLinesInterInnerRadius = 70;
            v8GaugeConsumed.ScaleLinesInterOuterRadius = 75;
            v8GaugeConsumed.ScaleLinesInterWidth = 1;
            v8GaugeConsumed.ScaleLinesMajorColor = Color.BlanchedAlmond;
            v8GaugeConsumed.ScaleLinesMajorInnerRadius = 75;
            v8GaugeConsumed.ScaleLinesMajorOuterRadius = 65;
            v8GaugeConsumed.ScaleLinesMajorStepValue = 1F;
            v8GaugeConsumed.ScaleLinesMajorWidth = 2;
            v8GaugeConsumed.ScaleLinesMinorColor = Color.Gray;
            v8GaugeConsumed.ScaleLinesMinorInnerRadius = 75;
            v8GaugeConsumed.ScaleLinesMinorOuterRadius = 70;
            v8GaugeConsumed.ScaleLinesMinorTicks = 5;
            v8GaugeConsumed.ScaleLinesMinorWidth = 1;
            v8GaugeConsumed.ScaleNumbersColor = Color.FromArgb(0, 192, 192);
            v8GaugeConsumed.ScaleNumbersFormat = null;
            v8GaugeConsumed.ScaleNumbersRadius = 90;
            v8GaugeConsumed.ScaleNumbersRotation = 0;
            v8GaugeConsumed.ScaleNumbersStartScaleLine = 0;
            v8GaugeConsumed.ScaleNumbersStepScaleLines = 1;
            v8GaugeConsumed.Size = new Size(210, 180);
            v8GaugeConsumed.TabIndex = 37;
            v8GaugeConsumed.Text = "v8Gauge1";
            v8GaugeConsumed.Value = 0F;
            // 
            // v8GaugeBatteryCycles
            // 
            v8GaugeBatteryCycles.BaseArcColor = Color.Cyan;
            v8GaugeBatteryCycles.BaseArcRadius = 75;
            v8GaugeBatteryCycles.BaseArcStart = 135;
            v8GaugeBatteryCycles.BaseArcSweep = 270;
            v8GaugeBatteryCycles.BaseArcWidth = 2;
            v8GaugeBatteryCycles.Center = new Point(100, 100);
            v8GaugeLabel32.Color = SystemColors.Info;
            v8GaugeLabel32.Name = "GaugeLabel1";
            v8GaugeLabel32.Position = new Point(65, 50);
            v8GaugeLabel32.Text = "Battery Cycles";
            v8GaugeBatteryCycles.GaugeLabels.Add(v8GaugeLabel32);
            v8GaugeRange11.Color = Color.Red;
            v8GaugeRange11.EndValue = 8000F;
            v8GaugeRange11.InnerRadius = 65;
            v8GaugeRange11.InRange = false;
            v8GaugeRange11.Name = "GaugeRange1";
            v8GaugeRange11.OuterRadius = 75;
            v8GaugeRange11.StartValue = 6000F;
            v8GaugeBatteryCycles.GaugeRanges.Add(v8GaugeRange11);
            v8GaugeBatteryCycles.Location = new Point(246, 461);
            v8GaugeBatteryCycles.MaxValue = 8000F;
            v8GaugeBatteryCycles.MinValue = 0F;
            v8GaugeBatteryCycles.Name = "v8GaugeBatteryCycles";
            v8GaugeBatteryCycles.NeedleColor1 = V8GaugeNeedleColor.Blue;
            v8GaugeBatteryCycles.NeedleColor2 = Color.DimGray;
            v8GaugeBatteryCycles.NeedleRadius = 80;
            v8GaugeBatteryCycles.NeedleType = NeedleType.Advance;
            v8GaugeBatteryCycles.NeedleWidth = 2;
            v8GaugeBatteryCycles.ScaleLinesInterColor = Color.IndianRed;
            v8GaugeBatteryCycles.ScaleLinesInterInnerRadius = 70;
            v8GaugeBatteryCycles.ScaleLinesInterOuterRadius = 75;
            v8GaugeBatteryCycles.ScaleLinesInterWidth = 1;
            v8GaugeBatteryCycles.ScaleLinesMajorColor = Color.BlanchedAlmond;
            v8GaugeBatteryCycles.ScaleLinesMajorInnerRadius = 75;
            v8GaugeBatteryCycles.ScaleLinesMajorOuterRadius = 65;
            v8GaugeBatteryCycles.ScaleLinesMajorStepValue = 800F;
            v8GaugeBatteryCycles.ScaleLinesMajorWidth = 2;
            v8GaugeBatteryCycles.ScaleLinesMinorColor = Color.Gray;
            v8GaugeBatteryCycles.ScaleLinesMinorInnerRadius = 75;
            v8GaugeBatteryCycles.ScaleLinesMinorOuterRadius = 70;
            v8GaugeBatteryCycles.ScaleLinesMinorTicks = 5;
            v8GaugeBatteryCycles.ScaleLinesMinorWidth = 1;
            v8GaugeBatteryCycles.ScaleNumbersColor = Color.FromArgb(0, 192, 192);
            v8GaugeBatteryCycles.ScaleNumbersFormat = null;
            v8GaugeBatteryCycles.ScaleNumbersRadius = 90;
            v8GaugeBatteryCycles.ScaleNumbersRotation = 0;
            v8GaugeBatteryCycles.ScaleNumbersStartScaleLine = 0;
            v8GaugeBatteryCycles.ScaleNumbersStepScaleLines = 1;
            v8GaugeBatteryCycles.Size = new Size(210, 180);
            v8GaugeBatteryCycles.TabIndex = 38;
            v8GaugeBatteryCycles.Text = "v8Gauge1";
            v8GaugeBatteryCycles.Value = 0F;
            // 
            // v8GaugeCharge
            // 
            v8GaugeCharge.BaseArcColor = Color.Cyan;
            v8GaugeCharge.BaseArcRadius = 70;
            v8GaugeCharge.BaseArcStart = 135;
            v8GaugeCharge.BaseArcSweep = 270;
            v8GaugeCharge.BaseArcWidth = 2;
            v8GaugeCharge.Center = new Point(100, 100);
            v8GaugeLabel33.Color = SystemColors.Info;
            v8GaugeLabel33.Name = "GaugeLabel1";
            v8GaugeLabel33.Position = new Point(62, 50);
            v8GaugeLabel33.Text = "Battery Charge";
            v8GaugeCharge.GaugeLabels.Add(v8GaugeLabel33);
            v8GaugeCharge.Location = new Point(673, 42);
            v8GaugeCharge.MaxValue = 4F;
            v8GaugeCharge.MinValue = -4F;
            v8GaugeCharge.Name = "v8GaugeCharge";
            v8GaugeCharge.NeedleColor1 = V8GaugeNeedleColor.Blue;
            v8GaugeCharge.NeedleColor2 = Color.DimGray;
            v8GaugeCharge.NeedleRadius = 80;
            v8GaugeCharge.NeedleType = NeedleType.Advance;
            v8GaugeCharge.NeedleWidth = 2;
            v8GaugeCharge.ScaleLinesInterColor = Color.IndianRed;
            v8GaugeCharge.ScaleLinesInterInnerRadius = 65;
            v8GaugeCharge.ScaleLinesInterOuterRadius = 70;
            v8GaugeCharge.ScaleLinesInterWidth = 1;
            v8GaugeCharge.ScaleLinesMajorColor = Color.BlanchedAlmond;
            v8GaugeCharge.ScaleLinesMajorInnerRadius = 60;
            v8GaugeCharge.ScaleLinesMajorOuterRadius = 70;
            v8GaugeCharge.ScaleLinesMajorStepValue = 0.5F;
            v8GaugeCharge.ScaleLinesMajorWidth = 2;
            v8GaugeCharge.ScaleLinesMinorColor = Color.Gray;
            v8GaugeCharge.ScaleLinesMinorInnerRadius = 65;
            v8GaugeCharge.ScaleLinesMinorOuterRadius = 70;
            v8GaugeCharge.ScaleLinesMinorTicks = 5;
            v8GaugeCharge.ScaleLinesMinorWidth = 1;
            v8GaugeCharge.ScaleNumbersColor = Color.FromArgb(0, 192, 192);
            v8GaugeCharge.ScaleNumbersFormat = "F1";
            v8GaugeCharge.ScaleNumbersRadius = 87;
            v8GaugeCharge.ScaleNumbersRotation = 0;
            v8GaugeCharge.ScaleNumbersStartScaleLine = 0;
            v8GaugeCharge.ScaleNumbersStepScaleLines = 1;
            v8GaugeCharge.Size = new Size(205, 180);
            v8GaugeCharge.TabIndex = 33;
            v8GaugeCharge.Text = "v8Gauge3";
            v8GaugeCharge.Value = 0F;
            // 
            // v8GaugeInternalIO
            // 
            v8GaugeInternalIO.BaseArcColor = Color.Cyan;
            v8GaugeInternalIO.BaseArcRadius = 75;
            v8GaugeInternalIO.BaseArcStart = 135;
            v8GaugeInternalIO.BaseArcSweep = 270;
            v8GaugeInternalIO.BaseArcWidth = 2;
            v8GaugeInternalIO.Center = new Point(100, 100);
            v8GaugeLabel34.Color = SystemColors.Info;
            v8GaugeLabel34.Name = "GaugeLabel1";
            v8GaugeLabel34.Position = new Point(72, 50);
            v8GaugeLabel34.Text = "Internal IO";
            v8GaugeLabel35.Color = Color.White;
            v8GaugeLabel35.Name = "GaugeLabel2";
            v8GaugeLabel35.Position = new Point(90, 65);
            v8GaugeLabel35.Text = "kW";
            v8GaugeLabel36.Color = Color.Lime;
            v8GaugeLabel36.Name = "GaugeLabel1";
            v8GaugeLabel36.Position = new Point(90, 130);
            v8GaugeLabel36.Text = null;
            v8GaugeInternalIO.GaugeLabels.Add(v8GaugeLabel34);
            v8GaugeInternalIO.GaugeLabels.Add(v8GaugeLabel35);
            v8GaugeInternalIO.GaugeLabels.Add(v8GaugeLabel36);
            v8GaugeInternalIO.Location = new Point(459, 251);
            v8GaugeInternalIO.MaxValue = 5F;
            v8GaugeInternalIO.MinValue = -5F;
            v8GaugeInternalIO.Name = "v8GaugeInternalIO";
            v8GaugeInternalIO.NeedleColor1 = V8GaugeNeedleColor.Blue;
            v8GaugeInternalIO.NeedleColor2 = Color.DimGray;
            v8GaugeInternalIO.NeedleRadius = 80;
            v8GaugeInternalIO.NeedleType = NeedleType.Advance;
            v8GaugeInternalIO.NeedleWidth = 2;
            v8GaugeInternalIO.ScaleLinesInterColor = Color.IndianRed;
            v8GaugeInternalIO.ScaleLinesInterInnerRadius = 70;
            v8GaugeInternalIO.ScaleLinesInterOuterRadius = 75;
            v8GaugeInternalIO.ScaleLinesInterWidth = 1;
            v8GaugeInternalIO.ScaleLinesMajorColor = Color.BlanchedAlmond;
            v8GaugeInternalIO.ScaleLinesMajorInnerRadius = 75;
            v8GaugeInternalIO.ScaleLinesMajorOuterRadius = 65;
            v8GaugeInternalIO.ScaleLinesMajorStepValue = 1F;
            v8GaugeInternalIO.ScaleLinesMajorWidth = 2;
            v8GaugeInternalIO.ScaleLinesMinorColor = Color.Gray;
            v8GaugeInternalIO.ScaleLinesMinorInnerRadius = 75;
            v8GaugeInternalIO.ScaleLinesMinorOuterRadius = 70;
            v8GaugeInternalIO.ScaleLinesMinorTicks = 5;
            v8GaugeInternalIO.ScaleLinesMinorWidth = 1;
            v8GaugeInternalIO.ScaleNumbersColor = Color.FromArgb(0, 192, 192);
            v8GaugeInternalIO.ScaleNumbersFormat = null;
            v8GaugeInternalIO.ScaleNumbersRadius = 90;
            v8GaugeInternalIO.ScaleNumbersRotation = 0;
            v8GaugeInternalIO.ScaleNumbersStartScaleLine = 0;
            v8GaugeInternalIO.ScaleNumbersStepScaleLines = 1;
            v8GaugeInternalIO.Size = new Size(210, 180);
            v8GaugeInternalIO.TabIndex = 36;
            v8GaugeInternalIO.Text = "v8Gauge1";
            v8GaugeInternalIO.Value = 0F;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(button1);
            groupBox2.Controls.Add(button17);
            groupBox2.Controls.Add(button16);
            groupBox2.Controls.Add(button15);
            groupBox2.Controls.Add(button14);
            groupBox2.Controls.Add(button13);
            groupBox2.Controls.Add(button12);
            groupBox2.ForeColor = Color.LightGreen;
            groupBox2.Location = new Point(931, 31);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(338, 334);
            groupBox2.TabIndex = 39;
            groupBox2.TabStop = false;
            groupBox2.Text = "Control";
            // 
            // button1
            // 
            button1.BackColor = Color.Black;
            button1.ForeColor = Color.Chartreuse;
            button1.Location = new Point(42, 238);
            button1.Name = "button1";
            button1.Size = new Size(247, 33);
            button1.TabIndex = 6;
            button1.Text = "View Sofar Data";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button17
            // 
            button17.BackColor = Color.Black;
            button17.ForeColor = Color.Chartreuse;
            button17.Location = new Point(42, 283);
            button17.Name = "button17";
            button17.Size = new Size(247, 33);
            button17.TabIndex = 5;
            button17.Text = "Scripting";
            button17.UseVisualStyleBackColor = false;
            // 
            // button16
            // 
            button16.BackColor = Color.Black;
            button16.ForeColor = Color.Chartreuse;
            button16.Location = new Point(42, 197);
            button16.Name = "button16";
            button16.Size = new Size(247, 33);
            button16.TabIndex = 4;
            button16.Text = "View Agile Data";
            button16.UseVisualStyleBackColor = false;
            button16.Click += Agile_Click;
            // 
            // button15
            // 
            button15.BackColor = Color.Black;
            button15.ForeColor = Color.Chartreuse;
            button15.Location = new Point(42, 158);
            button15.Name = "button15";
            button15.Size = new Size(247, 33);
            button15.TabIndex = 3;
            button15.Text = "View Solcast";
            button15.UseVisualStyleBackColor = false;
            button15.Click += SolCastData_Click;
            // 
            // button14
            // 
            button14.BackColor = Color.Black;
            button14.ForeColor = Color.Chartreuse;
            button14.Location = new Point(42, 119);
            button14.Name = "button14";
            button14.Size = new Size(247, 33);
            button14.TabIndex = 2;
            button14.Text = "Set Passive Mode";
            button14.UseVisualStyleBackColor = false;
            button14.Click += Passive_Click;
            // 
            // button13
            // 
            button13.BackColor = Color.Black;
            button13.ForeColor = Color.Chartreuse;
            button13.Location = new Point(42, 80);
            button13.Name = "button13";
            button13.Size = new Size(247, 33);
            button13.TabIndex = 1;
            button13.Text = "Set TOU Mode";
            button13.UseVisualStyleBackColor = false;
            button13.Click += TOU_Click;
            // 
            // button12
            // 
            button12.BackColor = Color.Black;
            button12.ForeColor = Color.Chartreuse;
            button12.Location = new Point(42, 41);
            button12.Name = "button12";
            button12.Size = new Size(247, 33);
            button12.TabIndex = 0;
            button12.Text = "Options";
            button12.UseVisualStyleBackColor = false;
            button12.Click += Options_Click;
            // 
            // v8GaugeBattery
            // 
            v8GaugeBattery.BaseArcColor = Color.Cyan;
            v8GaugeBattery.BaseArcRadius = 80;
            v8GaugeBattery.BaseArcStart = 135;
            v8GaugeBattery.BaseArcSweep = 270;
            v8GaugeBattery.BaseArcWidth = 2;
            v8GaugeBattery.Center = new Point(100, 100);
            v8GaugeLabel37.Color = SystemColors.Info;
            v8GaugeLabel37.Name = "GaugeLabel1";
            v8GaugeLabel37.Position = new Point(74, 50);
            v8GaugeLabel37.Text = "Battery %";
            v8GaugeLabel38.Color = Color.Lime;
            v8GaugeLabel38.Name = "GaugeLabel2";
            v8GaugeLabel38.Position = new Point(90, 130);
            v8GaugeLabel38.Text = "0";
            v8GaugeBattery.GaugeLabels.Add(v8GaugeLabel37);
            v8GaugeBattery.GaugeLabels.Add(v8GaugeLabel38);
            v8GaugeRange12.Color = Color.Red;
            v8GaugeRange12.EndValue = 20F;
            v8GaugeRange12.InnerRadius = 70;
            v8GaugeRange12.InRange = true;
            v8GaugeRange12.Name = "GaugeRange1";
            v8GaugeRange12.OuterRadius = 80;
            v8GaugeRange12.StartValue = 0F;
            v8GaugeRange13.Color = Color.FromArgb(0, 192, 0);
            v8GaugeRange13.EndValue = 100F;
            v8GaugeRange13.InnerRadius = 70;
            v8GaugeRange13.InRange = false;
            v8GaugeRange13.Name = "GaugeRange2";
            v8GaugeRange13.OuterRadius = 80;
            v8GaugeRange13.StartValue = 20F;
            v8GaugeBattery.GaugeRanges.Add(v8GaugeRange12);
            v8GaugeBattery.GaugeRanges.Add(v8GaugeRange13);
            v8GaugeBattery.Location = new Point(462, 42);
            v8GaugeBattery.MaxValue = 100F;
            v8GaugeBattery.MinValue = 0F;
            v8GaugeBattery.Name = "v8GaugeBattery";
            v8GaugeBattery.NeedleColor1 = V8GaugeNeedleColor.Blue;
            v8GaugeBattery.NeedleColor2 = Color.DimGray;
            v8GaugeBattery.NeedleRadius = 80;
            v8GaugeBattery.NeedleType = NeedleType.Advance;
            v8GaugeBattery.NeedleWidth = 2;
            v8GaugeBattery.ScaleLinesInterColor = Color.IndianRed;
            v8GaugeBattery.ScaleLinesInterInnerRadius = 73;
            v8GaugeBattery.ScaleLinesInterOuterRadius = 80;
            v8GaugeBattery.ScaleLinesInterWidth = 1;
            v8GaugeBattery.ScaleLinesMajorColor = Color.BlanchedAlmond;
            v8GaugeBattery.ScaleLinesMajorInnerRadius = 70;
            v8GaugeBattery.ScaleLinesMajorOuterRadius = 80;
            v8GaugeBattery.ScaleLinesMajorStepValue = 10F;
            v8GaugeBattery.ScaleLinesMajorWidth = 2;
            v8GaugeBattery.ScaleLinesMinorColor = Color.Gray;
            v8GaugeBattery.ScaleLinesMinorInnerRadius = 75;
            v8GaugeBattery.ScaleLinesMinorOuterRadius = 80;
            v8GaugeBattery.ScaleLinesMinorTicks = 9;
            v8GaugeBattery.ScaleLinesMinorWidth = 1;
            v8GaugeBattery.ScaleNumbersColor = Color.FromArgb(0, 192, 192);
            v8GaugeBattery.ScaleNumbersFormat = null;
            v8GaugeBattery.ScaleNumbersRadius = 95;
            v8GaugeBattery.ScaleNumbersRotation = 0;
            v8GaugeBattery.ScaleNumbersStartScaleLine = 0;
            v8GaugeBattery.ScaleNumbersStepScaleLines = 1;
            v8GaugeBattery.Size = new Size(205, 180);
            v8GaugeBattery.TabIndex = 40;
            v8GaugeBattery.Text = "v8Gauge2";
            v8GaugeBattery.Value = 0F;
            // 
            // v8GaugeGeneratedSolar
            // 
            v8GaugeGeneratedSolar.BaseArcColor = Color.Cyan;
            v8GaugeGeneratedSolar.BaseArcRadius = 75;
            v8GaugeGeneratedSolar.BaseArcStart = 135;
            v8GaugeGeneratedSolar.BaseArcSweep = 270;
            v8GaugeGeneratedSolar.BaseArcWidth = 2;
            v8GaugeGeneratedSolar.Center = new Point(100, 100);
            v8GaugeLabel39.Color = SystemColors.Info;
            v8GaugeLabel39.Name = "GaugeLabel1";
            v8GaugeLabel39.Position = new Point(60, 50);
            v8GaugeLabel39.Text = "Generated, kWh";
            v8GaugeGeneratedSolar.GaugeLabels.Add(v8GaugeLabel39);
            v8GaugeGeneratedSolar.Location = new Point(246, 42);
            v8GaugeGeneratedSolar.MaxValue = 30F;
            v8GaugeGeneratedSolar.MinValue = 0F;
            v8GaugeGeneratedSolar.Name = "v8GaugeGeneratedSolar";
            v8GaugeGeneratedSolar.NeedleColor1 = V8GaugeNeedleColor.Blue;
            v8GaugeGeneratedSolar.NeedleColor2 = Color.DimGray;
            v8GaugeGeneratedSolar.NeedleRadius = 80;
            v8GaugeGeneratedSolar.NeedleType = NeedleType.Advance;
            v8GaugeGeneratedSolar.NeedleWidth = 2;
            v8GaugeGeneratedSolar.ScaleLinesInterColor = Color.IndianRed;
            v8GaugeGeneratedSolar.ScaleLinesInterInnerRadius = 70;
            v8GaugeGeneratedSolar.ScaleLinesInterOuterRadius = 75;
            v8GaugeGeneratedSolar.ScaleLinesInterWidth = 1;
            v8GaugeGeneratedSolar.ScaleLinesMajorColor = Color.BlanchedAlmond;
            v8GaugeGeneratedSolar.ScaleLinesMajorInnerRadius = 75;
            v8GaugeGeneratedSolar.ScaleLinesMajorOuterRadius = 65;
            v8GaugeGeneratedSolar.ScaleLinesMajorStepValue = 2F;
            v8GaugeGeneratedSolar.ScaleLinesMajorWidth = 2;
            v8GaugeGeneratedSolar.ScaleLinesMinorColor = Color.Gray;
            v8GaugeGeneratedSolar.ScaleLinesMinorInnerRadius = 75;
            v8GaugeGeneratedSolar.ScaleLinesMinorOuterRadius = 70;
            v8GaugeGeneratedSolar.ScaleLinesMinorTicks = 5;
            v8GaugeGeneratedSolar.ScaleLinesMinorWidth = 1;
            v8GaugeGeneratedSolar.ScaleNumbersColor = Color.FromArgb(0, 192, 192);
            v8GaugeGeneratedSolar.ScaleNumbersFormat = null;
            v8GaugeGeneratedSolar.ScaleNumbersRadius = 90;
            v8GaugeGeneratedSolar.ScaleNumbersRotation = 0;
            v8GaugeGeneratedSolar.ScaleNumbersStartScaleLine = 0;
            v8GaugeGeneratedSolar.ScaleNumbersStepScaleLines = 1;
            v8GaugeGeneratedSolar.Size = new Size(210, 180);
            v8GaugeGeneratedSolar.TabIndex = 41;
            v8GaugeGeneratedSolar.Text = "v8Gauge1";
            v8GaugeGeneratedSolar.Value = 0F;
            // 
            // v8GaugePVPower
            // 
            v8GaugePVPower.BaseArcColor = Color.Cyan;
            v8GaugePVPower.BaseArcRadius = 75;
            v8GaugePVPower.BaseArcStart = 135;
            v8GaugePVPower.BaseArcSweep = 270;
            v8GaugePVPower.BaseArcWidth = 2;
            v8GaugePVPower.Center = new Point(100, 100);
            v8GaugeLabel40.Color = SystemColors.Info;
            v8GaugeLabel40.Name = "GaugeLabel1";
            v8GaugeLabel40.Position = new Point(65, 50);
            v8GaugeLabel40.Text = "PV Power, kW";
            v8GaugePVPower.GaugeLabels.Add(v8GaugeLabel40);
            v8GaugeRange14.Color = Color.Red;
            v8GaugeRange14.EndValue = 90F;
            v8GaugeRange14.InnerRadius = 1;
            v8GaugeRange14.InRange = true;
            v8GaugeRange14.Name = "GaugeRange1";
            v8GaugeRange14.OuterRadius = 2;
            v8GaugeRange14.StartValue = 0F;
            v8GaugePVPower.GaugeRanges.Add(v8GaugeRange14);
            v8GaugePVPower.Location = new Point(30, 42);
            v8GaugePVPower.MaxValue = 3F;
            v8GaugePVPower.MinValue = 0F;
            v8GaugePVPower.Name = "v8GaugePVPower";
            v8GaugePVPower.NeedleColor1 = V8GaugeNeedleColor.Blue;
            v8GaugePVPower.NeedleColor2 = Color.DimGray;
            v8GaugePVPower.NeedleRadius = 80;
            v8GaugePVPower.NeedleType = NeedleType.Advance;
            v8GaugePVPower.NeedleWidth = 2;
            v8GaugePVPower.ScaleLinesInterColor = Color.IndianRed;
            v8GaugePVPower.ScaleLinesInterInnerRadius = 70;
            v8GaugePVPower.ScaleLinesInterOuterRadius = 75;
            v8GaugePVPower.ScaleLinesInterWidth = 1;
            v8GaugePVPower.ScaleLinesMajorColor = Color.BlanchedAlmond;
            v8GaugePVPower.ScaleLinesMajorInnerRadius = 75;
            v8GaugePVPower.ScaleLinesMajorOuterRadius = 65;
            v8GaugePVPower.ScaleLinesMajorStepValue = 0.25F;
            v8GaugePVPower.ScaleLinesMajorWidth = 2;
            v8GaugePVPower.ScaleLinesMinorColor = Color.Gray;
            v8GaugePVPower.ScaleLinesMinorInnerRadius = 75;
            v8GaugePVPower.ScaleLinesMinorOuterRadius = 70;
            v8GaugePVPower.ScaleLinesMinorTicks = 5;
            v8GaugePVPower.ScaleLinesMinorWidth = 1;
            v8GaugePVPower.ScaleNumbersColor = Color.FromArgb(0, 192, 192);
            v8GaugePVPower.ScaleNumbersFormat = "F1";
            v8GaugePVPower.ScaleNumbersRadius = 90;
            v8GaugePVPower.ScaleNumbersRotation = 0;
            v8GaugePVPower.ScaleNumbersStartScaleLine = 0;
            v8GaugePVPower.ScaleNumbersStepScaleLines = 1;
            v8GaugePVPower.Size = new Size(210, 180);
            v8GaugePVPower.TabIndex = 42;
            v8GaugePVPower.Text = "v8Gauge1";
            v8GaugePVPower.Value = 0F;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(button2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(WIFICBX);
            groupBox1.Controls.Add(TOUMacroCBX);
            groupBox1.Controls.Add(TimedModeRB);
            groupBox1.Controls.Add(PassiveModeRB);
            groupBox1.Controls.Add(TOUModeRB);
            groupBox1.Controls.Add(AutoModeRB);
            groupBox1.ForeColor = Color.LightGreen;
            groupBox1.Location = new Point(931, 371);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(338, 238);
            groupBox1.TabIndex = 40;
            groupBox1.TabStop = false;
            groupBox1.Text = "Options";
            // 
            // WIFICBX
            // 
            WIFICBX.AutoSize = true;
            WIFICBX.Checked = true;
            WIFICBX.CheckState = CheckState.Checked;
            WIFICBX.Location = new Point(42, 200);
            WIFICBX.Name = "WIFICBX";
            WIFICBX.Size = new Size(71, 19);
            WIFICBX.TabIndex = 44;
            WIFICBX.Text = "Use WIFI";
            WIFICBX.UseVisualStyleBackColor = true;
            WIFICBX.CheckedChanged += WIFICBX_CheckedChanged;
            // 
            // TOUMacroCBX
            // 
            TOUMacroCBX.AutoSize = true;
            TOUMacroCBX.Location = new Point(42, 127);
            TOUMacroCBX.Name = "TOUMacroCBX";
            TOUMacroCBX.Size = new Size(132, 19);
            TOUMacroCBX.TabIndex = 43;
            TOUMacroCBX.Text = "Activate TOU Macro";
            TOUMacroCBX.UseVisualStyleBackColor = true;
            // 
            // TimedModeRB
            // 
            TimedModeRB.AutoSize = true;
            TimedModeRB.Location = new Point(42, 77);
            TimedModeRB.Name = "TimedModeRB";
            TimedModeRB.Size = new Size(97, 19);
            TimedModeRB.TabIndex = 3;
            TimedModeRB.TabStop = true;
            TimedModeRB.Text = "Timing Mode";
            TimedModeRB.UseVisualStyleBackColor = true;
            TimedModeRB.CheckedChanged += TimedRB_CheckedChanged;
            // 
            // PassiveModeRB
            // 
            PassiveModeRB.AutoSize = true;
            PassiveModeRB.Location = new Point(42, 102);
            PassiveModeRB.Name = "PassiveModeRB";
            PassiveModeRB.Size = new Size(97, 19);
            PassiveModeRB.TabIndex = 2;
            PassiveModeRB.TabStop = true;
            PassiveModeRB.Text = "Passive Mode";
            PassiveModeRB.UseVisualStyleBackColor = true;
            PassiveModeRB.CheckedChanged += PassiveModeRB_CheckedChanged;
            // 
            // TOUModeRB
            // 
            TOUModeRB.AutoSize = true;
            TOUModeRB.Location = new Point(42, 52);
            TOUModeRB.Name = "TOUModeRB";
            TOUModeRB.Size = new Size(124, 19);
            TOUModeRB.TabIndex = 1;
            TOUModeRB.TabStop = true;
            TOUModeRB.Text = "Time Of Use Mode";
            TOUModeRB.UseVisualStyleBackColor = true;
            TOUModeRB.CheckedChanged += TOUModeRB_CheckedChanged;
            // 
            // AutoModeRB
            // 
            AutoModeRB.AutoSize = true;
            AutoModeRB.Location = new Point(42, 25);
            AutoModeRB.Name = "AutoModeRB";
            AutoModeRB.Size = new Size(85, 19);
            AutoModeRB.TabIndex = 0;
            AutoModeRB.TabStop = true;
            AutoModeRB.Text = "Auto Mode";
            AutoModeRB.UseVisualStyleBackColor = true;
            AutoModeRB.CheckedChanged += AutoModeRB_CheckedChanged;
            // 
            // TimeLBL
            // 
            TimeLBL.AutoSize = true;
            TimeLBL.ForeColor = Color.Lime;
            TimeLBL.Location = new Point(931, 626);
            TimeLBL.Name = "TimeLBL";
            TimeLBL.Size = new Size(113, 15);
            TimeLBL.TabIndex = 43;
            TimeLBL.Text = "Time of Last Update";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(156, 160);
            label1.Name = "label1";
            label1.Size = new Size(108, 15);
            label1.TabIndex = 46;
            label1.Text = "Macro Charge Rate";
            // 
            // button2
            // 
            button2.Location = new Point(75, 152);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 47;
            button2.Text = "button2";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(1299, 761);
            Controls.Add(TimeLBL);
            Controls.Add(groupBox1);
            Controls.Add(v8GaugePVPower);
            Controls.Add(v8GaugeGeneratedSolar);
            Controls.Add(v8GaugeBattery);
            Controls.Add(v8GaugeBoughtGrid);
            Controls.Add(v8GaugeHouseConsumption);
            Controls.Add(v8GaugeConsumed);
            Controls.Add(v8GaugeBatteryCycles);
            Controls.Add(v8GaugeCharge);
            Controls.Add(v8GaugeInternalIO);
            Controls.Add(groupBox2);
            Controls.Add(v8GaugeInverterT);
            Controls.Add(v8GaugeGridIO);
            Controls.Add(v8GaugeSold);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sofar Controller";
            FormClosing += MainForm_FormClosing;
            Load += MainForm_Load;
            Shown += MainForm_Shown;
            groupBox2.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private V8Gauge v8GaugeSold;
        private V8Gauge v8GaugeGridIO;
        private V8Gauge v8GaugeInverterT;
        private V8Gauge v8GaugeBoughtGrid;
        private V8Gauge v8GaugeHouseConsumption;
        private V8Gauge v8GaugeConsumed;
        private V8Gauge v8GaugeBatteryCycles;
        private V8Gauge v8GaugeCharge;
        private V8Gauge v8GaugeInternalIO;
        private GroupBox groupBox2;
        private Button button17;
        private Button button16;
        private Button button15;
        private Button button14;
        private Button button13;
        private Button button12;
        private V8Gauge v8GaugeBattery;
        private V8Gauge v8GaugeGeneratedSolar;
        private V8Gauge v8GaugePVPower;
        private GroupBox groupBox1;
        private RadioButton TOUModeRB;
        private RadioButton AutoModeRB;
        private RadioButton PassiveModeRB;
        private Button button1;
        private RadioButton TimedModeRB;
        private CheckBox TOUMacroCBX;
        private CheckBox WIFICBX;
        private Label TimeLBL;
        private Label label1;
        private Button button2;
    }
}
