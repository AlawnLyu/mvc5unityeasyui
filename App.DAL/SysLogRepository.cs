using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.IDAL;
using App.Models;

namespace App.DAL
{
    public class SysLogRepository : ISysLogRepository, IDisposable
    {
        public int Create(SysLog entity)
        {
            using (DBContainer db = new DBContainer())
            {
                db.SysLog.Add(entity);
                return db.SaveChanges();
            }
        }

        public void Delete(DBContainer db, string[] deleteCollection)
        {
            IQueryable<SysLog> collection = from s in db.SysLog where deleteCollection.Contains(s.Id) select s;
            foreach (SysLog item in collection)
            {
                db.SysLog.Remove(item);
            }
            db.SaveChanges();
        }

        public IQueryable<SysLog> GetList(DBContainer db)
        {
            IQueryable<SysLog> list = db.SysLog.AsQueryable();
            return list;
        }

        public SysLog GetById(string id)
        {
            using (DBContainer db = new DBContainer())
            {
                return db.SysLog.FirstOrDefault(s => s.Id == id);
            }
        }

        public bool IsExist(string id)
        {
            SysLog entity = GetById(id);
            return entity != null;
        }

        public void Dispose()
        {
        }
    }
}
