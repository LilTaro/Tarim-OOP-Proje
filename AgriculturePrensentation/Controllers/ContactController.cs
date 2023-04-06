using BusinessLayer.Abstract;
using BusinessLayer.ValidationRules;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace AgriculturePrensentation.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;
        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        public IActionResult Index()
        {
            var values = _contactService.GetListAll();
            return View(values);
        }
        public IActionResult DeleteMessage(int id)
        {
            var values = _contactService.getbyID(id);
            _contactService.Delete(values);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult MessageDetails(int id) 
        { 
            var values= _contactService.getbyID(id);
            return View(values);
        }
    }
}
