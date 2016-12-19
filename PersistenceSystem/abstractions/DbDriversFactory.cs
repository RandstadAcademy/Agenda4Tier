using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersistenceSystem.abstractions
{
    class DbDriversFactory
    {
        private static string GetConnectionString(string dbType)
        {

            if (dbType.Equals("SqlServer"))
            {
               return @"Data Source =.\NOESIS; Initial Catalog = Mermec; User ID =RegUsr; Password =RegUsr";
            }
            else
            {
                return @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=c:\\users\\fgran\\TestMermec.mdb";
            }

        }


        public static IDbConnection GetConnection(string dbType)
        {
            if (dbType.Equals("SqlServer"))
            {
                return new SqlConnection(GetConnectionString(dbType));
            }
            else
            {
                return new OleDbConnection(GetConnectionString(dbType));
            }
        }


        public static IDbCommand GetCommand(string dbType, IDbConnection connection , string query)
        {
            if (dbType.Equals("SqlServer"))
            {
                return new SqlCommand(query, (SqlConnection)connection);
            }
            else
            {
                return new OleDbCommand(query, (OleDbConnection)connection);
            }
        }
    }
}
