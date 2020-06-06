using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shopping.Model;
using Shopping.Data.Entity;

namespace Shopping.Data
{
   public class AccountDAL
    {
        public bool VerifyLoginDal(ref clsSignin objSignIn)
        {
            using (var maincontext = new Entity.LostAndFindEntities())
            {

                try
                {
                    string emailId = objSignIn.Username;
                    string password = objSignIn.password;
                    var objUsers = maincontext.VerifyLogin(objSignIn.Username, objSignIn.password).FirstOrDefault();

                    if (objUsers != null)
                    {

                        objSignIn.Email = objUsers.EmailId;
                        objSignIn.FirstName = objUsers.FirstName;
                        objSignIn.LastName = objUsers.LastName;
                        objSignIn.Role = objUsers.Role;
                        objSignIn.Username = objUsers.Username;
                        objSignIn.Phone = objUsers.Phone;
                        objSignIn.UserId = objUsers.id;

                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }


                catch (Exception ex)
                {
                    var text = ex.Message;
                }
                objSignIn = null;
                return false;
            }


        }
        //public bool RegisterUsersDal(ref clsSignin objSignIn)
        //{
        //    using (var maincontext = new Entity.ShoppingEntities())
        //    {

        //        try
        //        {
        //            string firstname = objSignIn.FirstName;
        //            string lastname = objSignIn.LastName;
        //            long roleId = 102;
        //            string mobile = objSignIn.Phone;
        //            string username = objSignIn.Username;
        //            string password = objSignIn.password;
        //            string email = objSignIn.Email;
        //            long userId = 101;
        //            long id = 0;
        //            var objUsers = maincontext.Web_SaveUsers(id, firstname, lastname, password, roleId, username, email, mobile, userId, true).FirstOrDefault();

        //            //return db_Result.UserResult;
        //            return true;
        //        }


        //        catch (Exception ex)
        //        {
        //            var text = ex.Message;
        //        }
        //        objSignIn = null;
        //        return false;
        //    }


        //}
    }
}
