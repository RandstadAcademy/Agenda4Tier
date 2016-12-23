using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersistenceSystem.abstractions
{
    public class AccessDbDriverFactory : AbstractDbDriverFactory
    {
        public override IDbCommand GetCommand(IDbConnection connection, string query)
        {
            return new OleDbCommand(query, (OleDbConnection)connection);
        }

        public override IDbConnection GetConnection()
        {
            return new OleDbConnection(GetConnectionString());
        }

        protected override string GetConnectionString()
        {
            return @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=c:\\users\\fgran\\TestMermec.mdb";
        }
    }
}
