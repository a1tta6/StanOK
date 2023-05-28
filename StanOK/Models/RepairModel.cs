using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StanOK.Models
{
    [Table("repair", Schema = "public")]

    public class RepairModel
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("machine_type")]
        public int MachineType { get; set; }

        [Column("repair_type")]
        public int RepairType { get; set; }

        [Column("date_begin")]
        public DateTime DateBegin { get; set; }

        [Column("comment")]
        public string Comment { get; set; }

        [ForeignKey("MachineType")]
        public MachineModel Machine { get; set; }

        [ForeignKey("RepairType")]
        public RepairTypeModel Repair { get; set; }

    }
}
