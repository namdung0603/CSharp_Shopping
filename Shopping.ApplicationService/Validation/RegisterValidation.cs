using FluentValidation;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Shopping.ApplicationService.DTO.Request.User;
using Shopping.Contract;

namespace Shopping.ApplicationService.Validation {
    public class RegisterValidation : AbstractValidator<RegisterRequest> {
        public RegisterValidation(IRepositoryWrapper wrapper) {
            RuleFor(x => x.FullName).NotEmpty().MaximumLength(100).MinimumLength(3);
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.Password).NotEmpty().MaximumLength(50).MinimumLength(8).Matches(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[*_-])[A-Za-z\d*_-]+$");
            RuleFor(x => x.RePassword).NotEmpty().MaximumLength(50).MinimumLength(8)
                .Equal(x => x.Password).WithMessage("Mat khau khong trung khop! Vui long dien lai mat khau!");
            RuleFor(x => x.Address).NotEmpty().MaximumLength(255);
        }
    }
}
