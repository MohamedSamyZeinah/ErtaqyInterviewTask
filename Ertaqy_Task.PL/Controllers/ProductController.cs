using Ertaqy_Task.BLL.Contract;
using Ertaqy_Task.BLL.DTOs;
using Ertaqy_Task.PL.ActionRequests;
using Ertaqy_Task.PL.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Ertaqy_Task.PL.Controllers
{
    public class ProductController : Controller
    {
        #region Fields
        private readonly IProductService _productService;
        private readonly IServiceProviderService _serviceProviderService;
        #endregion

        #region Constructor
        public ProductController(IProductService productService, IServiceProviderService serviceProviderService)
        {
            _productService = productService;
            _serviceProviderService = serviceProviderService;
        }
        #endregion

        #region Actions
        public IActionResult Index()
        {
            var products = _productService.GetAll();
            var productVM = products.Select(p => new ProductVM
            {
                Id = p.Id,
                ProductName = p.PrdctName,
                ProductPrice = p.PrdctPrice,
                ProviderId = p.ProviderId,
                CreationDate = p.CreationDate
            });
            return View(productVM);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var providersList = _serviceProviderService.GetAll();
            ViewData["providersList"] = providersList;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateProductAR createProductAR)
        {
            #region Before Vaidation
            //var productDto = new ProductDto
            //{
            //    PrdctName = createProductAR.ProductName,
            //    PrdctPrice = createProductAR.ProductPrice,
            //    ProviderId = createProductAR.ProviderId,
            //    CreationDate = DateTime.Now,
            //};
            //_productService.Create(productDto);
            //return RedirectToAction(nameof(Index)); 
            #endregion 

            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "Please correct the errors and try again.");
                return View(createProductAR);
            }

            var productDto = new ProductDto
            {
                PrdctName = createProductAR.ProductName,
                PrdctPrice = createProductAR.ProductPrice,
                ProviderId = createProductAR.ProviderId,
                CreationDate = DateTime.Now
            };
            int rowsAffected = _productService.Create(productDto);

            if (rowsAffected > 0)
            {
                TempData["SuccessMessage"] = "Product created successfully";
                return RedirectToAction(nameof(Index));
            }

            ModelState.AddModelError(string.Empty, "Failed to create product. Please try again.");

            return View(createProductAR);
        }

        #endregion
    }
}
