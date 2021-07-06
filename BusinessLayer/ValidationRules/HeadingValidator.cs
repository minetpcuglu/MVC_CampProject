using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
   public  class HeadingValidator:AbstractValidator<Heading>
    {

        public HeadingValidator() //kuralları manage nuget paket validation indirerek olusturulur
        {
            RuleFor(x => x.Category.CategoryName).NotEmpty().WithMessage("Kategori Boş geçilemez");
            RuleFor(x => x.HeadingName).NotEmpty().WithMessage("Başlık  Boş geçilemez");
            RuleFor(x => x.Writer.UserName).NotEmpty().WithMessage("Yazar boş geçilemez");


        }
    }
}
