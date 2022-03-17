using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Firm_Register.Models
{
    public class Firms
    {
        [Key]
        public int Firm_ID { get; set; }
        public string EIK { get; set; }
        public string Firm_Name { get; set; }
        [Display(Name = "Region")]
        public virtual int Region_Id { get; set; }
        [ForeignKey("Region_Id")]
        public virtual Regions Region { get; set; }
        public DateTime Found_Date { get; set; }
        public string Address { get; set; }
        public int Capital { get; set; }
        public string Info { get; set; }
    }
}
