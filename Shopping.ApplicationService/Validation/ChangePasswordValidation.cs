using FluentValidation;
using Shopping.ApplicationService.DTO.Request.User;
using Shopping.Contract;

namespace Shopping.ApplicationService.Validation {
    public class ChangePasswordValidation : AbstractValidator<ChangePassword> {
        public ChangePasswordValidation(IRepositoryWrapper wrapper) {
            RuleFor(x => x.NewPassword)
                .NotEmpty().WithMessage("Mat khau khong duoc de trong!")
                .MinimumLength(8).WithMessage("Mat khau khong duoc it hon 8 ki tu!")
                .MaximumLength(20)
                .Matches(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[*_-])[A-Za-z\d*_-]+$").WithMessage("Mat khau khong dung dinh dang!");
            RuleFor(x => x.ReNewPassword)
                .NotEmpty().WithMessage("Vui long nhap lai mat khau!")
                .Equal(x => x.NewPassword).WithMessage("Mat khau khong khop!");
        }
    }
}
