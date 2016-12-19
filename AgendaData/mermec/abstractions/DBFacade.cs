using AgendaData.mermec.abstractions.mappers;
using AgendaDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaData.mermec
{
    public class DBFacade
    {

       //private string _connectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=c:\\users\\fgran\\TestMermec.mdb";
        private string _dbType = "Access";
        private static DBFacade _instance;
        private DBFacade()
        {

        }
        public static DBFacade Instance()
        {
            if (_instance == null)
                _instance = new DBFacade();

            return _instance;
        }

        public void InitializeDB(string dbType)
        {
            _dbType = dbType;

           
        }



        public AbstractDomainObject GetById(string type, int id)
        {
            return MapperFactory
                .GetMapperByName(type, _dbType)
                .GetById(id);
        }
        public List<AbstractDomainObject> GetAll(string type)
        {
            return MapperFactory
               .GetMapperByName(type, _dbType)
               .GetAll();
        }

        public void SaveOrUpdate(AbstractDomainObject data)
        {

            String namew = data.GetType().Name;
            MapperFactory
               .GetMapperByName(namew, _dbType)
               .SaveOrUpdate(data);
        }

        public void Delete(AbstractDomainObject data)
        {
            String namew = data.GetType().Name;
            MapperFactory
               .GetMapperByName(namew, _dbType)
               .Delete(data);
        }
    }
}
