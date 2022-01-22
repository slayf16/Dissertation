using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryForOptimization.ObjectiveFunction
{
    /// <summary>
    /// Структура исходных данных в таблице главной формы
    /// </summary>
    public class InitialData
    {
        /// <summary>
        /// Название ГЭС
        /// </summary>
        public string GesName { get; set; }

        /// <summary>
        /// Расход воды в нижний бьеф на Январь
        /// </summary>
        public double WaterConsumptionNB { get; set; }

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
