using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Flow.IDAL;
using App.Models;

namespace App.Flow.DAL
{
    public class Flow_StepRepository : IFlow_StepRepository, IDisposable
    {
        public IQueryable<Flow_Step> GetList(DBContainer db)
        {
            IQueryable<Flow_Step> list = db.Flow_Step.AsQueryable();
            return list;
        }

        public int Create(Flow_Step entity)
        {
            using (DBContainer db = new DBContainer())
            {
                db.Flow_Step.Add(entity);
                return db.SaveChanges();
            }
        }

        public int Delete(string id)
        {
            using (DBContainer db = new DBContainer())
            {
                Flow_Step entity = db.Flow_Step.SingleOrDefault(o => o.Id == id);
                if (entity != null)
                {
                    var fsr = db.Flow_StepRule.AsQueryable().Where(o => o.StepId == entity.Id);
                    foreach (var o in fsr)
                    {
                        db.Flow_StepRule.Remove(o);
                    }
                    db.Flow_Step.Remove(entity);
                }
                return db.SaveChanges();
            }
        }

        public void Delete(DBContainer db, string[] deleteCollection)
        {
            IQueryable<Flow_Step> collection = from f in db.Flow_Step where deleteCollection.Contains(f.Id) select f;
            db.Flow_Step.RemoveRange(collection);
        }

        public int Edit(Flow_Step entity)
        {
            using (DBContainer db = new DBContainer())
            {
                db.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                return db.SaveChanges();
            }
        }

        public Flow_Step GetById(string id)
        {
            using (DBContainer db = new DBContainer())
            {
                return db.Flow_Step.SingleOrDefault(o => o.Id == id);
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
