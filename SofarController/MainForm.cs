using ReadOctopus;
using SofarController;
using System.Diagnostics;
using static ReadOctopus.Octopus;
using MyTimer = System.Threading.Timer;
using MyTimer2 = System.Windows.Forms.Timer;

namespace Controller
{
    public partial class MainForm : Form
    {
        private Sofar sofar;
        private Solcast solcast;
        private Octopus octData = new Octopus();
        private MyTimer PassiveTOUtimer, DataUpdateTimer;
        private Tarrif agile;
        private UpdateDomotics domoticz = new();
        private Options optionFrm;
        private OptionData options = new();
        private string dir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        private MyTimer2 MyTimer = new();
        private int WIFIUpdatePeriod = 5;
        private double WiredUpdatePeriod = 5;
        bool TOUUpdated = false;
        MacroData data = new();
        bool solcastRetrieved = false;

        public void UpdateByTimer()
        {
            if (!solcastRetrieved)
            {
                solcast = new Solcast(options);
                solcastRetrieved = true;
            }

            if (!TOUUpdated)
            {
                sofar.GetData(options, true);
                TOUUpdated = true;
            }
            else
            {
                sofar.GetData(options, false);
            }

            UpdateGaugeControls();

            WorkMode wm = sofar.mode;

            if (GetWorkModeCBX() != wm)
            {
                SetWorkModeCBX(wm);
            }
            ;

            if (WIFICBX.Checked)
            {
                MyTimer.Interval = (WIFIUpdatePeriod * 60 * 1000); // 5 mins
            }
            else
            {
                MyTimer.Interval = (((int)WiredUpdatePeriod * 60 * 1000)); // 1 mins
            }

            data.UpdateMacrodata(sofar, solcast);

            Macros m = new();
            TOUData tou =  m.ChargeBattteryWhenSolarForecastIsLow(sofar, options, data);

            if (TOUMacroCBX.Checked)
            {
                if (DateTime.Now.Hour > 11 && DateTime.Now.Hour < 1 && !TOUMacroRun)
                {
                    sofar.WriteTimeOfUseParams(0, tou, options);
                }      
            }

            UpdateTimeLabel();

            Update();
            Refresh();

            domoticz.SendData(sofar, solcast);
        }

        private void MyTimer_Tick(object sender, EventArgs e) // single thread
        {
            UpdateByTimer();
        }

        private void DataUpdateCallback(Object o)  // multi threaded
        {
            UpdateByTimer();
        }

        public void StartSingleThreadTimer()
        {
            if (WIFICBX.Checked)
            {
                MyTimer.Interval = (WIFIUpdatePeriod * 60 * 1000); // 5 mins
            }
            else
            {
                WiredUpdatePeriod = 1;
                MyTimer.Interval = ((int)(WiredUpdatePeriod * 60 * 1000)); // 1 mins
            }

            MyTimer.Tick += new EventHandler(MyTimer_Tick);
            MyTimer.Start();
        }

        public void StartMultiThreadTimer()
        {
            if (WIFICBX.Checked)
            {
                // MyTimer.Interval = (WIFIUpdatePeriod * 60 * 1000); // 5 mins
                DataUpdateTimer = new(DataUpdateCallback, this, 1000, WIFIUpdatePeriod * 60 * 1000);
            }
            else
            {
                // MyTimer.Interval = (WiredUpdatePeriod * 60 * 1000); // 1 mins
                DataUpdateTimer = new(DataUpdateCallback, this, 1000, (int)(WiredUpdatePeriod * 60 * 1000));
            }
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            Application.DoEvents();
            sofar.GetData(options, true);
            UpdateGaugeControls();
            domoticz.SendData(sofar, solcast);
            StartSingleThreadTimer();
            //StartMultiThreadTimer();
            //UpdateByTimer();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            solcast = new Solcast(options);
            solcastRetrieved = true;

            WIFICBX.Checked = options.WIFI;

            sofar = new Sofar(options);

            WorkMode mode = sofar.GetWorkMode(options);

            //  sofar.GetData(options, true);
            //  UpdateGaugeControls();

            //PassiveTOUtimer = new(TimerCallback, this, 0, Timeout.Infinite);

            agile = octData.GetTarriff();

            switch (sofar.mode)
            {
                case WorkMode.Auto:
                    AutoModeRB.Select();
                    break;

                case WorkMode.TOU:
                    TOUModeRB.Select();
                    break;

                case WorkMode.PASSIVE:
                    PassiveModeRB.Select();
                    break;

                case WorkMode.TIMED:
                    TimedModeRB.Select();
                    break;
            }

            TimeLBL.Text = "Please wait for initial data...";

            Refresh();
            Update();
        }

