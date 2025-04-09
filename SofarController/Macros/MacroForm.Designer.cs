namespace SofarController
{
    partial class MacroForm
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
            label1 = new Label();
            ForecastTxt = new TextBox();
            CapcityTxt = new TextBox();
            label2 = new Label();
            StartTimeTxt = new TextBox();
            label3 = new Label();
            EndTimeTxt = new TextBox();
            label4 = new Label();
            ChargeRateTxt = new TextBox();
            label5 = new Label();
            SOCTxt = new TextBox();
            label6 = new Label();
            SpareTxt = new TextBox();
            label7 = new Label();
            MinSOC = new TextBox();
            label8 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.Lime;
            label1.Location = new Point(175, 43);
            label1.Name = "label1";
            label1.Size = new Size(84, 15);
            label1.TabIndex = 0;
            label1.Text = "Forecast , kWh";
            // 
            // ForecastTxt
            // 
            ForecastTxt.Location = new Point(56, 40);
            ForecastTxt.Name = "ForecastTxt";
            ForecastTxt.Size = new Size(100, 23);
            ForecastTxt.TabIndex = 1;
            ForecastTxt.Text = "0";
            ForecastTxt.TextChanged += ForecastTxt_TextChanged;
            // 
            // CapcityTxt
            // 
            CapcityTxt.Location = new Point(56, 82);
            CapcityTxt.Name = "CapcityTxt";
            CapcityTxt.Size = new Size(100, 23);
            CapcityTxt.TabIndex = 4;
            CapcityTxt.Text = "20";
            CapcityTxt.TextChanged += CapcityTxt_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.Lime;
            label2.Location = new Point(175, 85);
            label2.Name = "label2";
            label2.Size = new Size(123, 15);
            label2.TabIndex = 3;
            label2.Text = "Battery Capacity, kWh";
            // 
            // StartTimeTxt
            // 
            StartTimeTxt.Location = new Point(56, 233);
            StartTimeTxt.Name = "StartTimeTxt";
            StartTimeTxt.Size = new Size(100, 23);
            StartTimeTxt.TabIndex = 6;
            StartTimeTxt.Text = "Start Time";
            StartTimeTxt.TextChanged += StartTimeTxt_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = Color.Lime;
            label3.Location = new Point(175, 236);
            label3.Name = "label3";
            label3.Size = new Size(61, 15);
            label3.TabIndex = 5;
            label3.Text = "Start Time";
            // 
            // EndTimeTxt
            // 
            EndTimeTxt.Location = new Point(56, 276);
            EndTimeTxt.Name = "EndTimeTxt";
            EndTimeTxt.Size = new Size(100, 23);
            EndTimeTxt.TabIndex = 8;
            EndTimeTxt.Text = "End Time";
            EndTimeTxt.TextChanged += EndTimeTxt_TextChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = Color.Lime;
            label4.Location = new Point(175, 279);
            label4.Name = "label4";
            label4.Size = new Size(57, 15);
            label4.TabIndex = 7;
            label4.Text = "End Time";
            // 
            // ChargeRateTxt
            // 
            ChargeRateTxt.Location = new Point(56, 322);
            ChargeRateTxt.Name = "ChargeRateTxt";
            ChargeRateTxt.Size = new Size(100, 23);
            ChargeRateTxt.TabIndex = 10;
            ChargeRateTxt.Text = "Charge Rate";
            ChargeRateTxt.TextChanged += ChargeRateTxt_TextChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.ForeColor = Color.Lime;
            label5.Location = new Point(175, 325);
            label5.Name = "label5";
            label5.Size = new Size(71, 15);
            label5.TabIndex = 9;
            label5.Text = "Charge Rate";
            // 
            // SOCTxt
            // 
            SOCTxt.Location = new Point(56, 116);
            SOCTxt.Name = "SOCTxt";
            SOCTxt.Size = new Size(100, 23);
            SOCTxt.TabIndex = 12;
            SOCTxt.Text = "SOC";
            SOCTxt.TextChanged += SOCTxt_TextChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.ForeColor = Color.Lime;
            label6.Location = new Point(175, 119);
            label6.Name = "label6";
            label6.Size = new Size(43, 15);
            label6.TabIndex = 11;
            label6.Text = "SOC %";
            // 
            // SpareTxt
            // 
            SpareTxt.Location = new Point(56, 195);
            SpareTxt.Name = "SpareTxt";
            SpareTxt.Size = new Size(100, 23);
            SpareTxt.TabIndex = 14;
            SpareTxt.Text = "Spare Capacity";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.ForeColor = Color.Lime;
            label7.Location = new Point(175, 198);
            label7.Name = "label7";
            label7.Size = new Size(115, 15);
            label7.TabIndex = 13;
            label7.Text = "Spare Capacity, kWh";
            // 
            // MinSOC
            // 
            MinSOC.Location = new Point(56, 154);
            MinSOC.Name = "MinSOC";
            MinSOC.Size = new Size(100, 23);
            MinSOC.TabIndex = 16;
            MinSOC.Text = "SOC";
            MinSOC.TextChanged += MinSOC_TextChanged;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.ForeColor = Color.Lime;
            label8.Location = new Point(176, 162);
            label8.Name = "label8";
            label8.Size = new Size(67, 15);
            label8.TabIndex = 15;
            label8.Text = "Min SOC %";
            // 
            // MacroForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Gray;
            ClientSize = new Size(384, 401);
            Controls.Add(MinSOC);
            Controls.Add(label8);
            Controls.Add(SpareTxt);
            Controls.Add(label7);
            Controls.Add(SOCTxt);
            Controls.Add(label6);
            Controls.Add(ChargeRateTxt);
            Controls.Add(label5);
            Controls.Add(EndTimeTxt);
            Controls.Add(label4);
            Controls.Add(StartTimeTxt);
            Controls.Add(label3);
            Controls.Add(CapcityTxt);
            Controls.Add(label2);
            Controls.Add(ForecastTxt);
            Controls.Add(label1);
            Name = "MacroForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "MacroForm";
            FormClosing += MacroForm_FormClosing;
            Load += MacroForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox ForecastTxt;
        private TextBox CapcityTxt;
        private Label label2;
        private TextBox StartTimeTxt;
        private Label label3;
        private TextBox EndTimeTxt;
        private Label label4;
        private TextBox ChargeRateTxt;
        private Label label5;
        private TextBox SOCTxt;
        private Label label6;
        private TextBox SpareTxt;
        private Label label7;
        private TextBox MinSOC;
        private Label label8;
    }
}