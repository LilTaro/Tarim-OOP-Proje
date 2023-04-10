using DataAccessLayer.Context;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace AgriculturePrensentation.ViewComponents
{
    public class _DashBoardOverviewPartial:ViewComponent
    {
        AgricultureContext c = new AgricultureContext();
        public IViewComponentResult Invoke()
        {
			ViewBag.TeamCount = c.Teams.Count();
			ViewBag.ServiceCount = c.Services.Count();
			ViewBag.messageCount = c.Contacts.Count();
			ViewBag.currentMonthMessage = c.Contacts.Where(x => x.Date.Month == DateTime.Now.Month).Count();
            ViewBag.AnnouncementTrue = c.Announcements.Where(X => X.Status == true).Count();
			ViewBag.AnnouncementFalse = c.Announcements.Where(X => X.Status == false).Count();
            ViewBag.urunPazarlama = c.Teams.Where(X => X.Title == "Ürün Pazarlama").Select(Y => Y.PersonName).FirstOrDefault();
			ViewBag.bakliyatYonetimi = c.Teams.Where(X => X.Title == "Bakliyat Yönetimi").Select(Y => Y.PersonName).FirstOrDefault();
			ViewBag.sutUretici = c.Teams.Where(X => X.Title == "Süt Üreticisi").Select(Y => Y.PersonName).FirstOrDefault();
			ViewBag.gubreYonetimi = c.Teams.Where(X => X.Title == "Gübre Yönetimi").Select(Y => Y.PersonName).FirstOrDefault();

			return View();
        }
    }
}