        public MainForm()
        {
            InitializeComponent();

            if (options.FileExists())
            {
                options.Read();
            }
            else
            {
                optionFrm = new(options);
                optionFrm.ShowDialog();
                options = optionFrm.GetOptions();
                options.Save();
            }
        }

        public void UpdateTimeLabel()
        {
            if (TimeLBL.InvokeRequired)
            {
                this.Invoke(new Action(() => UpdateTimeLabel()));
            }
            else
            {
                TimeLBL.Text = "Last Update: " + DateTime.Now.ToString();
            }
        }

        private void TimerCallback(Object o)
        {
            // Display the date/time when this method got called.
            Debug.WriteLine("In TimerCallback: " + DateTime.Now);

            MainForm mf = ((MainForm)o);
            mf.RunTOU5();
        }

        private bool TOUMacroRun = false;

        public void selectRB(RadioButton rb)
        {
            if (rb.InvokeRequired)
            {
                this.Invoke(new Action(() => selectRB(rb)));
            }
            else
            {
                rb.Select();
            }
        }

        public void RunTOU5()
        {
            if (sofar.mode == WorkMode.PASSIVE)
            {
                DateTime Start, End;
                double POW, SOC, BatterySOC, CurrentChargeRate;

                BatterySOC = sofar.GetSOC();
                TOUData TOUPassive = sofar.TOUPassive;

                Start = new DateTime(TOUPassive.StartDate, TOUPassive.StartTime);
                End = new DateTime(TOUPassive.EndDate, TOUPassive.EndTime);
                POW = TOUPassive.Pow;
                SOC = TOUPassive.Soc;
                CurrentChargeRate = sofar.GetChargeRate();

                if (SOC < BatterySOC)
                    return;

                DateTime now = DateTime.Now;

                if (now >= Start && now <= End)
                {
                    if (now.TimeOfDay > Start.TimeOfDay && now.TimeOfDay <= End.TimeOfDay)
                    {
                        if ((Math.Abs(CurrentChargeRate - POW) > 500))
                            sofar.SetChargeRate((ushort)POW);
                    }
                    else
                    {
                        sofar.SetChargeRate((ushort)0);
                        sofar.SetPassiveStandby(options);
                    }
                }
            }
        }

        private void SolCastData_Click(object sender, EventArgs e)
        {
            SolCastForm sf = new(solcast);
            sf.ShowDialog();
        }

        public void UpdateOctopusData()
        {
            agile = octData.GetTarriff();
        }

