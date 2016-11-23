Create PROCEDURE [dbo].[P_Sys_DeleteSysRoleSysUserByRoleId]
@roleId varchar(50)
AS
--更新角色用户中间关系表,前删除关联
BEGIN
    delete SysRoleSysUser where SysRoleId=@roleId
END