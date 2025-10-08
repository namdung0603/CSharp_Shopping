using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Infrastructure.Repository.IBase {
    public interface IRepository<T> {
        IQueryable<T> FindAll();
        IQueryable<T> FindWithCondition(Expression<Func<T,bool>> expression);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
