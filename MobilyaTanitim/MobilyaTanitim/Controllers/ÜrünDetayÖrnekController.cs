using MobilyaTanitim.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MobilyaTanitim.Controllers
{
    public class ÜrünDetayÖrnekController : Controller
    {
        // GET: ÜrünDetayÖrnek
        MvcMobilyaEntities2 db = new MvcMobilyaEntities2();
        public ActionResult Index(int id)
        {
            var by = db.Esyalar.Where(x => x.Eşyaid == id).ToList();
            return View(by);
        }

        //public ActionResult Index()
        //{

        //    return View();
        //}
    }
}