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
using LiveCharts;
using LiveCharts.Wpf;
using LibraryForOptimization.Excel;

namespace Dissertation_GUI
{
    /// <summary>
    /// Форма ответов (одна вкладка табличные ответы, вторая графические)
    /// </summary>
    public partial class AnswerForm : Form
    {
        /// <summary>
        /// поле для получения структуры ответа
        /// </summary>
        public List<AnswerStructure> answerTable = new List<AnswerStructure>();
       

        /// <summary>
        /// конструктор формы
        /// </summary>
        public AnswerForm()        
        {
            InitializeComponent(); 
        }

        /// <summary>
        /// метод обновления поля
        /// </summary>
        /// <param name="answer"></param>
        public void RetryAnswer(List<AnswerStructure> answer)
        {
            var k = 2;
            answerTable = answer;
            int countColumn = 3 * answer[0].RashodAnswer.Length + 2;
            //
            dataGridView1.ColumnCount = countColumn;//+3;
            dataGridView1.Columns[0].HeaderText = "Function Value";
            dataGridView1.Columns[1].HeaderText = "iteration";
            dataGridView1.Columns[0].Name = "Целевая функция";
            for (int i = 2; i < countColumn - answer[0].PowerAnswerGES.Length-answer[0].LevelUpperBief.Length; i++)
            {
                dataGridView1.Columns[i].HeaderText = $"Q{i - 1}";
                k++;
            }
            var h = 1;
            for (int i = k; i < countColumn - answer[0].PowerAnswerGES.Length; i++)
            {                
                dataGridView1.Columns[i].HeaderText = $"P{h}";
                h++;
                k++;
            }

            h = 1;

            for (int i = k; i < countColumn; i++)
            {
                dataGridView1.Columns[i].HeaderText = $"Z{h}";
                h++;
                k++;
            }

            //todo: переделать
            //for (int i = 5; i < countColumn+3; i++)
            //{
            //    dataGridView1.Columns[i].HeaderText = $"P{i - 4}";
            //}
         ;
            for (int i = 0; i<answer.Count; i++)
            {
                var kk = 2;
                dataGridView1.Rows.Add();
                dataGridView1[0, i].Value = answer[i].FunctionValue;
                dataGridView1[1, i].Value = answer[i].Iteration;
                for (int j = kk; j < countColumn - answer[0].PowerAnswerGES.Length - answer[0].LevelUpperBief.Length; j++)
                {
                    dataGridView1[j, i].Value = answer[i].RashodAnswer[j - 2];
                    kk++;
                }

                for (int j = kk; j < countColumn - answer[0].PowerAnswerGES.Length; j++)
                {
                    dataGridView1[j, i].Value = answer[i].PowerAnswerGES[j - answer[0].RashodAnswer.Length - 2];
                    kk++;
                }

                for (int j = kk; j < countColumn; j++)
                {
                    dataGridView1[j, i].Value = answer[i].LevelUpperBief[j - answer[0].RashodAnswer.Length - 2 - answer[0].PowerAnswerGES.Length];
                    kk++;
                }
                //for (int j = 5; j < countColumn+3; j++)
                //{
                //    dataGridView1[j, i].Value = a[i].PowerAnswerGES[j - 5];
                //}
            }

        }

        //todo: тормозит масштабирование
        /// <summary>
        /// Кнопка "построить график"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {

            int indexColumn = 0;// Convert.ToInt32(textBox1.Text);

            SeriesCollection series = new SeriesCollection();
            ChartValues<double> d = new ChartValues<double>();
            List<string> index = new List<string>();

            //foreach (var hui in bvelosity[0])
            //{
            //    d.Add(hui[0]);
            //}
            //foreach (var b in answerTable)
            //{
            //    index.Add(b.Iteration.ToString());
            //}
            //cartesianChart1.AxisX.Clear();
            //cartesianChart1.AxisX.Add(new Axis()
            foreach (var b in answerTable)
            {
                if (b.Iteration < 2)
                {
                    continue;
                }

                d.Add(b.FunctionValue);
                //d.Add(b.RashodAnswer[0]);
                index.Add(b.Iteration.ToString());
            }
            cartesianChart1.AxisX.Clear();
            cartesianChart1.AxisX.Add(new Axis()
            {
                Title = "итерация",
                Labels = index

            });
            LineSeries s = new LineSeries();

            s.Title = "значение целевой функции";
            s.Values = d;

            series.Add(s);
            cartesianChart1.Series = series;
            cartesianChart1.Zoom = LiveCharts.ZoomingOptions.X;
           

        }

        private void сохранитьКакТаблицуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WorkWithExcelExport.SaveToExcel(dataGridView1);
        }
    }
}
