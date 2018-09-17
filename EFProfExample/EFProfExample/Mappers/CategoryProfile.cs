using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using EFProfExample.Models;
using EFProfExample.ViewModels.Categories;

namespace EFProfExample.Mappers
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryViewModel>();

            CreateMap<Product, ProductViewModel>();
        }
    }
}