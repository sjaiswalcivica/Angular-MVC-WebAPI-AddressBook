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
    
    public partial class State
    {
        public int PKStateId { get; set; }
        public int FKCountryId { get; set; }
        public string StateName { get; set; }
        public Nullable<bool> IsActive { get; set; }
    
        public virtual Country Country { get; set; }
    }
}