using Shopping.Infrastructure.Models;

namespace Shopping.Infrastructure.Repository.IBase {
    public interface IUserRepository : IRepository<User> {
        IEnumerable<User> GetAllUser();
        User GetUserById(int id);
        Task<User?> GetUserByEmailAsync(string email);
        Task<User?> GetUserByRefreshToken(string refreshToken);
        void CreateUser(User user);
        void UpdateUser(User user);
        void DeleteUser(User user);
        Task<bool> ExistByEmailAsync(string email, CancellationToken ct);
    }
}
