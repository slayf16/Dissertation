using LibraryForOptimization;
using LibraryForOptimization.Excel.structureForExcel;
using LibraryForOptimization.ObjectiveFunction;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestOPt2;

namespace Dissertation_GUI
{
    public partial class MainForm : Form
    {

       

       // private DataGridView _selectedDataGridView { get; set;  }
        
        

        public BindingList<InitialData> initialDatas = new BindingList<InitialData>();

        public List<AnswerStructure> Answers = new List<AnswerStructure>();
       
        
       //TODO: подумать что делать с путями характеристик
        public List<string[]> way = new List<string[]>();

        public MainForm()
        {
            var testID = new int[3] {1, 2, 3 }; 
            var testN = new string[3] { "СШГЭС", "МГЭС", "КГЭС" };
            var testQ = new double[3] { 2100, 2109, 2230 };
            var testZ = new double[3] { 520, 324, 244 };
            for(int i = 0; i< 3; i++)
            {
                var test = new InitialData();
                test.GesId = testID[i];
                test.GesName = testN[i];
                test.LevelVB = testZ[i];
                test.WaterConsumptionNB = testQ[i];
                initialDatas.Add(test);
            }
            InitializeComponent();
            dataGridView1.DataSource = initialDatas;
            
            
        }

        private void LoadLimitGesClickToolStrip(object sender, EventArgs e)
        {
            try
            {
                var stationLimitModels = new List<StationLimitModel>();
                List<StationInfo> stationInfoModels;
                var openDialog = new OpenFileDialog();
                var diolog = openDialog.ShowDialog();
                if (diolog == DialogResult.OK)
                {
                    var path = openDialog.FileName;
                    stationInfoModels = WorkWithExcelImport.InputStructLimit(path);
                    foreach (var model in stationInfoModels)
                    {
                        var stationName = model.Name;
                        foreach (var stationLimit in model.Limits)
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
            }
            catch
            {
                MessageBox.Show("Неверный формат загружаемых данных", "Ошибка", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_MouseUp(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right)
            {
                dataGridView1.ContextMenuStrip = contextMenuStrip1; 
            }
        }

 
       
      
        void DeleteRowItem_Click(object sender, EventArgs e)
        {
            
        }

        //TODO: какая то херня
        private void AddToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.ContextMenuStrip == contextMenuStrip1)
            {
                var add = new AddFormInitData(dataGridView1.Rows.Count);
                add.ShowDialog();
                if (add.DialogResult == DialogResult.OK)
                {
                    initialDatas.Add(add.InitialGes);
                }
            }
            else
            {
                var add = new AddFormLimitData();
                add.Show();

            }
        }

        private void dataGridView2_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                dataGridView2.ContextMenuStrip = contextMenuStrip1;
            }
        }

        //TODO: сделать адекватное получение пути
        private void характеристикиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var stationLimitModels = new List<StationLimitModel>();
            
            var openDialog = new OpenFileDialog();
            openDialog.Multiselect = true;
           
            var diolog = openDialog.ShowDialog();
            if (diolog == DialogResult.OK)
            {
                
                var path = openDialog.FileNames;
                way.Add(path);
            }

        }

        private void расчетToolStripMenuItem_Click(object sender, EventArgs e)
        {

            var objectiveFunction = new FunctionEnergy(way);
            objectiveFunction.Init(initialDatas[0].LevelVB, initialDatas[1].LevelVB, initialDatas[2].LevelVB);
            var startPosition = new double[] { initialDatas[0].WaterConsumptionNB,
                initialDatas[1].WaterConsumptionNB, initialDatas[2].WaterConsumptionNB };
            /// задавать в интерфейсе (читает из второй датагридвьюшки)
            var lowerBound = new double[] { 0, 700, 1740 };
            var upperBound = new double[] { 12000, 13000, 19000 };

            var swarm = new ParticleSwarm(100, lowerBound, upperBound, startPosition, p =>
            {
                var pList = new List<double>(p);
                return objectiveFunction.Calculate(pList);
            });
            var max = 0.0;
           // List<(double, double)> ps = new List<(double, double)>();

            PogressBarForm progressBarForm = new PogressBarForm();

            progressBarForm.Show();
            
            var answerRashod = new List<double[]>();


            swarm.Step(1000, i =>
            {
                
                Answers.Add(new AnswerStructure(swarm.BestFitness,i));
                //ps.Add((swarm.BestFitness, swarm.BestPosition[0]));
                double a = i;
                Answers[i].RashodAnswer =objectiveFunction.RashodAnswer;
                answerRashod.Add(objectiveFunction.RashodAnswer);
                progressBarForm.progress(Convert.ToInt32(Math.Round(a / 10)));
                
                return false;
      
            });

            
            progressBarForm.Close();
            MessageBox.Show("Расчет выполнен", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            AnswerForm answerForm = new AnswerForm();
            answerForm.RetryAnswer(Answers);
            answerForm.Show();
        }
    }
}
