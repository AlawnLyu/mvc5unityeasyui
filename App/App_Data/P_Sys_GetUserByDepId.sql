USE [DB]
GO
/****** Object:  StoredProcedure [dbo].[P_Sys_GetUserByDepId]    Script Date: 03/21/2015 22:08:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[P_Sys_GetUserByDepId]
@DepId varchar(50)
as
begin

--读取角色所包含的用户
with CTE_Depart(Id ,Name ,ParentID )as
(
    select    a.Id ,a.Name ,a.Id  ParentID
    from    SysStruct  a
    union    all
    select    a.Id,a.Name ,b.ParentID 
    from    SysStruct a
            join CTE_Depart b on a.ParentID = b.Id 
)

 select    b.*,0 as flag
from    CTE_Depart a
        left join SysUser b  on a.id = b.DepId 
where    a.ParentID=@DepId and b.Id is not null


end 