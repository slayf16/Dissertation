using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryForOptimization.Excel.structureForExcel
{
    public class StationLimitModel
    {
        public string GesName { get; set;  }


        public string PeriodStart { get; set; }

        public string PeriodFinish { get; set; }

        /// <summary>
        /// Название ограничения (мощность, расход и т.д.)
        /// </summary>
        public string LimitName { get; set; }

        /// <summary>
        /// вид ограничения (больше/меньше)
        /// </summary>
        public string LimitType { get; set; }

        /// <summary>
        /// Значение ограничения
        /// </summary>
        public double LimitValue { get; set; }
    }
}
