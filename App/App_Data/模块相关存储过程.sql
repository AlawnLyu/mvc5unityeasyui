USE [DB]
GO
/****** Object:  StoredProcedure [dbo].[P_Sys_InsertSysRight]    Script Date: 12/24/2013 23:10:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[P_Sys_InsertSysRight]
as
--将设置好的模块分配到角色组
    insert into SysRight(Id,ModuleId,RoleId,Rightflag)
        select distinct b.Id+a.Id,a.Id,b.Id,0 from SysModule a,SysRole b
        where a.Id+b.Id not in(select ModuleId+RoleId from SysRight)
        
GO    

Create proc [dbo].[P_Sys_ClearUnusedRightOperate]
as
--清理权限中的无用项目
delete from SysRightOperate where Id not in(
    select a.RoleId+a.ModuleId+b.KeyCode from SysRight a,SysModuleOperate b
        where a.ModuleId = b.ModuleId
)
GO