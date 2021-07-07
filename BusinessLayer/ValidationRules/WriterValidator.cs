using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidator: AbstractValidator<Writer>
    {
        public WriterValidator() //kuralları manage nuget paket validation indirerek olusturulur
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Yazar Adı Boş geçilemez");
            RuleFor(x => x.WriterSurname).NotEmpty().WithMessage("Soyadı  boş geçilemez");
            //RuleFor(x => x.WriterAbout.Contains('a')).NotEmpty().WithMessage("Hakkında kısmı boş geçilemez  ");
            RuleFor(x => x.UserName).MinimumLength(3).WithMessage("Yazar İsmi en az 3 Karakter içermelidir");
            RuleFor(x => x.WriterTitle).NotEmpty().WithMessage("Ünvan boş geçilemez");
            RuleFor(x => x.WriterSurname).MaximumLength(50).WithMessage("Kategori ismi en fazla 50 karakter içermelidir");
        }
    }
}
