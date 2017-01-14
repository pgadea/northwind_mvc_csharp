using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NorthwindProject.Entities.Abstract;

namespace NorthwindProject.Entities.Concrete
{
    public class Product:IEntity
    {
        public int Id { get; set; }

        public string ProductName { get; set; }

        public int? CategoryId { get; set; }

        public string QuantityPerUnit { get; set; }

        public decimal? UnitPrice { get; set; }

        public short? UnitsInStock { get; set; }

        public Category Category { get; set; }
    }
}
