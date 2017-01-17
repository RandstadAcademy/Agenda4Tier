using PersistenceSystem.abstractions.mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersistenceSystem;
using System.Data;
using SecuritySystem;
using PersistenceSystem.abstractions;
using System.Diagnostics;
using AgendaData.mermec.concreteMappers;

namespace AgendaDomain.Security
{
    class UtenteMapper : AbstractMapper
    {

        public UtenteMapper(string dbType)
            :base(dbType)
        {
            _table = "Users";
            _updateQuery = @"Update Users set
                            Username = @username, Password = @password,
                            Mail = @mail, NameAndSurname = @nameandsurname ";
            _insertQuery = @"Insert into Users( 
                                                Username,Password,Mail,NameAndSurname) values(@username, @password, @mail, @nameandsurname)";
        }

        protected override void PostInserActions(IDbCommand cmd, AbstractDomainObject data)
        {
            foreach (var item in ((Utente) data).Roles)
            {
                cmd.CommandText = String.Format("Insert into UserRoles (UserId, RoleId) values ({0}, {1})", data.Id, ((Ruolo) item).Id);
                cmd.ExecuteNonQuery();
            }
        }

        protected override AbstractDomainObject DoLoad(int ID, IDataReader r)
        {
            Utente utente = new Utente();
            utente.Id = ID;
            utente.Mail = r["Mail"].ToString();
            utente.Username = r["Username"].ToString();
            utente.NameAndSurname = r["NameAndSurname"].ToString();
            utente.Password = r["Password"].ToString();
            utente.Roles = RetrieveRoles(ID);
            
            return utente;
        }

        private List<IRole> RetrieveRoles(int userId)
        {
            IDbConnection conn = AbstractDbDriverFactory.GetDbDrivers(_dbType).GetConnection();
            IDbCommand cmd = AbstractDbDriverFactory.GetDbDrivers(_dbType).GetCommand(conn, "Select * from UserRoles where UserId = "+ userId);

            List<IRole> list = null;

            try
            {
                //uguale a prima solo che qui riempio una lista
                conn.Open();
                IDataReader r = cmd.ExecuteReader();
                list = new List<IRole>();
                int idToExtract = 0;
                RuoloMapper mapper = new RuoloMapper(_dbType);
                
                while (r.Read())
                {
                    idToExtract = Convert.ToInt32(r["RoleId"]);
                    AbstractDomainObject obj = mapper.GetById(idToExtract);
                    list.Add(obj as Ruolo);
                }

                r.Close();
                return list;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            finally
            {
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
                cmd.Dispose();
            }

            return list;
        }

        protected override void SetParameters(AbstractDomainObject data, IDbCommand cmd)
        {
            Utente utente = (Utente)data;
            //qui il discorso è leggermente diverso in quanto devo costruirmi dei parametri e valorizzarli
            IDbDataParameter param = cmd.CreateParameter();
            param.ParameterName = @"username";
            param.Value = utente.Username;
            cmd.Parameters.Add(param);

            param = cmd.CreateParameter();
            param.ParameterName = @"password";
            param.Value = utente.Password;
            cmd.Parameters.Add(param);

            param = cmd.CreateParameter();
            param.ParameterName = @"mail";
            param.Value = utente.Mail;
            cmd.Parameters.Add(param);

            param = cmd.CreateParameter();
            param.ParameterName = @"nameandsurname";
            param.Value = utente.NameAndSurname;
            cmd.Parameters.Add(param);

        }

    }
}
