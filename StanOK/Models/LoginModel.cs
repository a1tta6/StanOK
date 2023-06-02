using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StanOK.Authorization.Model
{
    [Table("users", Schema = "public")]
    public class LoginModel
    {
        [Key]
        [Column("login")]
        public string Login 
        { 
            get; 
            set; 
        }
        [Column("password")]
        public string Password 
        { 
            get; 
            set; 
        }
        [Column("Role")]
        public string Role { get; set; }
    }
}
