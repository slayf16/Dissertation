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

namespace Dissertation_GUI
{
    /// <summary>
    /// Форма добавления исходных данных
    /// </summary>
    public partial class AddFormInitData : Form
    {
        /// <summary>
        /// переменная, которую будем добавлять в список исходных данных
        /// </summary>
        public InitialData InitialGes { get; private set; }
        
        /// <summary>
        /// конструктор формы
        /// </summary>
        /// <param name="indexGes">количество гэс в каскаде</param>
        public AddFormInitData(int indexGes)
        {
            InitializeComponent();
            
            gesId.Text = (indexGes+1).ToString();

        }

        /// <summary>
        /// обработчик создания исходных данных
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OKButton_Click(object sender, EventArgs e)
        {
            try
            {
                
                var Ges = new InitialData()
                {
                    GesName = gesName.Text,
                    WaterConsumptionNB = Convert.ToDouble(waterConsumptionNB.Text),
                    LevelVB = Convert.ToDouble(levelVB.Text),
                    GesId = Convert.ToInt32(gesId.Text)
                };
                InitialGes = Ges;



                this.Close();
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// на случай, если передумали
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
