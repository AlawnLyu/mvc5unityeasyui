using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.BLL.Core;
using App.Common;
using App.IBLL;
using App.IDAL;
using App.Models;
using App.Models.Sys;
using Microsoft.Practices.Unity;

namespace App.BLL
{
    public class SysRightBLL : BaseBLL, ISysRightBLL
    {
        [Dependency]
        public ISysRightRepository m_Rep { get; set; }

        public int UpdateRight(SysRightOperateModel model)
        {
            //转换
            SysRightOperate rightOperate = new SysRightOperate();
            rightOperate.Id = model.Id;
            rightOperate.RightId = model.RightId;
            rightOperate.KeyCode = model.KeyCode;
            rightOperate.IsValid = model.IsValid;
            return m_Rep.UpdateRight(rightOperate);
        }

        public List<SysRightModelByRoleAndModuleModel> GetRightByRoleAndModule(string roleId, string moduleId)
        {
            List<P_Sys_GetRightByRoleAndModule_Result> queryData = m_Rep.GetRightByRoleAndModule(roleId, moduleId);
            return CreateModelList(ref queryData);
        }

        public IQueryable<P_Sys_GetRoleByUserId_Result> GetRoleByUserId(ref GridPager pager, string userId)
        {
            IQueryable<P_Sys_GetRoleByUserId_Result> queryData = m_Rep.GetRoleByUserId(db, userId);
            pager.totalRows = queryData.Count();
            queryData = m_Rep.GetRoleByUserId(db, userId);
            return queryData.Skip((pager.page - 1) * pager.rows).Take(pager.rows);
        }

        public IQueryable<P_Sys_GetUserByRoleId_Result> GetUserByRoleId(ref GridPager pager, string roleId)
        {
            IQueryable<P_Sys_GetUserByRoleId_Result> queryData = m_Rep.GetUserByRoleId(db, roleId);
            pager.totalRows = queryData.Count();
            queryData = m_Rep.GetUserByRoleId(db, roleId);
            return queryData.Skip((pager.page - 1) * pager.rows).Take(pager.rows);
        }

        public string GetRefSysUser(string roleId)
        {
            string UserName = "";
            var userList = m_Rep.GetRefSysUser(db, roleId);
            if (userList != null)
            {
                foreach (var user in userList)
                {
                    UserName += "[" + user.UserName + "] ";
                }
            }
            return UserName;
        }

        public string GetRefSysRole(string userId)
        {
            string RoleName = "";
            var roleList = m_Rep.GetRefSysRole(db, userId);
            if (roleList != null)
            {
                foreach (var user in roleList)
                {
                    RoleName += "[" + user.Name + "] ";
                }
            }
            return RoleName;
        }

        public bool UpdateSysRoleSysUser(string userId, string[] roleIds)
        {
            try
            {
                m_Rep.UpdateSysRoleSysUser(userId, roleIds);
                return true;

            }
            catch (Exception ex)
            {
                ExceptionHandler.WriteException(ex);
                return false;
            }
        }

        public bool UpdateSysUserSysRole(string roleId, string[] userIds)
        {
            try
            {
                m_Rep.UpdateSysUserSysRole(roleId, userIds);
                return true;

            }
            catch (Exception ex)
            {
                ExceptionHandler.WriteException(ex);
                return false;
            }
        }

        private List<SysRightModelByRoleAndModuleModel> CreateModelList(
            ref List<P_Sys_GetRightByRoleAndModule_Result> queryData)
        {
            return queryData.Select(r => new SysRightModelByRoleAndModuleModel()
            {
                Ids = r.RightId + r.KeyCode,
                Name = r.Name,
                KeyCode = r.KeyCode,
                IsValid = r.isvalid,
                RightId = r.RightId
            }).ToList();
        }
    }
}
