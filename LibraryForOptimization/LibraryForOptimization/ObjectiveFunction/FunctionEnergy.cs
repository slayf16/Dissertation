using LibraryForOptimization.Excel.structureForExcel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryForOptimization.ObjectiveFunction
{
    public class FunctionEnergy
    {
        /// <summary>
        /// вектор ответов по расходу
        /// </summary>
        public double[] RashodAnswer { get; private set; }
        /// <summary>
        /// поле для записи полных притоков к гидростанциям (которые ща ниже находятся)
        /// </summary>
        private List<double[]> SupplysWater = new List<double[]>();



        private double[] pritokKges = new double[] { 313, 268, 269, 1118, 3954, 3730,
                1752, 1485, 1310, 1095, 624, 369 };
        private double[] pritokSHges = new double[] { 408, 368, 364, 695, 2902, 3944,
                2930, 2567, 1969, 1253, 604, 452 };
        private double[] pritokMges = new double[] { 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0 };



        private double W0;

        private double W0M;

        private double W0K;

        private List<StructureСaracteristicGes> kgesWZ;
        private List<StructureСaracteristicGes> mgesWZ;
        private List<StructureСaracteristicGes> shgesWz;

        private double ZvbSh0 = 520.0;
        private double ZvbM0 = 324.0;
        private double ZvbK0 = 244.0;


        private List<StructureСaracteristicGes> kgesRashod;
        private List<StructureСaracteristicGes> mgesRashod;
        private List<StructureСaracteristicGes> shgesRashod;


        private List<StructureСaracteristicGes> kgesUd;
        private List<StructureСaracteristicGes> mgesUd;
        private List<StructureСaracteristicGes> shgesUd;
        //public FunctionEnergy(string way222, string way225, string way333)
        public FunctionEnergy(List<string[]> path)
        {


            //List<string[]> path = new List<string[]>();

            //path.Add(Directory.GetFiles(way222));
            //path.Add(Directory.GetFiles(way225));
            //path.Add(Directory.GetFiles(way333));

            kgesWZ = WorkWithExcelImport.InputStructCharacter(path[0][0]);
            mgesWZ = WorkWithExcelImport.InputStructCharacter(path[0][1]);
            shgesWz = WorkWithExcelImport.InputStructCharacter(path[0][2]);

            kgesRashod = WorkWithExcelImport.InputStructCharacter(path[1][0]);//Q-independent
            mgesRashod = WorkWithExcelImport.InputStructCharacter(path[1][1]);//Q-independent
            shgesRashod = WorkWithExcelImport.InputStructCharacter(path[1][2]);

            kgesUd = WorkWithExcelImport.InputStructCharacter(path[2][0]);
            mgesUd = WorkWithExcelImport.InputStructCharacter(path[2][1]);
            shgesUd = WorkWithExcelImport.InputStructCharacter(path[2][2]);           

            //начальный приток из листа для соответствующего месяца 
            var QprSh = pritokSHges[0];

            // обработка начального уровня воды в верхнем бьефе
            var dependentVariblesShges = shgesWz.Select(x => x.DependentVariable).ToList();            
            var Z1 = shgesWz[poiskNaib1Universal(dependentVariblesShges, ZvbSh0)];
            var Z2 = shgesWz[poiskNaimUniversal1(dependentVariblesShges, ZvbSh0)];

            var dependentVariblesmgesWZ = mgesWZ.Select(x => x.DependentVariable).ToList();         
            var Z1M = mgesWZ[poiskNaib1Universal(dependentVariblesmgesWZ, ZvbM0)];
            var Z2M = mgesWZ[poiskNaimUniversal1(dependentVariblesmgesWZ, ZvbM0)];

            var dependentVaribleskgesWZ = kgesWZ.Select(x => x.DependentVariable).ToList();
            var Z1K = kgesWZ[poiskNaib1Universal(dependentVaribleskgesWZ, ZvbK0)];       
            var Z2K = kgesWZ[poiskNaimUniversal1(dependentVaribleskgesWZ, ZvbK0)];

            W0 = Z1.IndependentVariable - (Z1.DependentVariable - ZvbSh0) *
                (Z1.IndependentVariable - Z2.IndependentVariable) / (Z1.DependentVariable - Z2.IndependentVariable);

            W0M = Z1M.IndependentVariable - (Z1M.DependentVariable - ZvbM0) *
                (Z1M.IndependentVariable - Z2M.IndependentVariable) / (Z1M.DependentVariable - Z2M.IndependentVariable);

            W0K = Z1K.IndependentVariable - (Z1K.DependentVariable - ZvbK0) *
                (Z1K.IndependentVariable - Z2K.IndependentVariable) / (Z1K.DependentVariable - Z2K.IndependentVariable);

        }

        public void Init(double ZvbSh0, double ZvbM0, double ZvbK0)
        {
            this.ZvbSh0 = ZvbSh0;
            this.ZvbM0 = ZvbM0;
            this.ZvbK0 = ZvbK0;

        }

        public double Calculate(List<double> vars)
        {

            //ОБРАБОТКА ИНТЕРВАЛА 

            const double t = 2678400; // секунд в месяце

            //РАСЧЕТ ПРИРАЩЕНИЯ ОБЪЕМА
            double dVSh = PrirostObyom(t, 0, 0, vars, pritokSHges, 0);
            double dVm = PrirostObyom(t, 1, 0, vars, pritokMges, vars[0]);
            double dVk = PrirostObyom(t, 2, 0, vars, pritokKges, vars[1]);


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
            array1[2] = poiskNab(shges20, vars[0], false);//Q1stroka
            array1[3] = poiskNam(shges20, vars[0], false);//Q2

            var zq1 = shges20[array1[2], array1[0]] - (shges20[0, array1[0]] - Zvbsrges) *
                (shges20[array1[2], array1[0]] - shges20[array1[2], array1[1]]) / (shges20[0, array1[0]] - shges20[0, array1[1]]);

            var zq2 = shges20[array1[3], array1[0]] - (shges20[0, array1[0]] - Zvbsrges) *
                (shges20[array1[3], array1[0]] - shges20[array1[3], array1[1]]) / (shges20[0, array1[0]] - shges20[0, array1[1]]);



            var ZnbiSH = zq1 - (shges20[array1[2], 0] - vars[0]) * (zq1 - zq2) / (shges20[array1[2], 0] - shges20[array1[3], 0]);
            var ZnbM = downBiyef(mgesRashod, vars, 1);
            var ZnbK = downBiyef(kgesRashod, vars, 2);

            //расчет напора
            var Zvb_srSH = (ZvbSh0 + ZVBendSH) / 2;
            var Hsh = (Zvb_srSH - ZnbiSH);

            var Zvb_srM = (ZvbM0 + ZVBendM) / 2;
            var Hm = Zvb_srM - ZnbM;

            var Zvb_srK = (ZvbK0 + ZVBendK) / 2;
            var Hk = Zvb_srK - ZnbK;




            // определение удельного расхода 

            var dependentVariblesShgesUd = shgesUd.Select(x => x.DependentVariable).ToList();         
            var q1sh = shgesUd[poiskNaib1Universal(dependentVariblesShgesUd, Hsh)];
            var q1sh1 = q1sh as StructureСaracteristicSpecificGes;    
            var q2sh = shgesUd[poiskNaimUniversal1(dependentVariblesShgesUd, Hsh)]; ;
            var q2sh2 = q2sh as StructureСaracteristicSpecificGes;
            var qudSH = q1sh1.DependentVariable2 - (q1sh1.DependentVariable - Hsh) *
                (q1sh1.DependentVariable2 - q2sh2.DependentVariable2) / (q1sh1.DependentVariable - q2sh2.DependentVariable);


            var dependentVariblesMgesUd = mgesUd.Select(x => x.DependentVariable).ToList();
            var q1M = mgesUd[poiskNaib1Universal(dependentVariblesMgesUd, Hm)];
            var q1M1 = q1M as StructureСaracteristicSpecificGes;
            var q2M = mgesUd[poiskNaimUniversal1(dependentVariblesMgesUd, Hm)]; ;
            var q2M2 = q2M as StructureСaracteristicSpecificGes;
            var qudM = q1M1.DependentVariable2 - (q1M1.DependentVariable - Hm) *
                (q1M1.DependentVariable2 - q2M2.DependentVariable2) / (q1M1.DependentVariable - q2M2.DependentVariable);


            var dependentVariblesKgesUd = kgesUd.Select(x => x.DependentVariable).ToList();//
            var q1K = kgesUd[poiskNaib1Universal(dependentVariblesKgesUd, Hk)];//
            var q1K1 = q1K as StructureСaracteristicSpecificGes;//
            var q2K = kgesUd[poiskNaimUniversal1(dependentVariblesKgesUd, Hk)]; //
            var q2K2 = q2K as StructureСaracteristicSpecificGes;
            var qudK = q1K1.DependentVariable2 - (q1K1.DependentVariable - Hk) *
                (q1K1.DependentVariable2 - q2K2.DependentVariable2) / (q1K1.DependentVariable - q2K2.DependentVariable);

            // расчет средней мощности и расчет выработки электроэнергии

            var Psh = vars[0] / qudSH;
            var Pm = vars[1] / qudM;
            var Pk = vars[2] / qudK;
            
            const double time = t / (3600 * 1000);

            double Esh;
            double Em;
            double Ek;


            //TODO: условия вводится вручную 
            Esh = getEnergy(Psh, 5250.0, time);
            Esh = getCorrectEnergy(Esh, 500, 540, Zvb_srSH);

            Em = getEnergy(Pm, 321, time);
            Em = getCorrectEnergy(Em, 319, 326.5, Zvb_srM);

            Ek = getEnergy(Pk, 6000, time);
            Ek = getCorrectEnergy(Ek, 225, 244.5, Zvb_srK);

            RashodAnswer = vars.ToArray(); 

            var E = Esh + Em + Ek;
            return E;
        }

        /// <summary>
        /// штрафная функция за нарушение границ установленной мощности электростанции
        /// </summary>
        /// <param name="P">фактическая мощность</param>
        /// <param name="limit">установленная мощность</param>
        /// <param name="time">время рассчетного периода</param>
        /// <returns>величина энергии с учетом ограничения</returns>
        private double getEnergy(double P, double limit, double time)
        {
            double energy;
            if (P > limit)
            {
                energy = (limit - (P - limit) * 5) * time;
            }
            else
            {
                energy = P * time;
            }
            return energy;
        }

        /// <summary>
        /// штрафная функция за нарушения границ уровня воды в водохранилище
        /// </summary>
        /// <param name="energy">значение энергии</param>
        /// <param name="limitLeft">уровень мертвого объема (минимальная граница)</param>
        /// <param name="limitRight">форсированный подпорный уровень (максимальная граница)</param>
        /// <param name="upperBiefLevel">фактическая величина</param>
        /// <returns>энергию электростанции за расчетный период</returns>
        private double getCorrectEnergy(double energy, double limitLeft, double limitRight, double upperBiefLevel)
        {
            var result = energy;

            if (upperBiefLevel >= limitRight)
            {
                result -= (upperBiefLevel - limitRight) * (upperBiefLevel - limitRight) * (int)1e4;
            }

            if (upperBiefLevel <= limitLeft)
            {
                result -= (-upperBiefLevel + limitLeft) * (-upperBiefLevel + limitLeft) * (int)1e4;
            }

            return result;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="array"></param>
        /// <param name="a"></param>
        /// <param name="varible"></param>
        /// <returns></returns>
        private int poiskNab(double[,] array, double a, bool varible)
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
        private int poiskNam(double[,] array, double a, bool varible)
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
        /// Расчет приращения объема
        /// </summary>
        /// <param name="t">расчетный интервал</param>
        /// <param name="indexGes">индекс гэс в каскаде (начиная с 0)</param>
        /// <param name="indexCalc">индекс расчета</param>
        /// <param name="rashod">массив переменных рачхода в НБ</param>
        /// <param name="pritok">массив бокового притока</param>
        /// <param name="pritokOtGes">приток от вышележащей гэс(для 0ых гэс равен 0)</param>
        /// <returns>приращение объема</returns>
        private double PrirostObyom(double t, int indexGes, 
            int indexCalc, List<double> rashod, double[] pritok, double pritokOtGes)
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
        private double lavelVBOnEndInterval(double W, double dV, List<StructureСaracteristicGes> mass)
        {
            double Wend = W + dV;

            var ind1 = poiskNaib1Universal(mass.Select(x => x.IndependentVariable).ToList(), Wend);
            var W1 = mass[ind1];

            var ind2 = poiskNaimUniversal1(mass.Select(x => x.IndependentVariable).ToList(), Wend);
            var W2 = mass[ind2];

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


        private int poiskNaib1Universal(List<double> mass, double chislo)
        {

            int j = 0;
            var res = double.MaxValue;
            for (int i = 0; i < mass.Count; i++)
            {
                var diff = mass[i] - chislo;

                if (diff >= 0)
                {
                    if (res > diff)
                    {
                        j = i;
                        res = diff;
                    }

                }
            }
            return j;
        }


        private int poiskNaimUniversal1(List<double> mass, double chislo)
        {
            int j = 0;
            var res = double.MaxValue;
            for (int i = 0; i < mass.Count; i++)
            {
                var diff = chislo - mass[i];

                if (diff >= 0)
                {
                    if (res > diff)
                    {
                        j = i;
                        res = diff;
                    }
                }
            }
            return j;
        }


        private double downBiyef(List<StructureСaracteristicGes> mass, List<double> Qnb, int gesNumber)
        {

            var indexQ1 = poiskNaib1Universal(mass.Select(x => x.IndependentVariable).ToList(), Qnb[gesNumber]);
            var indexQ2 = poiskNaimUniversal1(mass.Select(x => x.IndependentVariable).ToList(), Qnb[gesNumber]);
            var Z1 = mass[indexQ1].DependentVariable;
            var Z2 = mass[indexQ2].DependentVariable;
            var Q1 = mass[indexQ1].IndependentVariable;
            var Q2 = mass[indexQ2].IndependentVariable;
            
            var Znb = Z1 - (Q1 - Qnb[gesNumber]) *
                (Z1 - Z2) / (Q1 - Q2);
            return Znb;
        }


    }



}
