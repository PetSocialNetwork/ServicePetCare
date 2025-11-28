using FluentValidation;
using ServicePetCare.WebApi.Models.Requests;

namespace ServicePetCare.WebApi.Validators
{
    public class UpdateDogWalkingRequestValidator : AbstractValidator<UpdateDogWalkingRequest>
    {
        public UpdateDogWalkingRequestValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Id не заполнен.");
        }
    }
}
