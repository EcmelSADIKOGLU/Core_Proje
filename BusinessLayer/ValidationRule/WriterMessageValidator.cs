using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRule
{
    public class WriterMessageValidator:AbstractValidator<WriterMessage>
    {
        public WriterMessageValidator()
        {
            RuleFor(x => x.Receiver).NotEmpty().WithMessage("Alıcının mail adresini giriniz.");
            RuleFor(x => x.ReceiverName).NotEmpty().WithMessage("Alıcının adını giriniz.");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Mesajın konusu boş geçilemez.");
            RuleFor(x => x.Subject).MaximumLength(50).WithMessage("Mesajın konusu 50 karakterden fazla olamaz.");
            RuleFor(x => x.MessageContent).NotEmpty().WithMessage("Mesajın içeriği boş geçilemez.");
            RuleFor(x => x.MessageContent).MinimumLength(10).WithMessage("Mesajın içeriği 10 karakterden az olamaz.");

        }
    }
}
