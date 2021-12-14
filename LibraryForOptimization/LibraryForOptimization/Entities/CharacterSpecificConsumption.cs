using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryForOptimization.Entities
{
    [Table("ХарктеристикаГэсУдРасход")]
    public class CharacterSpecificConsumption
    {

        [Column("id")]
        public int Id { get; set; }

        [Column("id_ГЭС")]
        public int IdGes { get; set; }

        [Column("Напор")]
        public double WaterHead { get; set; }

        [Column("Мощность")]
        public double Power { get; set; }

        [Column("Удельный Расход")]
        public double SpecificConsumption { get; set; }


    }
}
