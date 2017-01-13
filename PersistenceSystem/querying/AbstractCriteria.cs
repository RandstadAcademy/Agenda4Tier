using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersistenceSystem.querying
{
    public abstract class AbstractCriteria
    {

        protected List<AbstractCriteria> criterias = new List<AbstractCriteria>();
        public virtual void Add(AbstractCriteria criteria)
        {
            throw new Exception("Non è un composite!!!");
        }
        protected string _operator;
        public abstract string Evaluate();
        

    }
}
