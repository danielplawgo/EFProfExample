using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EFProfExample.Models;

namespace EFProfExample.Repositories
{
    public partial class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(Lazy<DataContext> db)
            : base(db)
        {

        }

        public override IEnumerable<Product> GetAllActive(int page, int pageSize)
        {
            return DataContext.Set<Product>()
                .Where(e => e.IsActive)
                .OrderBy(e => e.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize).ToList();
        }
    }
}