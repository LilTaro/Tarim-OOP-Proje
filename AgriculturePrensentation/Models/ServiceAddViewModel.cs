using System.ComponentModel.DataAnnotations;

namespace AgriculturePrensentation.Models
{
    public class ServiceAddViewModel
    {
        [Display(Name = "Başlık")]
        [Required(ErrorMessage = "Başlık Boş Geçilemez")]
        public string ServiceTitle { get; set; }

        [Display(Name = "Açıklama")]
        [Required(ErrorMessage = "Açıklama Boş Geçilemez")]
        public string ServiceDesc { get; set; }

        [Display(Name = "Görsel")]
        [Required(ErrorMessage = "Görsel Boş Geçilemez")]
        public string ServiceImage { get; set; }
    }
}
