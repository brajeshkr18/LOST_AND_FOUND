using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Model
{
    public class clsFoundedPeople
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailId { get; set; }
        public string Phone { get; set; }
        public string FindPeopleImage { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
        public bool IsActive { get; set; }
        public bool UserId { get; set; }
        public bool IsApproved { get; set; }
        
        public string Address { get; set; }
        public string LostOrFound { get; set; }
        public string FullAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Pincode { get; set; }
    }
    public class RootObject
    {
        public string place_id { get; set; }
        public string licence { get; set; }
        public string osm_type { get; set; }
        public string osm_id { get; set; }
        public string lat { get; set; }

        public string lon { get; set; }

        public string display_name { get; set; }
        public Address address { get; set; }
    }
    public class Address
    {

        public string road { get; set; }
        public string suburb { get; set; }
        public string city { get; set; }
 
        public string state_district { get; set; }
        public string state { get; set; }
        public string postcode { get; set; }
        public string country { get; set; }
        public string country_code { get; set; }
    }
}
