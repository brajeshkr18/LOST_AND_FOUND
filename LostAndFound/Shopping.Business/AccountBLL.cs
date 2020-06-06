using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shopping.Model;
using Shopping.Data;
namespace Shopping.Business
{
    public class AccountBLL
    {
        public bool VerifyLogin(ref clsSignin objSignIn)
        {
            if ((new AccountDAL()).VerifyLoginDal(ref objSignIn))
            {
                return true;
            }
            return false;
        }
    }
}
