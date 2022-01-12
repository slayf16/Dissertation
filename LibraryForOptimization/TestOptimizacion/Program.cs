using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibOptimization.Optimization;
using LibOptimization;


namespace TestOptimizacion
{
    class Program
    {
        static void Main(string[] args)
        {
            var func = new SphereFunction();

            //Set objective function to optimizeclass
            var opt = new LibOptimization.Optimization.clsOptPSO(func);

           
           
            opt.InitialValueRangeLower = 10;
            opt.InitialValueRangeUpper = 1000;
            //Initialize(generate initial value)
            opt.Init();

            //Reset iteration
           // opt.Iteration = 2000;
            opt.DoIteration(5000000);

            //Get result
            var result = opt.Result;

            //output console
            Console.WriteLine("Eval : {0}", result.Eval);
            for (int i = 0; i < result.Count; i++)
            {
                Console.WriteLine("{0}", result[i]);
            }
            
            Console.ReadKey();
        }
    }
}
