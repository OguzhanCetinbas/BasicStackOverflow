//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Raklet.Models.EntityDataModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class SUBJECT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SUBJECT()
        {
            this.SOLUTION = new HashSet<SOLUTION>();
        }
    
        public int SUBJECT_ID { get; set; }
        public string PROBLEM { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SOLUTION> SOLUTION { get; set; }
    }
}
