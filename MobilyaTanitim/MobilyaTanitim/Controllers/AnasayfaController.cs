using MobilyaTanitim.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MobilyaTanitim.Controllers
{
    public class AnasayfaController : Controller
    {
        // GET: Anasayfa
        MvcMobilyaEntities2 db = new MvcMobilyaEntities2();
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult Partial1()
        {
            var degerler = db.Esyalar.OrderByDescending(x => x.Eşyaid).Take(4).ToList();
            return PartialView(degerler);
        }

        public PartialViewResult Partial2()
        {
            var deger = db.Esyalar.Where(x => x.Eşyaid == 21).ToList();
            return PartialView(deger);
        }
    }
}