using FluentValidation;
using Shopping.ApplicationService.DTO.Request.User;

namespace Shopping.ApplicationService.Validation {
    public class LoginValidation : AbstractValidator<LoginRequest> {
        public LoginValidation() {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email khong duoc de trong!")
                .EmailAddress().WithMessage("Email khong dung dinh dang!");
            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Mat khau khong duoc de trong!")
                .MinimumLength(8).WithMessage("Mat khau phai 8 ki tu tro len!")
                .Matches(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[*_-])[A-Za-z\d*_-]+$").WithMessage("Mat khau phai co chu cai viet hoa, chu cai viet thuong, so va ki tu!");
        }
    }
}
