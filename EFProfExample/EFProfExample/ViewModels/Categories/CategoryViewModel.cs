using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EFProfExample.ViewModels.Categories
{
    public class CategoryViewModel
    {
        public string Name { get; set; }

        public IEnumerable<ProductViewModel> Products { get; set; }
    }
}