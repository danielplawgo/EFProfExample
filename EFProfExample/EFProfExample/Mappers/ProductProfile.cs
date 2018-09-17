using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using EFProfExample.Models;
using EFProfExample.ViewModels.Products;

namespace EFProfExample.Mappers
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductViewModel>();
        }
    }
}