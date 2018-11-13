using Repositories.Entities;
using Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;
using Dapper;
using Dapper.Contrib.Extensions;
using System.Threading.Tasks;
using Dapper.Oracle;
using System.Data;

namespace Repositories.Repositories
{
    public class TB1Repository: BaseRepository<TB1>, ITB1Repository
    {
        public TB1Repository(DbConnection connection, DbTransaction transaction): base(connection, transaction)
        {
        }

        public async Task<IEnumerable<TB1>> GetAll()
        {
            return await this.DbConnection.GetAllAsync<TB1>();
        }

        public async Task InsertAsync(TB1 entity)
        {
            var sql = @"INSERT INTO TB1(NAME) VALUES(:Name)";
            await this.DbConnection.ExecuteAsync(sql: sql,
                param: new
                {
                    Name = entity.Name
                }, 
                transaction: this.DbTransaction
                );
        }

        public async Task<string> TestProcedureAsync()
        {
            var parameters = new OracleDynamicParameters();
            parameters.Add("genericParam", "aaaa", OracleMappingType.Varchar2, ParameterDirection.InputOutput);
            await this.DbConnection.ExecuteAsync("procOneINOUTParameter", parameters, commandType: CommandType.StoredProcedure);

            var a = parameters.Get<string>("genericParam");
            return a;
        }
    }
}
