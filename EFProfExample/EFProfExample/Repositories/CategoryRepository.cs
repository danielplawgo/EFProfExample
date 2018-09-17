using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using EFProfExample.Models;

namespace EFProfExample.Repositories
{
    public partial class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(Lazy<DataContext> db)
            : base(db)
        {

        }

        public override IEnumerable<Category> GetAllActive()
        {
            return DataContext.Set<Category>()
                .Where(e => e.IsActive)
                .ToList();
        }

        public IEnumerable<Category> GetAllActiveWithProducts()
        {
            return DataContext.Categories.Include(c => c.Products).Where(c => c.IsActive);
        }
    }
}