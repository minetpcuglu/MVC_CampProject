using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class CategoryValidator:AbstractValidator<Category>
    {
        public CategoryValidator() //kuralları manage nuget paket validation indirerek olusturulur
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Kategori İsmi Boş geçilemez");
            RuleFor(x => x.CategoryDescription).NotEmpty().WithMessage("Açıklama alanı boş geçilemez");
            RuleFor(x => x.CategoryName).MinimumLength(3).WithMessage("Kategori İsmi en az 3 Karakter içermelidir");
            RuleFor(x => x.CategoryName).MaximumLength(20).WithMessage("Kategori ismi en fazla 20 karakter içermelidir");
        }
    }
}
