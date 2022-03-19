using Firm_Register.Data;
using Firm_Register.Models;
using Firm_Register.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        public ActionResult Info(string firm_Name)
        {
           
            FirmViewModel firmModel = new FirmViewModel();
            firmModel.Firms = _db.Firms;
            firmModel.WorkPlaces = _db.WorkPlaces;
            var firm = _db.Firms.Where(x => x.Firm_Name == firm_Name).ToList();
            var workPlace = _db.WorkPlaces.Where(x => x.Firm_Id == firm[0].Firm_ID).ToList();
            ViewBag.Workers = workPlace.Count();
            ViewBag.Firm = firm[0];
            ViewBag.Trl = Transliteration(firm[0].Firm_Name);
            return View(firmModel);
        }
        public string Transliteration(string cyrilicName)
        {
            StringBuilder trl = new StringBuilder();
            Dictionary<string, string> BgToEng = new Dictionary<string, string>()
            {
                { "а", "a"}, { "А", "A"}, { "б", "b"}, { "Б", "B"}, { "в", "v"}, { "В", "V"}, { "г", "g"}, { "Г", "G"}, { "д", "d"}, { "Д", "D"},
                { "е", "e"}, { "Е", "E"}, { "ж", "zh"}, { "Ж", "ZH"}, { "з", "z"}, { "З", "Z"}, { "и", "i"}, { "И", "I"}, { "й", "y"}, { "Й", "Y"},
                { "к", "k"}, { "К", "K"}, { "л", "l"}, { "Л", "L"}, { "м", "m"}, { "М", "M"}, { "н", "n"}, { "Н", "N"}, { "о", "o"}, { "О", "O"},
                { "п", "p"}, { "П", "P"}, { "р", "r"}, { "Р", "R"}, { "с", "s"}, { "С", "S"}, { "т", "t"}, { "Т", "T"}, { "у", "u"}, { "У", "U"},
                { "ф", "f"}, { "Ф", "F"}, { "х", "h"}, { "Х", "H"}, { "ц", "ts"}, { "Ц", "TS"}, { "ч", "ch"}, { "Ч", "CH"}, { "ш", "sh"}, { "Ш", "SH"},
                { "щ", "sht"}, { "Щ", "SHT"}, { "ъ", "a"}, { "Ъ", "A"}, { "ь", "y" }, { "Ь", "Y"}, { "ю", "yu"}, { "Ю", "YU"}, { "я", "ya"}, { "Я", "YA"}
            };
            foreach(char l in cyrilicName)
                if (BgToEng.ContainsKey(l.ToString())) trl.Append(BgToEng[l.ToString()]);
                else trl.Append(l);
            return trl.ToString();
        }
    }
}
