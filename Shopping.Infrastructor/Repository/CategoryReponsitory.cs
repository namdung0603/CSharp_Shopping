using Microsoft.EntityFrameworkCore;
using Shopping.Infrastructure.Models;
using Shopping.Infrastructure.Repository.IBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Infrastructure.Repository {
    public class CategoryReponsitory : RepositoryBase<Category>, ICategoryRepository {
        public CategoryReponsitory(ShoppingContext context) : base(context) {

        }
        public ICollection<Category> GetAllCategory() {
            return FindAll().OrderBy(category => category.CatagoryName).ToList();
        }

        public async Task<Category?> GetCategoryByNameAsync(string nameCategory) {
            return await FindWithCondition(category => category.CatagoryName.Equals(nameCategory)).FirstOrDefaultAsync();
        }
    }
}
