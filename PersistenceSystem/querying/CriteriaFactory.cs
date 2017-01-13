using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersistenceSystem.querying
{
    public class CriteriaFactory
    {
        public static AbstractCriteria MatchCriteria(string columnName,string value)
        {
            return new MatchCriteria(columnName, value);
        }

        public static AbstractCriteria MatchEqualCriteria(string columnName, string value)
        {
            return new MatchEqualCriteria(columnName, value);
        }


        public static AbstractCriteria CompositeCriteria(BooleaOperator booleanOperator)
        {
            return new CompositeCriteria(booleanOperator);
        }


    }
}
