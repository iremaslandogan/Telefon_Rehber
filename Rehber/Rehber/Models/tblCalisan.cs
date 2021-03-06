//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Rehber.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class tblCalisan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblCalisan()
        {
            this.tblCalisan1 = new HashSet<tblCalisan>();
        }
    
        public int CalisanID { get; set; }
       
        [RegularExpression("([A-z^������������]+)", ErrorMessage = "Sadece harf girebilirsiniz.")]
        public string Ad { get; set; }
        [RegularExpression("([A-z^������������]+)", ErrorMessage = "Sadece harf girebilirsiniz.")]
        public string Soyad { get; set; }

        [RegularExpression("([0-9]+)", ErrorMessage="Sadece rakam girebilirsiniz.")]
        [StringLength(11, MinimumLength=11)]
        public string Telefon { get; set; }
        public Nullable<int> Departman { get; set; }
        public Nullable<int> Yonetici { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblCalisan> tblCalisan1 { get; set; }
        public virtual tblCalisan tblCalisan2 { get; set; }
        public virtual tblDepartman tblDepartman { get; set; }
    }
}
