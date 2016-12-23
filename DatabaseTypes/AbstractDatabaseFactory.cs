using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseTypes
{
    public abstract class AbstractDatabaseFactory
    {
        
        public abstract SqlServerFactory Get()

        //protected string ConnectionString = "";
        //protected IDbConnection Connection;
        //protected IDbCommand Command;

        //public string GetConnectionString()
        //{
        //    return ConnectionString;
        //}

        //public IDbConnection GetConnection()
        //{
        //    return Connection;
        //}

        //public IDbCommand GetCommand()
        //{
        //    return Command;
        //}

    }
}
