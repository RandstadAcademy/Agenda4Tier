using AgendaDomain.Security;
using PersistenceSystem;
using PersistenceSystem.abstractions.mappers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaData.mermec.concreteMappers
{
    public class RuoloMapper : AbstractMapper
    {
        public RuoloMapper(string dbType)
            :base(dbType)
        {
            _table = "Roles";
            _updateQuery = @"Update Roles set
                            Name = @name";
            _insertQuery = @"Insert into Roles(Name) values(@name)";
        }

        protected override AbstractDomainObject DoLoad(int ID, IDataReader r)
        {
            Ruolo ruolo = new Ruolo();
            ruolo.Id = ID;
            ruolo.Name = r["Name"].ToString();

            return ruolo;
        }

        protected override void SetParameters(AbstractDomainObject data, IDbCommand cmd)
        {
            Ruolo ruolo = (Ruolo)data;
            IDbDataParameter param = cmd.CreateParameter();
            param.ParameterName = @"name";
            param.Value = ruolo.Name;
            cmd.Parameters.Add(param);

        }

    }
}
