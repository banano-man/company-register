using Firm_Register.Data;
using Firm_Register.Models;
using Firm_Register.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Firm_Register.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _db;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, AppDbContext db)
        {
            _db = db;
            _logger = logger;
        }

        public ActionResult Index()
        {
            HomeViewModel homeModel = new HomeViewModel();
            homeModel.People = _db.People;
            homeModel.Firms = _db.Firms;
            homeModel.Regions = _db.Regions;
            ViewBag.PeopleCount = _db.People.Count() / 100 * 100;
            ViewBag.FirmsCount = _db.Firms.Count() / 10 * 10;
            return View(homeModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

