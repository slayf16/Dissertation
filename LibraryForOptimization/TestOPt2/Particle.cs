using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestOPt2
{
    /// <summary>
    /// модель частицы
    /// </summary>
    public class Particle
    {

        /// <summary>
        /// вектор аргумента
        /// </summary>
        public double[] position;

        /// <summary>
        /// вектор скоростей
        /// </summary>
        public double[] velocity;

        /// <summary>
        /// вектор аргумента для лучшей локальной позиции
        /// </summary>
        public double[] bestPosition;

        /// <summary>
        /// текущая позиция
        /// </summary>
        public double fitness;

        /// <summary>
        /// лучшая позиция
        /// </summary>
        public double bestFitness;

        /// <summary>
        /// конструктор класса
        /// </summary>
        /// <param name="numDimensions">количество аргументов в векторе (размерность функции)</param>
        public Particle(int numDimensions)
        {
            position = new double[numDimensions];
            velocity = new double[numDimensions];
            bestPosition = new double[numDimensions];
            bestFitness = fitness = double.MinValue;
        }
    }
}
