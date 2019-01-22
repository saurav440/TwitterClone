using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TwitterClone.UI.Models
{
    public class UserModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public string FullName { get; set; }
        public string Email { get; set; }
    }
}