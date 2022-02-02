using System;
using System.Collections.Generic;
using System.Threading.Tasks;



namespace TestOPt2
{
    public class ParticleSwarm
    {
        // Particle swarm parameters. 
        public double Omega { get; set; } = 0.729;
        public double Phi_G { get; set; } = 1.49445;
        public double Phi_P { get; set; } = 1.49445;

        /// <summary>
        /// поля для вывода траекторий скоростей 
        /// </summary>
        public List<List<double[]>> ListVelosity = new List<List<double[]>>();

        /// <summary>
        /// лучшее положение 
        /// </summary>
        /// <value>The best fitness.</value>
        public double BestResult { get; private set; }

        /// <summary>
        /// лучшее значение аргумента
        /// </summary>
        /// <value>The best position.</value>
        public double[] BestPosition { get; private set; }
      
        //поле для роя 
        private Particle[] _particles;
        //поля для границ на каждую координату вектора аргумента 
        private double[] _lowerBound;
        private double[] _upperBound;

        //поле для целевой функции
        private Func<double[], double> _objectiveFunc;

        /// <summary>       
        /// Конструктор класса
        /// </summary>
        /// <param name="numParticles">количество частиц</param>
        /// <param name="lowerBound">Нижняя граница аргумента</param>
        /// <param name="upperBound">Верхняя граница аргумента</param>
        /// <param name="evalFunc">целевая функция</param>
        public ParticleSwarm(int numParticles, double[] lowerBound, double[] upperBound, double[] startPosition, Func<double[], double> evalFunc)
        {

            if (lowerBound.Length != upperBound.Length)
                throw new ArgumentException("Dimensions of lower and upper bound do not match");

            _objectiveFunc = evalFunc;
            this._lowerBound = lowerBound;
            this._upperBound = upperBound;

            //размерность функции
            var numDimensions = lowerBound.Length;

            BestResult = double.MinValue;
            BestPosition = new double[numDimensions];
            _particles = new Particle[numParticles];

            for (int i = 0; i < numParticles; i++)
            {
                var p = new Particle(numDimensions);

                for (int j = 0; j < numDimensions; j++)
                {
                    var diff = upperBound[j] - lowerBound[j];
                    p.position[j] = nextDoubleInRange(lowerBound[j], upperBound[j]);
                    
                    //случайная скорсть 
                    p.velocity[j] = nextDoubleInRange(-diff, +diff);
                }

               // p.position = startPosition;
                _particles[i] = p;
             
            }
            
        }

        /// <summary>
        /// вычисление значений координат аргумента 
        /// </summary>
        /// <param name="min">минимальное значение границ</param>
        /// <param name="max">максимальное значение границ</param>
        /// <returns></returns>
        private double nextDoubleInRange(double min, double max)
        {
            return RandomMath.RandomMath.GetRandomValueReal() * (max - min) + min;
        }

        /// <summary>
        /// метод для вычисления шага
        /// </summary>
        /// <param name="count">максимальное количество итераций.</param>
        /// <param name="stepFunc">ступенчатая функция. Принимает текущий счетчик итераций и возвращает True,
        /// когда пошаговое выполнение должно быть прервано</param>
        public void Step(int count, Func<int, bool> stepFunc)
        {

            for (int i = 0; i < 3; i++)
            {
                ListVelosity.Add(new List<double[]>());                
            }
            for (int l = 0; l < count; l++)
            {
                for (int i = 0; i < 3; i++)
                {
                    ListVelosity[i].Add(_particles[i].velocity);
                }
                Parallel.For(0, _particles.Length, i =>
                {
                    evaluateParticle(_particles[i]);
                    moveParticle(_particles[i]);
                });

                if (stepFunc(l))
                    break;
            }

        }

        /// <summary>
        /// метод для проверки и записи лучшей позиции
        /// </summary>
        /// <param name="p">частица</param>
        private void evaluateParticle(Particle p)
        {
            p.fitness = _objectiveFunc(p.position);

            if (p.fitness > p.bestFitness)
            {
                p.bestFitness = p.fitness;
                Array.Copy(p.position, p.bestPosition, p.position.Length);

                lock (this)
                {
                    if (p.bestFitness > BestResult)
                    {
                        BestResult = p.bestFitness;
                        Array.Copy(p.bestPosition, BestPosition, p.bestPosition.Length);
                    }
                }
            }
        }

        /// <summary>
        /// метод для мычисления нового положения частицы
        /// </summary>
        /// <param name="p">частица</param>
        private void moveParticle(Particle p)
        {
            for (int i = 0; i < p.position.Length; i++)
            {


                var rp = RandomMath.RandomMath.GetRandomValueReal();
                var rg = RandomMath.RandomMath.GetRandomValueReal();

                p.velocity[i] = Omega * p.velocity[i]
                    + Phi_P * rp * (p.bestPosition[i] - p.position[i])
                    + Phi_G * rg * (BestPosition[i] - p.position[i]);

                p.position[i] += p.velocity[i];

                if (p.position[i] > _upperBound[i])
                    p.position[i] = _upperBound[i];
                if (p.position[i] < _lowerBound[i])
                    p.position[i] = _lowerBound[i];
            }
        }

    }
}