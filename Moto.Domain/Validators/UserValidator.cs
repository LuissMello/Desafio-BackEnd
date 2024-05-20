using DocumentValidator;
using FluentValidation;
using Moto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moto.Domain.Validators
{
    public class UserValidator : AbstractValidator<UserEntity>
    {
        public UserValidator()
        {
            RuleFor(x => x.Name)
                .Length(0, 50)
                .WithMessage("O nome deve possuir entre 0 e 50 caracteres");
            RuleFor(x => x.Password)
                .NotNull()
                .WithMessage("A senha não pode estar vazia");
            RuleFor(f => CnpjValidation.Validate(f.Cnpj)).Equal(true)
                .WithMessage("O Cnpj fornecido é inválido.");
            RuleFor(f => CnhValidation.Validate(f.Cnh)).Equal(true)
                .WithMessage("A Cnh fornecida é inválida.");
            RuleFor(x => x.CnhType).NotEqual(Enums.CnhType.None)
                .WithMessage("O tipo de Cnh deve ser informado");
            RuleFor(courseOffering => courseOffering.BirthDate)
                .Must(BeAValidDate)
                .WithMessage("A data de nascimento é obrigatória");
        }

        private bool BeAValidDate(DateTime date)
        {
            return !date.Equals(default);
        }
    }
}
