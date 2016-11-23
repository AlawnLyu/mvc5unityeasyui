Create PROCEDURE [dbo].[P_Sys_UpdateSysRoleSysUser]
@roleId varchar(50),@userId varchar(50)
AS
--更新角色用户中间关系表
BEGIN
    insert into SysRoleSysUser(Id,SysRoleId,SysUserId)
        values(@userId+@roleId,@roleId,@userId)
END