using FluentValidation;
using EventManagementAPI.DTOs;

namespace EventManagementAPI.Validators
{
    public class CreateLocationDTOValidator : AbstractValidator<CreateLocationDTO>
    {
        public CreateLocationDTOValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Le nom de la location est obligatoire.")
                .MaximumLength(100).WithMessage("Le nom de la location ne peut dépasser 100 caractères.");

            RuleFor(x => x.Address)
                .NotEmpty().WithMessage("L'adresse est obligatoire.")
                .MaximumLength(200).WithMessage("L'adresse ne peut dépasser 200 caractères.");

            RuleFor(x => x.City)
                .NotEmpty().WithMessage("La ville est obligatoire.")
                .MaximumLength(100).WithMessage("La ville ne peut dépasser 100 caractères.");

            RuleFor(x => x.Country)
                .NotEmpty().WithMessage("Le pays est obligatoire.")
                .MaximumLength(100).WithMessage("Le pays ne peut dépasser 100 caractères.");

            RuleFor(x => x.Capacity)
                .NotEmpty().WithMessage("La capacité est obligatoire.");
        }
    }
}
