using BusinessLayer.Abstract;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace AgriculturePrensentation.Controllers
{
    public class ImageController : Controller
    {
        private readonly IImageService _ImageService;

        public ImageController(IImageService ImageService)
        {
            _ImageService = ImageService;
        }

        public IActionResult Index()
        {
            var values = _ImageService.GetListAll();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddImage()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddImage(Image P)
        {
            ImageValidator imageValidator = new ImageValidator();
            ValidationResult result = imageValidator.Validate(P);
            if (result.IsValid)
            {
                _ImageService.Insert(P);
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
        public IActionResult DeleteImage(int id)
        {
            var values = _ImageService.getbyID(id);
            _ImageService.Delete(values);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult EditImage(int id)
        {
            var values = _ImageService.getbyID(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult EditImage(Image P)
        {
            ImageValidator imageValidator = new ImageValidator();
            ValidationResult result = imageValidator.Validate(P);
            if (result.IsValid)
            {
                _ImageService.Update(P);
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
