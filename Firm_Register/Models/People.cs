using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Firm_Register.Models
{
    public class People
    {
        [Key]
        public int Person_Id { get; set; }
        [DisplayName("Имейл")]
        [Required]
        [EmailAddress]
        public string Person_Email { get; set; }
        [DisplayName("Парола")]
        [Required]
        [StringLength(256, MinimumLength = 8)]
        public string Person_Password { get; set; }
        [DisplayName("Име")]
        [Required]
        [StringLength(50)]
        public string Person_First_Name { get; set; }
        [DisplayName("Фамилия")]
        [Required]
        [StringLength(50)]
        public string Person_Last_Name { get; set; }
        [DisplayName("ЕГН")]
        [Required]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "The field ЕГН must be a string with a length of 10.")]
        public string Person_EGN { get; set; }
    }
}
