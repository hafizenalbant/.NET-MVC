using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MobilyaTanitim.Models.Entity;

namespace MobilyaTanitim.Controllers
{
    public class UrunSayfasiController : Controller
    {
        // GET: UrunSayfasi
        MvcMobilyaEntities2 db = new MvcMobilyaEntities2();       
        public ActionResult Index()
        {
            var degerler = db.Esyalar.Where(x => x.Kategoriid == 1).ToList();
            return View(degerler);
        }


    
    }
}