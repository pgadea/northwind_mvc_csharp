using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NorthwindProject.Business.Abstract;
using NorthwindProject.Business.ValidationRules.FluentValidation;
using NorthwindProject.DataAccess.Abstract;
using NorthwindProject.Entities.ComplexTypes;
using NorthwindProject.Entities.Concrete;

namespace NorthwindProject.Business.Concrete.Managers
{
    public class ProductManager:IProductService
    {
        private IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public List<Product> GetAll(ProductFilter productFilter)
        {
            int? categoryId = productFilter.CategoryId;

            if (categoryId!=null)
            {
                return _productDal.GetList(
                    filter: product => product.CategoryId == categoryId,
                    orderBy: o => o.OrderBy(product => product.Id),
                    page: productFilter.Page,
                    pageSize: productFilter.PageSize
                    );
            }
            else
            {
                return _productDal.GetList(
                   orderBy: o => o.OrderBy(product => product.Id),
                   page: productFilter.Page,
                   pageSize: productFilter.PageSize
                   );
            }
        }

        public Product GetById(int id)
        {
            return _productDal.Get(p => p.Id == id);
        }

        public List<Product> GetByCategory(int categoryId)
        {
            return _productDal.GetList(p => p.CategoryId == categoryId);
        }

        public List<Product> GetByProductName(string productName)
        {
            return _productDal.GetList(p => p.ProductName.Contains(productName));
        }

        public void Add(Product product)
        {
            FluentValidatorTool.Validate(new ProductValidator(), product);
            ProductNameCheck(product);
            _productDal.Add(product);
        }

        private void ProductNameCheck(Product product)
        {
            bool thereIsAnyProductNameWithTheSameName =
                _productDal.GetList(p => p.ProductName == product.ProductName).Any();

            if (thereIsAnyProductNameWithTheSameName)
            {
                throw new Exception("There is already a product with the same name");
            }
        }

        public void Update(Product product)
        {
            FluentValidatorTool.Validate(new ProductValidator(), product);
            //ProductNameCheck(product);
            _productDal.Update(product);
        }

        public void Delete(Product product)
        {
            _productDal.Delete(product);
        }

        public int GetProductsCountByCategory(int? categoryId)
        {
            return _productDal.GetProductsCountByCategory(categoryId);
        }
    }
}
