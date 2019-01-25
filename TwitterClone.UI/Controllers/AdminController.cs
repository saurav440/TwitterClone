using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TwitterClone.BAL;
using TwitterClone.DAL;
using TwitterClone.UI.Models;

namespace TwitterClone.UI.Controllers
{
    public class AdminController : Controller
    {
        TwitterCloneBO obj = new TwitterCloneBO();
        // GET: Admin
        public ActionResult SignUp()
        {
            User model = new User();
            return View( model);
           
        }

        [HttpPost]
        public ActionResult SignUp(User model)
        {
           var response =  obj.CreateAccount(new Person()
            {
                User_id = model.UserName,
                Password = model.Password,
                FullName = model.FullName,
                Email = model.Email,
                joined = DateTime.Now,
                Active = true
            });

            
            return View(model);

        }
    }
}