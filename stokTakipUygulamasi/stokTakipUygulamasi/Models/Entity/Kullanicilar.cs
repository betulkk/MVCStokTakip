//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace stokTakipUygulamasi.Models.Entity
{
    using System;
    using System.Collections.Generic;

    public partial class Kullanicilar
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Kullanicilar()
        {
            this.Satislar = new HashSet<Satislar>();
        }

        public int id { get; set; }
        public string KullaniciAdi { get; set; }
        public string Sifre { get; set; }
        public string AdSoyad { get; set; }
        public string eMail { get; set; }
        public string Telefon { get; set; }
        public string KullaniciRolu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Satislar> Satislar { get; set; }
    }
}
