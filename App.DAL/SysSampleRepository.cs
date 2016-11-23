using System;
using System.Data.Entity;
using System.Linq;
using App.IDAL;
using App.Models;

namespace App.DAL
{
    public class SysSampleRepository : ISysSampleRepository, IDisposable
    {
        public IQueryable<SysSample> GetList(DBContainer db, string queryStr)
        {
            IQueryable<SysSample> list = db.SysSample.Where(s => s.Name.Contains(queryStr)).AsQueryable();
            return list;
        }

        public int Create(SysSample entity)
        {
            using (DBContainer db = new DBContainer())
            {
                db.SysSample.Add(entity);
                return db.SaveChanges();
            }
        }

        public int Delete(string id)
        {
            using (DBContainer db = new DBContainer())
            {
                SysSample entity = db.SysSample.SingleOrDefault(s => s.Id == id);
                if (entity != null)
                {
                    db.SysSample.Remove(entity);
                }
                return db.SaveChanges();
            }
        }

        public int Edit(SysSample entity)
        {
            using (DBContainer db = new DBContainer())
            {
                db.Entry(entity).State = EntityState.Modified;
                return db.SaveChanges();
            }
        }

        public SysSample GetById(string id)
        {
            using (DBContainer db = new DBContainer())
            {
                return db.SysSample.SingleOrDefault(s => s.Id == id);
            }
        }

        public bool IsExist(string id)
        {
            SysSample entity = GetById(id);
            return entity != null;
        }

        public void Dispose()
        {
        }
    }
}
