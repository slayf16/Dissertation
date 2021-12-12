using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryForOptimization
{
    public class ValidValue
    {
        public static bool ValidRestriction(string text)
        {
            bool restriction = true;
            if (text == "<=")
            {
                restriction = false;
            }
            return restriction;
        }
    }
}
