namespace SofarController
{
    partial class SofarForm
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
            SofarDataGrid = new DataGridView();
            Property = new DataGridViewTextBoxColumn();
            Value = new DataGridViewTextBoxColumn();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)SofarDataGrid).BeginInit();
            SuspendLayout();
            // 
            // SofarDataGrid
            // 
            SofarDataGrid.AllowUserToAddRows = false;
            SofarDataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            SofarDataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            SofarDataGrid.Columns.AddRange(new DataGridViewColumn[] { Property, Value });
            SofarDataGrid.Location = new Point(184, 12);
            SofarDataGrid.Name = "SofarDataGrid";
            SofarDataGrid.Size = new Size(580, 561);
            SofarDataGrid.TabIndex = 26;
            // 
            // Property
            // 
            Property.HeaderText = "Property";
            Property.Name = "Property";
            // 
            // Value
            // 
            Value.HeaderText = "Value";
            Value.Name = "Value";
            // 
            // button1
            // 
            button1.Location = new Point(12, 12);
            button1.Name = "button1";
            button1.Size = new Size(146, 31);
            button1.TabIndex = 28;
            button1.Text = "Update Values";
            button1.UseVisualStyleBackColor = true;
            // 
            // SofarForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(808, 585);
            Controls.Add(button1);
            Controls.Add(SofarDataGrid);
            Name = "SofarForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SofarForm";
            ((System.ComponentModel.ISupportInitialize)SofarDataGrid).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private DataGridViewTextBoxColumn Property;
        private DataGridViewTextBoxColumn Value;
        private Button button1;
        public DataGridView SofarDataGrid;
    }
}