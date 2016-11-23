using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Common;
using App.Models;
using App.Models.Sys;

namespace App.IBLL
{
    public interface ISysRightBLL
    {
        int UpdateRight(SysRightOperateModel model);

        List<SysRightModelByRoleAndModuleModel> GetRightByRoleAndModule(string roleId, string moduleId);

        IQueryable<P_Sys_GetRoleByUserId_Result> GetRoleByUserId(ref GridPager pager, string userId);

        IQueryable<P_Sys_GetUserByRoleId_Result> GetUserByRoleId(ref GridPager pager, string roleId);

        string GetRefSysUser(string roleId);

        string GetRefSysRole(string userId);

        bool UpdateSysRoleSysUser(string userId, string[] roleIds);

        bool UpdateSysUserSysRole(string roleId, string[] userIds);
    }
}
