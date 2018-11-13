using Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.UnitOfWorks
{
    public interface IUnitOfWork : IDisposable
    {
        ITB1Repository TB1Repository { get; }

        void Commit();
        void BeginTransaction();
    }
}
