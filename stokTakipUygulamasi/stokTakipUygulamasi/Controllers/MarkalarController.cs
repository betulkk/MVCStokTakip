using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using stokTakipUygulamasi.Models.Entity;

namespace eTicaretMVC.Controllers
{

    [Authorize(Roles = "yönetici")]

    public class MarkalarController : Controller
    {
        stokTakipEntities1 m = new stokTakipEntities1();
        // GET: Markalar
        public ActionResult Index()
        {
            return View(m.Markalar.ToList()); ;
        }

        [HttpGet]

        public ActionResult MarkaEkle()
        {
            BilgiGetir();//Ctrl-R-M---Yeni metot oluşturma
            return View();

        }

        private void BilgiGetir()
        {
            var model = new Markalar();
            List<SelectListItem> liste = new List<SelectListItem>(from x in m.Kategoriler
                                                                  select new SelectListItem
                                                                  {
                                                                      Value = x.id.ToString(),
                                                                      Text = x.Kategori
                                                                  }).ToList();

            ViewBag.l = liste;
        }

        [HttpPost]
        public ActionResult MarkaEkle(Markalar s1)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.KategoriID = new SelectList(m.Kategoriler, "id", "Kategori", s1.KategoriID);
                return View();
            }
            m.Entry(s1).State = System.Data.Entity.EntityState.Added;
            m.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult SİL(int id)
        {
            var marka = m.Markalar.Find(id);
            m.Markalar.Remove(marka);
            m.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult MarkaGetir(int id)
        {
            BilgiGetir();
            var model = m.Markalar.Find(id);
            if (model == null) return HttpNotFound();
            return View(model);
        }

        public ActionResult MarkaGuncelle(Markalar p)
        {
            if (!ModelState.IsValid)
            {
                BilgiGetir();
                return View("MarkaGetir");

            }
            m.Entry(p).State = System.Data.Entity.EntityState.Modified;
            m.SaveChanges();
            return RedirectToAction("Index");
        }


    }

}
