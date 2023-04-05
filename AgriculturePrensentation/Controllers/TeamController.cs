using BusinessLayer.Abstract;
using BusinessLayer.ValidationRules;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace AgriculturePrensentation.Controllers
{
    public class TeamController : Controller
    {
        private readonly ITeamService _teamService;

        public TeamController(ITeamService teamService)
        {
            _teamService = teamService;
        }

        public IActionResult Index()
        {
            var values=_teamService.GetListAll();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddTeam() 
        { 
            return View();
        }
        [HttpPost]
        public IActionResult AddTeam(Team P) 
        { 
            TeamValidator teamValidator = new TeamValidator();
            ValidationResult result = teamValidator.Validate(P);
            if (result.IsValid)
            {
                _teamService.Insert(P);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
        public IActionResult DeleteTeam(int id)
        {
            var values = _teamService.getbyID(id);
            _teamService.Delete(values);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult EditTeam(int id)
        {
            var values = _teamService.getbyID(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult EditTeam(Team P)
        {
            TeamValidator teamValidator = new TeamValidator();
            ValidationResult result = teamValidator.Validate(P);
            if (result.IsValid)
            {
                _teamService.Update(P);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
    }
}
