using Microsoft.EntityFrameworkCore;
using Shopping.Infrastructure.Repository.IBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Infrastructure.Repository {
    public class RepositoryBase<T> : IRepository<T> where T : class {
        protected ShoppingContext _context { get; set; }
        public RepositoryBase(ShoppingContext context) {
            _context = context;
        }

        public IQueryable<T> FindAll() => _context.Set<T>().AsNoTracking();
        //AsNoTracking khong theo doi cac entity duoc lay ra.
        //Cac entity se chi la doi tuong du lieu 'readonly' - EF Core khong ton bo nho
        //va tai nguyen de theo doi chung
        //=> Giup tang toc do truy van va giam overhead.

        public void Create(T entity) => _context.Set<T>().Add(entity);

        public void Update(T entity) => _context.Set<T>().Update(entity);

        public void Delete(T entity) => _context.Set<T>().Remove(entity);

        public IQueryable<T> FindWithCondition(Expression<Func<T, bool>> expression) => _context.Set<T>().Where(expression).AsNoTracking();
        // Expression<Func<T, bool>> expression: dau vao se nhan mot bieu thuc dieu kien, vi du: u => u < 18.
    }
}
