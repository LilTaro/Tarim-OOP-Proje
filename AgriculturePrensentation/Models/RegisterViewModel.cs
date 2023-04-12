using System.ComponentModel.DataAnnotations;

namespace AgriculturePrensentation.Models
{
	public class RegisterViewModel
	{
		[Required(ErrorMessage = "Lütfen Kullanıcı Adını Giriniz")]
		public string UserName { get; set; }
		[Required(ErrorMessage = "Lütfen Şifrenizi Giriniz")]
		public string password { get; set; }
		[Required(ErrorMessage = "Lütfen Şifrenizi Tekrar Giriniz")]
		[Compare("password", ErrorMessage = "Şifreler Uygun Değil")]
		public string PasswordConfirm { get; set; }
		[Required(ErrorMessage = "Lütfen Mail Adresinizi Giriniz")]
		public string Mail { get; set; }
	}
}
