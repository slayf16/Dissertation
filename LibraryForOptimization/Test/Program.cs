using LibraryForOptimization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;


namespace Test
{
    public class Program
    {
        static void Main(string[] args)
        {
            //var context = new StationContext();
            //var data = context.Stations.ToList();

            //var station = new Station()
            //{ 
            //    Id = 10,
            //    Name = "Name"
            //};
            //context.Stations.Add(station);
            //context.SaveChanges();

            
            string way = "C:/Users/AMK29/Desktop/Файлы тесты для диплома";
            string[] path = Directory.GetFiles(way);
            List<StructureDataLimitGes> d = WorkWithExcel.InputStructLimit(path[0]);
            List<StructureСaracteristicGes> KGESrashod = WorkWithExcel.InputStructCharacter(path[1]);
            List<StructureСaracteristicGes> MGESud = WorkWithExcel.InputStructCharacter(path[2]);
            List<StructureСaracteristicGes> SHGESrashod = WorkWithExcel.InputStructCharacter(path[3]);

            //обработка заданного значения
            double Qt = 0;
            double Qxsbi = 0;
            double Qxx = 0;
            double Qnb = 0;
            double Qtmax = 0;

            if(Qt!=0 | Qxsbi!=0 | Qxx!=0 )
            {
                Qnb = Qt + Qxsbi + Qxx;
            }
            else
            {
                if(Qnb != 0)
                {
                    if(Qnb-Qxx>Qtmax)
                    {
                        Qt = Qtmax;
                        Qxsbi = Qnb - Qxx - Qt;
                    }
                    else
                    {
                        Qt = Qnb - Qxx;
                        Qxsbi = 0;
                    }
                }
            }

            // надо у лехи попросить обработку от аномалий входных характеристик 

            //обработка интервала 



            Console.WriteLine("введите Q");


            Console.WriteLine("все");
            Console.ReadKey();
        }          
    }
}
