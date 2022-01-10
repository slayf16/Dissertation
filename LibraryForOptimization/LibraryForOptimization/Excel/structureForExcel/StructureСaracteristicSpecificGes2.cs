using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryForOptimization.Excel.structureForExcel
{
    /// <summary>
    /// 
    /// </summary>
    public class StructureСaracteristicSpecificGes2: StructureСaracteristicSpecificGes
    {
        /// <summary>
        /// Дополнительная зависимая переменная (только для 
        /// характеристики удельного расхода), в остальных случаях NULL
        /// </summary>
        public double DependentVariable3 { get; set; }

        /// <summary>
        /// Дополнительная зависимая переменная (только для 
        /// характеристики удельного расхода), в остальных случаях NULL
        /// </summary>
        public double DependentVariable4 { get; set; }                
    }
}
