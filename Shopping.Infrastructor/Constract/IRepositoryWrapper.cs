using Shopping.Infrastructure.Repository.IBase;

namespace Shopping.Contract {
    public interface IRepositoryWrapper {
        IUserRepository UserRepository { get; }
        IProductRepository ProductRepository { get; }
        ICategoryRepository CategoryRepository { get; }
        void Save();
    }
}
