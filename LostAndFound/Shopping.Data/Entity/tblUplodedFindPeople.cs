//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Shopping.Data.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblUplodedFindPeople
    {
        public long id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FindPeopleImage { get; set; }
        public string Phone { get; set; }
        public bool IsActive { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public System.DateTime ModifiedDate { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<decimal> Latitude { get; set; }
        public Nullable<decimal> Longitude { get; set; }
        public bool IsApproved { get; set; }
        public string EmailId { get; set; }
        public string Address { get; set; }
        public string FullAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string PinCode { get; set; }
        public string LostOrFound { get; set; }
    }
}
