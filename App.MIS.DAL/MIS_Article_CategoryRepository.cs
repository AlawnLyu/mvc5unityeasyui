using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.MIS.IDAL;
using App.Models;

namespace App.MIS.DAL
{
    public class MIS_Article_CategoryRepository : IMIS_Article_CategoryRepository, IDisposable
    {
        public IQueryable<MIS_Article_Category> GetList(DBContainer db)
        {
            return db.MIS_Article_Category.AsQueryable();
        }

        public int Create(MIS_Article_Category entity)
        {
            using (DBContainer db = new DBContainer())
            {
                db.MIS_Article_Category.Add(entity);
                return db.SaveChanges();
            }
        }

        public int Delete(string id)
        {
            using (DBContainer db = new DBContainer())
            {
                MIS_Article_Category entity = db.MIS_Article_Category.SingleOrDefault(o => o.Id == id);
                if (entity != null)
                {
                    db.MIS_Article_Category.Remove(entity);
                }
                return db.SaveChanges();
            }
        }

        public void Delete(DBContainer db, string[] deleteCollection)
        {
            IQueryable<MIS_Article_Category> collection = from f in db.MIS_Article_Category
                                                          where deleteCollection.Contains(f.Id)
                                                          select f;
            db.MIS_Article_Category.RemoveRange(collection);
        }

        public int Edit(MIS_Article_Category entity)
        {
            using (DBContainer db = new DBContainer())
            {
                db.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                return db.SaveChanges();
            }
        }

        public MIS_Article_Category GetById(string id)
        {
            using (DBContainer db = new DBContainer())
            {
                return db.MIS_Article_Category.SingleOrDefault(o => o.Id == id);
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
