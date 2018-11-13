using Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Interfaces
{
    public interface ITB1Service
    {
        IEnumerable<TB1> GetAll();
    }
}
