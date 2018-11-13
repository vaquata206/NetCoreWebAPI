using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.IRepositories
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
    }
}
