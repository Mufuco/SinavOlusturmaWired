using FluentValidation;
using Microsoft.AspNetCore.Identity;
using ProjectTek.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTek.BusinessLayer.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Lütfen kullanıcı adı giriniz empty!");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Lütfen şifre giriniz! empty");
            
        }

    }
}
