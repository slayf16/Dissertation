using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryForOptimization.Entities
{
    [Table("Каскад")]
    public class Cascade
    {
        [Column("id_Каскад")]
        public int Id { get; set; }

        [Column("Каскад")]
        public string Name { get; set; }
    }
}
