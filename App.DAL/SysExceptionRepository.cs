using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.IDAL;
using App.Models;

namespace App.DAL
{
    public class SysExceptionRepository : ISysExceptionRepository, IDisposable
    {
        public int Create(SysException entity)
        {
            using (DBContainer db = new DBContainer())
            {
                db.SysException.Add(entity);
                return db.SaveChanges();
            }
        }

        public IQueryable<SysException> GetList(DBContainer db)
        {
            return db.SysException.AsQueryable();
        }

        public SysException GetById(string id)
        {
            using (DBContainer db = new DBContainer())
            {
                return db.SysException.FirstOrDefault(s => s.Id == id);
            }
        }

        public bool IsExist(string id)
        {
            SysException entity = GetById(id);
            return entity != null;
        }

        public void Dispose()
        {
        }
    }
}
