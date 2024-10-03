namespace SofarController
{
    partial class Options
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
            label6 = new Label();
            label5 = new Label();
            SolcastAPIKey = new TextBox();
            SolcastLocationCodeTXT = new TextBox();
            label4 = new Label();
            SerialTXT = new TextBox();
            label3 = new Label();
            IPPortTxt = new TextBox();
            label2 = new Label();
            IPAddresstxt = new TextBox();
            COMPORTtxt = new TextBox();
            label1 = new Label();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(SolcastAPIKey);
            groupBox1.Controls.Add(SolcastLocationCodeTXT);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(SerialTXT);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(IPPortTxt);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(IPAddresstxt);
            groupBox1.Controls.Add(COMPORTtxt);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(32, 24);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(175, 405);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Options";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(15, 340);
            label6.Name = "label6";
            label6.Size = new Size(87, 15);
            label6.TabIndex = 33;
            label6.Text = "Solcast API Key";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(17, 275);
            label5.Name = "label5";
            label5.Size = new Size(124, 15);
            label5.TabIndex = 32;
            label5.Text = "Solcast Location Code";
            // 
            // SolcastAPIKey
            // 
            SolcastAPIKey.Location = new Point(15, 358);
            SolcastAPIKey.Name = "SolcastAPIKey";
            SolcastAPIKey.Size = new Size(100, 23);
            SolcastAPIKey.TabIndex = 31;
            SolcastAPIKey.Text = "Enter";
            SolcastAPIKey.Validating += SolcastAPIKey_Validating;
            // 
            // SolcastLocationCodeTXT
            // 
            SolcastLocationCodeTXT.Location = new Point(15, 295);
            SolcastLocationCodeTXT.Name = "SolcastLocationCodeTXT";
            SolcastLocationCodeTXT.Size = new Size(100, 23);
            SolcastLocationCodeTXT.TabIndex = 30;
            SolcastLocationCodeTXT.Text = "Enter";
            SolcastLocationCodeTXT.Validating += SolcastLocationCodeTXT_Validating;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(15, 214);
            label4.Name = "label4";
            label4.Size = new Size(54, 15);
            label4.TabIndex = 29;
            label4.Text = "Serial No";
            // 
            // SerialTXT
            // 
            SerialTXT.Location = new Point(15, 232);
            SerialTXT.Name = "SerialTXT";
            SerialTXT.Size = new Size(100, 23);
            SerialTXT.TabIndex = 28;
            SerialTXT.Text = "Enter";
            SerialTXT.Validating += SerialTXT_Validating;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(15, 156);
            label3.Name = "label3";
            label3.Size = new Size(29, 15);
            label3.TabIndex = 27;
            label3.Text = "Port";
            // 
            // IPPortTxt
            // 
            IPPortTxt.Location = new Point(15, 174);
            IPPortTxt.Name = "IPPortTxt";
            IPPortTxt.Size = new Size(100, 23);
            IPPortTxt.TabIndex = 26;
            IPPortTxt.Text = "8899";
            IPPortTxt.Validating += IPPortTxt_Validating;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(15, 99);
            label2.Name = "label2";
            label2.Size = new Size(60, 15);
            label2.TabIndex = 25;
            label2.Text = "IP address";
            // 
            // IPAddresstxt
            // 
            IPAddresstxt.Location = new Point(15, 117);
            IPAddresstxt.Name = "IPAddresstxt";
            IPAddresstxt.Size = new Size(100, 23);
            IPAddresstxt.TabIndex = 24;
            IPAddresstxt.Text = "Enter";
            IPAddresstxt.Validating += IPAddresstxt_Validating;
            // 
            // COMPORTtxt
            // 
            COMPORTtxt.Location = new Point(15, 61);
            COMPORTtxt.Name = "COMPORTtxt";
            COMPORTtxt.Size = new Size(100, 23);
            COMPORTtxt.TabIndex = 23;
            COMPORTtxt.Text = "Enter";
            COMPORTtxt.Validating += COMPORTtxt_Validating;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(15, 31);
            label1.Name = "label1";
            label1.Size = new Size(60, 15);
            label1.TabIndex = 22;
            label1.Text = "COM Port";
            // 
            // Options
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(239, 450);
            Controls.Add(groupBox1);
            Name = "Options";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Options";
            FormClosing += Options_FormClosing;
            Load += Options_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Label label1;
        private TextBox COMPORTtxt;
        private Label label2;
        private TextBox IPAddresstxt;
        private Label label3;
        private TextBox IPPortTxt;
        private Label label4;
        private TextBox SerialTXT;
        private Label label6;
        private Label label5;
        private TextBox SolcastAPIKey;
        private TextBox SolcastLocationCodeTXT;
    }
}