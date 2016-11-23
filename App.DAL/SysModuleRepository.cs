using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.IDAL;
using App.Models;

namespace App.DAL
{
    public class SysModuleRepository : ISysModuleRepository, IDisposable
    {
        public IQueryable<SysModule> GetList(DBContainer db)
        {
            IQueryable<SysModule> list = db.SysModule.AsQueryable();
            return list;
        }

        public IQueryable<SysModule> GetModuleBySystem(DBContainer db, string parentId)
        {
            IQueryable<SysModule> list = db.SysModule.Where(o => o.ParentId == parentId).AsQueryable();
            return list;
        }

        public int Create(SysModule entity)
        {
            using (DBContainer db = new DBContainer())
            {
                db.SysModule.Add(entity);
                return db.SaveChanges();
            }
        }

        public void Delete(DBContainer db, string id)
        {
            SysModule entity = db.SysModule.SingleOrDefault(o => o.Id == id);
            if (entity != null)
            {
                //删除sysright表数据
                var sr = db.SysRight.AsQueryable().Where(a => a.ModuleId == entity.Id);
                foreach (var o in sr)
                {
                    //删除sysrightoperate表数据
                    var sro = db.SysRightOperate.AsQueryable().Where(a => a.RightId == o.Id);
                    foreach (var o2 in sro)
                    {
                        db.SysRightOperate.Remove(o2);
                    }
                    db.SysRight.Remove(o);
                }
                //删除sysmoduleoperate表数据
                var smo = db.SysModuleOperate.AsQueryable().Where(a => a.ModuleId == entity.Id);
                foreach (var o3 in smo)
                {
                    db.SysModuleOperate.Remove(o3);
                }
                db.SysModule.Remove(entity);
                //db.SaveChanges();
            }
        }

        public int Edit(SysModule entity)
        {
            using (DBContainer db = new DBContainer())
            {
                db.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                return db.SaveChanges();
            }
        }

        public SysModule GetById(string id)
        {
            using (DBContainer db = new DBContainer())
            {
                return db.SysModule.SingleOrDefault(a => a.Id == id);
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
