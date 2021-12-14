using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeOpenXml;




namespace LibraryForOptimization
{ 
    /// <summary>
    /// 
    /// </summary>
    public class WorkWithExcel
    {


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
                        var obj = new StructureDataLimitGes()
                        {
                            Period = (sheet.Cells[i, 1].Value ?? "").ToString(),
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



        private static List<StructureСaracteristicGes> GetListСaracter(ExcelWorksheet sheet)
        {
            List<StructureСaracteristicGes> list = new List<StructureСaracteristicGes>();
            for (int i = 1; i < sheet.Dimension.Rows; i++)
            {
                var obj = new StructureСaracteristicGes()
                {
                    DependentVariable = Convert.ToDouble(sheet.Cells[i, 1].Value),
                    IndependentVariable = Convert.ToDouble(sheet.Cells[i, 2].Value)
                };
                list.Add(obj);
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
