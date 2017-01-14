using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NorthwindProject.Entities.ComplexTypes
{
    public class ProductFilter
    {
        public int? CategoryId { get; set; }

        public int? Page { get; set; }

        public int? PageSize { get; set; }

        public string ProductName { get; set; }
    }
}
