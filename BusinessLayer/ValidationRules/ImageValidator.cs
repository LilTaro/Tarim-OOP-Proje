using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class ImageValidator : AbstractValidator<Image>
    {
        public ImageValidator()
        {
            RuleFor(X => X.Title).NotEmpty().WithMessage("Başlık Boş Bırakılamaz");
            RuleFor(X => X.Description).NotEmpty().WithMessage("Açıklama Boş Bırakılamaz");
            RuleFor(X => X.ImageUrl).NotEmpty().WithMessage("Görsel Yolu Boş Bırakılamaz");
            RuleFor(X => X.Title).MaximumLength(20).WithMessage("Lütfen En Fazla 20 Karakter Giriniz");
            RuleFor(X => X.Title).MinimumLength(8).WithMessage("Lütfen En Az 8 Karakter Giriniz");
            RuleFor(X => X.Description).MaximumLength(50).WithMessage("Lütfen En Fazla 50 Karakter Giriniz");
            RuleFor(X => X.Description).MinimumLength(20).WithMessage("Lütfen En Az 20 Karakter Giriniz");
        }
    }
}
