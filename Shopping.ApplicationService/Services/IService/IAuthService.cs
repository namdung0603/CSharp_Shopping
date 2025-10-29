using Shopping.ApplicationService.DTO.Request.User;
using Shopping.ApplicationService.DTO.Response;

namespace Shopping.ApplicationService.Services.IService {
    public interface IAuthService {
        Task<TokenResponse?> LoginAsync(LoginRequest login);
        Task<TokenResponse?> RefreshTokenAsync(RefreshTokenRequest refreshToken);
    }
}
