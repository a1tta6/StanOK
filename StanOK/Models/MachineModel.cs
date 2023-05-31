using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StanOK.Models
{
    [Table("Machines", Schema = "public")]

    public class MachineModel
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("machine_type")]
        public string MachineType { get; set; }
        [Column("country")]
        public string Country { get; set; }
        [Column("brand")]
        public string Brand { get; set; }
        [Column("year")]
        public int Year { get; set; }
    }
}
