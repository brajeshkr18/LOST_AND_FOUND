using Shopping.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shopping.Business;
using System.Web.Security;

namespace Shopping.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Login()
        {
            ViewBag.Mesage = "Login";
            return View();
        }
        [HttpPost]
        public ActionResult Login(clsSignin objSignin)
        {
            try
            {
                if ((new AccountBLL()).VerifyLogin(ref objSignin))
                {
                    FormsAuthentication.SetAuthCookie(objSignin.Username, false);
                    Response.Cookies[objSignin.Username].Expires = DateTime.Now.AddSeconds(10);
                    Session["UserInfo"] = objSignin;
                    return Json(new { Status = "Success" });
                }
                return Json(new { Status = "Failure", Message = "Username/Password does not match" , objSignin });
            }
            catch (Exception ex)
            {
                return Json(new { Status = "Failure", Message = "A network related issue occered. Please try again to login" });
            }

        }
        public ActionResult SignUp()
        {
            ViewBag.Mesage = "SignUp";
            return View();
        }
        [HttpPost]
        public ActionResult SignUp(clsSignin objSignin)
        {
            try
            {
                //if ((new AccountBLL()).VerifyLogin(ref objSignin))
                //{
                //    FormsAuthentication.SetAuthCookie(objSignin.Username, false);
                //    Response.Cookies[objSignin.Username].Expires = DateTime.Now.AddSeconds(10);
                //    Session["UserInfo"] = objSignin;
                //    return Json(new { Status = "Success" });
                //}
                return Json(new { Status = "Failure", Message = "Username/Password does not match" });
            }
            catch (Exception ex)
            {
                return Json(new { Status = "Failure", Message = "A network related issue occered. Please try again to login" });
            }

        }
    }
}