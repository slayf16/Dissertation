using LibraryForOptimization.Excel.structureForExcel;
using LibraryForOptimization.ObjectiveFunction;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestOPt2;

namespace Dissertation_GUI
{
    /// <summary>
    /// Форма для отслеживания и выполнения процесса расчета
    /// </summary>
    public partial class PogressBarForm : Form
    {
        /// <summary>
        /// Публичное поле для ответов
        /// </summary>
        public List<AnswerStructure> Answers = new List<AnswerStructure>();

        /// <summary>
        /// приватное поле для инициализации метода оптимизации
        /// </summary>
        private ParticleSwarm _swarm;

        /// <summary>
        /// приватное поле для инициализации целевой функции
        /// </summary>
        private FunctionEnergy _objectiveFunction;

        /// <summary>
        /// Метод для принятия инициализирующих расчетных величин
        /// </summary>
        /// <param name="answerss">Инициализация поля ответов</param>
        /// <param name="swarms">Метод расчета</param>
        /// <param name="objectiveFunctions">подготовленная целевая функция</param>
        public void Init(List<AnswerStructure> answerss, ParticleSwarm swarms, FunctionEnergy objectiveFunctions)
        {
            Answers = answerss;
            _swarm = swarms;
            _objectiveFunction = objectiveFunctions;
        }

        /// <summary>
        /// Конструктор формы
        /// </summary>
        public PogressBarForm()
        {
            InitializeComponent();
            label1.Text = "";
        }
        
        /// <summary>
        /// Приватное поле для визуализации прогресса на форме
        /// </summary>
        /// <param name="i">счетчик прогресса</param>
        private void progress(int i)
        {
            progressBar1.Value = i;
            label1.Text = $"{i}%";
        }
        
        /// <summary>
        /// Кнопка для отмены расчета
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelButton_Click(object sender, EventArgs e)
        {
            if(backgroundWorker1.IsBusy)
            {
                label1.Text = "Cancelling...";
                backgroundWorker1.CancelAsync();
                MessageBox.Show("Расчет отменен", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
            }
        }

        /// <summary>
        /// Событие для запуска асинхронной операции
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker bgW = sender as BackgroundWorker;
            f1(bgW, e);
        }

        /// <summary>
        /// событие для обработки изменения прогресса расчета
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progress(e.ProgressPercentage);
        }


        /// <summary>
        /// событие для обработки: завершение, прерывания и т.д фонового процесса
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if(e.Cancelled)
            {
                return;
            }           
            List<AnswerStructure> copy = new List<AnswerStructure>(Answers);
            MessageBox.Show("Расчет выполнен", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            AnswerForm answerForm = new AnswerForm();
            answerForm.RetryAnswer(copy);
            answerForm.Show();
            this.Close();
        }

        /// <summary>
        /// Запускает операцию в фоновом режиме, при открытии формы 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PogressBarForm_Shown(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();           
        }

        /// <summary>
        /// метод для выполнения расчета 
        /// </summary>
        /// <param name="bgw">отдельный поток для обновление прогрессБар</param>
        /// <param name="e"></param>
        private void f1(BackgroundWorker bgw, DoWorkEventArgs e)
        {
            _swarm.Step(1000, i =>
            {
                Answers.Add(new AnswerStructure(_swarm.BestResult, i, _objectiveFunction.RashodAnswer,
                    _objectiveFunction.PowerAnswerGes, _objectiveFunction.LevelUpperBief));
                double a = i;
                bgw.ReportProgress(Convert.ToInt32(Math.Round(a / 10)));       
            if (bgw.CancellationPending)
                {
                    e.Cancel = true;
                    return true;
                }
                return false;
            });          
        }
    }
}
