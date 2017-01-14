using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NorthwindProject.Entities.Concrete;

namespace NorthwindProject.MvcWebUI.Models
{
    public class LoginViewModel
    {
        public User User { get; set; }

        public bool RememberMe { get; set; }
    }
}
