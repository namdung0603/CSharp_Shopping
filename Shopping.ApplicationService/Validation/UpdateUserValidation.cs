using FluentValidation;
using Shopping.ApplicationService.DTO.Request.User;
using Shopping.Contract;

namespace Shopping.ApplicationService.Validation {
    public class UpdateUserValidation : AbstractValidator<UpdateRequest> {
        public UpdateUserValidation(IRepositoryWrapper wrapper) {
            RuleFor(x => x.Email)
                .EmailAddress().WithMessage("Sai moe dinh dang roi kia! Ngu the!");

        }
    }
}
