using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using EFProfExample.Repositories;
using EFProfExample.ViewModels.Categories;

namespace EFProfExample.Controllers
{
    public class CategoriesController : Controller
    {
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

        public CategoriesController(Lazy<ICategoryRepository> categoryRepository,
            Lazy<IMapper> mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        // GET: Categories
        public ActionResult Index()
        {
            var categories = CategoryRepository.GetAllActive(1, 10);

            return View(categories);
        }

        public ActionResult LazyLoading()
        {
            var categories = CategoryRepository.GetAllActive();

            var viewModel = Mapper.Map<IEnumerable<CategoryViewModel>>(categories);

            return Json(viewModel, JsonRequestBehavior.AllowGet);
        }

        public ActionResult EarlyLoading()
        {
            var categories = CategoryRepository.GetAllActiveWithProducts();

            var viewModel = Mapper.Map<IEnumerable<CategoryViewModel>>(categories);

            return Json(viewModel, JsonRequestBehavior.AllowGet);
        }
    }
}