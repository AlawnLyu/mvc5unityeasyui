using System;
using System.Linq;
using App.Flow.IDAL;
using App.Models;
using System.Data;

namespace App.Flow.DAL
{
    public class Flow_FormRepository : IFlow_FormRepository, IDisposable
    {
        public IQueryable<Flow_Form> GetList(DBContainer db)
        {
            IQueryable<Flow_Form> list = db.Flow_Form.AsQueryable();
            return list;
        }

        public int Create(Flow_Form entity)
        {
            using (DBContainer db = new DBContainer())
            {
                db.Flow_Form.Add(entity);
                return db.SaveChanges();
            }
        }

        public int Delete(string id)
        {
            using (DBContainer db = new DBContainer())
            {
                Flow_Form entity = db.Flow_Form.SingleOrDefault(o => o.Id == id);
                if (entity != null)
                {
                    db.Flow_Form.Remove(entity);
                }
                return db.SaveChanges();
            }
        }

        public void Delete(DBContainer db, string[] deleteCollection)
        {
            IQueryable<Flow_Form> collection = from f in db.Flow_Form where deleteCollection.Contains(f.Id) select f;
            db.Flow_Form.RemoveRange(collection);
        }

        public int Edit(Flow_Form entity)
        {
            using (DBContainer db = new DBContainer())
            {
                db.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                return db.SaveChanges();
            }
        }

        public Flow_Form GetById(string id)
        {
            using (DBContainer db = new DBContainer())
            {
                return db.Flow_Form.SingleOrDefault(o => o.Id == id);
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