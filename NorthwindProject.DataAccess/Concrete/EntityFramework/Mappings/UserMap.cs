using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Mapping;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NorthwindProject.Entities.Concrete;

namespace NorthwindProject.DataAccess.Concrete.EntityFramework.Mappings
{
    public class UserMap:EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            HasKey(t => t.Id);

            Property(t => t.UserName).IsRequired();
            Property(t => t.Password).IsRequired();

            ToTable("Users");

            Property(t => t.Id).HasColumnName("Id");
            Property(t => t.UserName).HasColumnName("UserName");
            Property(t => t.Password).HasColumnName("Password");
        }
    }
}
