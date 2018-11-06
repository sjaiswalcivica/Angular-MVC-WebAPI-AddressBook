//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AddressbookApp.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Addressbook
    {
        public int PKAddressId { get; set; }
        public int FKStateId { get; set; }
        public int FKUserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailId { get; set; }
        public string PhoneNo { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public long ZipCode { get; set; }
        public bool IsActive { get; set; }
    
        public virtual State State { get; set; }
        public virtual Userdetail Userdetail { get; set; }
    }
}
