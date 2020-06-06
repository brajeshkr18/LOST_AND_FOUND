using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Model
{
   public class clsProductListDetail
    {

        public long id { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public bool IsActive { get; set; }
        public long ProductTypeId { get; set; }
        public string ImageUrl { get; set; }
        public string ProductPrice { get; set; }
        public string ImageUrl1 { get; set; }
        public string ImageUrl2 { get; set; }
        public string ImageUrl3 { get; set; }
        public string ImageUrl4 { get; set; }

    }
}
