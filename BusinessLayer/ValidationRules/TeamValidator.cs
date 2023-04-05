using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class TeamValidator : AbstractValidator<Team>
    {
        public TeamValidator()
        {
            RuleFor(X => X.PersonName).NotEmpty().WithMessage("İsim Boş Geçilemez");
            RuleFor(X => X.Title).NotEmpty().WithMessage("Görev Kısmı Boş Geçilemez");
            RuleFor(X => X.ImageUrl).NotEmpty().WithMessage("Resim Yolu Boş Geçilemez");
            RuleFor(X => X.PersonName).MaximumLength(50).WithMessage("Lütfen 50 Karakterden Daha Az Veri Girişi Yapın");
            RuleFor(X => X.PersonName).MinimumLength(5).WithMessage("Lütfen 5 Karakteden Daha Fazla Veri Giriş Yapın");
            RuleFor(X => X.Title).MaximumLength(50).WithMessage("Lütfen 50 Karakterden Daha Az Veri Girişi Yapın");
            RuleFor(X => X.Title).MinimumLength(3).WithMessage("Lütfen 3 Karakteden Daha Fazla Veri Giriş Yapın");

        }
    }
}
