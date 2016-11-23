using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.MIS.IDAL;
using App.Models;

namespace App.MIS.DAL
{
    public class MIS_ArticleRepository : IMIS_ArticleRepository, IDisposable
    {
        public IQueryable<MIS_Article> GetList(DBContainer db)
        {
            return db.MIS_Article.AsQueryable();
        }

        public int Create(MIS_Article entity)
        {
            using (DBContainer db = new DBContainer())
            {
                db.MIS_Article.Add(entity);
                return db.SaveChanges();
            }
        }

        public int Delete(string id)
        {
            using (DBContainer db = new DBContainer())
            {
                MIS_Article entity = db.MIS_Article.SingleOrDefault(o => o.Id == id);
                if (entity != null)
                {
                    db.MIS_Article.Remove(entity);
                }
                return db.SaveChanges();
            }
        }

        public void Delete(DBContainer db, string[] deleteCollection)
        {
            IQueryable<MIS_Article> collection = from f in db.MIS_Article
                                                 where deleteCollection.Contains(f.Id)
                                                 select f;
            db.MIS_Article.RemoveRange(collection);
        }

        public int Edit(MIS_Article entity)
        {
            using (DBContainer db = new DBContainer())
            {
                db.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                return db.SaveChanges();
            }
        }

        public MIS_Article GetById(string id)
        {
            using (DBContainer db = new DBContainer())
            {
                return db.MIS_Article.SingleOrDefault(a => a.Id == id);
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
