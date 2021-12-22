using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryForOptimization
{
    /// <summary>
    /// 
    /// </summary>
    public class ValidValue
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static bool ValidRestriction(string text)
        {
            bool restriction = true;
            if (text == "<=")
            {
                restriction = false;
            }
            return restriction;
        }

        public static bool ValidNum(int num)
        {
            if(num>0)
            {
                return true;
            }
            else
            {
                throw new Exception("в файле присутствуют " +
                    "отрицательные величины, проверьте входной файл");
            }                     
        }
    }
}
