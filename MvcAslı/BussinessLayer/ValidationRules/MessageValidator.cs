using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.ValidationRules
{
    public class MessageValidator:AbstractValidator<Message>

    {
        public MessageValidator()
        {
            RuleFor(x => x.ReceiverMail).NotEmpty().WithMessage("boş geçilemez");
            RuleFor(x => x.SenderMail).NotEmpty().WithMessage("boş geçilemez");
            RuleFor(x => x.SenderMail).MinimumLength(3).WithMessage("en az 3 karakter giriniz");
            //RuleFor(x => x.Subject).MaximumLength(1000).WithMessage("20 karakterden fazla giremezsiniz");
            RuleFor(x => x.ReceiverMail).NotEmpty().WithMessage("açıklamayı boş geçemezsiniz");
           // RuleFor(x => x.Subject).MinimumLength(3).WithMessage("en az 3 karakter giriniz");
        }
    }
}
