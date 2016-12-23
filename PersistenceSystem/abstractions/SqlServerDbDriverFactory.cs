using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersistenceSystem.abstractions
{
    class SqlServerDbDriverFactory : AbstractDbDriverFactory
    {
        public override IDbCommand GetCommand(IDbConnection connection, string query)
        {
            return new SqlCommand(query, (SqlConnection)connection);
        }

        public override IDbConnection GetConnection()
        {
            return new SqlConnection(GetConnectionString());
        }

        protected override string GetConnectionString()
        {
            return @"Data Source =.\NOESIS; Initial Catalog = Mermec; User ID =RegUsr; Password =RegUsr";
        }
    }
}
