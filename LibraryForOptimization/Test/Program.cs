using LibraryForOptimization;
using LibraryForOptimization.Excel.structureForExcel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Linq;


namespace Test
{
    public class Program
    {
        static void Main(string[] args)
        {
            
            string way222 = "C:/Users/AMK29/Desktop/Файлы тесты для диплома/Новая папка/wz";
            string way225 = "C:/Users/AMK29/Desktop/Файлы тесты для диплома/Новая папка/расход";
            string way333 = "C:/Users/AMK29/Desktop/Файлы тесты для диплома/Новая папка/уд";

            List<string[]> path = new List<string[]>();

            path.Add(Directory.GetFiles(way222));
            path.Add(Directory.GetFiles(way225));
            path.Add(Directory.GetFiles(way333));
            
            var kgesWZ = WorkWithExcel.InputStructCharacter(path[0][0]);
            var mgesWZ = WorkWithExcel.InputStructCharacter(path[0][1]);
            var shgesWz = WorkWithExcel.InputStructCharacter(path[0][2]);

            var kgesRashod = WorkWithExcel.InputStructCharacter(path[1][0]);
            var mgesRashod = WorkWithExcel.InputStructCharacter(path[1][1]);
            var shgesRashod = WorkWithExcel.InputStructCharacter(path[1][2]);

            var kgesUd = WorkWithExcel.InputStructCharacter(path[2][0]);
            var mgesUd = WorkWithExcel.InputStructCharacter(path[2][1]);
            var shgesUd = WorkWithExcel.InputStructCharacter(path[2][2]);

            var pritokKges = new double[] { 313, 268, 269, 1118, 3954, 3730, 
                1752, 1485, 1310, 1095, 624, 369 };
            var pritokSHges = new double[] { 408, 368, 364, 695, 2902, 3944, 
                2930, 2567, 1969, 1253, 604, 452 };
            var pritokMges = new double[] { 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0 };

            var Qi = new double[] { 2100, 2109, 2230 };

           



            // задается в ручную , это начальный уровень воды в водохранилище            
            var ZvbSh0 = 520.0;
            var ZvbM0 = 324.0;
            var ZvbK0 = 244.0;

            //начальный приток из листа для соответствующего месяца 
            var QprSh = pritokSHges[0];

            // обработка начального уровня воды в верхнем бьефе
            var Z1 = poiskNaib(shgesWz, ZvbSh0);
            var Z2 = poiskNaim(shgesWz, ZvbSh0);
            var Z1M = poiskNaib(mgesWZ, ZvbM0);
            var Z2M = poiskNaim(mgesWZ, ZvbM0);
            var Z1K = poiskNaib(kgesWZ, ZvbK0);
            var Z2K = poiskNaim(kgesWZ, ZvbK0);

            var W0 = Z1.IndependentVariable - (Z1.DependentVariable - ZvbSh0) *
                (Z1.IndependentVariable - Z2.IndependentVariable) / (Z1.DependentVariable - Z2.IndependentVariable);

            var W0M = Z1M.IndependentVariable - (Z1M.DependentVariable - ZvbM0) *
                (Z1M.IndependentVariable - Z2M.IndependentVariable) / (Z1M.DependentVariable - Z2M.IndependentVariable);

            var W0K = Z1K.IndependentVariable - (Z1K.DependentVariable - ZvbK0) *
                (Z1K.IndependentVariable - Z2K.IndependentVariable) / (Z1K.DependentVariable - Z2K.IndependentVariable);

            //обработка заданного значения здесь начинается работа пользователя
            double Qt = 0 ;
            double Qxsbi = 0;
            double Qxx = 0;
            double Qnb = 2100;
            double Qtmax = 2200;

            if (Qt != 0 | Qxsbi != 0 | Qxx != 0)
            {
                Qnb = Qt + Qxsbi + Qxx;
            }
            else
            {
                if (Qnb != 0)
                {
                    if (Qnb - Qxx > Qtmax)
                    {
                        Qt = Qtmax;
                        Qxsbi = Qnb - Qxx - Qt;
                    }
                    else
                    {
                        // в маткаде постоянно попадаем сюда
                        Qt = Qnb - Qxx;
                        Qxsbi = 0;
                    }
                }
            }

            // надо у лехи попросить обработку от аномалий входных характеристик 

            //ОБРАБОТКА ИНТЕРВАЛА 

            const int t = 2678400; // секунд в месяце

            //РАСЧЕТ ПРИРАЩЕНИЯ ОБЪЕМА
            double dVSh = PrirostObyom(t, 0, 0, Qi, pritokSHges, 0);
            double dVm = PrirostObyom(t, 1, 0, Qi, pritokMges, Qi[0]);
            double dVk = PrirostObyom(t, 2, 0, Qi, pritokKges, Qi[1]);


            //РАСЧЕТ ВЕРХНЕГО БЬЕФА НА КОНЕЦ ИНТЕРАВАЛА (здесь должна быть проверка на уровень воды)
            double ZVBendSH = lavelVBOnEndInterval(W0, dVSh, shgesWz);
            double ZVBendM = lavelVBOnEndInterval(W0M, dVm, mgesWZ);
            double ZVBendK = lavelVBOnEndInterval(W0K, dVk, kgesWZ);

            //уровень нижнего бьефа для СШГЭС
            var Zvbsrges = (ZvbM0 + ZVBendM) / 2;
            var shges20 = new double[shgesRashod.Count, 5];
            var index = 0;
            foreach (var a in shgesRashod)
            {

               
                if (a is StructureСaracteristicSpecificGes2)
                {
                    var item = a as StructureСaracteristicSpecificGes2;
                    shges20[index, 0] = item.DependentVariable;
                    shges20[index, 1] = item.IndependentVariable;
                    shges20[index, 2] = item.DependentVariable2;
                    shges20[index, 3] = item.DependentVariable3;
                    shges20[index, 4] = item.DependentVariable4;
                    index++;
                }
            }
            var f = shges20.Length;
            var r = shges20.GetLength(1);
            var array1 = new int[4];
            array1[0] = poiskNab(shges20, Zvbsrges, true);//z1
            array1[1] = poiskNam(shges20, Zvbsrges, true);//z2
            array1[2] = poiskNab(shges20, Qnb, false);//Q1stroka
            array1[3] = poiskNam(shges20, Qnb, false);//Q2

            var zq1 = shges20[array1[2], array1[0]] - (shges20[0, array1[0]] - Zvbsrges) *
                (shges20[array1[2], array1[0]] - shges20[array1[2], array1[1]]) / (shges20[0, array1[0]] - shges20[0, array1[1]]);

            var zq2 = shges20[array1[3], array1[0]] - (shges20[0, array1[0]] - Zvbsrges) *
                (shges20[array1[3], array1[0]] - shges20[array1[3], array1[1]]) / (shges20[0, array1[0]] - shges20[0, array1[1]]);

            var ZnbiSH = zq1 - (shges20[array1[2], 0] - Qnb) * (zq1 - zq2) / (shges20[array1[2], 0] - shges20[array1[3], 0]);

            //расчет напора
            var Zvb_srSH = (ZvbSh0 + ZVBendSH) / 2;
            var Hsh = (Zvb_srSH - ZnbiSH);

            // определение удельного расхода 
            var q1sh = poiskNaib(shgesUd, Hsh);
            var q1sh1 = q1sh as StructureСaracteristicSpecificGes;
            var q2sh = poiskNaim(shgesUd, Hsh);
            var q2sh2 = q2sh as StructureСaracteristicSpecificGes;

            var qudSH = q1sh1.DependentVariable2 - (q1sh1.DependentVariable - Hsh) * 
                (q1sh1.DependentVariable2 - q2sh2.DependentVariable2) / (q1sh1.DependentVariable - q2sh2.DependentVariable);

            // расчет средней мощности и расчет выработки электроэнергии
            var Psh = Qt / qudSH;
            var E = Psh * t / (3600 * 1000);

            Console.WriteLine("введите Q");


            Console.WriteLine("все");
            Console.ReadKey();
        }

       
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="array"></param>
        /// <param name="a"></param>
        /// <param name="varible"></param>
        /// <returns></returns>
        public static int poiskNab(double[,] array, double a, bool varible)
        {
            double max = double.MaxValue;
            var mass = new List<double>();
            if(varible)
            {
                for(int i = 0; i<array.GetLength(1);i++)
                {
                    mass.Add(array[0, i]);
                }
            }
            else
            {
                for (int i = 0; i < array.GetLength(0); i++)
                {
                    mass.Add(array[i, 0]);
                }
            }

            int j = 0;
            for (int i = 0; i < mass.Count; i++)
            {
                var diff = mass[i] - a;

                if (diff >= 0)
                {
                    if (max > diff)
                    {
                        j = i;
                        max = diff;
                    }
                }
            }
            return j;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="array"></param>
        /// <param name="a"></param>
        /// <param name="varible"></param>
        /// <returns></returns>
        public static int poiskNam(double[,] array, double a, bool varible)
        {
            double max = double.MaxValue;
            var mass = new List<double>();
            if (varible)
            {
                for (int i = 0; i < array.GetLength(1); i++)
                {
                    mass.Add(array[0, i]);
                }
            }
            else
            {
                for (int i = 0; i < array.GetLength(0); i++)
                {
                    mass.Add(array[i, 0]);
                }
            }

            int j = 0;
            for (int i = 0; i < mass.Count; i++)
            {
                var diff = -mass[i] + a;

                if (diff >= 0)
                {
                    if (max > diff)
                    {
                        j = i;
                        max = diff;
                    }
                }
            }
            return j;
        }

        /// <summary>
        /// Метод для поиска ближайшего наибольшего в массивах (Z(w)) и удельного расхода
        /// </summary>
        /// <param name="mass">Массив</param>
        /// <param name="chislo">Число относительно которого происходит поиск</param>
        /// <returns>Ближайшее большее число из mass к число chislo</returns>
        public static StructureСaracteristicGes poiskNaib(List<StructureСaracteristicGes> mass, double chislo)
        {
    
            int j = 0;
            var res = double.MaxValue;
            for (int i = 0; i < mass.Count; i++)
            {
                var diff = mass[i].DependentVariable - chislo;

                if (diff>=0)
                {
                    if(res > diff)
                    {
                        j = i;
                        res = diff;
                    }
                  
                }
            }
            return mass[j];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mass"></param>
        /// <param name="chislo"></param>
        /// <returns></returns>
        public static StructureСaracteristicGes poiskNaim(List<StructureСaracteristicGes> mass, double chislo)
        {

            int j = 0;
            var res = double.MaxValue;
            for (int i = 0; i < mass.Count; i++)
            {
                var diff = chislo - mass[i].DependentVariable;

                if (diff >= 0)
                {
                    if (res > diff)
                    {
                        j = i;
                        res = diff;
                    }

                }
            }
            return mass[j];
        }

        /// <summary>
        /// Расчет приращения объема
        /// </summary>
        /// <param name="t">расчетный интервал</param>
        /// <param name="indexGes">индекс гэс в каскаде (начиная с 0)</param>
        /// <param name="indexCalc">индекс расчета</param>
        /// <param name="rashod">массив переменных рачхода в НБ</param>
        /// <param name="pritok">массив бокового притока</param>
        /// <param name="pritokOtGes">приток от вышележащей гэс(для 0ых гэс равен 0)</param>
        /// <returns>приращение объема</returns>
        public static double PrirostObyom(double t, int indexGes, 
            int indexCalc, double[] rashod, double[] pritok, double pritokOtGes)
        {
            if (indexGes==0)
            {
               double dV = (pritok[indexCalc] - rashod[indexGes]) * t / Math.Pow(10, 9);
               return dV;
            }
            else
            {
                double Qpr = (pritok[indexCalc] + pritokOtGes);
                double dV = (Qpr - rashod[indexGes]) * t / Math.Pow(10, 9);
                return dV;
            }
        }

        /// <summary>
        /// Уровень воды на конец интервала
        /// </summary>
        /// <param name="W">начальный объем W0</param>
        /// <param name="dV">изменение объема</param>
        /// <param name="mass">характеристика ГЭС (объем от уровня)</param>
        /// <returns></returns>
        public static double lavelVBOnEndInterval(double W, double dV, List<StructureСaracteristicGes> mass)
        {
            double Wend = W + dV;
            var W1 = poiskNaib1(mass, Wend);
            var W2 = poiskNaim1(mass, Wend);
            var Z = W1.DependentVariable - (W1.IndependentVariable - Wend)
                * (W1.DependentVariable - W2.DependentVariable) / (W1.IndependentVariable - W2.IndependentVariable);
            return Z;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mass"></param>
        /// <param name="chislo"></param>
        /// <returns></returns>
        public static StructureСaracteristicGes poiskNaib1(List<StructureСaracteristicGes> mass, double chislo)
        {

            int j = 0;
            var res = double.MaxValue;
            for (int i = 0; i < mass.Count; i++)
            {
                var diff = mass[i].IndependentVariable - chislo;

                if (diff >= 0)
                {
                    if (res > diff)
                    {
                        j = i;
                        res = diff;
                    }

                }
            }
            return mass[j];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mass"></param>
        /// <param name="chislo"></param>
        /// <returns></returns>
        public static StructureСaracteristicGes poiskNaim1(List<StructureСaracteristicGes> mass, double chislo)
        {
            int j = 0;
            var res = double.MaxValue;
            for (int i = 0; i < mass.Count; i++)
            {
                var diff = chislo - mass[i].IndependentVariable;

                if (diff >= 0)
                {
                    if (res > diff)
                    {
                        j = i;
                        res = diff;
                    }
                }
            }
            return mass[j];
        }
    }
}
