using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace AgriculturePrensentation.ViewComponents
{
    public class _DashBoardTablePartial:ViewComponent
    {
        private readonly IContactService _contactService;

		public _DashBoardTablePartial(IContactService contactService)
		{
			_contactService = contactService;
		}

		public IViewComponentResult Invoke()
        {
            var values = _contactService.GetListAll();
            return View(values);
        }
    }
}
