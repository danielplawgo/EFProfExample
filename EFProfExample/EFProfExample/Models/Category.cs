using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EFProfExample.Models
{
    public class Category : BaseModel
    {
        public string Name { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}