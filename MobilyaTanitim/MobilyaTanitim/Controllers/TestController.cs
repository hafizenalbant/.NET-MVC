using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MobilyaTanitim.Models.Entity;
namespace MobilyaTanitim.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        MvcMobilyaEntities2 db = new MvcMobilyaEntities2();
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Ekle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Ekle(Esyalar e)
        {
            return View();
        }
    }
}