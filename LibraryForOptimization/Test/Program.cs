using LibraryForOptimization;
using LibraryForOptimization.Entities;
using LibraryForOptimization.Repository;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class Program
    {
        static void Main(string[] args)
        {
            var context = new StationContext();
            var data = context.Stations.ToList();

            var station = new Station()
            { 
                Id = 10,
                Name = "Name"
            };
            context.Stations.Add(station);
            context.SaveChanges();

            data = context.Stations.ToList();
            string way = "C:/Users/AMK29/Desktop/Файлы тесты для диплома";
            string[] path = Directory.GetFiles(way);
            List<StructureDataLimitGes> d = WorkWithExcel.InputStructLimit(path[0]);
            List<StructureСaracteristicGes> d1 = WorkWithExcel.InputStructCharacter(path[1]);
            Console.WriteLine("все");
            Console.ReadKey();
        }          
    }
}
