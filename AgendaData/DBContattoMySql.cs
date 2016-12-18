using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgendaDomain;
using MySql.Data.MySqlClient;

namespace AgendaData
{
    class DBContattoMySql : IDBContatto
    {
        //stringa di connessione con il database con relative Path
        private string _connectionStringMysql = "server=127.0.0.1;uid=root;" + "pwd=;database=agenda4tier;";
        private MySqlConnection _conn;

        /// <summary>
        /// Medoto che ci permette di estrarre un contatto in base al suo ID
        /// </summary>
        /// <param name="ID">Id del contatto da estrarre</param>
        /// <returns></returns>
        public Contatto GetByID(int ID)
        {


            _conn = new MySqlConnection(_connectionStringMysql);
            MySqlCommand cmd = null;
            Contatto contatto = null;

            try
            {
                //apro la connessione verso il DB
                _conn.Open();
                cmd = _conn.CreateCommand();
                cmd.CommandText = "Select * from Contatti where ID = " + ID.ToString() + "";
                //eseguo il comando e mi faccio tornare un reader che mi permetterà di muovermi sui dati
                MySqlDataReader r = cmd.ExecuteReader();

                //se ho letto qualcosa creo un contatto e lo valorizzo
                if (r.Read())
                {
                    contatto = new Contatto();
                    contatto.ID = ID;
                    contatto.Mail = r["Mail"].ToString();
                    contatto.Tel = r["Tel"].ToString();
                    contatto.Name = r["Name1"].ToString();
                    contatto.MessageType = (MessageType)Enum.Parse(typeof(MessageType), r["MessageType"].ToString());
                }

                r.Close();

                //ritorno il contatto
                return contatto;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                //il blocco finally mi viene eseguito sempre sia quando le cose vanno male che quando vanno bene
                if (_conn.State == System.Data.ConnectionState.Open)
                {
                    _conn.Close();
                }
                cmd.Dispose();
            }

        }
        /// <summary>
        /// Metodo che mi permette di estrarre tutti i contatti
        /// Ritorna una lista di oggetti Contatto
        /// </summary>
        public List<Contatto> GetAll()
        {

            List<Contatto> list = null;
            _conn = new MySqlConnection(_connectionStringMysql);
            MySqlCommand cmd = null;


            try
            {
                _conn.Open();
                cmd = _conn.CreateCommand();
                cmd.CommandText = "Select * from Contatti";
                MySqlDataReader r = cmd.ExecuteReader();
                list = new List<Contatto>();
                Contatto contatto = null;
                while (r.Read())
                {
                    contatto = new Contatto();
                    contatto.ID = Convert.ToInt32(r["ID"]);
                    contatto.Mail = r["Mail"].ToString();
                    contatto.Tel = r["Tel"].ToString();
                    contatto.Name = r["Name1"].ToString();
                    contatto.MessageType = (MessageType)Enum.Parse(typeof(MessageType), r["MessageType"].ToString());
                    list.Add(contatto);
                }

                r.Close();
                return list;

            }
            catch (MySqlException ex)
            {
                Console.Write(ex.ToString());
            }
            finally
            {
                if (_conn.State == System.Data.ConnectionState.Open)
                {
                    _conn.Close();
                }
                cmd.Dispose();
            }

            return list;

        }

        /// <summary>
        /// Metodo che mi permette di salvare o aggiornare un contatto
        /// </summary>
        /// <param name="contatto">Oggetto contatto da Salvare/Aggiornare</param>
        public void SaveOrUpdate(Contatto contatto)
        {
            //se l'id del contatto è 0 ovvero non esiste eseguo una insert altrimenti faccio una update
            if (contatto.ID == 0)
            {
                DoInsert(contatto);
                return;
            }

            Update(contatto);

        }

        /// <summary>
        /// Metodo che mi esegue l'update
        /// </summary>
        /// <param name="contatto">IL contatto aggiornato, si userà il suo id per fare l'update</param>
        private void Update(Contatto contatto)
        {
            _conn = new MySqlConnection(_connectionStringMysql);
            MySqlCommand cmd = null;


            try
            {
                _conn.Open();
                cmd = _conn.CreateCommand();
                cmd.CommandText = @"Update Contatti set Name1 = @name1, Tel = @tel, Mail = @mail, MessageType = @mt where ID = " + contatto.ID;
                //vedi update il concetto è lo stesso
                MySqlParameter param = cmd.CreateParameter();
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
                param.Value = contatto.MessageType.ToString();
                cmd.Parameters.Add(param);

                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                Console.Write("");
            }
            finally
            {
                if (_conn.State == System.Data.ConnectionState.Open)
                {
                    _conn.Close();
                }
                cmd.Dispose();
            }
        }

        /// <summary>
        /// Metodo che esegue l'insert
        /// </summary>
        /// <param name="contatto">Contatto da cui verranno presi i dati da usare nell'insert</param>
        private void DoInsert(Contatto contatto)
        {

            _conn = new MySqlConnection(_connectionStringMysql);
            MySqlCommand cmd = null;

            try
            {
                _conn.Open();
                cmd = _conn.CreateCommand();
                cmd.CommandText = "Insert into Contatti(Name1, Tel, Mail, MessageType) values(@name1, @tel, @mail, @mt)";
                //vedi update il concetto è lo stesso
                MySqlParameter param = cmd.CreateParameter();
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
                param.Value = contatto.MessageType.ToString();
                cmd.Parameters.Add(param);

                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                Console.Write("");
            }
            finally
            {
                if (_conn.State == System.Data.ConnectionState.Open)
                {
                    _conn.Close();
                }
                cmd.Dispose();
            }
        }

        /// <summary>
        /// Metodo che effettua una cancellazione in base ad un ID
        /// </summary>
        /// <param name="ID">Id che utilizzerò per cancellare</param>
        public void Delete(int ID)
        {
            _conn = new MySqlConnection(_connectionStringMysql);
            MySqlCommand cmd = null;
            try
            {

                _conn.Open();
                cmd = _conn.CreateCommand();
                cmd.CommandText = "Delete from Contatti where ID = " + ID.ToString();
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                Console.Write("");
            }
            finally
            {
                if (_conn.State == System.Data.ConnectionState.Open)
                {
                    _conn.Close();
                }
                cmd.Dispose();
            }

        }
    }
}
