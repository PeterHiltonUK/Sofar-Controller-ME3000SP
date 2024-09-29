namespace SofarController
{
    partial class TOUControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            groupBox2 = new GroupBox();
            label24 = new Label();
            TOUStartDate = new TextBox();
            label9 = new Label();
            TOUStartTime = new TextBox();
            label5 = new Label();
            SOC1 = new TextBox();
            TOUEndDate = new TextBox();
            label8 = new Label();
            TOUEnabledCBX = new CheckBox();
            ChargeRate1 = new TextBox();
            label6 = new Label();
            TOUEndTime = new TextBox();
            label4 = new Label();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(label24);
            groupBox2.Controls.Add(TOUStartDate);
            groupBox2.Controls.Add(label9);
            groupBox2.Controls.Add(TOUStartTime);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(SOC1);
            groupBox2.Controls.Add(TOUEndDate);
            groupBox2.Controls.Add(label8);
            groupBox2.Controls.Add(TOUEnabledCBX);
            groupBox2.Controls.Add(ChargeRate1);
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(TOUEndTime);
            groupBox2.Controls.Add(label4);
            groupBox2.Location = new Point(15, 15);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(240, 261);
            groupBox2.TabIndex = 24;
            groupBox2.TabStop = false;
            groupBox2.Text = "TOU 1";
            // 
            // label24
            // 
            label24.AutoSize = true;
            label24.Location = new Point(15, 196);
            label24.Name = "label24";
            label24.Size = new Size(30, 15);
            label24.TabIndex = 34;
            label24.Text = "SOC";
            // 
            // TOUStartDate
            // 
            TOUStartDate.Location = new Point(98, 126);
            TOUStartDate.Name = "TOUStartDate";
            TOUStartDate.Size = new Size(100, 23);
            TOUStartDate.TabIndex = 29;
            TOUStartDate.Text = "01/01/94";
            TOUStartDate.Validating += TOUStartDate_Validating;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(13, 126);
            label9.Name = "label9";
            label9.Size = new Size(58, 15);
            label9.TabIndex = 30;
            label9.Text = "Start Date";
            // 
            // TOUStartTime
            // 
            TOUStartTime.Location = new Point(98, 63);
            TOUStartTime.Name = "TOUStartTime";
            TOUStartTime.Size = new Size(100, 23);
            TOUStartTime.TabIndex = 4;
            TOUStartTime.Text = "01:30";
            TOUStartTime.Validating += TOUStartTime_Validating;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(13, 63);
            label5.Name = "label5";
            label5.Size = new Size(60, 15);
            label5.TabIndex = 5;
            label5.Text = "Start Time";
            // 
            // SOC1
            // 
            SOC1.Location = new Point(99, 193);
            SOC1.Name = "SOC1";
            SOC1.Size = new Size(100, 23);
            SOC1.TabIndex = 33;
            SOC1.Text = "90";
            SOC1.Validating += SOC1_Validating;
            // 
            // TOUEndDate
            // 
            TOUEndDate.Location = new Point(98, 155);
            TOUEndDate.Name = "TOUEndDate";
            TOUEndDate.Size = new Size(100, 23);
            TOUEndDate.TabIndex = 31;
            TOUEndDate.Text = "31/12/94";
            TOUEndDate.Validating += TOUEndDate_Validating;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(13, 155);
            label8.Name = "label8";
            label8.Size = new Size(54, 15);
            label8.TabIndex = 32;
            label8.Text = "End Date";
            // 
            // TOUEnabledCBX
            // 
            TOUEnabledCBX.AutoSize = true;
            TOUEnabledCBX.Location = new Point(98, 29);
            TOUEnabledCBX.Name = "TOUEnabledCBX";
            TOUEnabledCBX.Size = new Size(68, 19);
            TOUEnabledCBX.TabIndex = 28;
            TOUEnabledCBX.Text = "Enabled";
            TOUEnabledCBX.UseVisualStyleBackColor = true;
            TOUEnabledCBX.CheckedChanged += TOUEnabledCBX_CheckedChanged;
            // 
            // ChargeRate1
            // 
            ChargeRate1.Location = new Point(98, 225);
            ChargeRate1.Name = "ChargeRate1";
            ChargeRate1.Size = new Size(100, 23);
            ChargeRate1.TabIndex = 9;
            ChargeRate1.Text = "1000";
            ChargeRate1.Validating += ChargeRate1_Validating;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(14, 225);
            label6.Name = "label6";
            label6.Size = new Size(71, 15);
            label6.TabIndex = 10;
            label6.Text = "Charge Rate";
            // 
            // TOUEndTime
            // 
            TOUEndTime.Location = new Point(98, 92);
            TOUEndTime.Name = "TOUEndTime";
            TOUEndTime.Size = new Size(100, 23);
            TOUEndTime.TabIndex = 7;
            TOUEndTime.Text = "04:30";
            TOUEndTime.Validating += TOUEndTime_Validating;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(13, 92);
            label4.Name = "label4";
            label4.Size = new Size(52, 15);
            label4.TabIndex = 8;
            label4.Text = "End Tme";
            // 
            // TOUControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(groupBox2);
            Name = "TOUControl";
            Size = new Size(273, 294);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox2;
        private Label label24;
        private TextBox SOC1;
        private TextBox TOUEndDate;
        private TextBox TOUStartDate;
        private Label label8;
        private Label label9;
        private CheckBox TOUEnabledCBX;
        private TextBox ChargeRate1;
        private Label label6;
        private TextBox TOUEndTime;
        private TextBox TOUStartTime;
        private Label label4;
        private Label label5;
    }
}
