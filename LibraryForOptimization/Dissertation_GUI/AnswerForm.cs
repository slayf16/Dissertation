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
    public partial class AnswerForm : Form
    {
        public BindingList<AnswerStructure> answerViewTable = new BindingList<AnswerStructure>(); 
        public AnswerForm()
        
        {

            InitializeComponent();
        }
    }
}
