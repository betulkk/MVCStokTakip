using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Net.Mail;
using System.Net;
using stokTakipUygulamasi.Models.Entity;

namespace eTicaretMVC.Controllers
{
    [AllowAnonymous]

    public class KullanicilarController : Controller
    {
        stokTakipEntities1 k = new stokTakipEntities1();
        [HttpGet]
        // GET: Kullanicilar
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Kullanicilar k1)
        {
            var users = k.Kullanicilar.FirstOrDefault(x => x.KullaniciAdi == k1.KullaniciAdi && x.Sifre == k1.Sifre);
            if (users != null)
            {
                FormsAuthentication.SetAuthCookie(k1.KullaniciAdi, false);
                return RedirectToAction("Index", "Urun");
            }

            ViewBag.hata = "Kullanıcı adı veya şifre yanlış.";
            return View();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
        [HttpGet]
        public ActionResult SifreyiYenile()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SifreyiYenile(Kullanicilar p)
        {
            var kullanici = k.Kullanicilar.Where(x => x.eMail == p.eMail).FirstOrDefault();
            if (kullanici != null)
            {
                Guid random = Guid.NewGuid();
                kullanici.Sifre = random.ToString().Substring(0, 8);
                //     k.SaveChanges();
                SmtpClient smtpClient = new SmtpClient("smtp.yandex.com", 587);
                smtpClient.EnableSsl = true;
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("betuldestek@yandex.com", "Şifre Sıfırlama");
                mail.To.Add(kullanici.eMail);
                mail.IsBodyHtml = true;
                mail.Subject = "Şifre değiştirme işlemi";
                mail.Body += "Merhaba" + kullanici.AdSoyad + ".<br/> Kullanıcı adınız:" + kullanici.KullaniciAdi + "<br/> Şifreniz:" + kullanici.Sifre;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                NetworkCredential network = new NetworkCredential("betuldestek@yandex.com", "qkkgxowrnepymxkp");
                smtpClient.Credentials = network;
                smtpClient.Send(mail);
                return RedirectToAction("login");

            }

            ViewBag.hata = "Böyle bir e-Mail adresi bulunmamaktadır.";
            return View();
        }
        [HttpGet]
        public ActionResult Kaydol()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Kaydol(Kullanicilar p)
        {
            if (!ModelState.IsValid) { return View(); }
            p.KullaniciRolu = "personel";
            k.Entry(p).State = System.Data.Entity.EntityState.Added;
            k.SaveChanges();
            return RedirectToAction("Login");
        }
    }
}