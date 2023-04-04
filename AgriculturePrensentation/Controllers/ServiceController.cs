using AgriculturePrensentation.Models;
using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace AgriculturePrensentation.Controllers
{
	public class ServiceController : Controller
	{
		private readonly IServiceService _serviceService;

		public ServiceController(IServiceService serviceService)
		{
			_serviceService = serviceService;
		}

		public IActionResult Index()
		{
			var values = _serviceService.GetListAll();
			return View(values);
		}
		[HttpGet]
		public IActionResult AddService() 
		{ 
			return View(new ServiceAddViewModel());
		}
		[HttpPost]
		public IActionResult AddService(ServiceAddViewModel model) 
		{
			if (ModelState.IsValid)
			{
				_serviceService.Insert(new Service()
				{
					ServiceTitle = model.ServiceTitle,
					ServiceDesc = model.ServiceDesc,
					ServiceImage = model.ServiceImage
				});
				return RedirectToAction("Index");
			}
			return View(model);
		}
		public IActionResult DeleteService(int id) 
		{
			var values = _serviceService.getbyID(id);
			_serviceService.Delete(values);
			return RedirectToAction("Index");
		}
		[HttpGet]
		public IActionResult EditService(int id) 
		{
			var values= _serviceService.getbyID(id);
			return View(values);
		}
		[HttpPost]
        public IActionResult EditService(Service P)
        {
            _serviceService.Update(P);
			return RedirectToAction("Index");
        }
    }
}
