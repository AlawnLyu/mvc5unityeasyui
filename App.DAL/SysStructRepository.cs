using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.IDAL;
using App.Models;

namespace App.DAL
{
    public class SysStructRepository : ISysStructRepository, IDisposable
    {
        public IQueryable<SysStruct> GetList(DBContainer db)
        {
            IQueryable<SysStruct> list = db.SysStruct.AsQueryable();
            return list;
        }

        public int Create(SysStruct entity)
        {
            using (DBContainer db = new DBContainer())
            {
                db.SysStruct.Add(entity);
                return db.SaveChanges();
            }
        }

        public int Delete(string id)
        {
            using (DBContainer db = new DBContainer())
            {
                SysStruct entity = db.SysStruct.SingleOrDefault(o => o.Id == id);
                if (entity != null)
                {
                    db.SysStruct.Remove(entity);
                }
                return db.SaveChanges();
            }
        }

        public void Delete(DBContainer db, string[] deleteCollection)
        {
            IQueryable<SysStruct> collection = from r in db.SysStruct where deleteCollection.Contains(r.Id) select r;
            db.SysStruct.RemoveRange(collection);
        }

        public int Edit(SysStruct entity)
        {
            using (DBContainer db = new DBContainer())
            {
                db.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                return db.SaveChanges();
            }
        }

        public SysStruct GetById(string id)
        {
            using (DBContainer db = new DBContainer())
            {
                return db.SysStruct.SingleOrDefault(o => o.Id == id);
            }
        }

        public bool IsExist(string id)
        {
            return GetById(id) != null;
        }

        public void Dispose()
        {
        }
    }
}
