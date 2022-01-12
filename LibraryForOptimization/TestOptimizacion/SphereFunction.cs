using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestOptimizacion
{

    class SphereFunction : LibOptimization.Optimization.absObjectiveFunction
    {
        public SphereFunction()
        {
        }

        /// <summary>
        /// design objective function
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public override double F(List<double> x)
        {
            var ret = 0.0;
            var dim = this.NumberOfVariable(); //or x.Count
            for (int i = 0; i < dim; i++)
            {
                ret += (x[i] * x[i])  ;// x^2
            }
            return ret;
        }

        /// <summary>
        /// Gradient of the objective function
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public override List<double> Gradient(List<double> x)
        {
            //If you use the gradient method or Newton method, implement the derivative of the objective function. otherwise, return null.
            return null;
        }


        /// <summary>
        /// Hessian matrix of the objective function
        /// </summary>
        /// <param name="aa"></param>
        /// <returns></returns>
        public override List<List<double>> Hessian(List<double> x)
        {
            //If you use the Newton method, implement the derivative of the objective function. otherwise, return null.
            return null;
        }


        /// <summary>
        /// The number of dimensions of the objective function
        /// </summary>
        /// <returns></returns>
        public override int NumberOfVariable()
        {
            return 1;
        }
    }
}
