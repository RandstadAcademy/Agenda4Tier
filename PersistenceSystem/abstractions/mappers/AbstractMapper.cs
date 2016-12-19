using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;

namespace PersistenceSystem.abstractions.mappers
{
    public abstract class AbstractMapper : IDBMapper
    {
       
        private string _dbType;
        protected string _table = "";

        protected string _updateQuery;
        protected string _insertQuery;



        public AbstractMapper(String dbType)
        {
           
            _dbType = dbType;
        }

        public virtual AbstractDomainObject GetById(int Id)
        {
            //per poter fare una chiamata al DB devo avere due oggetti, ovvero una connessione e un comando
            IDbConnection conn = DbDriversFactory.GetConnection(_dbType);
            IDbCommand cmd =  DbDriversFactory.GetCommand(_dbType,conn,"Select * from "+ _table + " where ID = " + Id.ToString() + "");

            try
            {
                //apro la connessione verso il DB
                conn.Open();

                //eseguo il comando e mi faccio tornare un reader che mi permetterà di muovermi sui dati
                IDataReader r = cmd.ExecuteReader();
                AbstractDomainObject obj = null;

                //se ho letto qualcosa creo un contatto e lo valorizzo
                if (r.Read())
                {
                    obj = DoLoad(Id, r);
                }

                r.Close();

                //ritorno il contatto
                return obj;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                //il blocco finally mi viene eseguito sempre sia quando le cose vanno male che quando vanno bene
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
                cmd.Dispose();
            }
        }

        protected abstract AbstractDomainObject DoLoad(int id, IDataReader r);
       

        public virtual void Delete(AbstractDomainObject data)
        {
            IDbConnection conn = DbDriversFactory.GetConnection(_dbType);
            IDbCommand cmd = DbDriversFactory.GetCommand(_dbType, conn, @"Delete from " + _table + " where ID = " + data.Id.ToString());

            try
            {
                conn.Open();
                IDbDataParameter param = cmd.CreateParameter();
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

        public virtual List<AbstractDomainObject> GetAll()
        {
            IDbConnection conn = DbDriversFactory.GetConnection(_dbType);
            IDbCommand cmd = DbDriversFactory.GetCommand(_dbType, conn, "Select * from " + _table);

            List<AbstractDomainObject> list = null;

            try
            {
                //uguale a prima solo che qui riempio una lista
                conn.Open();
                IDataReader r = cmd.ExecuteReader();
                list = new List<AbstractDomainObject>();

                while (r.Read())
                {
                    AbstractDomainObject obj = DoLoad(Convert.ToInt32(r["ID"]), r);

                    list.Add(obj);
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

        public virtual void SaveOrUpdate(AbstractDomainObject data)
        {
            //se l'id del contatto è 0 ovvero non esiste eseguo una insert altrimenti faccio una update
            if (data.Id == 0)
            {
                DoInsert(data);
                return;
            }

            DoUpdate(data);
        }

        private void DoInsert(AbstractDomainObject data)
        {
            IDbConnection conn = DbDriversFactory.GetConnection(_dbType);
            IDbCommand cmd = DbDriversFactory.GetCommand(_dbType, conn, _insertQuery);

            try
            {
                conn.Open();

                SetParameters(data, cmd);

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

        private void DoUpdate(AbstractDomainObject data)
        {
            IDbConnection conn = DbDriversFactory.GetConnection(_dbType);
            IDbCommand cmd = DbDriversFactory.GetCommand(_dbType, conn, _updateQuery + " where Id = " + data.Id.ToString());
          

            try
            {
                conn.Open();

                SetParameters(data, cmd);

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

        protected abstract void SetParameters(AbstractDomainObject data,  IDbCommand cmd);
    }
}