        private void GetFromSofarTOUParams(bool Reset)
        {
            string StartTimeHr = "";
            string StartTimeMin = "";

            string EndTimeHr = "";
            string EndTimeMin = "";

            string StartMonth = "";
            string StartDay = "";

            string EndMonth = "";
            string EndDay = "";

            ushort soc, pow;
            bool TOUEnabled = false;

            //for (int i = 0; i < 4; i++)
            for (int i = 0; i < 1; i++)
            {
                //sofardata.ReadTimeOfUseParams(i);
                sofar.ReadTimeOfUseParamsCase0(options);
                StartTimeHr = sofar.StartTimeHr.ToString();
                StartTimeMin = sofar.StartTimeMin.ToString();
                EndTimeHr = sofar.EndTimeHr.ToString();
                EndTimeMin = sofar.EndTimeMin.ToString();
                StartMonth = sofar.StartMonth.ToString();
                StartDay = sofar.StartDay.ToString();
                EndMonth = sofar.EndMonth.ToString();
                EndDay = sofar.EndDay.ToString();

                soc = sofar.Soc;
                pow = sofar.Pow;

                if (sofar.TOUEnabled == 1)
                {
                    TOUEnabled = true;
                }
                else
                {
                    TOUEnabled = false;
                }

                string StartTime = StartTimeHr + ":" + StartTimeMin;
                string EndTime = EndTimeHr + ":" + EndTimeMin;

                string StartDate = StartDay + "/" + StartMonth;
                string EndDate = EndDay + "/" + EndMonth;

                switch (i)
                {
                    case 0:
                        sofar.TOU1.Update(i, false, "", "", "", "", 0, 0);
                        sofar.TOU1.Update(i, TOUEnabled, StartTime, EndTime, StartDate, EndDate, soc, pow);
                        break;

                    case 1:
                        sofar.TOU2.Update(i, false, "", "", "", "", 0, 0);
                        sofar.TOU2.Update(i, TOUEnabled, StartTime, EndTime, StartDate, EndDate, soc, pow);
                        break;

                    case 2:
                        sofar.TOU3.Update(i, false, "", "", "", "", 0, 0);
                        sofar.TOU3.Update(i, TOUEnabled, StartTime, EndTime, StartDate, EndDate, soc, pow);
                        break;

                    case 3:
                        sofar.TOU4.Update(i, false, "", "", "", "", 0, 0);
                        sofar.TOU4.Update(i, TOUEnabled, StartTime, EndTime, StartDate, EndDate, soc, pow);
                        break;
                }

                if (Reset)
                {
                    sofar.TOU1.Update(i, false, "", "", "", "", 0, 0);
                    sofar.TOU2.Update(i, false, "", "", "", "", 0, 0);
                    sofar.TOU3.Update(i, false, "", "", "", "", 0, 0);
                    sofar.TOU4.Update(i, false, "", "", "", "", 0, 0);
                }
            }
        }

        private void Passive_Click(object sender, EventArgs e)
        {
            if (DataUpdateTimer is not null)
                DataUpdateTimer.Change(10000, 50000);

            if (sofar.mode == WorkMode.PASSIVE)
            {
                PassiveForm frm = new(sofar, sofar.TOUPassive, options);
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select Passive mode");
            }

            if (DataUpdateTimer is not null)
                DataUpdateTimer.Change(100, 5000);
        }

        private void TOU_Click(object sender, EventArgs e)
        {
            //TOUForm frm = new(sofardata.TOU1, sofardata.TOU2, sofardata.TOU3, sofardata.TOU4, sofardata);
            if (DataUpdateTimer is not null)
                DataUpdateTimer.Change(10000, 50000);

            if (sofar.DataAvailable)
            {
                if (!sofar.TOU1.Enabled)
                {
                    Debugger.Break();

                    sofar.UpdateTOUData(0, options);
                }

                TOUSingle frm = new(sofar.TOU1, sofar, options);
                frm.ShowDialog();
            }
            else
                MessageBox.Show("Please wait for data to update");

            if (DataUpdateTimer is not null)
                DataUpdateTimer.Change(100, 5000);
        }

        private void Agile_Click(object sender, EventArgs e)
        {
            if (DataUpdateTimer is not null)
                DataUpdateTimer.Change(10000, 50000);

            AgileForm frm = new AgileForm(agile);
            frm.ShowDialog();

            if (DataUpdateTimer is not null)
                DataUpdateTimer.Change(100, 5000);
        }

        private void AutoModeRB_CheckedChanged(object sender, EventArgs e)
        {
            if (AutoModeRB.Checked == true)
            {
                sofar.mode = WorkMode.Auto;
                // sofar.SetWorkMode((WorkMode)sofar.mode, options);
            }
        }

        private void TOUModeRB_CheckedChanged(object sender, EventArgs e)
        {
            if (TOUModeRB.Checked == true)
            {
                sofar.mode = WorkMode.TOU;
                //  sofar.SetWorkMode((WorkMode)sofar.mode, options);
            }
        }

