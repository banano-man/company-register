using Firm_Register.Data;
using Firm_Register.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Firm_Register.Controllers
{
    public class FirmsController : Controller
    {
        private readonly AppDbContext _db;

        public FirmsController(AppDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Regions> objList = _db.Regions;
            return View(objList);
        }
    }
}
