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

        public IEnumerable<User> GetAllUser() {
            return FindAll().OrderBy(x => x.Fullname).ToList();
        }

        public User GetUserById(int id) {
            return FindWithCondition(user => user.Id == id).FirstOrDefault();
            // lay nguoi dung co id bang id truyen vao sau do lay ket qua dau tien, neu khong co thi tra ve gia tri mac dinh
            // cua object la gia tri null.
        }

        public void UpdateUser(User user) {
            Update(user);
        }
    }
}
