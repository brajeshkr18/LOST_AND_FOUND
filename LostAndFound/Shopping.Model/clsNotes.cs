using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Model
{
   public class clsNotes
    {
       public clsNotes()
        {
            this.lstNotes = new List<clsNotes>();
        }
        public string Notes { get; set; }
       public List<clsNotes> lstNotes { get; set; }
    }
}
