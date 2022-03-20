using Firm_Register.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Firm_Register.ViewModels
{
    public class MyFirmViewModel
    {
        public IEnumerable<People> People { get; set; }
        public IEnumerable<Roles> Roles { get; set; }
        public IEnumerable<WorkPlace> WorkPlaces { get; set; }
    }
}
