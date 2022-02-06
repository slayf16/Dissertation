using LibraryForOptimization;
using LibraryForOptimization.Excel.structureForExcel;
using LibraryForOptimization.ObjectiveFunction;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using TestOPt2;


namespace Dissertation_GUI
{
    public partial class MainForm : Form
    {


        int iii = 0;

        /// <summary>
        /// поле для определения с какого Дата грид было вызвано контекстное меню
        /// </summary>
        public int ClickDatagrid;


        /// <summary>
        /// Поле для инициализирующих данных (первая таблица)
        /// </summary>
        public BindingList<InitialData> initialDatas = new BindingList<InitialData>();

        /// <summary>
        /// Поле для ограничений (загружаем со стороны [таблица 2]), 
        /// </summary>
        public BindingList<StationLimitModel> stationLimitModels = new BindingList<StationLimitModel>();

        /// <summary>
        /// поле для передачи ответов в другие формы
        /// </summary>
       // public List<AnswerStructure> Answers = new List<AnswerStructure>();

        /// <summary>
        /// словарь для чтения структур 
        /// </summary>
        public Dictionary<string, List<StructureСaracteristicGes>> structures = new Dictionary<string, List<StructureСaracteristicGes>>();
      
        /// <summary>
        /// 
        /// </summary>
        public MainForm()
        {
            var testID = new int[3] {1, 2, 3 }; 
            var testN = new string[3] { "СШГЭС", "МГЭС", "КГЭС" };
            var testQ = new double[3] { 2100, 2109, 2230 };
            var testZ = new double[3] { 535, 322, 240 };

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
            dataGridView2.DataSource = stationLimitModels;                        
        }

        private void LoadLimitGesClickToolStrip(object sender, EventArgs e)
        {
            try
            {
                List<StationInfo> stationInfoModels;
                var openDialog = new OpenFileDialog();
                openDialog.Filter = "Excel file (*.xlsx)|*.xlsx";
                var diolog = openDialog.ShowDialog();
                if (diolog == DialogResult.OK)
                {
                    var path = openDialog.FileName;
                    stationInfoModels = WorkWithExcelImport.InputStructLimit(path);
                    if (stationInfoModels.Count != 0)
                    {
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
                    }
                    else
                    {

                        MessageBox.Show("Неверная структура загружаемых данных", "Ошибка",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
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
                ClickDatagrid = 1;

            }
        }
             
        private void dataGridView2_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                dataGridView2.ContextMenuStrip = contextMenuStrip1;
                ClickDatagrid = 2;
            }
        }

        private void AddToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ClickDatagrid == 1)
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

        //TODO: спросить у никиты, как сократить
        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (ClickDatagrid == 1)
                {
                    var a = dataGridView1.CurrentCellAddress;//X - столбец Y - строка
                    dataGridView1.Rows[a.Y].Selected = true;
                    var result = MessageBox.Show("Вы уверены что хотите удалить данную строку?", "Внимание",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                   
                    if(result ==DialogResult.Yes)
                    {
                        initialDatas.RemoveAt(a.Y);
                    }
                    else
                    {
                        dataGridView1.Rows[a.Y].Selected = false;
                        dataGridView1.Rows[a.Y].Cells[a.X].Selected = true;

                    }
                }
                else
                {
                    var a = dataGridView2.CurrentCellAddress;//X - столбец Y - строка
                    dataGridView2.Rows[a.Y].Selected = true;
                    var result = MessageBox.Show("Вы уверены что хотите удалить данную строку?", "Внимание",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        stationLimitModels.RemoveAt(a.Y);
                    }
                    else
                    {
                        dataGridView2.Rows[a.Y].Selected = false;
                        dataGridView2.Rows[a.Y].Cells[a.X].Selected = true;

                    }

                }
            }
            catch
            {
                MessageBox.Show("Необходимо выбрать строку для удаления", "Информация",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        //TODO: сделать адекватное получение пути
        private void характеристикиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var testWay = new List<string>();
                List<string> sfd = new List<string>();
                var stationLimitModels = new List<StationLimitModel>();

                var openDialog = new OpenFileDialog();
                openDialog.Multiselect = true;

                var diolog = openDialog.ShowDialog();
                if (diolog == DialogResult.OK)
                {
                    var path = openDialog.FileNames;

                    foreach (var a in path)
                    {
                        testWay.Add(a);

                    }
                }
                
                foreach (var path in testWay)
                {
                    var bigDatas = WorkWithExcelImport.InputStructCharacter(path);
                    if (bigDatas.Count != 0)
                    {
                        structures.Add(Path.GetFileNameWithoutExtension(path), bigDatas);
                        fillingSheet(path);
                    }
                    else
                    {
                        throw new Exception("неверная структура  данных");
                    }
                }

               
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void calculationButton(object sender, EventArgs e)
        {
            try
            {
                
                var answers = new List<AnswerStructure>();
                var objectiveFunction = new FunctionEnergy(structures);
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
                PogressBarForm progressBarForm = new PogressBarForm();
                progressBarForm.Init(answers, swarm, objectiveFunction);
                progressBarForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void fillingSheet(string textToList)
        {
            listBox1.Items.Add($"{Path.GetFileName(textToList)}\t");
            iii++;
        }
        
        private void exitProgram(object sender, EventArgs e)
        {
            this.Close();
        }


        private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            Regex regex = new Regex("[А-я]");
            double a; 
            switch (e.ColumnIndex)
            {
                case 0:
                    {
                        if (!regex.IsMatch(e.FormattedValue.ToString()))
                        {
                            MessageBox.Show("Введите текст", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            e.Cancel = true;

                        }
                        break;
                    }
                default:
                    {
                        if (!double.TryParse(e.FormattedValue.ToString(),out a))
                        {
                            MessageBox.Show("Должно быть число", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            e.Cancel = true;
                            break;
                        }

                        if(Convert.ToDouble(e.FormattedValue)<0)
                        {
                            MessageBox.Show("число должно быть положительным", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            e.Cancel = true;
                        }
                        break;
                    }
            }     
        }

        //TODO:
        private void ClearButtonClick(object sender, EventArgs e)
        {

        }
    }
}
