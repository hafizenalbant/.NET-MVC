//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MobilyaTanitim.Models.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class Esyalar
    {
        public int Eşyaid { get; set; }
        public string EşyaAd { get; set; }
        public string EşyaResim { get; set; }
        public Nullable<int> Kategoriid { get; set; }
        public string DetayResim1 { get; set; }
        public string DetayResim2 { get; set; }
        public string DetayResim3 { get; set; }
        public string Detayicerik { get; set; }
        public Nullable<int> Fiyat { get; set; }
    
        public virtual Kategoriler Kategoriler { get; set; }
    }
}
