using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersistenceSystem.querying
{
    public class Query
    {
        private string _table;
        private AbstractCriteria _clause;
        public Query(string table)
        {
            _table = table;
        }
        public Query()
        {
           
        }

        internal void SetTable(string table)
        {
            _table = table;
        }

        public void AddWhereclause(AbstractCriteria clause)
        {
            _clause = clause;
        }
        
        public string GenerateQuery()
        {
            if (string.IsNullOrEmpty(_table))
                throw new Exception("Tabella non specificata");

            string where = _clause.Evaluate();
            string whereToString = string.IsNullOrEmpty(where) ? "" : " where ";
            return string
                .Format("Select * from {0} {1} {2}", 
                _table,
                whereToString,
                where);
        }


    }
}
