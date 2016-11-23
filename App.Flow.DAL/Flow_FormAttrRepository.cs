using System;
using System.Linq;
using App.Flow.IDAL;
using App.Models;

namespace App.Flow.DAL
{
    public class Flow_FormAttrRepository : IFlow_FormAttrRepository, IDisposable
    {
        public IQueryable<Flow_FormAttr> GetList(DBContainer db)
        {
            IQueryable<Flow_FormAttr> list = db.Flow_FormAttr.AsQueryable();
            return list;
        }

        public int Create(Flow_FormAttr entity)
        {
            using (DBContainer db = new DBContainer())
            {
                db.Flow_FormAttr.Add(entity);
                return db.SaveChanges();
            }
        }

        public int Delete(string id)
        {
            using (DBContainer db = new DBContainer())
            {
                Flow_FormAttr entity = db.Flow_FormAttr.SingleOrDefault(o => o.Id == id);
                if (entity != null)
                {
                    db.Flow_FormAttr.Remove(entity);
                }
                return db.SaveChanges();
            }
        }

        public void Delete(DBContainer db, string[] deleteCollection)
        {
            IQueryable<Flow_FormAttr> collection = from f in db.Flow_FormAttr where deleteCollection.Contains(f.Id) select f;
            db.Flow_FormAttr.RemoveRange(collection);
        }

        public int Edit(Flow_FormAttr entity)
        {
            using (DBContainer db = new DBContainer())
            {
                db.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                return db.SaveChanges();
            }
        }

        public Flow_FormAttr GetById(string id)
        {
            using (DBContainer db = new DBContainer())
            {
                return db.Flow_FormAttr.SingleOrDefault(o => o.Id == id);
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