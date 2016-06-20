using CoffeeShop.Models;
using NPoco;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoffeeShop.Components
{
    public abstract class BaseRepository
    {
        protected virtual T GetById<T>(int id)
        {
            T item = default(T);
            using (var db = GetDatabase())
                item = db.SingleOrDefaultById<T>(id);

            return item;
        }

        protected virtual IEnumerable<T> GetAll<T>()
        {
            IEnumerable<T> list = null;
            using (var db = GetDatabase())
                list = db.Fetch<T>();

            return list;
        }


        protected string GetTableName<T>()
        {
            var tName = typeof(T)
                .GetCustomAttributes(typeof(TableNameAttribute), false)
                .Cast<TableNameAttribute>()
                .FirstOrDefault();

            return tName.Value;
        }

        protected IEnumerable<T> GetWithChildren<T, K>(string sql) where T : BaseModel where K : BaseModel
        {
            IEnumerable<T> items = null;
            using (var db = GetDatabase())
                items = db.FetchOneToMany<T, K>(p => p.Id, c => c.Id, new Sql(sql));
                
            return items;
        }

        protected IEnumerable<T> GetAllWithChildren<T, K>(string fkParent) where T : BaseModel where K : BaseModel
        {
            string tblNameP = GetTableName<T>();
            string tblNameC = GetTableName<K>();

            string sql = String.Format("SELECT X.*, Y.* FROM {0} X LEFT JOIN {1} Y ON X.Id = Y.{2}", tblNameP, tblNameC, fkParent);
            return GetWithChildren<T, K>(sql);
        }

        protected T GetByIdWithChildren<T, K>(int id, string fkParent) where T : BaseModel where K : BaseModel
        {
            string tblNameP = GetTableName<T>();
            string tblNameC = GetTableName<K>();

            string sql = String.Format("SELECT X.*, Y.* FROM {0} X LEFT JOIN {1} Y ON X.Id = Y.{2} WHERE X.Id = {3}",
                tblNameP, tblNameC, fkParent, id);

            return GetWithChildren<T, K>(sql).FirstOrDefault();
        }

        

        protected virtual T GetOne<T>(string stmt, params object[] parameters)
        {
            T item = default(T);
            using (var db = GetDatabase())
                item = db.FirstOrDefault<T>(stmt, parameters);
            return item;
        }

        public virtual List<T> QueryMany<T>(string sqlStmt, params object[] parameters)
        {
            using (var db = GetDatabase())
                return db.Fetch<T>(sqlStmt, parameters);
        }

        protected virtual IEnumerable<T> GetMany<T>(string stmt, params object[] parameters)
        {
            IEnumerable<T> list = null;
            using (var db = GetDatabase())
                list = db.Fetch<T>(stmt, parameters);
            return list;
        }

        protected virtual bool DeleteById<T>(int id)
        {
            if (id == 0)
                throw new Exception("You must, must, give me an id.");

            T item = default(T);
            using (var db = GetDatabase())
            {
                item = db.SingleOrDefaultById<T>(id);
                if (item == null)
                    return false;
                db.Delete(item);
            }
            return true;
        }

        protected virtual T Insert<T>(T item) where T:BaseModel
        {
            if (item.Id != 0)
                throw new Exception ("You have given me an invalid id. :(");
            using (var db = GetDatabase())
                db.Insert<T>(item);
            return item;
        }

        protected int InsertMany<T>(IEnumerable<T> items) where T : BaseModel
        {
            if (items.Any(i => !i.IsNew()))
                return 0;

            int count = 0;
            using (var db = GetDatabase())
            {
                try
                {
                    db.BeginTransaction();

                    foreach (var item in items)
                    {
                        db.Insert(item);
                        count++;
                    }

                    db.CompleteTransaction();
                }
                catch (Exception e)
                {
                    db.AbortTransaction();
                    throw (e);
                }
            }

            return count;
        }

        protected int InsertBulk<T>(IEnumerable<T> items)
        {
            using (var db = GetDatabase())
            {
                try
                {
                    db.InsertBulk<T>(items);
                }
                catch (Exception e)
                {
                    throw (e);
                }
            }

            return items.Count();
        }

        protected virtual bool Update<T>(T item) where T : BaseModel
        {
            if (item.Id == 0)
                throw new Exception("You must, must, give me an id.");
            using (var db = GetDatabase())
            {
                if (db.SingleOrDefaultById<T>(item.Id) == null)
                    return false;
                db.Update(item);
            }
            return true;
        }
                
        protected Database GetDatabase()
        {
            var db = new Database("CoffeeShop");
            db.CommandTimeout = 300;
            return db;
        }

        protected T GetScalar<T>(string sqlStmt, params object[] parameters)
        {
            using (var db = GetDatabase())
                return db.ExecuteScalar<T>(sqlStmt, parameters);
        }

        public T QueryOne<T>(string sqlStmt, params object[] parameters)
        {
            using (var db = GetDatabase())
                return db.FirstOrDefault<T>(sqlStmt, parameters);
        }
    }
}