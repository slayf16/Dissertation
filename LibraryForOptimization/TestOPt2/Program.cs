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
            var lowerBound = new double[] { -100 };
            var upperBound = new double[] { 100 };
            var swarm = new ParticleSwarm(1, lowerBound, upperBound, p =>
            {
                return - p[0]*p[0] +10 ;
            });

            swarm.Step(2000, i => {
                Console.WriteLine($"{i}; {swarm.BestFitness}; {swarm.BestPosition[0]}");
                return Console.KeyAvailable;
            });
            Console.ReadKey();
        }
    }
}
