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
        List<List<double[]>> bvelosity = new List<List<double[]>>();

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
        /// <param name="a"></param>
        public void RetryAnswer(List<AnswerStructure> a, List<List<double[]>> b)
        {
            bvelosity = b;
            answerTable = a;
            int countColumn = a[0].RashodAnswer.Length + 2;
            dataGridView1.ColumnCount = countColumn;
            dataGridView1.Columns[0].HeaderText = "Function Value";
            dataGridView1.Columns[1].HeaderText = "iteration";
            for (int i = 2; i < countColumn; i++)
            {
                dataGridView1.Columns[i].HeaderText = $"Q{i - 1}";
            }
            
            for(int i = 0; i<a.Count; i++)
            {
                dataGridView1.Rows.Add();
                dataGridView1[0, i].Value = a[i].FunctionValue;
                dataGridView1[1, i].Value = a[i].Iteration;
                for (int j = 2; j < countColumn; j++)
                {
                    dataGridView1[j, i].Value = a[i].RashodAnswer[j - 2];
                }
            }
            //answerViewTable = a;
            //dataGridView1.DataSource = answerViewTable;

        }

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

                //d.Add(b.FunctionValue);
                d.Add(b.RashodAnswer[0]);
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

        }
    }
}
