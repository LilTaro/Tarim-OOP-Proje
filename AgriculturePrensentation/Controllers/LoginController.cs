using AgriculturePrensentation.Models;
using DocumentFormat.OpenXml.Office2010.ExcelAc;
using DocumentFormat.OpenXml.Office2021.DocumentTasks;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AgriculturePrensentation.Controllers
{
	[AllowAnonymous]
	public class LoginController : Controller
	{
		private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

		public LoginController(UserManager<AppUser> userManager,SignInManager<AppUser> signInManager) 
		{
            _signInManager = signInManager;
			_userManager = userManager;
		}
        [HttpGet]
		public IActionResult Index()
		{
			return View();
		}
        [HttpPost]
        public async Task<IActionResult> Index(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(loginViewModel.username, loginViewModel.password, false, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Dashboard");
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            return View();
        }


		[HttpGet]
		public IActionResult SignUp()
		{
			return View();
		}
		[HttpPost]
        public async Task<IActionResult> SignUp(RegisterViewModel registerViewModel)
        {
            AppUser identityUser = new AppUser()
            {
                UserName = registerViewModel.UserName,
                Email = registerViewModel.Mail
            };
            if (registerViewModel.password == registerViewModel.PasswordConfirm)
            {
                var result = await _userManager.CreateAsync(identityUser, registerViewModel.password);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return View(registerViewModel);
        }
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Login");
        }
    }
}
