using System;
using System.Linq;
using App.Flow.IDAL;
using App.Models;
using System.Data;

namespace App.Flow.DAL
{
    public class Flow_StepRuleRepository : IFlow_StepRuleRepository, IDisposable
    {
        public IQueryable<Flow_StepRule> GetList(DBContainer db)
        {
            IQueryable<Flow_StepRule> list = db.Flow_StepRule.AsQueryable();
            return list;
        }

        public int Create(Flow_StepRule entity)
        {
            using (DBContainer db = new DBContainer())
            {
                db.Flow_StepRule.Add(entity);
                return db.SaveChanges();
            }
        }

        public int Delete(string id)
        {
            using (DBContainer db = new DBContainer())
            {
                Flow_StepRule entity = db.Flow_StepRule.SingleOrDefault(o => o.Id == id);
                if (entity != null)
                {
                    db.Flow_StepRule.Remove(entity);
                }
                return db.SaveChanges();
            }
        }

        public void Delete(DBContainer db, string[] deleteCollection)
        {
            IQueryable<Flow_StepRule> collection = from f in db.Flow_StepRule where deleteCollection.Contains(f.Id) select f;
            db.Flow_StepRule.RemoveRange(collection);
        }

        public int Edit(Flow_StepRule entity)
        {
            using (DBContainer db = new DBContainer())
            {
                db.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                return db.SaveChanges();
            }
        }

        public Flow_StepRule GetById(string id)
        {
            using (DBContainer db = new DBContainer())
            {
                return db.Flow_StepRule.SingleOrDefault(o => o.Id == id);
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