using Firm_Register.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Firm_Register.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<People> People { get; set; }
        public IEnumerable<Firms> Firms { get; set; }
        public IEnumerable<Regions> Regions { get; set; }
    }
}
