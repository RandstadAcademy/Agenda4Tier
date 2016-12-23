using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseTypes
{
    class AccessServerFactory : AbstractDatabaseFactory
    {
        public override AccessServerFactory GetAccessServer()
        {
            throw new NotImplementedException();
        }

        public override SqlServerFactory GetSqlServer()
        {
            throw new NotImplementedException();
        }
    }
}
