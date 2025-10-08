using Shopping.Contract;
using Shopping.Infrastructure.Repository.IBase;

namespace Shopping.Infrastructure.Repository {
    public class RepositoryWrapper : IRepositoryWrapper {
        private ShoppingContext _shoppingContext;
        private IUserRepository _userRepository;
        private IProductRepository _productRepository;

        public IUserRepository UserRepository {
            get {
                if (_userRepository == null) {
                    _userRepository = new UserRepository(_shoppingContext);
                }
                return _userRepository;
            }
        }

        // là property công khai trả về IUserRepository
        // khi duoc goi lan dau, no se tao moi UserRepository ( truyen _repoContext vao)
        // Nhung lan goi sau se dung lai _userRepository da duoc khoi tao -> tiet kiem tai nguyen

        public IProductRepository ProductRepository {
            get {
                if (_productRepository == null) {
                    _productRepository = new ProductRepository(_shoppingContext);
                }
                return _productRepository;
            }
        }

        public RepositoryWrapper(ShoppingContext context) {
            _shoppingContext = context;
        }

        public void Save() {
            _shoppingContext.SaveChanges();
        }
    }
}
