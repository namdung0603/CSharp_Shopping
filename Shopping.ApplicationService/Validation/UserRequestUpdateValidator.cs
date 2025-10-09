using FluentValidation;
using Shopping.ApplicationService.DTO.Request;
using Shopping.Contract;
using Shopping.Infrastructure.Repository.IBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.ApplicationService.Validation {
    public class UserRequestUpdateValidator : AbstractValidator<UserRequestUpdate> {
        public UserRequestUpdateValidator(IRepositoryWrapper wrapper) {
            RuleFor(x => x.Email)
                .MustAsync(async (email, ct) => !await wrapper.UserRepository.ExistByEmailAsync(email, ct));
        }
    }
}
