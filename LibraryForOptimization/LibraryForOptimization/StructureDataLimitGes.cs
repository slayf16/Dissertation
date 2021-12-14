using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryForOptimization
{
    public class StructureDataLimitGes 
    {
        /// <summary>
        /// Период действия ограничения 
        /// </summary>
        public string Period { get; set; }

        /// <summary>
        /// Название ограничения (мощность, расход и т.д.)
        /// </summary>
        public string NameLimitation { get; set; }

        /// <summary>
        /// вид ограничения (больше/меньше)
        /// </summary>
        public bool RestrictionType { get; set; }

        /// <summary>
        /// Значение ограничения
        /// </summary>
        public double NumericalValue { get; set; }

        /// <summary>
        /// 
        /// </summary>
        ///public string Namestation { get; set; }
    }
}
