using Microsoft.AspNetCore.Mvc;

namespace AgriculturePrensentation.ViewComponents
{
	public class _AnnouncementPartial:ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
