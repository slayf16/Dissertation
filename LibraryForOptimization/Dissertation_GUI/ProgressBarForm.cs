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
    public partial class ProgressBarForm : Form
    {
        
        public ProgressBarForm()
        {
            InitializeComponent();
            label1.Text = "";
            
        }
        
        public void progress(int i)
        {

            progressBar1.Value = i;
            label1.Text = $"{progressBar1.Value.ToString()}%";
        }

    }
}
