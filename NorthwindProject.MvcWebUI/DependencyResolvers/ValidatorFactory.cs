using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentValidation;
using Ninject;
using NorthwindProject.Business.ValidationRules.FluentValidation;
using NorthwindProject.Entities.Concrete;

namespace NorthwindProject.MvcWebUI.DependencyResolvers
{
    public class FluentValidatorFactory:ValidatorFactoryBase
    {
        private IKernel _kernel;

        public FluentValidatorFactory()
        {
            _kernel =new StandardKernel();
            _kernel.Bind<IValidator<Product>>().To<ProductValidator>().InSingletonScope();

        }

        public override IValidator CreateInstance(Type validatorType)
        {
            return (validatorType == null) ? null : (IValidator) _kernel.TryGet(validatorType);
        }
    }
}