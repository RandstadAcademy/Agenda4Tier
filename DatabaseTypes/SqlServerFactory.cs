using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseTypes
{
    class SqlServerFactory : AbstractDatabaseFactory
    {



        //public SqlServerFactory()
        //{
        //    ConnectionString = @"Data Source =.\NOESIS; Initial Catalog = Mermec; User ID =RegUsr; Password =RegUsr";
        //    Connection = new SqlConnection(ConnectionString);
        //    Command = new SqlCommand(query, (SqlConnection) Connection);
        //}

        public override AccessServerFactory GetAccessServer()
        {
            new 
        }

        public override SqlServerFactory GetSqlServer()
        {
            throw new NotImplementedException();
        }
    }
}
