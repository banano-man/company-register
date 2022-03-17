using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Firm_Register.Models
{
    public class People
    {
        [Key]
        public int Person_Id { get; set; }
        public string Person_Email { get; set; }
        public string Person_Password { get; set; }
        public string Person_First_Name { get; set; }
        public string Person_Last_Name { get; set; }
        public string Person_EGN { get; set; }
    }
}
