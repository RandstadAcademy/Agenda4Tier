using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersistenceSystem.abstractions
{
    public abstract class AbstractDbDriverFactory
    {

        protected abstract string GetConnectionString();
        public abstract IDbCommand GetCommand(IDbConnection connection, string query);
        public abstract IDbConnection GetConnection();

        public static AbstractDbDriverFactory GetDbDrivers(string dbType)
        {
            if (dbType.Equals("SqlServer"))
            {
                return new SqlServerDbDriverFactory();
            }
            else
            {
                return new AccessDbDriverFactory();
            }
        }

    }
}
