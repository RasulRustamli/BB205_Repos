using FluentValidation;
using System.Text.RegularExpressions;

namespace BlogApp.Business.DTOs.UserDtos
{
    public record RegisterDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
    public class RegisterDtoValidation : AbstractValidator<RegisterDto>
    {
        public RegisterDtoValidation()
        {
            RuleFor(r => r.Name)
                .NotEmpty()
                .WithMessage("Name bos ola bilmez")
                .MaximumLength(30)
                .WithMessage("Name-in uzunlugu 30-dan cox ola bilmez")
                .MinimumLength(3)
                .WithMessage("Name-in uzunlugu 3-den az ola bilmez");
            RuleFor(r => r.Surname)
             .NotEmpty()
             .WithMessage("Surname bos ola bilmez")
            .MaximumLength(30)
            .WithMessage("Surname-in uzunlugu 30-dan cox ola bilmez")
            .MinimumLength(3)
            .WithMessage("Surname-in uzunlugu 3-den az ola bilmez");
            RuleFor(r => r.UserName)
            .NotEmpty()
            .WithMessage("UserName bos ola bilmez")
            .MaximumLength(30)
            .WithMessage("UserName-in uzunlugu 30-dan cox ola bilmez")
            .MinimumLength(3)
            .WithMessage("UserName-in uzunlugu 3-den az ola bilmez");

            //RuleFor(r => r.Email)
            //    .EmailAddress();
            RuleFor(r => r.Email)
            .NotEmpty()
            .WithMessage("Email bos ola bilmez")
            .Must(e =>
            {
                Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                Match match = regex.Match(e);
                return match.Success;
            })
            .WithMessage("Email formati duxgun daxil edin");

            RuleFor(r => r.Password)
                 .NotEmpty()
                 .WithMessage("Password bos ola bilmez")
                 .Must(p =>
                 {
                     Regex regex = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,}$");
                     Match match = regex.Match(p);
                     return match.Success;
                 })
                 .WithMessage("Passwordu duzgun daxil edin");
            RuleFor(r => r)
                .Must(e => e.Password == e.ConfirmPassword)
                .WithMessage("Passwordla Confirm Password eyni deyil");











        }
    }
}
