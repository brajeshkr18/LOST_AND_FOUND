using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shopping.Model;

namespace Shopping.Data
{
    public class AdminDAL
    {
        //public List<clsRole> GetRoles()
        //{
        //    using (var maincontext = new Entity.ShoppingEntities())
        //    {
        //        var objgetRoles = maincontext.Web_Roles().ToList();
        //        List<clsRole> lstRoles = new List<clsRole>();

        //        if (objgetRoles.Count() > 0)
        //        {
        //            foreach (var Roles in objgetRoles)
        //            {
        //                clsRole objRolesDetails = new clsRole();
        //                objRolesDetails.RoleId = Roles.id;
        //                objRolesDetails.Role = Roles.Role;
        //                lstRoles.Add(objRolesDetails);
        //            }

        //            return lstRoles;
        //        }

        //        return lstRoles;
        //    }
        //}
        public int ApproveRefuse(clsFoundedPeople objFoundedPeople)
        {
            using (var maincontext = new Entity.LostAndFindEntities())
            {

                var obj = new Entity.tblUplodedFindPeople();
                //var obj = maincontext.tblPractices.FirstOrDefault();
                if (obj != null)
                {
                    if (objFoundedPeople.Id > 0)
                    {
                        var id = objFoundedPeople.Id;
                        var objspeci = new Entity.tblUplodedFindPeople();
                        objspeci = maincontext.tblUplodedFindPeoples.Single(a => a.id == id);
                        objspeci.IsApproved = objFoundedPeople.IsApproved;
                        maincontext.SaveChanges();
                        return 1;

                    }
                    else
                    {
                        return 1;
                    }
                }
                else
                {
                    return 0;
                }

            }
        }
    }
}
