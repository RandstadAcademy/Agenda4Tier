using AgendaDomain;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaData
{
    public class DBContatto
    {

        private string _connectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\Tommaso\Documents\Visual Studio 2015\Projects\TestMermec.mdb";


        public Contatto GetByID(int ID)
        {
            
            OleDbConnection conn = new OleDbConnection(_connectionString);
            OleDbCommand cmd = new OleDbCommand("Select * from Contatti where ID = "+ ID.ToString()+"", conn);

            try
            {
                conn.Open();
                OleDbDataReader r = cmd.ExecuteReader();
                Contatto contatto = null;
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
                return contatto;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if(conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
                cmd.Dispose();
            }
        }

        public List<Contatto> GetAll()
        {


            OleDbConnection conn = new OleDbConnection(_connectionString);
            OleDbCommand cmd = new OleDbCommand("Select * from Contatti", conn);
            List<Contatto> list = null;

            try
            {
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

        public void SaveOrUpdate(Contatto contatto)
        {

            if(contatto.ID == 0)
            {
                DoInsert(contatto);
                return;
            }

            Update(contatto);

        }

        private void Update(Contatto contatto)
        {
            OleDbConnection conn = new OleDbConnection(_connectionString);
            OleDbCommand cmd = new OleDbCommand(@"Update Contatti set 
                                                Name1 = @name1, Tel = @tel, 
                                                Mail = @mail, MessageType = @mt where ID = "+ contatto.ID, conn);

            try
            {
                conn.Open();
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

        private void DoInsert(Contatto contatto)
        {
            OleDbConnection conn = new OleDbConnection(_connectionString);
            OleDbCommand cmd = new OleDbCommand(@"Insert into Contatti( 
                                                Name1,Tel,Mail,MessageType) values(@name1, @tel, @mail, @mt)", conn);

            try
            {
                conn.Open();
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

        public void Delete(int ID)
        {

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
