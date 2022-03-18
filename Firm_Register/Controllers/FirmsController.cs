using Firm_Register.Data;
using Firm_Register.Models;
using Firm_Register.ViewModels;
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

        public ActionResult Index(string region)
        {
            ViewBag.region = region;
            FirmViewModel firmModel = new FirmViewModel();
            firmModel.Firms = _db.Firms;
            firmModel.Regions = _db.Regions;
            return View(firmModel);
        }
    }
}
