using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories.Entities
{
    [Table("TB1")]
    public class TB1
    {
        [ExplicitKey]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
