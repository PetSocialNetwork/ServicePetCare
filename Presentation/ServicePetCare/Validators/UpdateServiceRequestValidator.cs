using FluentValidation;
using ServicePetCare.WebApi.Models.Requests;

namespace ServicePetCare.WebApi.Validators
{
    public class UpdateServiceRequestValidator : AbstractValidator<UpdateServiceRequest>
    {
        public UpdateServiceRequestValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Id не заполнен.");
        }
    }
}
