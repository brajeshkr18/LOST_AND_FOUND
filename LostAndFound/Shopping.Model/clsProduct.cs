using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Model
{
   public  class clsProduct
    {
        public List<clsproductList> lstproducts { get; set; }
        public List<clsProductListDetail> lstProductListDetail { get; set; }
        public clsProductListDetail Product { get; set; }
    }
}
