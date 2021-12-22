using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryForOptimization.Entities
{
    [Table("ГЭС")]
    public class Station
    {
        [Column("id_ГЭС")]
        public int Id { get; set; }

        [Column("Название ГЭС")]
        public string Name { get; set; }

        // вопросик разрешает значению быть Null
        [Column("id_Каскад")]
        public int? CascadeId { get; set; }

        //TODO: разрешить NULL
        public Cascade Cascade { get; set; }

        public LimitStation LimitStation { get; set; }
    }

}
