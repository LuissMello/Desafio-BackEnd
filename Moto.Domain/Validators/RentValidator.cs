using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moto.Domain.Validators
{
    using DocumentValidator;
    using FluentValidation;
    using global::Moto.Domain.Entities;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Numerics;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;

    namespace Moto.Domain.Validators
    {
        public class RentValidator : AbstractValidator<RentEntity>
        {
            public RentValidator()
            {
                RuleFor(x => x.EndDate)
                    .GreaterThanOrEqualTo(x => x.StartDate)
                    .WithMessage("A data final deve ser maior ou igual a data inicial");
                RuleFor(x => x.User)
                    .NotNull()
                    .WithMessage("O usuário deve ser informado");
                RuleFor(x => x.Bike)
                    .NotNull()
                    .WithMessage("A moto deve ser informada");
                RuleFor(x => x.Plan)
                    .NotNull()
                    .WithMessage("O plano deve ser informado");

            }
        }
    }

}
