//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BMS.DA
{
    using System;
    using System.Collections.Generic;
    
    public partial class Brouwerij
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Brouwerij()
        {
            this.Bieren = new HashSet<Bier>();
        }
    
        public int Id { get; set; }
        public string Naam { get; set; }
        public string Locatie { get; set; }
        public string Beschrijving { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Bier> Bieren { get; set; }
    }
}