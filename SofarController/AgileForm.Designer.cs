namespace SofarController
{
    partial class AgileForm
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
            chart1 = new Charts.ChartControl();
            SuspendLayout();
            // 
            // chart1
            // 
            chart1.Dock = DockStyle.Fill;
            chart1.ForeColor = Color.Red;
            chart1.Location = new Point(0, 0);
            chart1.Margin = new Padding(4, 3, 4, 3);
            chart1.Name = "chart1";
            chart1.Size = new Size(800, 450);
            chart1.TabIndex = 15;
            // 
            // AgileForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(800, 450);
            Controls.Add(chart1);
            Name = "AgileForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion
        private Charts.ChartControl chart1;
    }
}