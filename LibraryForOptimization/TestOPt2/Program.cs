using LibraryForOptimization.ObjectiveFunction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TestOPt2
{
    class Program
    {
        static void Main(string[] args)
        {
           // string way222 = "C:/Users/AMK29/Desktop/Файлы тесты для диплома/Новая папка/wz";
           // string way225 = "C:/Users/AMK29/Desktop/Файлы тесты для диплома/Новая папка/расход";
           // string way333 = "C:/Users/AMK29/Desktop/Файлы тесты для диплома/Новая папка/уд";
           // //изменил в целевой функции конструктор
           // var ff = new FunctionEnergy(way222, way225, way333);

           // ff.Init(520.0, 324.0, 244.0);

           // var startPosition = new double[] { 2100, 2109, 2230 };

           // /// задавать в интерфейсе
           // var lowerBound = new double[] { 0, 700, 1740 };
           // var upperBound = new double[] { 12000, 13000, 19000 };
           // var swarm = new ParticleSwarm(50, lowerBound, upperBound, startPosition, p =>
           //{
           //    var pList = new List<double>(p);
           //    return ff.Calculate(pList);
           //});
           // var max = 0.0;
           // swarm.Step(1000, i =>
           // {
           //     Console.WriteLine($"{i}; {swarm.BestFitness}; {swarm.BestPosition[0]}");
           //     //max = Math.Max(max, swarm.BestFitness);

           //     return Console.KeyAvailable;
           // });
           // //Console.WriteLine(max);
           // Console.ReadKey();
        }
    }
}
