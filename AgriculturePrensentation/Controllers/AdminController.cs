using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace AgriculturePrensentation.Controllers
{
	public class AdminController : Controller
	{
		private readonly IAdminService _adminService;

		public AdminController(IAdminService adminService)
		{
			_adminService = adminService;
		}

		public IActionResult Index()
		{
			var values = _adminService.GetListAll();
			return View(values);
		}
		[HttpGet]
        public IActionResult AddAdmin()
        {
           return View();
        }
		[HttpPost]
        public IActionResult AddAdmin(Admin P)
		{
			_adminService.Insert(P);
			return RedirectToAction("Index");
		}
		[HttpGet]
		public IActionResult EditAdmin(int id) 
		{
			var values = _adminService.getbyID(id);
			return View(values);
		}
		[HttpPost]
		public IActionResult EditAdmin(Admin P)
		{
			_adminService.Update(P);
			return RedirectToAction("Index");
		}
		public IActionResult DeleteAdmin(int id)
		{
			var values = _adminService.getbyID(id);
			_adminService.Delete(values);
			return RedirectToAction("Index");
		}
	}
}
