using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace AgriculturePrensentation.ViewComponents
{
	public class _SocialMediaPartial:ViewComponent
	{
		private readonly ISocialMediaService _service;

		public _SocialMediaPartial(ISocialMediaService service)
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
