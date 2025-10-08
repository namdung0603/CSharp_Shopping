using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.ApplicationService.Services.IService {
    public interface IBaseService<T, TResponse>
        where T : class
        where TResponse : class {
        Task<TResponse> GetAllAsync();
    }
}
