using Shopping.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Infrastructure.Repository.IBase {
    public interface IProductRepository : IRepository<Product> {
        IEnumerable<Product> GetAllProduct();
        Task<Product?> GetProductById(int id);
        void CreateProduct(Product product);
        void DeleteProduct(Product product);
        void UpdateProduct(Product product);
    }
}
