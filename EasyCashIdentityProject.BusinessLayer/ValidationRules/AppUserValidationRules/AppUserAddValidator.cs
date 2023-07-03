using System;
using FluentValidation;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyCashIdentityProject.DtoLayer.Dtos.AppUserDtos;

namespace EasyCashIdentityProject.BusinessLayer.ValidationRules.AppUserValidationRules
{
    public class AppUserAddValidator:AbstractValidator<AppUserAddDto>
    {
        //ctro tab+tab yazınca constructer otomatik açılır.
        public AppUserAddValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Ad alanı boş geçilemez.");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Soyad alanı boş geçilemez.");
            RuleFor(x => x.Username).NotEmpty().WithMessage("Kullanıcı adı alanı boş geçilemez.");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Mail adresi alanı boş geçilemez.");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Şifre alanı boş geçilemez.");
            RuleFor(x => x.ConfirmPassword).NotEmpty().WithMessage("Şifre alanı boş geçilemez.");
            RuleFor(x => x.Name).MaximumLength(30).WithMessage("Lütfen en fazla 30 karakter giriniz");
            RuleFor(x => x.Name).MinimumLength(2).WithMessage("Lütfen en az 2karakter giriniz");
            RuleFor(x => x.ConfirmPassword).Equal(x => x.Password).WithMessage("Parolanız eşleşmiyor");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Lütfen geçerli bir email giriniz");
        }
        
    }
}
