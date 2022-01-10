using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using LibraryForOptimization.Excel.structureForExcel;
using OfficeOpenXml;




namespace LibraryForOptimization
{ 
    /// <summary>
    /// 
    /// </summary>
    public class WorkWithExcel
    {

        //+
        /// <summary>
        /// метод для формирования массива из входящих файлов 
        /// </summary>
        /// <param name="path">путь до файла, который считываем</param>
        public static List<StructureDataLimitGes> InputStructLimit(string path)
        {
            var datas = new List<StructureDataLimitGes>();
            using (ExcelPackage package = new ExcelPackage(new FileInfo(path)))
            {
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                var sheet = package.Workbook.Worksheets["Лист1"];
                datas = GetListLimitGes(sheet);
                return datas;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static List<StructureСaracteristicGes> InputStructCharacter(string path)
        {
            var datas = new List<StructureСaracteristicGes>();
            using (ExcelPackage package = new ExcelPackage(new FileInfo(path)))
            {
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                var sheet = package.Workbook.Worksheets["Лист1"];
                datas = GetListСaracter(sheet);
                return datas;
            }
        }

        //solid: не делаю универсальные методы, потому что один метод, за один функционал 
        //+
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sheet"></param>
        /// <returns></returns>
        private static List<StructureDataLimitGes> GetListLimitGes(ExcelWorksheet sheet)
        {
            List<StructureDataLimitGes> list = new List<StructureDataLimitGes>();
            for (int i = 1; i<sheet.Dimension.Rows; i++)
            {
                if ((string)sheet.Cells[i, 4].Value == "Значение")
                {
                    i++;
                    for (; sheet.Cells[i, 4].Value != null; i++)
                    {
                        var a = Regex.Matches((string)sheet.Cells[i, 1].Value, @"\d{2}.\d{2}");                       
                        var obj = new StructureDataLimitGes()
                        {   
                            StartPeriod = Convert.ToDateTime(a[0].ToString()),
                            FinishPeriod = Convert.ToDateTime(a[1].ToString()),                            
                            NameLimitation = (sheet.Cells[i, 2].Value ?? "").ToString(),
                            RestrictionType = ValidValue.ValidRestriction((sheet.Cells[i, 3].Value ?? "").ToString()),
                            NumericalValue = Convert.ToDouble(sheet.Cells[i, 4].Value)
                        };
                        list.Add(obj);
                    }
                }                            
            }
            return list;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sheet"></param>
        /// <returns></returns>
        private static List<StructureСaracteristicGes> GetListСaracter(ExcelWorksheet sheet)
        {
            var list = new List<StructureСaracteristicGes>();
            switch (sheet.Dimension.Columns)
            {
                case 2:
                    {
                        list = new List<StructureСaracteristicGes>();
                        for (int i = 1; i <= sheet.Dimension.Rows; i++)
                        {
                            var obj = new StructureСaracteristicGes()
                            {
                                DependentVariable = Convert.ToDouble(sheet.Cells[i, 1].Value),
                                IndependentVariable = Convert.ToDouble(sheet.Cells[i, 2].Value)
                            };
                            list.Add(obj);
                        }

                        break;
                    }

                case 3:
                    {

                        for (int i = 1; i <= sheet.Dimension.Rows; i++)
                        {
                            var obj = new StructureСaracteristicSpecificGes()
                            {

                                DependentVariable = Convert.ToDouble(sheet.Cells[i, 1].Value),
                                IndependentVariable = Convert.ToDouble(sheet.Cells[i, 2].Value),
                                DependentVariable2 = Convert.ToDouble(sheet.Cells[i, 3].Value)
                            };
                            list.Add(obj);
                        }

                        break;
                    }

                case 5:
                
                    {

                        for (int i = 1; i <= sheet.Dimension.Rows; i++)
                        {
                            var obj = new StructureСaracteristicSpecificGes2()
                            {
                                DependentVariable = Convert.ToDouble(sheet.Cells[i, 1].Value),
                                IndependentVariable = Convert.ToDouble(sheet.Cells[i,2].Value),
                                DependentVariable2 = Convert.ToDouble(sheet.Cells[i, 3].Value),
                                DependentVariable3 = Convert.ToDouble(sheet.Cells[i, 4].Value),
                                DependentVariable4 = Convert.ToDouble(sheet.Cells[i, 5].Value)

                                //DependentVariable = Convert.ToDouble(sheet.Cells[i + 2, 2].Value),
                                //IndependentVariable = Convert.ToDouble(sheet.Cells[i + 2, 3].Value),
                                //DependentVariable2 = Convert.ToDouble(sheet.Cells[i + 2, 4].Value),
                                //DependentVariable3 = Convert.ToDouble(sheet.Cells[i + 2, 5].Value),
                                //DependentVariable4 = Convert.ToDouble(sheet.Cells[i + 2, 6].Value)
                            };
                            list.Add(obj);
                        }

                        break;
                    }
            }
            return list;

        }

        /// <summary>
        /// метод для формирования массива для выходящих фаайлов
        /// </summary>
        /// <param name="path">путь куда сохраняем</param>
        public void Output(string path)
        {

        }
    }
}
