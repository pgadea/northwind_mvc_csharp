﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NorthwindProject.Entities.Concrete;

namespace NorthwindProject.DataAccess.Abstract
{
    public interface IUserDal:IEntityRepository<User>
    {
    }
}
