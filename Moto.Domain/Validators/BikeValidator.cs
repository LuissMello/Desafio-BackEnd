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
    public class BikeValidator : AbstractValidator<BikeEntity>
    {
        public BikeValidator()
        {
            RuleFor(x => x.Year)
                .GreaterThan(1900)
                .LessThan(2024)
                .WithMessage("O ano deve ser entre 1900 e 2024");
            RuleFor(x => x.Model)
                .NotNull()
                .WithMessage("O modelo não pode estar vazio");
            RuleFor(courseOffering => courseOffering.Plate)
                .Must(BeAValidPlate)
                .WithMessage("A placa deve estar no padrão correto");
        }

        private bool BeAValidPlate(string plate)
        {
            if (string.IsNullOrWhiteSpace(plate)) { return false; }
            {
                if (plate.Length > 8) { return false; }

                plate = plate.Replace("-", "").Trim();

                // Padrão MERCOSUL
                if (char.IsLetter(plate, 4))
                {
                    var padraoMercosul = new Regex("[a-zA-Z]{3}[0-9]{1}[a-zA-Z]{1}[0-9]{2}");
                    return padraoMercosul.IsMatch(plate);
                }
                else
                {
                    // Padrão antigo
                    var padraoNormal = new Regex("[a-zA-Z]{3}[0-9]{4}");
                    return padraoNormal.IsMatch(plate);
                }
            }
        }
    }
}
