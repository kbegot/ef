using FluentValidation;
using EventManagementAPI.DTOs;

namespace EventManagementAPI.Validators
{
    public class CreateEventDTOValidator : AbstractValidator<CreateEventDTO>
    {
        public CreateEventDTOValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Le titre est obligatoire.")
                .MaximumLength(100).WithMessage("Le titre ne peut dépasser 100 caractères.");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("La description est obligatoire.");

            RuleFor(x => x.StartDate)
                .NotEmpty().WithMessage("La date de début est obligatoire.")
                .LessThan(x => x.EndDate).WithMessage("La date de début doit être antérieure à la date de fin.");

            RuleFor(x => x.EndDate)
                .NotEmpty().WithMessage("La date de fin est obligatoire.");

            RuleFor(x => x.Status)
                .NotEmpty().WithMessage("Le statut est obligatoire.");

            RuleFor(x => x.Category)
                .NotEmpty().WithMessage("La catégorie est obligatoire.");

            RuleFor(x => x.LocationId)
                .GreaterThan(0).WithMessage("L'identifiant de la location doit être supérieur à 0.");
        }
    }
}
