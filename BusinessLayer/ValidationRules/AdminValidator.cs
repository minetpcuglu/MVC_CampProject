using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
   public class AdminValidator:AbstractValidator<Admin>
    {
        public AdminValidator() //kuralları manage nuget paket validation indirerek olusturulur
        {
            RuleFor(x => x.AdminName).NotEmpty().WithMessage("Mail Adresi Boş geçilemez");
            RuleFor(x => x.AdminPassword).NotEmpty().WithMessage("Parola  Boş geçilemez");
            RuleFor(x => x.RoleId).NotEmpty().WithMessage("Rol Boş geçilemez");
           
           
            
        }
    }
}
