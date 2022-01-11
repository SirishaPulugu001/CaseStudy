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
    
    public partial class UsersRegistrationDetail
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public UsersRegistrationDetail()
        {
            this.CustomerPolicyDetails = new HashSet<CustomerPolicyDetail>();
            this.PolicyClaims = new HashSet<PolicyClaim>();
            this.PolicyDetails = new HashSet<PolicyDetail>();
            this.PremiumPayments = new HashSet<PremiumPayment>();
        }
    
        public int UserID { get; set; }
        public string Username { get; set; }
        public string UserPassword { get; set; }
        public Nullable<int> UserType { get; set; }
        public string MobileNumber { get; set; }
        public string Gender { get; set; }
        public Nullable<int> Age { get; set; }
        public string UserAddress { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CustomerPolicyDetail> CustomerPolicyDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PolicyClaim> PolicyClaims { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PolicyDetail> PolicyDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PremiumPayment> PremiumPayments { get; set; }
        public virtual UserType1 UserType1 { get; set; }
    }
}
