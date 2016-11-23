Create PROCEDURE [dbo].[P_Sys_DeleteSysRoleSysUserByUserId]
@userId varchar(50)
AS
--更新角色用户中间关系表,前删除关联
BEGIN
    delete SysRoleSysUser where SysUserId=@userId
END