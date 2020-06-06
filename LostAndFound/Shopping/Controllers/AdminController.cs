using Shopping.Business;
using Shopping.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shopping.Controllers
{
    [ValidateUser(AllowedRoles = "Admin")]
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Manage()
        {
            if (Session["UserInfo"] != null)
            {
                var UserRole = ((Shopping.Model.clsSignin)Session["UserInfo"]).Role;
                if (UserRole == "Admin")
                {
                    clsListFoundedPeople objfoundedppl = new clsListFoundedPeople();
                    objfoundedppl.lstFoundedPeople = (new HomeBLL().GetFoundedPeople(0));
                    return View(objfoundedppl);
                }
            }
            return RedirectToAction("Logout");

           
           // return View();
        }
        public ActionResult ApproveRefuse(clsFoundedPeople objFoundedPeople)
        {
            if (Session["UserInfo"] != null)
            {
             var UserRole = ((Shopping.Model.clsSignin)Session["UserInfo"]).Role;
                if (UserRole == "Admin")
                {
                   
             var ApproveRefuse_Result = (new AdminBLL()).ApproveRefuse(objFoundedPeople);
            if (ApproveRefuse_Result == 1)
                return Json(new { Status = "Success", Message = "image has been Approve/Refuse successfully." });
            else if (ApproveRefuse_Result == 2)
                return Json(new { Status = "Success", Message = "image has been Approve/Refuse successfully." });
            else if (ApproveRefuse_Result == 0)
                return Json(new { Status = "Failure", Message = "There is already a specility with this name, Try with a different name. " });
            else
                return Json(new { Status = "Failure", Message = "Seems something is wrong! Please try again later." });
                }
            }
            return RedirectToAction("Logout");
        }
    }
}