using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersistenceSystem
{
    public class AbstractDomainObject
    {
        public int Id { get; set; }


        public virtual string DoValidate()
        {
            return "";
        }


        public void Validate() {
            
            string error = this.DoValidate();
            if (!String.IsNullOrEmpty(error))
                throw new Exception(error);
            
        }



    }


    


}
