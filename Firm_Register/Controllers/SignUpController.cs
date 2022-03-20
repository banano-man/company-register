using Firm_Register.Data;
using Firm_Register.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Firm_Register.Controllers
{
    public class SignUpController : Controller
    {
        private readonly AppDbContext _db;

        public SignUpController(AppDbContext db)
        {
            _db = db;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(People obj)
        {
            if (ModelState.IsValid)
            {
                _db.People.Add(obj);
                _db.SaveChanges();
                return RedirectToPage("~/Home/Index");
            }
            return View(obj);
        }
    }
}
