using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NorthwindProject.Entities.Concrete;

namespace NorthwindProject.DataAccess.Concrete.EntityFramework.Mappings
{
    public class CategoryMap:EntityTypeConfiguration<Category>
    {
        public CategoryMap()
        {
            HasKey(t => t.Id);

            Property(t => t.CategoryName).IsRequired().HasMaxLength(15);

            ToTable("Categories");

            Property(t => t.Id).HasColumnName("CategoryID");
            Property(t => t.CategoryName).HasColumnName("CategoryName");
            Property(t => t.Description).HasColumnName("Description");
        }
    }
}
