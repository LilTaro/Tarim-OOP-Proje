using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace AgriculturePrensentation.ViewComponents
{
	public class _GalleryPartial:ViewComponent
	{
		private readonly IImageService _ImageService;

		public _GalleryPartial(IImageService ImageService)
		{
			_ImageService = ImageService;
		}

		public IViewComponentResult Invoke()
		{
			var values = _ImageService.GetListAll();
			return View(values);
		}
	}
}
