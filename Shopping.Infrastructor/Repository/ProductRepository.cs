using Shopping.Infrastructure.Models;
using Shopping.Infrastructure.Repository.IBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Infrastructure.Repository {
    public class ProductRepository : RepositoryBase<Product>, IProductRepository {
        public ProductRepository(ShoppingContext context) : base(context) {

        }

        public IEnumerable<Product> GetAllProduct() {
            return FindAll().OrderBy(product => product.ProductName).ToList();
        }

        public Product GetProductById(int id) {
            return FindWithCondition(product => product.Id == id).FirstOrDefault();
        }
    }
}
