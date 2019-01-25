using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TwitterClone.UI.Models;
using TwitterClone.BAL;

namespace TwitterClone.UI.Controllers
{
    public class LoginController : Controller
    {
        TwitterCloneBO obj = new TwitterCloneBO();
        // GET: Login
        public ActionResult Index()
        {
            User model = new User();
            return View(model);
        }

        [HttpPost]
        public ActionResult Login(string userid,string pwd)
        {
            if(obj.IsUserExist(userid))
            {
                if(obj.ValidatedUser(userid, pwd))
                {
                   return RedirectToAction("GetDetails");
                }
                else
                {
                    ViewBag.Message = "Invalid UserName or Password";
                }
            }
            else
            {
                ViewBag.Message = "User not exist.";
            }
            return View("Index");
        }

        public ActionResult GetDetails()
        {
            return View("tweets");
        }
    }
}