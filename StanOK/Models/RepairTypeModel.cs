using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StanOK.Models
{
    [Table("repair_types", Schema = "public")]
    public class RepairTypeModel
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("repair_name")]
        public string Repair_name 
        { 
            get; 
            set; }
        [Column("duration")]
        public string Duration 
        { 
            get; 
            set; }
        [Column("cost")]
        public int Cost { get; set; }
        [Column("comment")]
        public string Comment { get; set; }
    }
}
