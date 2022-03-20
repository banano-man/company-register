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
    public class MyFirmsController : Controller
    {
        private readonly AppDbContext _db;

        public MyFirmsController(AppDbContext db)
        {
            _db = db;
        }

        public IActionResult Index(People person)
        {
            ViewBag.Person = person;
            MyFirmViewModel firmModel = new MyFirmViewModel();
            firmModel.People = _db.People;
            firmModel.Roles = _db.Roles;
            firmModel.WorkPlaces = _db.WorkPlaces;
            return View(firmModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(WorkPlace obj)
        {
            _db.WorkPlaces.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.WorkPlaces.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(WorkPlace obj)
        {
            _db.WorkPlaces.Update(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.WorkPlaces.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirm(int? id)
        {
            var obj = _db.WorkPlaces.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.WorkPlaces.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
