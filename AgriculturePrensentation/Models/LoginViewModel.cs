﻿using System.ComponentModel.DataAnnotations;

namespace AgriculturePrensentation.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Lütfen Kullanıcı Adını Girin")]
        public string username { get; set; }
        [Required(ErrorMessage = "Lütfen Şifrenizi Girin")]
        public string password { get; set; }
    }
}
