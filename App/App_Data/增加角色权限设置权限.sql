
INSERT INTO [SysModuleOperate] ([Id],[Name],[KeyCode],[ModuleId],[IsValid],[Sort]) values ('RoleAuthorizeCreate','创建','Create','RoleAuthorize',0,0)
INSERT INTO [SysModuleOperate] ([Id],[Name],[KeyCode],[ModuleId],[IsValid],[Sort]) values ('RoleAuthorizeDelete','删除','Delete','RoleAuthorize',0,0)
INSERT INTO [SysModuleOperate] ([Id],[Name],[KeyCode],[ModuleId],[IsValid],[Sort]) values ('RoleAuthorizeDetails','详细','Details','RoleAuthorize',0,0)
INSERT INTO [SysModuleOperate] ([Id],[Name],[KeyCode],[ModuleId],[IsValid],[Sort]) values ('RoleAuthorizeEdit','编辑','Edit','RoleAuthorize',0,0)
INSERT INTO [SysModuleOperate] ([Id],[Name],[KeyCode],[ModuleId],[IsValid],[Sort]) values ('RoleAuthorizeExport','导出','Export','RoleAuthorize',0,0)
INSERT INTO [SysModuleOperate] ([Id],[Name],[KeyCode],[ModuleId],[IsValid],[Sort]) values ('RoleAuthorizeQuery','查询','Query','RoleAuthorize',0,0)
INSERT INTO [SysModuleOperate] ([Id],[Name],[KeyCode],[ModuleId],[IsValid],[Sort]) values ('RoleAuthorizeSave','保存','Save','RoleAuthorize',0,0)

INSERT INTO [SysRight] ([Id],[ModuleId],[RoleId],[Rightflag]) values ('administratorRoleAuthorize','RoleAuthorize','administrator',1)


INSERT INTO [SysRightOperate] ([Id],[RightId],[KeyCode],[IsValid]) values ('administratorRoleAuthorizeCreate','administratorRoleAuthorize','Create',1)
INSERT INTO [SysRightOperate] ([Id],[RightId],[KeyCode],[IsValid]) values ('administratorRoleAuthorizeDelete','administratorRoleAuthorize','Delete',1)
INSERT INTO [SysRightOperate] ([Id],[RightId],[KeyCode],[IsValid]) values ('administratorRoleAuthorizeDetails','administratorRoleAuthorize','Details',1)
INSERT INTO [SysRightOperate] ([Id],[RightId],[KeyCode],[IsValid]) values ('administratorRoleAuthorizeEdit','administratorRoleAuthorize','Edit',1)
INSERT INTO [SysRightOperate] ([Id],[RightId],[KeyCode],[IsValid]) values ('administratorRoleAuthorizeExport','administratorRoleAuthorize','Export',1)
INSERT INTO [SysRightOperate] ([Id],[RightId],[KeyCode],[IsValid]) values ('administratorRoleAuthorizeQuery','administratorRoleAuthorize','Query',1)
INSERT INTO [SysRightOperate] ([Id],[RightId],[KeyCode],[IsValid]) values ('administratorRoleAuthorizeSave','administratorRoleAuthorize','Save',1)

INSERT INTO [SysModuleOperate] ([Id],[Name],[KeyCode],[ModuleId],[IsValid],[Sort]) values ('UserManageAllot','分配角色','Allot','UserManage',0,0)
INSERT INTO [SysModuleOperate] ([Id],[Name],[KeyCode],[ModuleId],[IsValid],[Sort]) values ('UserManageCreate','创建','Create','UserManage',0,0)
INSERT INTO [SysModuleOperate] ([Id],[Name],[KeyCode],[ModuleId],[IsValid],[Sort]) values ('UserManageDelete','删除','Delete','UserManage',0,0)
INSERT INTO [SysModuleOperate] ([Id],[Name],[KeyCode],[ModuleId],[IsValid],[Sort]) values ('UserManageDetails','详细','Details','UserManage',0,0)
INSERT INTO [SysModuleOperate] ([Id],[Name],[KeyCode],[ModuleId],[IsValid],[Sort]) values ('UserManageEdit','编辑','Edit','UserManage',0,0)
INSERT INTO [SysModuleOperate] ([Id],[Name],[KeyCode],[ModuleId],[IsValid],[Sort]) values ('UserManageExport','导出','Export','UserManage',0,0)
INSERT INTO [SysModuleOperate] ([Id],[Name],[KeyCode],[ModuleId],[IsValid],[Sort]) values ('UserManageQuery','查询','Query','UserManage',0,0)
INSERT INTO [SysModuleOperate] ([Id],[Name],[KeyCode],[ModuleId],[IsValid],[Sort]) values ('UserManageSave','保存','Save','UserManage',0,0)

INSERT INTO [SysRight] ([Id],[ModuleId],[RoleId],[Rightflag]) values ('administratorUserManage','UserManage','administrator',1)

INSERT INTO [SysRightOperate] ([Id],[RightId],[KeyCode],[IsValid]) values ('administratorUserManageAllot','administratorUserManage','Allot',1)
INSERT INTO [SysRightOperate] ([Id],[RightId],[KeyCode],[IsValid]) values ('administratorUserManageCreate','administratorUserManage','Create',1)
INSERT INTO [SysRightOperate] ([Id],[RightId],[KeyCode],[IsValid]) values ('administratorUserManageDelete','administratorUserManage','Delete',1)
INSERT INTO [SysRightOperate] ([Id],[RightId],[KeyCode],[IsValid]) values ('administratorUserManageDetails','administratorUserManage','Details',1)
INSERT INTO [SysRightOperate] ([Id],[RightId],[KeyCode],[IsValid]) values ('administratorUserManageEdit','administratorUserManage','Edit',1)
INSERT INTO [SysRightOperate] ([Id],[RightId],[KeyCode],[IsValid]) values ('administratorUserManageExport','administratorUserManage','Export',1)
INSERT INTO [SysRightOperate] ([Id],[RightId],[KeyCode],[IsValid]) values ('administratorUserManageQuery','administratorUserManage','Query',1)
INSERT INTO [SysRightOperate] ([Id],[RightId],[KeyCode],[IsValid]) values ('administratorUserManageSave','administratorUserManage','Save',1)