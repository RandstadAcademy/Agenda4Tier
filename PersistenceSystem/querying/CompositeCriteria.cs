using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersistenceSystem.querying
{
    public class CompositeCriteria : AbstractCriteria
    {
        protected BooleaOperator _booleanOperator;
        public CompositeCriteria(BooleaOperator booleanOperator)
        {
            _booleanOperator = booleanOperator;
        }

        public override void Add(AbstractCriteria criteria)
        {
            criterias.Add(criteria);
        }



        public override string Evaluate()
        {
            string result = "";
            int i = 0;
            foreach (var item in criterias)
            {
                if (i == 0)
                {
                    result = item.Evaluate();
                }else
                {
                    result = result + " " + BooleanOperatorToString() + " " + item.Evaluate(); 
                }
                i++;
            }
            if (string.IsNullOrEmpty(result.Trim()))
                return "";
            return " ( " + result + " ) ";
        }

        private string BooleanOperatorToString()
        {
            switch (_booleanOperator)
            {
                case BooleaOperator.And:
                    return "AND";
                case BooleaOperator.Or:
                    return "OR";
                case BooleaOperator.Not:
                    return "NOT";
                default:
                    return "";
            }
        }
    }
}
