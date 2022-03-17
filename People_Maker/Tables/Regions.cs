using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Firm_Register.Models
{
    public class Regions
    {
        [Key]
        public int Region_Id { get; set; }
        public string Region_Name { get; set; }
    }
}
