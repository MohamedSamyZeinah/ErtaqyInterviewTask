using Ertaqy_Task.BLL.Contract;
using Ertaqy_Task.BLL.DTOs;
using Ertaqy_Task.PL.ActionRequests;
using Ertaqy_Task.PL.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Ertaqy_Task.PL.Controllers
{
    public class ServiceProviderController : Controller
    {
        #region Fields
        private readonly IServiceProviderService _serviceProviderService;
        #endregion

        #region Constructor
        public ServiceProviderController(IServiceProviderService serviceProviderService)
        {
            _serviceProviderService = serviceProviderService;
        }
        #endregion

        #region Actions
        [HttpGet]
        public IActionResult Index()
        {
            var data = _serviceProviderService.GetAll();
            var providerVMlist = data.Select(sp => new ServiceProviderVM
            {
                Id = sp.Id,
                ProviderName = sp.ProviderName,
                ProviderEmail = sp.ProviderEmail,
                ProviderPhoneNumber = sp.ProviderPhoneNumber,
                ProviderAddress = sp.ProviderAddress
            });
            return View(providerVMlist);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateServicePrviderAR proviserActionRequest)
        {
            if (ModelState.IsValid)
            {
                var providerDto = new ServiceProviderDto
                {
                    ProviderName = proviserActionRequest.ProviderName,
                    ProviderEmail = proviserActionRequest.ProviderEmail,
                    ProviderPhoneNumber = proviserActionRequest.ProviderPhoneNumber,
                    ProviderAddress = proviserActionRequest.ProviderAddress
                };
                _serviceProviderService.Create(providerDto);
                return RedirectToAction(nameof(Index));
            }
            ModelState.AddModelError(string.Empty, "Invalid Data");

            return View(proviserActionRequest);

        }
        #endregion
    }
}
