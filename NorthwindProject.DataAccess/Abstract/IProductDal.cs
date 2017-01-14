using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NorthwindProject.Entities.ComplexTypes;
using NorthwindProject.Entities.Concrete;

namespace NorthwindProject.DataAccess.Abstract
{
    public interface IProductDal:IEntityRepository<Product>
    {
        List<ProductDetail> GetProductDetails();

        int GetProductsCountByCategory(int? categoryId);
    }
}
