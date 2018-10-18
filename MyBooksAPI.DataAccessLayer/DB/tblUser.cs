//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MyBooksAPI.DataAccessLayer.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblUser
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblUser()
        {
            this.tblCarts = new HashSet<tblCart>();
            this.tblInvoices = new HashSet<tblInvoice>();
            this.tblWishlists = new HashSet<tblWishlist>();
        }
    
        public int UserId { get; set; }
        public string EmailId { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string ContactNo { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string UserType { get; set; }
        public string ReferralId { get; set; }
        public bool IsVerified { get; set; }
        public int Role { get; set; }
        public Nullable<System.DateTime> DateOfBirth { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<bool> IsActive { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblCart> tblCarts { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblInvoice> tblInvoices { get; set; }
        public virtual tblRole tblRole { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblWishlist> tblWishlists { get; set; }
    }
}
