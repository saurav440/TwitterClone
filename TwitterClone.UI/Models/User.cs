using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TwitterClone.UI.Models
{
    public class User
    {
        [Required(ErrorMessage ="User Name is required field")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password is required field")]
        public string Password { get; set; }
        [Required(ErrorMessage = "FullName is requred field")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "User Name is required field")]
        public string Email { get; set; }
    }
}