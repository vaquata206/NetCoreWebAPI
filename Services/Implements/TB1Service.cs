using Repositories.Entities;
using Repositories.UnitOfWorks;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Implements
{
    public class TB1Service : ITB1Service
    {
        private IUnitOfWork _unitOfWork;

        public TB1Service(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public IEnumerable<TB1> GetAll()
        {
            //return this._unitOfWork.TB1Repository.GetAll().Result;
            var a = this._unitOfWork.TB1Repository.TestProcedureAsync().Result;
            return null;
        }
    }
}
