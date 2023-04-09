using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace AgriculturePrensentation.ViewComponents
{
	public class _ServicePartial:ViewComponent
	{
		private readonly IServiceService _service;

		public _ServicePartial(IServiceService service)
		{
			_service = service;
		}

		public IViewComponentResult Invoke()
		{
			var values = _service.GetListAll();
			return View(values);
		}
	}
}
