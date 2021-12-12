using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryForOptimization
{
    public class StructureСaracteristicGes
    {
        /// <summary>
        /// зависимая переменная характеристики
        /// </summary>
        double DependentVariable { get; set; }


        /// <summary>
        /// независимая переменная характеристики
        /// </summary>
        double IndependentVariable { get; set; }


        /// <summary>
        /// Дополнительная зависимая переменная (только для 
        /// характеристики удельного расхода), в остальных случаях NULL
        /// </summary>
        double DependentVariable2 { get; set; }
    }
}
