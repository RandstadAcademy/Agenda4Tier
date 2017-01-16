
using PersistenceSystem.abstractions.mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using PersistenceSystem.querying;

namespace PersistenceSystem.abstractions
{
    public class DBFacade
    {

       //private string _connectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=c:\\users\\fgran\\TestMermec.mdb";
        private string _dbType = "Access";
        private static DBFacade _instance;
        private IMapperFactory _mapperFactory;
        private PersistenceSystemConfig _persistenceSystemConfig;

        public IMapperFactory MapperFactory
        {
            set
            {
                _mapperFactory = value;
            }
        }

        internal PersistenceSystemConfig PersistenceSystemConfig
        {
            get
            {
                return _persistenceSystemConfig;
            }
        }

        private DBFacade()
        {
        }

        public static DBFacade Instance()
        {
            if (_instance == null)
                _instance = new DBFacade();

            return _instance;
        }

        public void InitializeSystem(PersistenceSystemConfig persistenceSystemConfig)
        {
            _persistenceSystemConfig = persistenceSystemConfig;
            _dbType = persistenceSystemConfig.DBType;
            ObjectHandle handle = Activator.CreateInstance(PersistenceSystemConfig.MapperFactoryDllName, PersistenceSystemConfig.MapperFactoryClassName);
            _mapperFactory = (IMapperFactory)handle.Unwrap();
        }

        public void InitializeDB(string dbType)
        {
            CheckConfig();
            _dbType = dbType;
            
        }

        public AbstractDomainObject GetById(string type, int id)
        {
            CheckConfig();
            return _mapperFactory
                .GetMapperByName(type, _dbType)
                .GetById(id);
        }
        public List<AbstractDomainObject> GetAll(string type)
        {
            CheckConfig();
            return _mapperFactory
               .GetMapperByName(type, _dbType)
               .GetAll();
        }

        public void SaveOrUpdate(AbstractDomainObject data)
        {
            //if(!Ringo.IsNullOrEmpty() && Ringo.Length>0) 
                //gangOfRandazzo.Eat(Ringo);
            // 
            CheckConfig();
            String namew = data.GetType().Name;
            _mapperFactory
               .GetMapperByName(namew, _dbType)
               .SaveOrUpdate(data);
        }

        public void Delete(AbstractDomainObject data)
        {
            CheckConfig();
            String namew = data.GetType().Name;
            _mapperFactory
               .GetMapperByName(namew, _dbType)
               .Delete(data);
        }

        private void CheckConfig()
        {
            if (PersistenceSystemConfig == null)
                throw new Exception("System not initialized");
        }

        public List<AbstractDomainObject> Find(string type, Query q)
        {
            return _mapperFactory
               .GetMapperByName(type, _dbType)
               .find(q);
        }

        public Query CreateQuery()
        {
            return new Query();
        }
    }
}
