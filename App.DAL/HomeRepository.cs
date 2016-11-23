using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.IDAL;
using App.Models;

namespace App.DAL
{
    public class HomeRepository : IHomeRepository, IDisposable
    {
        public List<SysModule> GetMenuByPersonId(DBContainer db, string personId, string moduleId)
        {
            var menu =
                (from m in db.SysModule
                 join rl in db.SysRight on m.Id equals rl.ModuleId
                 join r in
                     (from r in db.SysRole
                      from u in db.SysUser
                      where u.Id == personId
                      select r) on rl.RoleId equals r.Id
                 where rl.Rightflag
                 where m.ParentId == moduleId
                 where m.Id != "0"
                 select m).Distinct()
                    .OrderBy(o => o.Sort)
                    .ToList();
            return menu;
        }

        public void Dispose()
        {
        }
    }
}
