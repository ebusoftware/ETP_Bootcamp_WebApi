using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_CampFinalProject.Features.Commands.User.CreateUser
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(u => u.Email)
                .NotEmpty()
                .NotNull()
                .WithMessage("Mail Adresi zorunludur.")
                .EmailAddress()
                .WithMessage("lütfen mail adresini doğru formatta giriniz.");

            RuleFor(u => u.Password)
                .NotEmpty()
                .NotNull()
                .WithMessage("Şifre boş geçilemez.")
                .MinimumLength(8)
                .MaximumLength(60)
                .WithMessage("Şifre en az 8 en fazla 60 karakter arasında olmalıdır.");

            RuleFor(u => u.Username)
                .NotNull()
                .NotEmpty()
                .WithMessage("Kullanıcı Adı girilmedi.")
                .MinimumLength(5)
                .MaximumLength(35)
                .WithMessage("Kullanıcı Adı, en az 5, en fazla 35 karakter arasında olmalıdır.");

            RuleFor(u => u.PasswordConfirm)
                .NotEmpty()
                .NotNull()
                .WithMessage("Şifreyi Doğrulamadınız.")
                .MinimumLength(8)
                .MaximumLength(60)
                .Equal(u => u.Password)
                .WithMessage("Şifreler aynı olmalı");

            RuleFor(u => u.NameSurname)
                .NotEmpty()
                .NotNull()
                .WithMessage("Ad ve Soyadınızı girmediniz.");
        }
    }
}
