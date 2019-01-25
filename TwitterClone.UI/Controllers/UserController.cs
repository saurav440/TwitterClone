using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TwitterClone.UI.Models;

namespace TwitterClone.UI.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        //[ActionName("User")]
        public ActionResult Index()
        {
            return View();
        }
    }
}