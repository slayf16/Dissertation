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

        /// <summary>
        /// 
        /// </summary>
        public double[] PowerAnswerGES;

        /// <summary>
        /// 
        /// </summary>
        public double[] LevelUpperBief;

        public AnswerStructure() { }


       // List<List<double>> velosity;


        public AnswerStructure(double functionValue, int iteration, double[] rashodAnswer, double[] powerAnswerGES, double[] levelUpperBief)
        {
            FunctionValue = functionValue;
            Iteration = iteration;
            RashodAnswer = rashodAnswer;
            PowerAnswerGES = powerAnswerGES;
            LevelUpperBief = levelUpperBief;
        }
    }
}
