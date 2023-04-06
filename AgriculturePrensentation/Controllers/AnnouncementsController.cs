using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient.DataClassification;
using System;

namespace AgriculturePrensentation.Controllers
{
    public class AnnouncementsController : Controller
    {
        private readonly IAnnouncementService _announcementService;

        public AnnouncementsController(IAnnouncementService announcementService)
        {
            _announcementService = announcementService;
        }

        public IActionResult Index()
        {
            var values = _announcementService.GetListAll();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddAnnouncement()
        { 
            return View();
        }
        [HttpPost]
        public IActionResult AddAnnouncement(Announcement P)
        {
            P.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            P.Status = false;
            _announcementService.Insert(P);
            return RedirectToAction("Index");
        }
        public IActionResult DeleteAnnouncement(int id)
        {
            var values= _announcementService.getbyID(id);
            _announcementService.Delete(values);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult EditAnnouncement(int id)
        {
            var values = _announcementService.getbyID(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult EditAnnouncement(Announcement P)
        {
            _announcementService.Update(P);
            return RedirectToAction("Index");
        }
        public IActionResult ChangeStatusToTrue(int id)
        {
            _announcementService.AnnouncementStatusTrue(id);
            return RedirectToAction("Index");
        }
        public IActionResult ChangeStatusToFalse(int id)
        {
            _announcementService.AnnouncementStatusFalse(id);
            return RedirectToAction("Index");
        }
    }
}
