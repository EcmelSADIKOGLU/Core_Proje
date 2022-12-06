using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRule
{
    public class PortfolioValidator:AbstractValidator<Portfolio>
    {
        public PortfolioValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Proje ismi boş geçilemez.");
            RuleFor(x => x.ImageURL).NotEmpty().WithMessage("Görsel alanı boş geçilemez.");
            RuleFor(x => x.ImageURL2).NotEmpty().WithMessage("Görsel alanı boş geçilemez.");
            RuleFor(x => x.Price).NotEmpty().WithMessage("Fiyat alanı boş geçilemez.");
            RuleFor(x => x.Value).NotEmpty().WithMessage("Değer alanı boş geçilemez.");


            RuleFor(x => x.Name).MinimumLength(5).WithMessage("Proje ismi en az 5 karakter içermeli.");
            RuleFor(x => x.ImageURL).MinimumLength(5).WithMessage("Proje ismi en az 5 karakter içermeli.");
            RuleFor(x => x.ImageURL2).MinimumLength(5).WithMessage("Proje ismi en az 5 karakter içermeli.");
            RuleFor(x => x.Price).MinimumLength(5).WithMessage("Proje ismi en az 5 karakter içermeli.");
            //RuleFor(x => x.Value).LessThan(0).WithMessage("Değer 0-100 aralığında girilmeli.");


            RuleFor(x => x.Name).MaximumLength(50).WithMessage("Proje ismi en fazla 505 karakter içermeli.");
            RuleFor(x => x.ImageURL).MaximumLength(300).WithMessage("Proje ismi en fazla 300 karakter içermeli.");
            RuleFor(x => x.ImageURL2).MaximumLength(300).WithMessage("Proje ismi en fazla 300 karakter içermeli.");
            RuleFor(x => x.Price).MaximumLength(50).WithMessage("Proje ismi en fazla 50 karakter içermeli.");
            //RuleFor(x => x.Value).GreaterThan(100).WithMessage("Değer 0-100 aralığında girilmeli.");

        }
    }
}
