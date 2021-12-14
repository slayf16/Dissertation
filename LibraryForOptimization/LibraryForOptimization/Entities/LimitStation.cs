using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryForOptimization.Entities
{
    [Table("Ограничение")]
    public class LimitStation
    {
        [Column("id_ограничения")]
        public Int64 IdLimit { get; set; }

        [Column("id_ГЭС")]
        public int IdGes { get; set; }

        [Column("Начало периода ограничения")]
        public DateTime? StartPeriod { get; set; }

        [Column("Конец периода ограничения")]
        public DateTime? FinishPeriod { get; set; }

        [Column("Вид ограничения")]
        public bool RestrictionType { get; set; }

        [Column("Название ограничения")]
        public string RestrictionName { get; set; }

        [Column("Вид ограничения")]
        public double RestrictionValue { get; set; }
    }
}
