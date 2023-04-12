using System;

namespace AgriculturePrensentation.Models
{
	public class ContactModel
	{
		public int ContactID { get; set; }
        public string ContactName { get; set; }
        public string ContactMail { get; set; }
		public string ContactDetails { get; set; }
		public DateTime ContactDateTime { get; set; }
	}
}
