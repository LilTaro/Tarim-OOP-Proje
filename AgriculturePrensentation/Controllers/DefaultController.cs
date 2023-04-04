using BusinessLayer.Concrete;
using DataAccessLayer.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace AgriculturePrensentation.Controllers
{
    public class DefaultController : Controller
    {
        ServiceManager serviceManager = new ServiceManager(new EFServiceDal());
        public IActionResult Index()
        {
            var values = serviceManager.GetListAll();
            return View(values);
        }
    }
}
