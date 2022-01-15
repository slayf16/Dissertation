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
            string way222 = "C:/Users/AMK29/Desktop/Файлы тесты для диплома/Новая папка/wz";
            string way225 = "C:/Users/AMK29/Desktop/Файлы тесты для диплома/Новая папка/расход";
            string way333 = "C:/Users/AMK29/Desktop/Файлы тесты для диплома/Новая папка/уд";
            var ff = new FunctionEnergy(way222, way225, way333);

            ff.Init(520.0, 324.0, 244.0);
            var pizda = new List<double>() { 2100, 2109, 2230 };
            var xer = ff.Calculate(pizda);

            var lowerBound = new double[] { 1000,1000,1000 };
            var upperBound = new double[] { 10000, 10000, 10000 };
            var swarm = new ParticleSwarm(1000, lowerBound, upperBound, p =>
            {
                var pList = new List<double>(p);
                return ff.Calculate(pList);
            });

            swarm.Step(2000, i => {
                Console.WriteLine($"{i}; {swarm.BestFitness}; {swarm.BestPosition[0]}");
                return Console.KeyAvailable;
            });
            Console.ReadKey();
        }
    }
}
