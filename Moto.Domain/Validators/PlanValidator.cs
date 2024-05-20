using DocumentValidator;
using FluentValidation;
using Moto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Moto.Domain.Validators
{
    public class PlanValidator : AbstractValidator<PlanEntity>
    {
        public PlanValidator()
        {
            RuleFor(x => x.Days)
                .GreaterThan(0)
                .WithMessage("A quantidade de dias tem que ser maior que zero");
            RuleFor(x => x.Price)
                .NotNull()
                .WithMessage("O preço não pode estar vazio");
            RuleFor(x => x.Fee)
                .NotNull()
                .WithMessage("A taxa não pode estar vazia");
        }
    }
}
