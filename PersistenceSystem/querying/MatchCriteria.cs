using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersistenceSystem.querying
{
    public class MatchCriteria : AbstractCriteria
    {


        protected string _columnName;
        protected string _value;
        public MatchCriteria(string columnName, string value)
        {
            _operator = "like";
            _columnName = columnName;
            _value = "'%" + value + "%'";
        }


        public override string Evaluate()
        {
            return string.Format("{0} {1} {2}", _columnName, _operator, _value);
        }
    }
}
