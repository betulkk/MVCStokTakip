using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using stokTakipUygulamasi.Models.Entity;

//using Excel = Microsoft.Office.Interop.Excel;
namespace eTicaretMVC.Controllers
{
    [Authorize]

    public class UrunController : Controller
    {
        stokTakipEntities1 sto = new stokTakipEntities1();
        // GET: Urun
        public ActionResult Index(string arama)
        {
            var model = sto.Urunler.ToList();
            if (!string.IsNullOrEmpty(arama))
            {
                model = model.Where(x => x.UrunAdi.Contains(arama) || x.BarkodNO.Contains(arama)).ToList();

            }
            return View(model);
        }


        [HttpGet]

        public ActionResult UrunEkle()
        {
            var model = new Urunler();
            Yenile(model);
            return View(model);

        }

        private void Yenile(Urunler model)
        {
            List<Kategoriler> kategorilist = sto.Kategoriler.OrderBy(x => x.Kategori).ToList();
            model.KategoriListesi = (from x in kategorilist
                                     select new SelectListItem
                                     {
                                         Text = x.Kategori,
                                         Value = x.id.ToString()
                                     }
                                     ).ToList();
        }

        [HttpPost]
        public ActionResult UrunEkle(Urunler s1)
        {
            if (!ModelState.IsValid)
            {
                //return View("UrunEkle");
                var model = new Urunler();
                Yenile(model);
                return View(model);

            }

            sto.Entry(s1).State = System.Data.Entity.EntityState.Added;
            sto.SaveChanges();
            return RedirectToAction("Index");
            //sto.Urunler.Add(s1);
            //sto.SaveChanges();
            //return View();
        }



        public ActionResult SİL(int id)
        {
            var urun = sto.Urunler.Find(id);
            sto.Urunler.Remove(urun);
            sto.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult UrunGetir(int id)
        {
            var model = sto.Urunler.Find(id);
            Yenile(model);
            List<Markalar> markalist = sto.Markalar.Where(x => x.KategoriID == model.KategoriID).OrderBy(x => x.Marka).ToList();
            model.MarkalarListesi = (from x in markalist
                                     select new SelectListItem
                                     {
                                         Text = x.Marka,
                                         Value = x.id.ToString()
                                     }).ToList();
            if (model == null) return HttpNotFound();
            return View(model);
        }

        public ActionResult UrunGuncelle(Urunler p)
        {
            if (!ModelState.IsValid)
            {
                var model = sto.Urunler.Find(p.id);
                Yenile(model);
                List<Markalar> markalist = sto.Markalar.Where(x => x.KategoriID == model.KategoriID).OrderBy(x => x.Marka).ToList();
                model.MarkalarListesi = (from x in markalist
                                         select new SelectListItem
                                         {
                                             Text = x.Marka,
                                             Value = x.id.ToString()
                                         }).ToList();
                if (model == null) return HttpNotFound();
                return View(model);

            }
            sto.Entry(p).State = System.Data.Entity.EntityState.Modified;
            sto.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public JsonResult MarkaGetir(int ID)
        {
            var model = new Urunler();
            List<Markalar> markaListe = sto.Markalar.Where(x => x.KategoriID == ID).OrderBy(x => x.Marka).ToList();
            model.MarkalarListesi = (from x in markaListe
                                     select new SelectListItem
                                     {
                                         Text = x.Marka,
                                         Value = x.id.ToString()
                                     }).ToList();
            model.MarkalarListesi.Insert(0, new SelectListItem { Text = "Seçiniz.", Value = "" });
            return Json(model.MarkalarListesi, JsonRequestBehavior.AllowGet);

        }
    }
}


    //    public JsonResult ExcelAktar()
    //    {
    //        try
    //        {
    //            var liste = sto.Urunler.ToList();
    //           // Excel.Application application = new Excel.Application();
    //            //Excel.Workbook workbook = application.Workbooks.Add(System.Reflection.Missing.Value); ;
    //            //Excel.Worksheet worksheet = workbook.ActiveSheet;
    //           // worksheet.Cells[1, 1] = "ID";
    //            //worksheet.Cells[1, 2] = "Barkod Numarası";
    //            //worksheet.Cells[1, 3] = "Ürün Adı";
    //            //worksheet.Cells[1, 4] = "Ürün Stok";
    //            //worksheet.Cells[1, 5] = "Ürün Fiyatı";
    //            //worksheet.Cells[1, 6] = "Tarih";
    //            int row = 2;
    //            foreach (var item in liste)
    //            {
    //                worksheet.Cells[row, 1] = item.id;
    //                worksheet.Cells[row, 2] = item.BarkodNO;
    //                worksheet.Cells[row, 3] = item.UrunAdi;
    //                worksheet.Cells[row, 4] = item.UrunStok;
    //                worksheet.Cells[row, 5] = item.AlisFiyati;
    //                worksheet.Cells[row, 6] = item.Tarih;
    //                row++;

    //                worksheet.Cells[row, 3].ColumnWidth = 15;
    //                worksheet.Cells[row, 4].ColumnWidth = 15;
    //                worksheet.Cells[row, 6].ColumnWidth = 20;

    //            }
    //            var heading = worksheet.get_Range("A1", "F1");
    //            heading.Font.Bold = true;
    //            heading.Font.Size = 13;
    //            heading.Font.Color = System.Drawing.Color.Red;

    //            var sum = sto.Urunler.Sum(x => x.AlisFiyati).ToString();
    //            var range_sum = worksheet.get_Range("E" + row);
    //            range_sum.Value2 = "Total = " + sum;
    //            range_sum.Font.Bold = true;
    //            var range_Fiyat = worksheet.get_Range("E2", "E" + row);
    //            range_Fiyat.NumberFormat = "#,###,###.00";

    //            var range_Tarih = worksheet.get_Range("F2", "F" + row);
    //            range_Tarih.NumberFormat = "dd,MM,yyyy";

    //            workbook.SaveAs("d:\\stokBilgi.xls");
    //            workbook.Close();
    //            application.Quit();
    //            ViewBag.mesaj = "İşlem Başarılı";
    //        }
    //        catch (Exception ex)
    //        {
    //            ViewBag.mesaj = ex.Message;
    //        }
    //        return Json(ViewBag.mesaj, JsonRequestBehavior.AllowGet);
    //    }
    //}


//}
