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
    
    public partial class tblCart
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblCart()
        {
            this.tblInvoices = new HashSet<tblInvoice>();
        }
    
        public int CartId { get; set; }
        public Nullable<int> Quantity { get; set; }
        public string ISBN { get; set; }
        public Nullable<int> UserId { get; set; }
        public Nullable<bool> PayStatus { get; set; }
    
        public virtual tblBook tblBook { get; set; }
        public virtual tblUser tblUser { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblInvoice> tblInvoices { get; set; }
    }
}
