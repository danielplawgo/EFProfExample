﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EFProfExample.Models
{
    public class Product : BaseModel
    {
        public string Name { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
    }
}