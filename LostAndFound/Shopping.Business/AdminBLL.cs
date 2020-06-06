using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shopping.Model;
using Shopping.Data;


namespace Shopping.Business
{
    public class AdminBLL
    {
        //public List<clsRole> GetRoles()
        //{
        //    List<clsRole> lstRoles = new List<clsRole>();

        //    return lstRoles = (new AdminDAL()).GetRoles();

        //}
        public int ApproveRefuse(clsFoundedPeople objFoundedPeople)
        {
            return (new AdminDAL()).ApproveRefuse(objFoundedPeople);
        }
    }
}