        private void PassiveModeRB_CheckedChanged(object sender, EventArgs e)
        {
            if (PassiveModeRB.Checked == true)
            {
                sofar.mode = WorkMode.PASSIVE;
                //  sofar.SetWorkMode((WorkMode)sofar.mode, options);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SofarForm sf = new(sofar, options);
            sf.ShowDialog();
        }

        private void TimedRB_CheckedChanged(object sender, EventArgs e)
        {
            if (TimedModeRB.Checked == true)
            {
                sofar.mode = WorkMode.TIMED;
                //   sofar.SetWorkMode((WorkMode)sofar.mode, options);
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //sofar.SetWorkMode(sofar.mode, options);

            if (DataUpdateTimer is not null)
                DataUpdateTimer.Dispose();

            switch (sofar.mode)
            {
                case WorkMode.TIMED:
                    sofar.SetWorkMode((int)WorkMode.Auto, options);
                    break;

                case WorkMode.PASSIVE:
                    sofar.SetWorkMode((int)WorkMode.Auto, options); // temporary
                    break;

                case WorkMode.Auto:
                    break;

                case WorkMode.TOU:
                    break;
            }

            options.Save();
        }

        private void Options_Click(object sender, EventArgs e)
        {
            Options optionsForm = new Options(options);
            optionsForm.ShowDialog(options);
        }

        private void WIFICBX_CheckedChanged(object sender, EventArgs e)
        {
            options.WIFI = WIFICBX.Checked;
            if (sofar is not null)
                sofar.setPortOrSockets(options);

            if (WIFICBX.Checked)
            {
                MyTimer.Interval = (WIFIUpdatePeriod * 60 * 1000); // 5 mins
            }
            else
            {
                MyTimer.Interval = (int)(WiredUpdatePeriod * 60 * 1000); // 1 mins
            }
        }

        public WorkMode GetWorkModeCBX()
        {
            if (AutoModeRB.Checked)
                return WorkMode.Auto;
            if (TimedModeRB.Checked)
                return WorkMode.TIMED;
            if (TOUModeRB.Checked)
                return WorkMode.TOU;
            if (PassiveModeRB.Checked)
                return WorkMode.PASSIVE;
            return WorkMode.Auto;
        }

        public void SetWorkModeCBX(WorkMode wm)
        {
            switch (wm)
            {
                case WorkMode.Auto:
                    AutoModeRB.Checked = true;
                    break;

                case WorkMode.TIMED:
                    TimedModeRB.Checked = true;
                    break;

                case WorkMode.TOU:
                    TOUModeRB.Checked = true;
                    break;

                case WorkMode.PASSIVE:
                    PassiveModeRB.Checked = true;
                    break;
            }
        }

        public void UpdateGaugeControls()
        {
            if (sofar.Data.ContainsKey(eData.PVGenerationPwr))
                Updatev8GaugePower((float)sofar.Data[eData.PVGenerationPwr]);
            if (sofar.Data.ContainsKey(eData.TodayGeneratedSolarWh))
                Updatev8v8GaugeGeneratedSolar((float)sofar.Data[eData.TodayGeneratedSolarWh]);
            if (sofar.Data.ContainsKey(eData.BatteryChrgLevel))
                Updatev8GaugeBattery((float)sofar.Data[eData.BatteryChrgLevel]);
            if (sofar.Data.ContainsKey(eData.BatteryChargeDischargePwr))
                Updatev8GaugeCharge((float)sofar.Data[eData.BatteryChargeDischargePwr]);

            if (sofar.Data.ContainsKey(eData.HouseConsumptionPwr))
                Updatev8GaugeHouseConsumption((float)sofar.Data[eData.HouseConsumptionPwr]);
            if (sofar.Data.ContainsKey(eData.TodayBoughtGridWh))
                Updatev8GaugeBoughtGrid((float)sofar.Data[eData.TodayBoughtGridWh]);
            if (sofar.Data.ContainsKey(eData.InternalIOPwr))
                Updatev8v8GaugeInternalIO((float)sofar.Data[eData.InternalIOPwr]);
            if (sofar.Data.ContainsKey(eData.TodaySoldSolarWh))
                Updatev8v8GaugeSold((float)sofar.Data[eData.TodaySoldSolarWh]);

            if (sofar.Data.ContainsKey(eData.TodayConsumptionWh))
                Updatev8v8GaugeConsumed((float)sofar.Data[eData.TodayConsumptionWh]);
            if (sofar.Data.ContainsKey(eData.BatteryCycles))
                Updatev8v8GaugeBatteryCycles((float)sofar.Data[eData.BatteryCycles]);
            if (sofar.Data.ContainsKey(eData.GridIOPwr))
                Updatev8v8GaugeGridIO((float)sofar.Data[eData.GridIOPwr]);
            if (sofar.Data.ContainsKey(eData.InverterInternalTemp))
                Updatev8v8GaugeInverterT((float)sofar.Data[eData.InverterInternalTemp]);
        }

        public void Updatev8GaugePower(float val)
        {
            if (v8GaugePVPower.InvokeRequired)
            {
                this.Invoke(new Action(() => Updatev8GaugePower(val)));
            }
            else
            {
                v8GaugePVPower.Value = val;
            }
        }

        public void Updatev8v8GaugeGeneratedSolar(float val)
        {
            if (v8GaugeGeneratedSolar.InvokeRequired)
            {
                this.Invoke(new Action(() => Updatev8v8GaugeGeneratedSolar(val)));
            }
            else
            {
                v8GaugeGeneratedSolar.Value = val;
            }
        }

        public void Updatev8GaugeBattery(float val)
        {
            if (v8GaugeBattery.InvokeRequired)
            {
                this.Invoke(new Action(() => Updatev8GaugeBattery(val)));
            }
            else
            {
                v8GaugeBattery.Value = val;
                if (v8GaugeBattery.GaugeLabels.Count > 1)
                    v8GaugeBattery.GaugeLabels[1].Text = val.ToString() + " %";
            }
        }

        public void Updatev8GaugeCharge(float val)
        {
            if (v8GaugeCharge.InvokeRequired)
            {
                this.Invoke(new Action(() => Updatev8GaugeCharge(val)));
            }
            else
            {
                v8GaugeCharge.Value = val;
            }
        }

        public void Updatev8GaugeHouseConsumption(float val)
        {
            if (v8GaugeHouseConsumption.InvokeRequired)
            {
                this.Invoke(new Action(() => Updatev8GaugeHouseConsumption(val)));
            }
            else
            {
                v8GaugeHouseConsumption.Value = val;
            }
        }

        public void Updatev8GaugeBoughtGrid(float val)
        {
            if (v8GaugeBattery.InvokeRequired)
            {
                this.Invoke(new Action(() => Updatev8GaugeBoughtGrid(val)));
            }
            else
            {
                v8GaugeBoughtGrid.Value = val;
            }
        }

        public void Updatev8v8GaugeInternalIO(float val)
        {
            if (v8GaugeInternalIO.InvokeRequired)
            {
                this.Invoke(new Action(() => Updatev8v8GaugeInternalIO(val)));
            }
            else
            {
                v8GaugeInternalIO.Value = val;
                //if (v8GaugeInternalIO.GaugeLabels.Count > 2)
                //    v8GaugeInternalIO.GaugeLabels[2].Text = val.ToString();
            }
        }

        public void Updatev8v8GaugeSold(float val)
        {
            if (v8GaugeSold.InvokeRequired)
            {
                this.Invoke(new Action(() => Updatev8v8GaugeSold(val)));
            }
            else
            {
                v8GaugeSold.Value = val;
            }
        }

        public void Updatev8v8GaugeConsumed(float val)
        {
            if (v8GaugeConsumed.InvokeRequired)
            {
                this.Invoke(new Action(() => Updatev8v8GaugeConsumed(val)));
            }
            else
            {
                v8GaugeConsumed.Value = val;
            }
        }

        public void Updatev8v8GaugeBatteryCycles(float val)
        {
            if (v8GaugeBatteryCycles.InvokeRequired)
            {
                this.Invoke(new Action(() => Updatev8v8GaugeBatteryCycles(val)));
            }
            else
            {
                v8GaugeBatteryCycles.Value = val;
            }
        }

        public void Updatev8v8GaugeGridIO(float val)
        {
            if (v8GaugeGridIO.InvokeRequired)
            {
                this.Invoke(new Action(() => Updatev8v8GaugeGridIO(val)));
            }
            else
            {
                v8GaugeGridIO.Value = val;
                //  if (v8GaugeGridIO.GaugeLabels.Count > 2)
                //      v8GaugeGridIO.GaugeLabels[2].Text = val.ToString();
            }
        }

        public void Updatev8v8GaugeInverterT(float val)
        {
            if (v8GaugeInverterT.InvokeRequired)
            {
                this.Invoke(new Action(() => Updatev8v8GaugeInverterT(val)));
            }
            else
            {
                v8GaugeInverterT.Value = val;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            data.UpdateMacrodata(sofar, solcast);
            Macros macro = new();
            macro.ChargeBattteryWhenSolarForecastIsLow(sofar, options, data);
            MacroForm mf = new(data);
            mf.Show();
        }
    }
}