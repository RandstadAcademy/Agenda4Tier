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

        

        private Dictionary<int, CompositeCriteria> dictComposite = new Dictionary<int, CompositeCriteria>();
        private int currentCompositeIndex = 0;

        private bool _firstMatch = false;
        


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

            //get the select string

            return string
                .Format("Select * from {0} {1} {2}", 
                _table,
                whereToString,
                where);
        }


        public Query AddCriteria(AbstractCriteria criteria)
        {
            if (currentCompositeIndex > 0)
                dictComposite[currentCompositeIndex - 1].Add(criteria);

            if (_firstMatch == true) throw new Exception("Non puoi aggiungere criteri semplici in fila");
            else this.AddWhereclause(criteria);

            _firstMatch = true;

            return this;
        }
        public Query AddCompositeCriteria(BooleaOperator booleanOperator)
        {
              
            dictComposite.Add(currentCompositeIndex, (CompositeCriteria)CriteriaFactory.CompositeCriteria(booleanOperator));
            currentCompositeIndex++;

            _firstMatch = false;

            return this;
        }

        public Query EndComposite()
        {
            if (currentCompositeIndex > 0)
                currentCompositeIndex--;

            if (currentCompositeIndex == 0) this.AddWhereclause(dictComposite[0]);
            return this;
        }


    }
}
