using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MobilyaTanitim.Models.Entity;
using PagedList;
using PagedList.Mvc;
namespace MobilyaTanitim.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        MvcMobilyaEntities2 db = new MvcMobilyaEntities2();
        public ActionResult Index(int sayfa=1)
        {
            //var degerler = db.Kategoriler.ToList();
            var degerler = db.Kategoriler.ToList().ToPagedList(sayfa, 5);
            return View(degerler);
        }



        [HttpGet]
        public ActionResult YeniKategori()
        {
            return View();
        }


        [HttpPost]
        public ActionResult YeniKategori(Kategoriler p1)
        {
            if (!ModelState.IsValid)
            {
                return View("YeniKategori");
            }
            db.Kategoriler.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult SIL(int id)
        {
            var kategori = db.Kategoriler.Find(id);
            db.Kategoriler.Remove(kategori);
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult KategoriGetir(int id)
        {
            var ktgr = db.Kategoriler.Find(id);
            return View("KategoriGetir", ktgr);
        }

        public ActionResult Guncelle(Kategoriler p1)
        {
            var ktg = db.Kategoriler.Find(p1.Kategoriid);
            ktg.KategoriAd = p1.KategoriAd;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}