namespace SofarController
{
    partial class PassiveForm
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
            groupBox1 = new GroupBox();
            DischargeRate = new TextBox();
            button3 = new Button();
            ChargeRate = new TextBox();
            label3 = new Label();
            label2 = new Label();
            button2 = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(DischargeRate);
            groupBox1.Controls.Add(button3);
            groupBox1.Controls.Add(ChargeRate);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(button2);
            groupBox1.Location = new Point(37, 32);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(212, 196);
            groupBox1.TabIndex = 36;
            groupBox1.TabStop = false;
            groupBox1.Text = "Passive Mode";
            // 
            // DischargeRate
            // 
            DischargeRate.Location = new Point(87, 153);
            DischargeRate.Name = "DischargeRate";
            DischargeRate.Size = new Size(100, 23);
            DischargeRate.TabIndex = 7;
            DischargeRate.Text = "1000";
            DischargeRate.Validating += DischargeRate_Validating;
            // 
            // button3
            // 
            button3.Location = new Point(14, 124);
            button3.Name = "button3";
            button3.Size = new Size(112, 23);
            button3.TabIndex = 9;
            button3.Text = "Discharge";
            button3.UseVisualStyleBackColor = true;
            button3.Click += SetDischargRate_Click;
            // 
            // ChargeRate
            // 
            ChargeRate.Location = new Point(87, 80);
            ChargeRate.Name = "ChargeRate";
            ChargeRate.Size = new Size(100, 23);
            ChargeRate.TabIndex = 4;
            ChargeRate.Text = "1000";
            ChargeRate.Validating += ChargeRate_Validating;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(10, 161);
            label3.Name = "label3";
            label3.Size = new Size(71, 15);
            label3.TabIndex = 8;
            label3.Text = "Charge Rate";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(10, 88);
            label2.Name = "label2";
            label2.Size = new Size(71, 15);
            label2.TabIndex = 5;
            label2.Text = "Charge Rate";
            // 
            // button2
            // 
            button2.Location = new Point(14, 46);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 6;
            button2.Text = "Charge";
            button2.UseVisualStyleBackColor = true;
            button2.Click += SetCHargeRate_Click;
            // 
            // PassiveForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(314, 262);
            Controls.Add(groupBox1);
            Name = "PassiveForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Passive Mode";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private GroupBox groupBox1;
        private TextBox DischargeRate;
        private Button button3;
        private TextBox ChargeRate;
        private Label label3;
        private Label label2;
        private Button button2;
    }
}