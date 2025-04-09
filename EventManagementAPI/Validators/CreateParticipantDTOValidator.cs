using FluentValidation;
using EventManagementAPI.DTOs;

namespace EventManagementAPI.Validators
{
    public class CreateParticipantDTOValidator : AbstractValidator<CreateParticipantDTO>
    {
        public CreateParticipantDTOValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("Le prénom est obligatoire.")
                .MaximumLength(50).WithMessage("Le prénom ne peut dépasser 50 caractères.");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Le nom est obligatoire.")
                .MaximumLength(50).WithMessage("Le nom ne peut dépasser 50 caractères.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("L'email est obligatoire.")
                .EmailAddress().WithMessage("L'email doit être valide.")
                .MaximumLength(100).WithMessage("L'email ne peut dépasser 100 caractères.");

            RuleFor(x => x.Company)
                .NotEmpty().WithMessage("La compagnie est obligatoire.")
                .MaximumLength(100).WithMessage("La compagnie ne peut dépasser 100 caractères.");

            RuleFor(x => x.JobTitle)
                .NotEmpty().WithMessage("Le titre du poste est obligatoire.")
                .MaximumLength(50).WithMessage("Le titre du poste ne peut dépasser 50 caractères.");
        }
    }
}
