using Microsoft.EntityFrameworkCore;
using Shopping.Infrastructure.Models;
using Shopping.Infrastructure.Repository.IBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Infrastructure.Repository {
    public class UserRepository : RepositoryBase<User>, IUserRepository {
        public UserRepository(ShoppingContext context) : base(context) {

        }

        public void CreateUser(User user) {
            Create(user);
        }

        public void DeleteUser(User user) {
            Delete(user);
        }

        public async Task<bool> ExistByEmailAsync(string email, CancellationToken ct) {
            return await _context.Users.AnyAsync(x => x.Email == email);
        }

        public IEnumerable<User> GetAllUser() {
            return FindAll().OrderBy(x => x.Fullname).ToList();
        }

        public Task<User?> GetUserByEmailAsync(string email) {
            return FindWithCondition(user => user.Email.Equals(email)).FirstOrDefaultAsync();
        }

        public User GetUserById(int id) {
            return FindWithCondition(user => user.Id == id).FirstOrDefault();
            // lay nguoi dung co id bang id truyen vao sau do lay ket qua dau tien, neu khong co thi tra ve gia tri mac dinh
            // cua object la gia tri null.
        }

        public async Task<User?> GetUserByRefreshToken(string refreshToken) {
            return await FindWithCondition(user => user.RefreshToken.Equals(refreshToken)).FirstOrDefaultAsync();
        }

        public void UpdateUser(User user) {
            Update(user);
        }
    }
}
