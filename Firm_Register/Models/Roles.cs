using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Firm_Register.Models
{
    public class Roles
    {
        [Key]
        public int Role_Id { get; set; }
        public string Role_Name { get; set; }
    }
}
