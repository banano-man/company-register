using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Firm_Register.Models
{
    public class Family
    {
        [Key]
        public int Family_Id { get; set; }
        public string Family_Name { get; set; }
    }
}
