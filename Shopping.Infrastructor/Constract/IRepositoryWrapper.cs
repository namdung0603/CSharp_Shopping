using Shopping.Infrastructure.Repository.IBase;

namespace Shopping.Contract {
    public interface IRepositoryWrapper {
        IUserRepository UserRepository { get; }
        IProductRepository ProductRepository { get; }
        void Save();
    }
}
