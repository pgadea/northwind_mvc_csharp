using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Ninject;
using NorthwindProject.Business.Abstract;
using NorthwindProject.Business.Concrete.Managers;
using NorthwindProject.DataAccess.Abstract;
using NorthwindProject.DataAccess.Concrete.EntityFramework;

namespace NorthwindProject.MvcWebUI.DependencyResolvers
{
    public class NinjectControllerFactory:DefaultControllerFactory
    {
        private IKernel _kernel;

        public NinjectControllerFactory()
        {
            _kernel =new StandardKernel();
            _kernel.Bind<IProductService>().To<ProductManager>().InSingletonScope();
            _kernel.Bind<IProductDal>().To<EfProductDal>().InSingletonScope();
            _kernel.Bind<ICategoryService>().To<CategoryManager>().InSingletonScope();
            _kernel.Bind<ICategoryDal>().To<EfCategoryDal>().InSingletonScope();
            _kernel.Bind<IUserService>().To<UserManager>().InSingletonScope();
            _kernel.Bind<IUserDal>().To<EfUserDal>().InSingletonScope();
        }
        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return controllerType == null? null : (IController) _kernel.Get(controllerType);
        }
    }
}