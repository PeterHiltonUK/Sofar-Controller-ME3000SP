using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SofarController
{
    public partial class TOUSingle : Form
    {
        private Sofar sofarClass;
        OptionData optionData;

        public TOUSingle(TOUData tOU0, Sofar sofarClass,OptionData optionData)
        {
            this.optionData = optionData;
            InitializeComponent();
            this.sofarClass = sofarClass;
            tou1.Data = tOU0;
            tou1.Update();
        }

        private void SaveTOU1_Click(object sender, EventArgs e)
        {
            tou1.RetriveData();
            sofarClass.WriteTimeOfUseParams(0, tou1.Data, optionData);
        }

        private void LoadTOU1_Click(object sender, EventArgs e)
        {
            sofarClass.UpdateTOUData(0, optionData);
            tou1.Update();
        }

    }
}
