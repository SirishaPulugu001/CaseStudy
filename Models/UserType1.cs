//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CaseStudy.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class UserType1
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public UserType1()
        {
            this.UsersRegistrationDetails = new HashSet<UsersRegistrationDetail>();
        }
    
        public int UserType { get; set; }
        public string UserDescription { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UsersRegistrationDetail> UsersRegistrationDetails { get; set; }
    }
}
