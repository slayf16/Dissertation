using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryForOptimization.Excel.structureForExcel
{
    public class StationInfo
    {
        public string Name { get; set;}


        public List<StructureDataLimitGes> Limits { get; set; }
    }
}
