using LibraryForOptimization;
using LibraryForOptimization.Excel.structureForExcel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dissertation_GUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void ограниченияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var stationLimitModels = new List<StationLimitModel>();
            List<StationInfo> stationInfoModels;
            var openDialog = new OpenFileDialog();
            var diolog =  openDialog.ShowDialog();
            if (diolog == DialogResult.OK)
            {
                var path = openDialog.FileName;
                stationInfoModels = WorkWithExcel.InputStructLimit(path);
                foreach(var model in stationInfoModels)
                {
                    var stationName = model.Name;
                    foreach(var stationLimit in model.Limits )
                    {
                        var stationLimitModel = new StationLimitModel()
                        {
                            GesName = stationName,
                            LimitName = stationLimit.NameLimitation,
                            //заменить иф элз
                            LimitType = stationLimit.RestrictionType ? ">=" : "<=",
                            LimitValue = stationLimit.NumericalValue,
                            PeriodStart = stationLimit.StartPeriod.ToShortDateString(),
                            PeriodFinish = stationLimit.FinishPeriod.ToShortDateString()
                        };
                        stationLimitModels.Add(stationLimitModel);
                    }
                }
               
                dataGridView2.DataSource = stationLimitModels;

                

            }

            //dataGridView1.DataSource = ad;


        }
    }
}
