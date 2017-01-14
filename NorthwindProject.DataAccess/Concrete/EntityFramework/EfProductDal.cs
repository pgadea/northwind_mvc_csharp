using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NorthwindProject.DataAccess.Abstract;
using NorthwindProject.DataAccess.Concrete.EntityFramework.Contexts;
using NorthwindProject.Entities.ComplexTypes;
using NorthwindProject.Entities.Concrete;

namespace NorthwindProject.DataAccess.Concrete.EntityFramework
{
    public class EfProductDal:EfEntityRepositoryBase<Product,NorthwindContext>,IProductDal
    {
        public List<ProductDetail> GetProductDetails()
        {
            throw new NotImplementedException();
        }

        public int GetProductsCountByCategory(int? categoryId)
        {
            using (var context=new NorthwindContext())
            {
                if (categoryId==null)
                {
                    return context.Products.Count();
                }

                return context.Products.Count(p => p.CategoryId == categoryId);
            }
        }
    }
}
