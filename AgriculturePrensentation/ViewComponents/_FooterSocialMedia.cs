using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace AgriculturePrensentation.ViewComponents
{
	public class _FooterSocialMedia:ViewComponent
	{
		private readonly ISocialMediaService _socialMediaService;

		public _FooterSocialMedia(ISocialMediaService socialMediaService)
		{
			_socialMediaService = socialMediaService;
		}

		public IViewComponentResult Invoke()
		{
			var values = _socialMediaService.GetListAll();
			return View(values);
		}
	}
}
