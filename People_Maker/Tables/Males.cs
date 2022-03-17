using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Firm_Register.Data
{
    public class Males
    {
        [Key]
        public int Male_Id { get; set; }
        public string Male_Name { get; set; }
    }
}
