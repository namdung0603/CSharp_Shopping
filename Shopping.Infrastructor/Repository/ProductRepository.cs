using Microsoft.EntityFrameworkCore;
using Shopping.Infrastructure.Models;
using Shopping.Infrastructure.Repository.IBase;

namespace Shopping.Infrastructure.Repository {
    public class ProductRepository : RepositoryBase<Product>, IProductRepository {
        private readonly ShoppingContext _context;
        public ProductRepository(ShoppingContext context) : base(context) {
            _context = context;
        }

        public void CreateProduct(Product product) {
            Create(product);
        }

        public void DeleteProduct(Product product) {
            Delete(product);
        }

        public IEnumerable<Product> GetAllProduct() {
            return FindAll().OrderBy(product => product.ProductName).Include(product => product.Categories).ToList();
        }

        public async Task<Product?> GetProductById(int id) {
            return await _context.Products
                .Include(product => product.Categories)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public void UpdateProduct(Product product) {
            Update(product);
        }
    }
}
