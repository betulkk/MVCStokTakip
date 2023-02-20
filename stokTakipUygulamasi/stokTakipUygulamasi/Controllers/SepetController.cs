using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace stokTakipUygulamasi.Controllers
{
    public class SepetController : Controller
    {
        // GET: Sepet
        public ActionResult Index(decimal? Tutar)
        {
            if (User.Identity.IsAuthenticated) 
            {
                var kullaniciadi = User.Identity.Name;
            }
            return HttpNotFound();
        }
    }
}