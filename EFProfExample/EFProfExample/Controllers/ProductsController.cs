using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Bogus;
using EFProfExample.Models;
using EFProfExample.Repositories;
using EFProfExample.ViewModels.Products;

namespace EFProfExample.Controllers
{
    public class ProductsController : Controller
    {
        private Lazy<IProductRepository> _productRepository;

        protected IProductRepository ProductRepository
        {
            get { return _productRepository.Value; }
        }

        private Lazy<ICategoryRepository> _categoryRepository;

        protected ICategoryRepository CategoryRepository
        {
            get { return _categoryRepository.Value; }
        }

        private Lazy<IMapper> _mapper;

        protected IMapper Mapper
        {
            get { return _mapper.Value; }
        }

        public ProductsController(Lazy<IProductRepository> productRepository,
            Lazy<ICategoryRepository> categoryRepository,
            Lazy<IMapper> mapper)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        // GET: Products
        public ActionResult Index()
        {
            var products = ProductRepository.GetAllActive();

            var viewModels = Mapper.Map<IEnumerable<ProductViewModel>>(products);

            return Json(viewModels, JsonRequestBehavior.AllowGet);
        }

        public ActionResult IndexWithPagination()
        {
            var products = ProductRepository.GetAllActive(1, 20);

            var viewModels = Mapper.Map<IEnumerable<ProductViewModel>>(products);

            return Json(viewModels, JsonRequestBehavior.AllowGet);
        }

        public ActionResult TwoDataContext()
        {
            var categories = CategoryRepository.GetAllActive(1, 10);

            var products = ProductRepository.GetAllActive(1, 10);

            return Content("Done");
        }
    }
}