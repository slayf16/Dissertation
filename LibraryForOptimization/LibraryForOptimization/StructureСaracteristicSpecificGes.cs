using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryForOptimization
{
    class StructureСaracteristicSpecificGes : StructureСaracteristicGes
    {
        /// <summary>
        /// Дополнительная зависимая переменная (только для 
        /// характеристики удельного расхода), в остальных случаях NULL
        /// </summary>
        public double DependentVariable2 { get; set; }
    }
}
