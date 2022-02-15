using EntityLayer.Concreate;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.ValidationRules
{
   public class WriterValidator:AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("yazar adını boş geçemezsiniz");
            RuleFor(x => x.WriterSurname).NotEmpty().WithMessage("yazar soyadını boş geçemezsiniz");
            RuleFor(x => x.WriterAbout).NotEmpty().WithMessage("hakkımda kısmını boş geçemezsiniz");
            RuleFor(x => x.WriterSurname).MinimumLength(3).WithMessage("en az 3 karakter giriniz");
            RuleFor(x => x.WriterTittle).NotEmpty().WithMessage("yazar başlık alanını boş geçemezsiniz");
            RuleFor(x => x.WriterSurname).MaximumLength(200).WithMessage("200 karakterden fazla giremezsiniz");
        }
    }
}
