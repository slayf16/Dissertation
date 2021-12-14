using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryForOptimization.Entities
{
    [Table("ХарактеристикаГЭСОбъем")]
    public class CharacterVolume
    {

        [Column("id")]
        public int Id { get; set; }

        [Column("id_ГЭС")]
        public int IdGes { get; set; }

        [Column("УровеньВБ")]
        public double LevelWater { get; set; }

        [Column("ОбъемВБ")]
        public double VolumeWater { get; set; }
    }


}
}
