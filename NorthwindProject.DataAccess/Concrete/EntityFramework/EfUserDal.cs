using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NorthwindProject.DataAccess.Abstract;
using NorthwindProject.DataAccess.Concrete.EntityFramework.Contexts;
using NorthwindProject.Entities.Concrete;

namespace NorthwindProject.DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, NorthwindContext>, IUserDal
    {
    }
}
