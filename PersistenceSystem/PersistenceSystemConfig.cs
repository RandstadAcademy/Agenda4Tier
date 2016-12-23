using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersistenceSystem
{
    public class PersistenceSystemConfig
    {
        public string AccessConnectionString { get; set; }
        public string SqlConnectionString { get; set; }
        public string DBType { get; set; }
        public string MapperFactoryDllName { get; set; }
        public string MapperFactoryClassName { get; set; }
    }
}
