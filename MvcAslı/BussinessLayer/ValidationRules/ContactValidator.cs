using EntityLayer.Concreate;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.ValidationRules
{
    public class ContactValidator:AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(x => x.UserMail).NotEmpty().WithMessage("mail adresini boş geçemezsiniz");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("açıklamayı boş geçemezsiniz");
            RuleFor(x => x.UserName).MinimumLength(3).WithMessage("en az 3 karakter giriniz");
            RuleFor(x => x.Subject).MaximumLength(3).WithMessage("20 karakterden fazla giremezsiniz");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("açıklamayı boş geçemezsiniz");
            RuleFor(x => x.Subject).MinimumLength(50).WithMessage("20 karakterden fazla giremezsiniz");

        }
    }
}
