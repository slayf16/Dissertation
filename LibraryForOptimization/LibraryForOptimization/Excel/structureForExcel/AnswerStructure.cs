using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryForOptimization.Excel.structureForExcel
{
    //TODO:дополнить потом
    /// <summary>
    /// Структура ответа 
    /// </summary>
    public class AnswerStructure
    {
        public double FunctionValue { get; set; }

        public int Iteration { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public double[] RashodAnswer;

        public AnswerStructure() { }


        public AnswerStructure(double functionValue, int iteration)
        {
            FunctionValue = functionValue;
            Iteration = iteration;
        }
    }
}
