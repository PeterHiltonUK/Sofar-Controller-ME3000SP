namespace SofarController
{
    public partial class SofarForm : Form
    {
        Sofar sofar;
        public SofarForm(Sofar sofardata, OptionData options)
        {
            InitializeComponent();
            sofar= sofardata;
            ClearGrid();
            UpdateGrid(options);
        }

        public void ClearGrid()
        {
            if (SofarDataGrid.InvokeRequired)
            {
                SofarDataGrid.Invoke(new MethodInvoker(ClearGrid));
            }
            else
            {
                SofarDataGrid.Rows.Clear();
            }
        }

        public void GridAddRow(Tuple<string, int, double, double, bool> val)
        {
            if (SofarDataGrid.InvokeRequired)
            {
                SofarDataGrid.Invoke(new Action(() => GridAddRow(val)));
            }
            else
            {
                SofarDataGrid.Rows.Add(new string[] { val.Item1, val.Item3.ToString() });
            }
        }

        private void UpdateGrid(OptionData options)
        {
            List<Tuple<string, int, double, double, bool>> values = sofar.GetData(options, false);

            for (int i = 0; i < values.Count; i++)
            {
                GridAddRow(values[i]);
            }
        }
    }
}
