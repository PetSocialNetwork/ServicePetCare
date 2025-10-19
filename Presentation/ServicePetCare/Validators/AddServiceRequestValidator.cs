using FluentValidation;
using ServicePetCare.WebApi.Models.Requests;

namespace ServicePetCare.WebApi.Validators
{
    public class AddServiceRequestValidator : AbstractValidator<AddServiceRequest>
    {
        public AddServiceRequestValidator()
        {
            RuleFor(x => x.ProfileId)
                .NotEmpty()
                .WithMessage("ProfileId не заполнен.");

            RuleFor(x => x.ServiceTypeId)
                .NotEmpty()
                .WithMessage("ServiceTypeId не заполнен.");
        }
    }
}
