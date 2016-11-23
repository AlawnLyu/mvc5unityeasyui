using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.IDAL;
using App.Models;
using App.Models.Sys;

namespace App.DAL
{
    public class SysRightRepository : ISysRightRepository, IDisposable
    {
        public List<permModel> GetPermission(string accountid, string controller)
        {
            using (DBContainer db = new DBContainer())
            {
                List<permModel> rights = (from r in db.P_Sys_GetRightOperate(accountid, controller)
                                          select new permModel
                                          {
                                              KeyCode = r.KeyCode,
                                              IsValid = r.IsValid
                                          }).ToList();
                return rights;
            }
        }

        public int UpdateRight(SysRightOperate model)
        {
            //判断rightOperate是否存在，如果存在就更新rightOperate，否则就添加一条
            using (DBContainer db = new DBContainer())
            {
                SysRightOperate right = db.SysRightOperate.FirstOrDefault(o => o.Id == model.Id);
                if (right != null)
                {
                    right.RightId = model.RightId;
                    right.KeyCode = model.KeyCode;
                    right.IsValid = model.IsValid;
                    db.Entry(right).State = System.Data.Entity.EntityState.Modified;
                }
                else
                {
                    db.SysRightOperate.Add(model);
                }
                if (db.SaveChanges() > 0)
                {
                    //更新角色--模块的有效标志RightFlag
                    var sysRight = (from r in db.SysRight where r.Id == model.RightId select r).First();
                    db.P_Sys_UpdateSysRightRightFlag(sysRight.ModuleId, sysRight.RoleId);
                    return 1;
                }
            }
            return 0;
        }

        public List<P_Sys_GetRightByRoleAndModule_Result> GetRightByRoleAndModule(string roleId, string moduleId)
        {
            List<P_Sys_GetRightByRoleAndModule_Result> result = null;
            using (DBContainer db = new DBContainer())
            {
                result = db.P_Sys_GetRightByRoleAndModule(roleId, moduleId).ToList();
            }
            return result;
        }

        public IQueryable<P_Sys_GetRoleByUserId_Result> GetRoleByUserId(DBContainer db, string userId)
        {
            return db.P_Sys_GetRoleByUserId(userId).AsQueryable();
        }

        public IQueryable<P_Sys_GetUserByRoleId_Result> GetUserByRoleId(DBContainer db, string roleId)
        {
            return db.P_Sys_GetUserByRoleId(roleId).AsQueryable();
        }

        public IQueryable<SysUser> GetRefSysUser(DBContainer db, string roleId)
        {
            if (!string.IsNullOrWhiteSpace(roleId))
            {
                return from m in db.SysUser
                       join f in db.SysRoleSysUser
                       on m.Id equals f.SysUserId
                       where f.SysRoleId == roleId
                       select m;
            }
            return null;
        }

        public IQueryable<SysRole> GetRefSysRole(DBContainer db, string userId)
        {
            if (!string.IsNullOrWhiteSpace(userId))
            {
                return from m in db.SysRole
                       join f in db.SysRoleSysUser
                       on m.Id equals f.SysRoleId
                       where f.SysUserId == userId
                       select m;
            }
            return null;
        }

        public void UpdateSysRoleSysUser(string userId, string[] roleIds)
        {
            using (DBContainer db = new DBContainer())
            {
                db.P_Sys_DeleteSysRoleSysUserByUserId(userId);
                foreach (string roleid in roleIds)
                {
                    if (!string.IsNullOrWhiteSpace(roleid))
                    {
                        db.P_Sys_UpdateSysRoleSysUser(roleid, userId);
                    }
                }
                db.SaveChanges();
            }
        }

        public void UpdateSysUserSysRole(string roleId, string[] userIds)
        {
            using (DBContainer db = new DBContainer())
            {
                db.P_Sys_DeleteSysRoleSysUserByRoleId(roleId);
                foreach (var userid in userIds)
                {
                    if (!string.IsNullOrWhiteSpace(userid))
                    {
                        db.P_Sys_UpdateSysRoleSysUser(roleId, userid);
                    }
                }
                db.SaveChanges();
            }
        }

        public void Dispose()
        {
        }
    }
}
