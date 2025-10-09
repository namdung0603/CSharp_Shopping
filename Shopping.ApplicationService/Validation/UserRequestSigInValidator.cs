using FluentValidation;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Shopping.ApplicationService.DTO.Request;
using Shopping.Contract;

namespace Shopping.ApplicationService.Validation {
    public class UserRequestSigInValidator : AbstractValidator<UserRequestSignin> {
        public UserRequestSigInValidator(IRepositoryWrapper wrapper) {
            RuleFor(x => x.FullName).NotEmpty().MaximumLength(100).MinimumLength(3);
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.Password).NotEmpty().MaximumLength(50).MinimumLength(8);
            RuleFor(x => x.RePassword).NotEmpty().MaximumLength(50).MinimumLength(8)
                .Equal(x => x.Password).WithMessage("Mat khau khong trun khop! Vui long dien lai mat khau!");

            
            
        }
    }
}
