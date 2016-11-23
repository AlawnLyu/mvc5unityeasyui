using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Models;
using App.Models.Sys;

namespace App.IDAL
{
    public interface ISysRightRepository
    {
        List<permModel> GetPermission(string accountid, string controller);

        //更新
        int UpdateRight(SysRightOperate model);

        //按选择的角色及模块加载模块的权限项
        List<P_Sys_GetRightByRoleAndModule_Result> GetRightByRoleAndModule(string roleId, string moduleId);

        IQueryable<P_Sys_GetRoleByUserId_Result> GetRoleByUserId(DBContainer db, string userId);

        IQueryable<P_Sys_GetUserByRoleId_Result> GetUserByRoleId(DBContainer db, string roleId);

        IQueryable<SysUser> GetRefSysUser(DBContainer db, string roleId);

        IQueryable<SysRole> GetRefSysRole(DBContainer db, string userId);

        void UpdateSysRoleSysUser(string userId, string[] roleIds);

        void UpdateSysUserSysRole(string roleId, string[] userIds);
    }
}
