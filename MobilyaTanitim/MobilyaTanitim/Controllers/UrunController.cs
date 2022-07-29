using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MobilyaTanitim.Models.Entity;
using PagedList;
using PagedList.Mvc;
namespace MobilyaTanitim.Controllers
{
    public class UrunController : Controller
    {
        // GET: Urun
        MvcMobilyaEntities2 db = new MvcMobilyaEntities2();
        public ActionResult Index(int sayfa=1)
        {
            //var degerler = db.Esyalar.ToList();
            var degerler = db.Esyalar.ToList().ToPagedList(sayfa, 10);
            return View(degerler);
        }


        [HttpGet]
        public ActionResult UrunEkle()
        {
            List<SelectListItem> degerler = (from i in db.Kategoriler.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KategoriAd,
                                                 Value = i.Kategoriid.ToString()
                                             }).ToList();

            ViewBag.dgr = degerler;
            return View();
        }

        [HttpPost]
        public ActionResult UrunEkle(Esyalar p1)
        {
            var ktg = db.Kategoriler.Where(m => m.Kategoriid == p1.Kategoriler.Kategoriid).FirstOrDefault();
            p1.Kategoriler = ktg;
            db.Esyalar.Add(p1);

            if (Request.Files.Count>0)
            {
                string dosyaadi = Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string dosyaadi1 = Path.GetFileName(Request.Files[1].FileName);
                string uzanti1 = Path.GetExtension(Request.Files[1].FileName);
                string dosyaadi2 = Path.GetFileName(Request.Files[2].FileName);
                string uzanti2 = Path.GetExtension(Request.Files[2].FileName);
                string dosyaadi3 = Path.GetFileName(Request.Files[3].FileName);
                string uzanti3 = Path.GetExtension(Request.Files[3].FileName);
                string yol = "~/Image/" + dosyaadi + uzanti;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                p1.EşyaResim = "/Image/" + dosyaadi + uzanti;

                string yol1 = "~/Image/" + dosyaadi1 + uzanti1;
                Request.Files[1].SaveAs(Server.MapPath(yol1));
                p1.DetayResim1= "/Image/" + dosyaadi1 + uzanti1;

                string yol2 = "~/Image/" + dosyaadi2 + uzanti2;
                Request.Files[2].SaveAs(Server.MapPath(yol2));
                p1.DetayResim2 = "/Image/" + dosyaadi2 + uzanti2;

                string yol3 = "~/Image/" + dosyaadi3 + uzanti3;
                Request.Files[3].SaveAs(Server.MapPath(yol3));
                p1.DetayResim3 = "/Image/" + dosyaadi3 + uzanti3;
            }
            db.Esyalar.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult SIL(int id)
        {
            var urunler = db.Esyalar.Find(id);
            db.Esyalar.Remove(urunler);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult UrunGetir(int id)
        {
            var urun = db.Esyalar.Find(id);

            List<SelectListItem> degerler = (from i in db.Kategoriler.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KategoriAd,
                                                 Value = i.Kategoriid.ToString()
                                             }).ToList();

            ViewBag.dgr = degerler;


            return View("UrunGetir", urun);
        }

        public ActionResult Guncelle(Esyalar p)
        {
            var urun = db.Esyalar.Find(p.Eşyaid);
            urun.EşyaAd = p.EşyaAd;
            if (Request.Files.Count > 0)
            {
                string dosyaadi = Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string dosyaadi1 = Path.GetFileName(Request.Files[1].FileName);
                string uzanti1 = Path.GetExtension(Request.Files[1].FileName);
                string dosyaadi2 = Path.GetFileName(Request.Files[2].FileName);
                string uzanti2 = Path.GetExtension(Request.Files[2].FileName);
                string dosyaadi3 = Path.GetFileName(Request.Files[3].FileName);
                string uzanti3 = Path.GetExtension(Request.Files[3].FileName);
                string yol = "~/Image/" + dosyaadi + uzanti;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                p.EşyaResim = "/Image/" + dosyaadi + uzanti;

                string yol1 = "~/Image/" + dosyaadi1 + uzanti1;
                Request.Files[1].SaveAs(Server.MapPath(yol1));
                p.DetayResim1 = "/Image/" + dosyaadi1 + uzanti1;

                string yol2 = "~/Image/" + dosyaadi2 + uzanti2;
                Request.Files[2].SaveAs(Server.MapPath(yol2));
                p.DetayResim2 = "/Image/" + dosyaadi2 + uzanti2;

                string yol3 = "~/Image/" + dosyaadi3 + uzanti3;
                Request.Files[3].SaveAs(Server.MapPath(yol3));
                p.DetayResim3 = "/Image/" + dosyaadi3 + uzanti3;
            }
            urun.EşyaResim = p.EşyaResim;
            urun.DetayResim1 = p.DetayResim1;
            urun.DetayResim2 = p.DetayResim2;
            urun.DetayResim3 = p.DetayResim3;

            urun.Detayicerik = p.Detayicerik;
            urun.Fiyat = p.Fiyat;
            var ktg = db.Kategoriler.Where(m => m.Kategoriid == p.Kategoriler.Kategoriid).FirstOrDefault();
            urun.Kategoriid = ktg.Kategoriid;
            //urun.URUNKATEGORI = p.URUNKATEGORI;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}