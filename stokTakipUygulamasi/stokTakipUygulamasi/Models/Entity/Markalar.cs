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
    using System.ComponentModel.DataAnnotations;

    public partial class Markalar
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Markalar()
        {
            this.Urunler = new HashSet<Urunler>();
        }

        public int id { get; set; }
        [Required(ErrorMessage = "Kategori alan? bo? ge?ilemez")]
        public string Marka { get; set; }
        public int KategoriID { get; set; }
        public string Aciklama { get; set; }

        public virtual Kategoriler Kategoriler { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Urunler> Urunler { get; set; }
    }
}
