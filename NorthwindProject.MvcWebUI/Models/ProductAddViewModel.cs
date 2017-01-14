using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using NorthwindProject.Entities.Concrete;

namespace NorthwindProject.MvcWebUI.Models
{
    public class ProductAddViewModel
    {
        public Product Product { get; set; }

        public List<SelectListItem> Categories { get; set; }
    }
}
