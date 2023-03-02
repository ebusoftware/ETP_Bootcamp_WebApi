using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_CampFinalProject.Features.Commands
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {

        public CreateProductCommandValidator()
        {
            RuleFor(p => p.ProductName)
               .NotEmpty()
               .NotNull()
               .WithMessage("Ürün adı boş geçilemez!")
               .MinimumLength(3)
               .MaximumLength(150)
               .WithMessage("Lütfen en az 3 en fazla 150 karakter olacak şekilde giriniz.");


            

            RuleFor(p => p.Price)
                .NotEmpty()
                .NotNull()
                .WithMessage("Fiyat bilgisi boş geçilemez.")
                .Must(a => a >= 0)
                .WithMessage("Fiyat bilgisi negatif olamaz!");

        }

    }
}
