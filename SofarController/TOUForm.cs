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
    public partial class TOUForm : Form
    {
        private Sofar sofarClass;
        OptionData optionData;

        public TOUForm(TOUData tOU0, TOUData tOU1, TOUData tOU2, TOUData tOU3, Sofar sofarClass, OptionData options)
        {
            optionData = options;
            InitializeComponent();

            this.sofarClass = sofarClass;

            tou1.Data = tOU0;
            tou2.Data = tOU1;
            tou3.Data = tOU2;
            tou4.Data = tOU3;

            tou1.Update();
            tou2.Update();
            tou3.Update();
            tou4.Update();
        }

        private void TOULoadData_Click(object sender, EventArgs e)
        {
            tou1.Update();
            tou2.Update();
            tou3.Update();
            tou4.Update();
        }

        private void SaveTOU1_Click(object sender, EventArgs e)
        {
            tou1.RetriveData();
            sofarClass.WriteTimeOfUseParams(0, tou1.Data,optionData);
        }

        private void SaveTOU2_Click(object sender, EventArgs e)
        {
            tou2.RetriveData();
            sofarClass.WriteTimeOfUseParams(1, tou2.Data, optionData);
        }

        private void SaveTOU3_Click(object sender, EventArgs e)
        {
            tou3.RetriveData();
            sofarClass.WriteTimeOfUseParams(2, tou3.Data, optionData);
        }

        private void SaveTOU4_Click(object sender, EventArgs e)
        {
            tou4.RetriveData();
            sofarClass.WriteTimeOfUseParams(3, tou4.Data, optionData);
        }

        private void LoadTOU1_Click(object sender, EventArgs e)
        {
            sofarClass.UpdateTOUData(0, optionData);
            tou1.Update();
        }

        private void LoadTOU2_Click(object sender, EventArgs e)
        {
            sofarClass.UpdateTOUData(1, optionData);
            tou2.Update();
        }

        private void LOADTOU3_Click(object sender, EventArgs e)
        {
            sofarClass.UpdateTOUData(2, optionData);
            tou3.Update();
        }

        private void LAODTOU4_Click(object sender, EventArgs e)
        {
            sofarClass.UpdateTOUData(3, optionData);
            tou4.Update();
        }
    }
}