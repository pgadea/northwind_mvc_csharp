using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NorthwindProject.MvcWebUI.Models
{
    public class ProductListViewModel
    {
        public List<Entities.Concrete.Product> Products { get; set; }

        public PagingInfo PagingInfo { get; set; }
    }
}
