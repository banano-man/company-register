using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SolrNet.Utils;

namespace Firm_Register.Models
{
    public class WorkPlace
    {
        [Column(Order = 1)]
        [Display(Name = "Person")]
        public virtual int Person_Id { get; set; }
        [ForeignKey("Person_Id")]
        public virtual People Person { get; set; }
        [Column(Order = 2)]
        [Display(Name = "Firm")]
        public virtual int Firm_Id { get; set; }
        [ForeignKey("Firm_Id")]
        public virtual Firms Firm { get; set; }
        [Display(Name = "Role")]
        public virtual int Role_Id { get; set; }
        [ForeignKey("Role_Id")]
        public virtual Roles Role { get; set; }
    }
}
