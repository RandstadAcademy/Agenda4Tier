using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;
using System.Diagnostics;
using PersistenceSystem.querying;

namespace PersistenceSystem.abstractions.mappers
{
    public abstract class AbstractMapper : IDBMapper
    {

        //protected Dictionary<int, AbstractDomainObject> _cache = new Dictionary<int, AbstractDomainObject>();

        protected string _dbType;
        protected string _table = "";

        protected string _updateQuery;
        protected string _insertQuery;



        public AbstractMapper(String dbType)
        {
           
            _dbType = dbType;
        }

        public virtual AbstractDomainObject GetById(int Id)
        {

            //AbstractDomainObject result = TryRetrieveFromCache(Id);
            //if (result != null)
            //    return result;

            //per poter fare una chiamata al DB devo avere due oggetti, ovvero una connessione e un comando
            IDbConnection conn = AbstractDbDriverFactory.GetDbDrivers(_dbType).GetConnection();
            IDbCommand cmd = AbstractDbDriverFactory.GetDbDrivers(_dbType).GetCommand(conn,"Select * from "+ _table + " where ID = " + Id.ToString() + "");

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

        //protected AbstractDomainObject TryRetrieveFromCache(int id)
        //{
        //    if (_cache.ContainsKey(id))
        //        return _cache[id];
        //    return null;
        //}

        protected abstract AbstractDomainObject DoLoad(int id, IDataReader r);
       

        public virtual void Delete(AbstractDomainObject data)
        {
            IDbConnection conn = AbstractDbDriverFactory.GetDbDrivers(_dbType).GetConnection();
            IDbCommand cmd = AbstractDbDriverFactory.GetDbDrivers(_dbType).GetCommand(conn, @"Delete from " + _table + " where ID = " + data.Id.ToString());

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
            IDbConnection conn = AbstractDbDriverFactory.GetDbDrivers(_dbType).GetConnection();
            IDbCommand cmd = AbstractDbDriverFactory.GetDbDrivers(_dbType).GetCommand(conn, "Select * from " + _table);

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

        public virtual void SaveOrUpdate(AbstractDomainObject data)
        {
            data.Validate();
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
            IDbConnection conn = AbstractDbDriverFactory.GetDbDrivers(_dbType).GetConnection();
            IDbCommand cmd = AbstractDbDriverFactory.GetDbDrivers(_dbType).GetCommand(conn, _insertQuery);

            try
            {
                conn.Open();

                SetParameters(data, cmd);

                cmd.ExecuteNonQuery();


                cmd.CommandText = "Select @@Identity";
                data.Id = Convert.ToInt32(cmd.ExecuteScalar());
                PostInserActions(cmd, data);
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

        protected virtual void PostInserActions(IDbCommand cmd, AbstractDomainObject data)
        {
            
        }

        private void DoUpdate(AbstractDomainObject data)
        {
            IDbConnection conn = AbstractDbDriverFactory.GetDbDrivers(_dbType).GetConnection();
            IDbCommand cmd = AbstractDbDriverFactory.GetDbDrivers(_dbType).GetCommand(conn, _updateQuery + " where Id = " + data.Id.ToString());
          

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

        public List<AbstractDomainObject> find(Query query)
        {
            query.SetTable(_table);
            string sql = query.GenerateQuery();


            IDbConnection conn = AbstractDbDriverFactory.GetDbDrivers(_dbType).GetConnection();
            IDbCommand cmd = AbstractDbDriverFactory.GetDbDrivers(_dbType).GetCommand(conn, sql);

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
    }
}
