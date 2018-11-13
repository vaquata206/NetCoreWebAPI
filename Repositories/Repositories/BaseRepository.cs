using Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;
using Dapper;

namespace Repositories.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        public DbConnection DbConnection { get; private set; }
        public DbTransaction DbTransaction { get; private set; }
        public BaseRepository(DbConnection dbConnection, DbTransaction dbTransaction)
        {
            this.DbConnection = dbConnection;
            this.DbTransaction = dbTransaction;
        }
    }
}
