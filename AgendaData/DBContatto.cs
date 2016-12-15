using AgendaDomain;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaData
{
    /// <summary>
    /// Classe che rappresenta l'unione logica tra il nostro dominio e le nostre sorgenti dati
    /// </summary>
    public class DBContatto
    {
        //stringa di connessione con il database
        private string _connectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Tommaso\Documents\Visual Studio 2015\Projects\Agenda\TestMermec.mdb";

        /// <summary>
        /// Medoto che ci permette di estrarre un contatto in base al suo ID
        /// </summary>
        /// <param name="ID">Id del contatto da estrarre</param>
        /// <returns></returns>
        public Contatto GetByID(int ID)
        {
            //per poter fare una chiamata al DB devo avere due oggetti, ovvero una connessione e un comando
            OleDbConnection conn = new OleDbConnection(_connectionString);
            OleDbCommand cmd = new OleDbCommand("Select * from Contatti where ID = "+ ID.ToString()+"", conn);

            try
            {
                //apro la connessione verso il DB
                conn.Open();

                //eseguo il comando e mi faccio tornare un reader che mi permetterà di muovermi sui dati
                OleDbDataReader r = cmd.ExecuteReader();
                Contatto contatto = null;

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
                if(conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
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

            //vedi sopra
            OleDbConnection conn = new OleDbConnection(_connectionString);
            OleDbCommand cmd = new OleDbCommand("Select * from Contatti", conn);
            List<Contatto> list = null;

            try
            {
                //uguale a prima solo che qui riempio una lista
                conn.Open();
                OleDbDataReader r = cmd.ExecuteReader();
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
            catch (Exception)
            {
                Console.Write("");
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

        /// <summary>
        /// Metodo che mi permette di salvare o aggiornare un contatto
        /// </summary>
        /// <param name="contatto">Oggetto contatto da Salvare/Aggiornare</param>
        public void SaveOrUpdate(Contatto contatto)
        {
            //se l'id del contatto è 0 ovvero non esiste eseguo una insert altrimenti faccio una update
            if(contatto.ID == 0)
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
            OleDbConnection conn = new OleDbConnection(_connectionString);
            OleDbCommand cmd = new OleDbCommand(@"Update Contatti set 
                                                Name1 = @name1, Tel = @tel, 
                                                Mail = @mail, MessageType = @mt where ID = "+ contatto.ID, conn);

            try
            {
                conn.Open();

                //qui il discorso è leggermente diverso in quanto devo costruirmi dei parametri e valorizzarli
                OleDbParameter param = cmd.CreateParameter();
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
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
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
            OleDbConnection conn = new OleDbConnection(_connectionString);
            OleDbCommand cmd = new OleDbCommand(@"Insert into Contatti( 
                                                Name1,Tel,Mail,MessageType) values(@name1, @tel, @mail, @mt)", conn);

            try
            {
                conn.Open();

                //vedi update il concetto è lo stesso
                OleDbParameter param = cmd.CreateParameter();
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
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
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
            //come su
            OleDbConnection conn = new OleDbConnection(_connectionString);
            OleDbCommand cmd = new OleDbCommand(@"Delete from Contatti where ID = " +ID.ToString(), conn);

            try
            {
                conn.Open();
                OleDbParameter param = cmd.CreateParameter();
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                Console.Write("");
            }
            finally
            {
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
                cmd.Dispose();
            }

        }
    }
}
