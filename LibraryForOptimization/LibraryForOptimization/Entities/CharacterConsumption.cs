using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryForOptimization.Entities
{
    [Table("ХарактеристикаГЭСРасход")]
    public class CharacterConsumption
    {

        [Column("id")]
        public int Id { get; set; }

        [Column("id_ГЭС")]
        public int IdGes { get; set; }

        [Column("УровеньНБ")]
        public double LevelWater { get; set; }

        [Column("Расход")]
        public double ConsumptionWater { get; set; }
    }
}
