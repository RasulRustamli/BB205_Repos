using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Business.DTOs.UserDtos
{
    public record LoginDto
    {
        public string UserNameOrEmail { get; set; }
        public string Password { get; set; }
    }
    public class LoginDtoValidation:AbstractValidator<LoginDto>
    {
        public LoginDtoValidation()
        {
            RuleFor(l=>l.UserNameOrEmail)
                .NotEmpty()
                .WithMessage("UserName/Email bos ola bilmez");
            RuleFor(l=>l.Password)
                .NotEmpty()
                .WithMessage("Password bos ola bilmez");
        }
    }
}
