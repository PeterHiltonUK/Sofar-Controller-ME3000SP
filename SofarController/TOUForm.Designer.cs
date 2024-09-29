namespace SofarController
{
    partial class TOUForm
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
            TOUData touData5 = new TOUData();
            TOUData touData6 = new TOUData();
            TOUData touData7 = new TOUData();
            TOUData touData8 = new TOUData();
            LOADTOU3 = new Button();
            SaveTOU1 = new Button();
            tou1 = new TOUControl();
            TOULoadData = new Button();
            LAODTOU4 = new Button();
            LoadTOU1 = new Button();
            SaveTOU3 = new Button();
            SaveTOU2 = new Button();
            tou3 = new TOUControl();
            tou2 = new TOUControl();
            LoadTOU2 = new Button();
            SaveTOU4 = new Button();
            tou4 = new TOUControl();
            SuspendLayout();
            // 
            // LOADTOU3
            // 
            LOADTOU3.Location = new Point(605, 85);
            LOADTOU3.Name = "LOADTOU3";
            LOADTOU3.Size = new Size(75, 23);
            LOADTOU3.TabIndex = 41;
            LOADTOU3.Text = "Load Data";
            LOADTOU3.UseVisualStyleBackColor = true;
            LOADTOU3.Click += LOADTOU3_Click;
            // 
            // SaveTOU1
            // 
            SaveTOU1.Location = new Point(123, 85);
            SaveTOU1.Name = "SaveTOU1";
            SaveTOU1.Size = new Size(75, 23);
            SaveTOU1.TabIndex = 40;
            SaveTOU1.Text = "Save Data";
            SaveTOU1.UseVisualStyleBackColor = true;
            SaveTOU1.Click += SaveTOU1_Click;
            // 
            // tou1
            // 
            touData5.Enabled = false;
            touData5.EndDate = new DateOnly(1, 1, 1);
            touData5.EndTime = new TimeOnly(0L);
            touData5.PassiveChargeRate = 0D;
            touData5.PassiveDischargeRate = 0D;
            touData5.Pow = (ushort)0;
            touData5.Soc = (ushort)0;
            touData5.StartDate = new DateOnly(1, 1, 1);
            touData5.StartTime = new TimeOnly(0L);
            tou1.Data = touData5;
            tou1.GroupName = "TOU 1";
            tou1.Location = new Point(31, 114);
            tou1.Name = "tou1";
            tou1.Size = new Size(273, 294);
            tou1.TabIndex = 39;
            // 
            // TOULoadData
            // 
            TOULoadData.Location = new Point(42, 21);
            TOULoadData.Name = "TOULoadData";
            TOULoadData.Size = new Size(159, 23);
            TOULoadData.TabIndex = 38;
            TOULoadData.Text = "Load All Data";
            TOULoadData.UseVisualStyleBackColor = true;
            TOULoadData.Click += TOULoadData_Click;
            // 
            // LAODTOU4
            // 
            LAODTOU4.Location = new Point(886, 85);
            LAODTOU4.Name = "LAODTOU4";
            LAODTOU4.Size = new Size(75, 23);
            LAODTOU4.TabIndex = 47;
            LAODTOU4.Text = "Load Data";
            LAODTOU4.UseVisualStyleBackColor = true;
            LAODTOU4.Click += LAODTOU4_Click;
            // 
            // LoadTOU1
            // 
            LoadTOU1.Location = new Point(42, 85);
            LoadTOU1.Name = "LoadTOU1";
            LoadTOU1.Size = new Size(75, 23);
            LoadTOU1.TabIndex = 46;
            LoadTOU1.Text = "Load Data";
            LoadTOU1.UseVisualStyleBackColor = true;
            LoadTOU1.Click += LoadTOU1_Click;
            // 
            // SaveTOU3
            // 
            SaveTOU3.Location = new Point(686, 85);
            SaveTOU3.Name = "SaveTOU3";
            SaveTOU3.Size = new Size(75, 23);
            SaveTOU3.TabIndex = 45;
            SaveTOU3.Text = "Save Data";
            SaveTOU3.UseVisualStyleBackColor = true;
            SaveTOU3.Click += SaveTOU3_Click;
            // 
            // SaveTOU2
            // 
            SaveTOU2.Location = new Point(407, 85);
            SaveTOU2.Name = "SaveTOU2";
            SaveTOU2.Size = new Size(75, 23);
            SaveTOU2.TabIndex = 44;
            SaveTOU2.Text = "Save Data";
            SaveTOU2.UseVisualStyleBackColor = true;
            SaveTOU2.Click += SaveTOU2_Click;
            // 
            // tou3
            // 
            touData6.Enabled = false;
            touData6.EndDate = new DateOnly(1, 1, 1);
            touData6.EndTime = new TimeOnly(0L);
            touData6.PassiveChargeRate = 0D;
            touData6.PassiveDischargeRate = 0D;
            touData6.Pow = (ushort)0;
            touData6.Soc = (ushort)0;
            touData6.StartDate = new DateOnly(1, 1, 1);
            touData6.StartTime = new TimeOnly(0L);
            tou3.Data = touData6;
            tou3.GroupName = "TOU 3";
            tou3.Location = new Point(588, 114);
            tou3.Name = "tou3";
            tou3.Size = new Size(273, 294);
            tou3.TabIndex = 43;
            // 
            // tou2
            // 
            touData7.Enabled = false;
            touData7.EndDate = new DateOnly(1, 1, 1);
            touData7.EndTime = new TimeOnly(0L);
            touData7.PassiveChargeRate = 0D;
            touData7.PassiveDischargeRate = 0D;
            touData7.Pow = (ushort)0;
            touData7.Soc = (ushort)0;
            touData7.StartDate = new DateOnly(1, 1, 1);
            touData7.StartTime = new TimeOnly(0L);
            tou2.Data = touData7;
            tou2.GroupName = "TOU 2";
            tou2.Location = new Point(310, 114);
            tou2.Name = "tou2";
            tou2.Size = new Size(273, 294);
            tou2.TabIndex = 42;
            // 
            // LoadTOU2
            // 
            LoadTOU2.Location = new Point(326, 85);
            LoadTOU2.Name = "LoadTOU2";
            LoadTOU2.Size = new Size(75, 23);
            LoadTOU2.TabIndex = 50;
            LoadTOU2.Text = "Load Data";
            LoadTOU2.UseVisualStyleBackColor = true;
            LoadTOU2.Click += LoadTOU2_Click;
            // 
            // SaveTOU4
            // 
            SaveTOU4.Location = new Point(967, 85);
            SaveTOU4.Name = "SaveTOU4";
            SaveTOU4.Size = new Size(75, 23);
            SaveTOU4.TabIndex = 49;
            SaveTOU4.Text = "Save Data";
            SaveTOU4.UseVisualStyleBackColor = true;
            SaveTOU4.Click += SaveTOU4_Click;
            // 
            // tou4
            // 
            touData8.Enabled = false;
            touData8.EndDate = new DateOnly(1, 1, 1);
            touData8.EndTime = new TimeOnly(0L);
            touData8.PassiveChargeRate = 0D;
            touData8.PassiveDischargeRate = 0D;
            touData8.Pow = (ushort)0;
            touData8.Soc = (ushort)0;
            touData8.StartDate = new DateOnly(1, 1, 1);
            touData8.StartTime = new TimeOnly(0L);
            tou4.Data = touData8;
            tou4.GroupName = "TOU 4";
            tou4.Location = new Point(867, 114);
            tou4.Name = "tou4";
            tou4.Size = new Size(273, 294);
            tou4.TabIndex = 48;
            // 
            // TOUForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1187, 442);
            Controls.Add(LoadTOU2);
            Controls.Add(SaveTOU4);
            Controls.Add(tou4);
            Controls.Add(LAODTOU4);
            Controls.Add(LoadTOU1);
            Controls.Add(SaveTOU3);
            Controls.Add(SaveTOU2);
            Controls.Add(tou3);
            Controls.Add(tou2);
            Controls.Add(LOADTOU3);
            Controls.Add(SaveTOU1);
            Controls.Add(tou1);
            Controls.Add(TOULoadData);
            Name = "TOUForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "TOU Form";
            ResumeLayout(false);
        }

        #endregion

        private Button LOADTOU3;
        private Button SaveTOU1;
        private TOUControl tou1;
        private Button TOULoadData;
        private Button LAODTOU4;
        private Button LoadTOU1;
        private Button SaveTOU3;
        private Button SaveTOU2;
        private TOUControl tou3;
        private TOUControl tou2;
        private Button LoadTOU2;
        private Button SaveTOU4;
        private TOUControl tou4;
    }
}