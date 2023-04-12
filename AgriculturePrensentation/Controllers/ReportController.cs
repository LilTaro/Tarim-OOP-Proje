using AgriculturePrensentation.Models;
using ClosedXML.Excel;
using DataAccessLayer.Context;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AgriculturePrensentation.Controllers
{
    public class ReportController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult StaticReport()
        {
            ExcelPackage excel = new ExcelPackage();
            var workbook = excel.Workbook.Worksheets.Add("Dosya 1");
            workbook.Cells[1, 1].Value = "Ürün Adı";
            workbook.Cells[1,2].Value = "Ürün Kategorisi";
            workbook.Cells[1,3].Value = "Ürün Stok";

            workbook.Cells[2, 1].Value = "Mercimek";
            workbook.Cells[2, 2].Value = "Bakliyat";
            workbook.Cells[2, 3].Value = "23 Ton";

            workbook.Cells[3, 1].Value = "Buğday";
            workbook.Cells[3, 2].Value = "Bakliyat";
            workbook.Cells[3, 3].Value = "88 Ton";

            workbook.Cells[4, 1].Value = "Arpa";
            workbook.Cells[4, 2].Value = "Bakliyat";
            workbook.Cells[4, 3].Value = "93 Ton";

            workbook.Cells[5, 1].Value = "Pirinç";
            workbook.Cells[5, 2].Value = "Bakliyat";
            workbook.Cells[5, 3].Value = "15 Ton";

            workbook.Cells[6, 1].Value = "Mısır";
            workbook.Cells[6, 2].Value = "Sebze";
            workbook.Cells[6, 3].Value = "49 Ton";

            var bytes = excel.GetAsByteArray();
            return File(bytes,"application/vnd.openxmlformats-officedocument.spreadsheetml.sheet","BakliyatRaporu.xlsx");
        }

        public List<ContactModel> ContactList()
        {
            List<ContactModel> contactModels = new List<ContactModel>();
            using (var context = new AgricultureContext())
            {
                contactModels = context.Contacts.Select(X => new ContactModel
                {
                    ContactID=X.ContactID,
                    ContactName=X.Name,
                    ContactDateTime=X.Date,
                    ContactMail=X.Mail,
                    ContactDetails=X.Message
                }).ToList();
            }
            return contactModels;
        }
        public IActionResult ContactReport()
        {
            using (var workBook = new XLWorkbook())
            {
                var workSheet = workBook.Worksheets.Add("Mesaj Listesi");
                workSheet.Cell(1, 1).Value = "Mesaj ID";
				workSheet.Cell(1, 2).Value = "Mesaj Gönderen";
				workSheet.Cell(1, 3).Value = "Mail Adresi";
				workSheet.Cell(1, 4).Value = "Mesaj İçeriği";
				workSheet.Cell(1, 5).Value = "Mesaj Tarihi";

                int contactRowCount = 2;
                foreach (var item in ContactList())
                {
                    workSheet.Cell(contactRowCount, 1).Value = item.ContactID;
                    workSheet.Cell(contactRowCount, 2).Value = item.ContactName;
                    workSheet.Cell(contactRowCount, 3).Value = item.ContactMail;
                    workSheet.Cell(contactRowCount, 4).Value = item.ContactDetails;
                    workSheet.Cell(contactRowCount, 5).Value = item.ContactDateTime;
                    contactRowCount++;
                }
                using (var stream = new MemoryStream())
                {
                    workBook.SaveAs(stream);
                    var contact = stream.ToArray();
                    return File(contact, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet","MesajRaporu.xlsx");
                }
			}
        }
		public List<AnnouncementModel> AnnouncementList()
		{
			List<AnnouncementModel> announcementModels = new List<AnnouncementModel>();
			using (var context = new AgricultureContext())
			{
                announcementModels = context.Announcements.Select(X => new AnnouncementModel
                {
                    AnnouncementID = X.AnnouncementID,
                    Status = X.Status,
                    Date = X.Date,
                    Desc = X.Description,
                    Title = X.Title,
                }).ToList();
			}
			return announcementModels;
		}
		public IActionResult AnnouncementReport()
		{
			using (var workBook = new XLWorkbook())
			{
				var workSheet = workBook.Worksheets.Add("Duyuru Listesi");
				workSheet.Cell(1, 1).Value = "Duyuru ID";
				workSheet.Cell(1, 2).Value = "Duyuru Başlık";
				workSheet.Cell(1, 3).Value = "Duyuru İçeriği";
				workSheet.Cell(1, 4).Value = "Duyuru Tarihi";
				workSheet.Cell(1, 5).Value = "Durum";
               
				int contactRowCount = 2;
				foreach (var item in AnnouncementList())
				{
					workSheet.Cell(contactRowCount, 1).Value = item.AnnouncementID;
					workSheet.Cell(contactRowCount, 2).Value = item.Title;
					workSheet.Cell(contactRowCount, 3).Value = item.Desc;
					workSheet.Cell(contactRowCount, 4).Value = item.Date;
					workSheet.Cell(contactRowCount, 5).Value = item.Status;
					contactRowCount++;
				}
				using (var stream = new MemoryStream())
				{
					workBook.SaveAs(stream);
					var contact = stream.ToArray();
					return File(contact, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "DuyuruRaporu.xlsx");
				}
			}
		}
	}
}
