using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Firm_Register.Models
{
    public class Females
    {
        [Key]
        public int Female_Id { get; set; }
        public string Female_Name { get; set; }
    }
}
