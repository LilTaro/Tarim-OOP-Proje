using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class AddressValidator:AbstractValidator<Address>
    {
        public AddressValidator()
        {
            RuleFor(X => X.Description1).NotEmpty().WithMessage("Açıklama1 Boş Geçilemez");
            RuleFor(X => X.Description2).NotEmpty().WithMessage("Açıklama2 Boş Geçilemez");
            RuleFor(X => X.Description3).NotEmpty().WithMessage("Açıklama3 Boş Geçilemez");
            RuleFor(X => X.Description4).NotEmpty().WithMessage("Açıklama4 Boş Geçilemez");
            RuleFor(X => X.MapInfo).NotEmpty().WithMessage("Harita Bilgisi Boş Geçilemez");
            RuleFor(X => X.Description1).MaximumLength(25).WithMessage("Lütfen En Fazla 25 Karakter Giriniz");
            RuleFor(X => X.Description2).MaximumLength(25).WithMessage("Lütfen En Fazla 25 Karakter Giriniz");
            RuleFor(X => X.Description3).MaximumLength(25).WithMessage("Lütfen En Fazla 25 Karakter Giriniz");
            RuleFor(X => X.Description4).MaximumLength(25).WithMessage("Lütfen En Fazla 25 Karakter Giriniz");

        }
    }
}
