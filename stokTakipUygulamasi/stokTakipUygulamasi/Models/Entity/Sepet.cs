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
    
    public partial class Sepet
    {
        public int id { get; set; }
        public int UrunID { get; set; }
        public decimal Fiyati { get; set; }
        public decimal Miktari { get; set; }
        public decimal ToplamFiyati { get; set; }
        public System.DateTime Tarih { get; set; }
    
        public virtual Urunler Urunler { get; set; }
    }
}
