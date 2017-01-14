using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NorthwindProject.Entities.Abstract;

namespace NorthwindProject.Entities.Concrete
{
    //Entity Framework Power Tools
    public class User:IEntity
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }


    }
}
