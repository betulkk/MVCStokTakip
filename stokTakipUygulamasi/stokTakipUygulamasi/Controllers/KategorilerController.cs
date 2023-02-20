using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using stokTakipUygulamasi.Models.Entity;

namespace eTicaretMVC.Controllers
{
    [Authorize(Roles = "yönetici")]
    public class KategorilerController : Controller
    {

        stokTakipEntities1 db = new stokTakipEntities1();
        // GET: Kategoriler
        public ActionResult Index()
        {
            return View(db.Kategoriler.ToList()); ;
        }

        [HttpGet]

        public ActionResult KategoriEkle()
        {
            return View();
        }


        [HttpPost]
        public ActionResult KategoriEkle(Kategoriler k1)
        {
            if (!ModelState.IsValid)
            { return View("KategoriEkle"); }
            db.Entry(k1).State = System.Data.Entity.EntityState.Added;
            db.SaveChanges();
            return RedirectToAction("Index");
        }



        public ActionResult SİL(int id)
        {
            var kat = db.Kategoriler.Find(id);
            db.Kategoriler.Remove(kat);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult GuncelleBilgiGetir(int id)
        {
            var model = db.Kategoriler.Find(id);
            if (model == null) return HttpNotFound();
            return View(model);
        }

        public ActionResult KategoriGuncelle(Kategoriler p)
        {
            db.Entry(p).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}