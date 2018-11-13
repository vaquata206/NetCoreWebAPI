using Oracle.ManagedDataAccess.Client;
using Repositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Repositories.Repositories;

namespace Repositories.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private bool _disposed = false;
        private DbConnection _connection;
        private DbTransaction _transaction;

        private ITB1Repository _tb1Repository = null;

        public UnitOfWork(string connectionString)
        {
            this._connection = new OracleConnection(connectionString);
            this._connection.Open();
            this._transaction = this._connection.BeginTransaction();
        }

        public ITB1Repository TB1Repository
        {
            get
            {
                if (this._tb1Repository == null)
                {
                    _tb1Repository = new TB1Repository(this._connection, this._transaction);
                }

                return this._tb1Repository;
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    this._connection.Dispose();
                }
            }

            _disposed = true;
        }

        public void BeginTransaction()
        {
            this._transaction = this._connection.BeginTransaction();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Commit()
        {
            try
            {
                if (_transaction != null)
                {
                    this._transaction.Commit();
                }
            }
            catch
            {
                _transaction.Rollback();
                throw;
            }
            finally
            {
                _transaction.Dispose();
                _transaction = _connection.BeginTransaction();
                ResetRepositories();
            }
        }

        private void ResetRepositories()
        {
            _tb1Repository = null;
        }
    }
}
