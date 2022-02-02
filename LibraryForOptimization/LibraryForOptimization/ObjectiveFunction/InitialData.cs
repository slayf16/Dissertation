using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace LibraryForOptimization.ObjectiveFunction
{
    
    /// <summary>
    /// Структура исходных данных в таблице главной формы
    /// </summary>
    public class InitialData
    {

        public string _gesName;

        /// <summary>
        /// Название ГЭС
        /// </summary>
        public string GesName// { get; set; }
        {
            get
            {
                return _gesName;
            }
            set
            {
                Regex regex = new Regex("[Aa-Яя]");
                if (regex.IsMatch(value))
                {
                    _gesName = value;
                }
                else
                {
                    throw new Exception("должен быть текст ");
                }
            }
        }

        /// <summary>
        /// Расход воды в нижний бьеф на Январь
        /// </summary>
        public double WaterConsumptionNB { get; set; }
        
            //get 
            //{
            //    return WaterConsumptionNB;
            //}
            //set
            //{
            //    if(value>=0)
            //    {
            //        WaterConsumptionNB = value;
            //    }
            //    else
            //    {
            //        throw new Exception("значение должно быть больше нуля ");
            //    }
            //}
        

        /// <summary>
        /// уровень воды в водохранилище на начало расчетного периода
        /// </summary>
        public double LevelVB { get; set; }

        /// <summary>
        /// Номер ГЭС внутри каскада
        /// </summary>
        public int GesId { get; set; }
    }
}
