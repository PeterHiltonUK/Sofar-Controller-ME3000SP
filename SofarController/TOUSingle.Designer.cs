namespace SofarController
{
    partial class TOUSingle
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
            TOUData touData1 = new TOUData();
            LoadTOU1 = new Button();
            SaveTOU1 = new Button();
            tou1Control = new TOUControl();
            SuspendLayout();
            // 
            // LoadTOU1
            // 
            LoadTOU1.Location = new Point(40, 30);
            LoadTOU1.Name = "LoadTOU1";
            LoadTOU1.Size = new Size(75, 23);
            LoadTOU1.TabIndex = 49;
            LoadTOU1.Text = "Load Data";
            LoadTOU1.UseVisualStyleBackColor = true;
            LoadTOU1.Click += LoadTOU1_Click;
            // 
            // SaveTOU1
            // 
            SaveTOU1.Location = new Point(121, 30);
            SaveTOU1.Name = "SaveTOU1";
            SaveTOU1.Size = new Size(75, 23);
            SaveTOU1.TabIndex = 48;
            SaveTOU1.Text = "Save Data";
            SaveTOU1.UseVisualStyleBackColor = true;
            SaveTOU1.Click += SaveTOU1_Click;
            // 
            // tou1
            // 
            touData1.Enabled = false;
            touData1.EndDate = new DateOnly(1, 1, 1);
            touData1.EndTime = new TimeOnly(0L);
            touData1.PassiveChargeRate = 0D;
            touData1.PassiveDischargeRate = 0D;
            touData1.Pow = (ushort)0;
            touData1.Soc = (ushort)0;
            touData1.StartDate = new DateOnly(1, 1, 1);
            touData1.StartTime = new TimeOnly(0L);
            tou1Control.Data = touData1;
            tou1Control.GroupName = "TOU 1";
            tou1Control.Location = new Point(29, 59);
            tou1Control.Name = "tou1";
            tou1Control.Size = new Size(273, 294);
            tou1Control.TabIndex = 47;
            // 
            // TOUSingle
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(340, 376);
            Controls.Add(LoadTOU1);
            Controls.Add(SaveTOU1);
            Controls.Add(tou1Control);
            Name = "TOUSingle";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "TOUSingle";
            ResumeLayout(false);
        }

        #endregion

        private Button LoadTOU1;
        private Button SaveTOU1;
        private TOUControl tou1Control;
    }
}