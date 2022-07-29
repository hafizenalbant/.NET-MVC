using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MobilyaTanitim.Models.Entity;
namespace MobilyaTanitim.Controllers
{
    public class DetaySayfaController : Controller
    {
        // GET: DetaySayfa
        MvcMobilyaEntities2 db = new MvcMobilyaEntities2();      
        public ActionResult Index(int id)
        {
           var by = db.Esyalar.Where(x => x.Eşyaid == id).ToList();         
            return View(by);
        }
    }
}