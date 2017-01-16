using AgendaDomain;
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
    public class DBMessaggio : AbstractMapper
    {

        public DBMessaggio(string dbType)
            :base(dbType)
        {
            _table = "Messaggi";
            _updateQuery = @"Update Messaggi set
                            Id_Contatto = @con, MessageType = @met,
                            MessageBody = @meb, MessageObject = @meo, SendDate = @sen ";
            _insertQuery = @"Insert into Messaggi( 
                                                Id_Contatto,MessageType,MessageBody,MessageObject, SendDate)
                            values(@con, @met, @meb, @meo, @sen)";
        }

        protected override AbstractDomainObject DoLoad(int ID, IDataReader r)
        {
            Messaggio messaggio = new Messaggio();
            messaggio.Id = ID;

            messaggio.Recipient = RetrieveContatto(Convert.ToInt32(r["Id_Contatto"]));

            messaggio.SendDate = Convert.ToDateTime(r["SendDate"]);
            messaggio.MessageObject = r["MessageObject"].ToString();
            messaggio.MessageBody = r["MessageBody"].ToString();
            messaggio.MessageType = r["MessageType"].ToString();
            return messaggio;
        }

        private Contatto RetrieveContatto(int v)
        {
            DBContatto n = new DBContatto(_dbType);
            return n.GetById(v) as Contatto;
        }

        protected override void SetParameters(AbstractDomainObject data, IDbCommand cmd)
        {
            Messaggio messaggio = (Messaggio)data;
            //qui il discorso è leggermente diverso in quanto devo costruirmi dei parametri e valorizzarli
            IDbDataParameter param = cmd.CreateParameter();
            param.ParameterName = @"con";
            param.Value = messaggio.Recipient.Id;
            cmd.Parameters.Add(param);

            param = cmd.CreateParameter();
            param.ParameterName = @"met";
            param.Value = messaggio.MessageType;
            cmd.Parameters.Add(param);

            param = cmd.CreateParameter();
            param.ParameterName = @"meb";
            param.Value = messaggio.MessageBody;
            cmd.Parameters.Add(param);

            param = cmd.CreateParameter();
            param.ParameterName = @"meo";
            param.Value = messaggio.MessageObject;
            cmd.Parameters.Add(param);

            param = cmd.CreateParameter();
            param.ParameterName = @"sen";
            param.Value = messaggio.SendDate;
            cmd.Parameters.Add(param);


        }

    }
}
