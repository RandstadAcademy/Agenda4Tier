using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersistenceSystem.querying
{
    public class EqualCriteria:AbstractCriteria
    {
        protected string _columnName;
        protected int _value;
        public EqualCriteria(string columnName, int value)
        {
            _operator = "=";
            _columnName = columnName;
            _value = value;
        }

        public override string Evaluate()
        {
            return string.Format("{0} {1} {2}", _columnName, _operator, _value);
        }
    }
}
