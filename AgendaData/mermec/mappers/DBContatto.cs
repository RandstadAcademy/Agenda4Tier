using AgendaData.mermec.abstractions;
using AgendaDomain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaData.mermec
{
    /// <summary>
    /// Classe che rappresenta l'unione logica tra il nostro dominio e le nostre sorgenti dati
    /// </summary>
    class DBContatto: AbstractMapper
    {

        public DBContatto(string dbType)
            :base(dbType)
        {
            _table = "Contatti";
            _updateQuery = @"Update Contatti set
                            Name1 = @name1, Tel = @tel,
                            Mail = @mail, MessageType = @mt ";
            _insertQuery = @"Insert into Contatti( 
                                                Name1,Tel,Mail,MessageType) values(@name1, @tel, @mail, @mt)";
        }

        protected override AbstractDomainObject DoLoad(int ID, IDataReader r)
        {
            Contatto contatto = new Contatto();
            contatto.Id = ID;
            contatto.Mail = r["Mail"].ToString();
            contatto.Tel = r["Tel"].ToString();
            contatto.Name = r["Name1"].ToString();
            contatto.MessageTypes = new List<string>(RetrieveMessageTypesArray(r));
            return contatto;
        }

        private  string[] RetrieveMessageTypesArray(IDataReader r)
        {
            //poichè la stringa serializzata nel campo
            //MessageType è una lista di stringhe separate da ','
            //allora recupero il camopo dal db e poi lo 
            //serializzo
            string list = "";
            if (r["MessageType"] == null)
            {
                list = "";
            }
            else
            {
                list = r["MessageType"].ToString();
            }
            //ottenurta la stringa finalemnte deserializzo
            string[] list1 = null;
            if (list.Equals(""))
            {
                list1 = new string[] { };
            }
            else
            {
                list1 = list.Split(new Char[] { ',' });
            }

            return list1;
        }


        protected override  void SetParameters(AbstractDomainObject data, IDbCommand cmd)
        {
            Contatto contatto = (Contatto)data;
            //qui il discorso è leggermente diverso in quanto devo costruirmi dei parametri e valorizzarli
            IDbDataParameter param = cmd.CreateParameter();
            param.ParameterName = @"name1";
            param.Value = contatto.Name;
            cmd.Parameters.Add(param);

            param = cmd.CreateParameter();
            param.ParameterName = @"tel";
            param.Value = contatto.Tel;
            cmd.Parameters.Add(param);

            param = cmd.CreateParameter();
            param.ParameterName = @"mail";
            param.Value = contatto.Mail;
            cmd.Parameters.Add(param);

            param = cmd.CreateParameter();
            param.ParameterName = @"mt";
            if (contatto.MessageTypes.Count == 0)
            {
                param.Value = DBNull.Value;
            }
            else
            {
                param.Value = String.Join(",", contatto.MessageTypes);
            }
            cmd.Parameters.Add(param);

          
        }

    }
}
