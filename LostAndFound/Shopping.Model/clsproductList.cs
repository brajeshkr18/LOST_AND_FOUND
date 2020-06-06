using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Model
{
    public class clsproductList
    {
       
        public long id { get; set; }
        public string ProductType { get; set; }
        public string ProductDescription { get; set; }
        public bool IsActive { get; set; }
        public string ImageUrl { get; set; }
       
    }
}
