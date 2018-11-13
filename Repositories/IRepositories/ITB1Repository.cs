using Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.IRepositories
{
    public interface ITB1Repository: IBaseRepository<TB1>
    {
        Task<IEnumerable<TB1>> GetAll();
        Task<string> TestProcedureAsync();
        Task InsertAsync(TB1 entity);
    }
}
