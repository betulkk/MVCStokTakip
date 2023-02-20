using stokTakipUygulamasi.Models.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

namespace stokTakipUygulamasi.MyModel
{
    public class MyUrunler
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MyUrunler()
        {
            //this.Satislar = new HashSet<Satislar>();
            this.MarkaListesi = new List<SelectListItem>();
            MarkaListesi.Insert(0, new SelectListItem { Text = "Önce Kategori Seçilmelidir.", Value = "" });
        }

        public int id { get; set; }
        [Required(ErrorMessage = "Barkod No alanı boş geçilemez.")]

        public string BarkodNO { get; set; }
        [Required(ErrorMessage = "Kategori alanı boş geçilemez.")]
        public int KategoriID { get; set; }
        [Required(ErrorMessage = "Marka alanı boş geçilemez.")]
        public int MarkaID { get; set; }
        [Required(ErrorMessage = "Ürün Adı alanı boş geçilemez.")]
        [Display(Name = "Ürün Adı")]
        public string UrunAdi { get; set; }
        [Required(ErrorMessage = "Stok alanı boş geçilemez.")]

        public int UrunStok { get; set; }
        [Required(ErrorMessage = "Ürün Fiyatı alanı boş geçilemez.")]
        [Display(Name = "Ürün Fiyatı")]
        public double AlisFiyati { get; set; }
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Tarih alanı boş geçilemez.")]

        public System.DateTime Tarih { get; set; }
        [Required(ErrorMessage = "Açıklama alanı boş geçilemez.")]

        public string Aciklama { get; set; }

        public virtual MyKategoriler Kategoriler { get; set; }
        public virtual MyMarkalar Markalar { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<Satislar> Satislar { get; set; }

        public List<SelectListItem> KategoriListesi { get; set; }

        public List<SelectListItem> MarkaListesi { get; set; }
    }
}
