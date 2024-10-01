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

        public TOUSingle(TOUData tou, Sofar sofarClass,OptionData optionData)
        {
            InitializeComponent();

            if (tou is not null)
            {
                this.optionData = optionData;
                this.sofarClass = sofarClass;
                tou1Control.Data = tou;
                tou1Control.Update();
            }
        }

        private void SaveTOU1_Click(object sender, EventArgs e)
        {
            tou1Control.RetriveData();
            if(sofarClass is not null)
                sofarClass.WriteTimeOfUseParams(0, tou1Control.Data, optionData);
        }

        private void LoadTOU1_Click(object sender, EventArgs e)
        {
            if (sofarClass is not null)
                sofarClass.UpdateTOUData(0, optionData);
            tou1Control.Update();
        }

    }
}
