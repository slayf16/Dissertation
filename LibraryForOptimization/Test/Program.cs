using LibraryForOptimization;
using LibraryForOptimization.Excel.structureForExcel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Linq;
using LibraryForOptimization.ObjectiveFunction;

namespace Test
{
    public class Program
    {
        static void Main(string[] args)
        {
            
            string way222 = "C:/Users/AMK29/Desktop/Файлы тесты для диплома/Новая папка/wz";
            string way225 = "C:/Users/AMK29/Desktop/Файлы тесты для диплома/Новая папка/расход";
            string way333 = "C:/Users/AMK29/Desktop/Файлы тесты для диплома/Новая папка/уд";

            var ff = new FunctionEnergy(way222, way225, way333);

            ff.Init(520.0, 324.0, 244.0);
            var pizda = new List<double>() { 2100, 2109, 2230 };
            var xer = ff.Calculate(pizda);

            Console.WriteLine("введите Q");
            Console.WriteLine("все");
            Console.ReadKey();
        }     
    }
}
