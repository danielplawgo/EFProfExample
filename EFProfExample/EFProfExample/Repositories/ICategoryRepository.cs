using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFProfExample.Models;

namespace EFProfExample.Repositories
{
    public partial interface ICategoryRepository : IRepository<Category>
    {
        IEnumerable<Category> GetAllActiveWithProducts();
    }
}
