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
        public BindingList<AnswerStructure> answerViewTable = new BindingList<AnswerStructure>(); 

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
        public void RetryAnswer(BindingList<AnswerStructure> a)
        {

            answerViewTable = a;
            dataGridView1.DataSource = answerViewTable;
            
        }

        /// <summary>
        /// Кнопка "построить график"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            SeriesCollection series = new SeriesCollection();
            ChartValues<double> d = new ChartValues<double>();
            List<string> index = new List<string>();

            foreach(var a in answerViewTable)
            {
                d.Add(a.FunctionValue);
                index.Add(a.Iteration.ToString());
            }
            cartesianChart1.AxisX.Clear();
            cartesianChart1.AxisX.Add(new Axis()
            {
                Title = "итерация",
                Labels = index

            }) ;
            LineSeries s = new LineSeries();

            s.Title = "значение целевой функции";
            s.Values = d;

            series.Add(s);
            cartesianChart1.Series = series;

        }
    }
}
