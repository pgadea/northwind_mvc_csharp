using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NorthwindProject.MvcWebUI.Models
{
    public class CategoryListViewModel
    {
        public List<Entities.Concrete.Category> Categories { get; set; }

        public int? CurrentCategory { get; set; }
    }
}
