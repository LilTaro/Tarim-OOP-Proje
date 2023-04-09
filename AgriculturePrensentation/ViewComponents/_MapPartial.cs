using DataAccessLayer.Context;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace AgriculturePrensentation.ViewComponents
{
	public class _MapPartial:ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			AgricultureContext context = new AgricultureContext();
			var values = context.Addresses.Select(X => X.MapInfo).FirstOrDefault();
			ViewBag.V = values;
			return View();
		}
	}
}
