using System;

namespace AgriculturePrensentation.Models
{
	public class AnnouncementModel
	{
        public int AnnouncementID { get; set; }
        public string Title { get; set; }
        public string Desc { get; set; }
        public DateTime Date { get; set; }
        public bool Status { get; set; }
    }
}
