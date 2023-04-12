using AgriculturePrensentation.Models;
using DocumentFormat.OpenXml.Office2021.DocumentTasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AgriculturePrensentation.Controllers
{
    public class ProfileController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;

        public ProfileController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            UserEditViewModel userEditViewModel = new UserEditViewModel();
            userEditViewModel.Mail = values.Email;
            userEditViewModel.Phone = values.PhoneNumber;
            return View(userEditViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserEditViewModel P)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            if (P.password == P.confirmPasword)
            {
                values.Email = P.Mail;
                values.PhoneNumber = P.Phone;
                values.PasswordHash = _userManager.PasswordHasher.HashPassword(values, P.password);
                var result= await _userManager.UpdateAsync(values);
                if (result.Succeeded) 
                {
                    return RedirectToAction("Index", "Login");
                }
            }
            return View();
        }
    }
}
