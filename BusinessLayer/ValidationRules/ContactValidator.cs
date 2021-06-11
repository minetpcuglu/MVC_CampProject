using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class ContactValidator:AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(x => x.UserMail).NotEmpty().WithMessage("Mail adresini boş geçilemez");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu Adı Boş geçilemez");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanıcı adı boş geçilemez");
            RuleFor(x => x.UserName).MinimumLength(3).WithMessage("Kullanıcı  İsmi en az 3 Karakter içermelidir");
            RuleFor(x => x.Subject).MaximumLength(20).WithMessage("Konu ismi en fazla 20 karakter içermelidir");
        }
    }
}
