INSERT INTO [SysModuleOperate] ([Id],[Name],[KeyCode],[ModuleId],[IsValid],[Sort]) values ('ModuleSettingCreate','创建','Create','ModuleSetting',0,0)
INSERT INTO [SysModuleOperate] ([Id],[Name],[KeyCode],[ModuleId],[IsValid],[Sort]) values ('ModuleSettingDelete','删除','Delete','ModuleSetting',0,0)
INSERT INTO [SysModuleOperate] ([Id],[Name],[KeyCode],[ModuleId],[IsValid],[Sort]) values ('ModuleSettingDetails','详细','Details','ModuleSetting',0,0)
INSERT INTO [SysModuleOperate] ([Id],[Name],[KeyCode],[ModuleId],[IsValid],[Sort]) values ('ModuleSettingEdit','编辑','Edit','ModuleSetting',0,0)
INSERT INTO [SysModuleOperate] ([Id],[Name],[KeyCode],[ModuleId],[IsValid],[Sort]) values ('ModuleSettingExport','导出','Export','ModuleSetting',0,0)
INSERT INTO [SysModuleOperate] ([Id],[Name],[KeyCode],[ModuleId],[IsValid],[Sort]) values ('ModuleSettingQuery','查询','Query','ModuleSetting',0,0)
INSERT INTO [SysModuleOperate] ([Id],[Name],[KeyCode],[ModuleId],[IsValid],[Sort]) values ('ModuleSettingSave','保存','Save','ModuleSetting',0,0)

INSERT INTO [SysRight] ([Id],[ModuleId],[RoleId],[Rightflag]) values ('administratorRightManage','RightManage','administrator',1)
INSERT INTO [SysRight] ([Id],[ModuleId],[RoleId],[Rightflag]) values ('administratorModuleSetting','ModuleSetting','administrator',1)


INSERT INTO [SysRightOperate] ([Id],[RightId],[KeyCode],[IsValid]) values ('administratorModuleSettingCreate','administratorModuleSetting','Create',1)
INSERT INTO [SysRightOperate] ([Id],[RightId],[KeyCode],[IsValid]) values ('administratorModuleSettingDelete','administratorModuleSetting','Delete',1)
INSERT INTO [SysRightOperate] ([Id],[RightId],[KeyCode],[IsValid]) values ('administratorModuleSettingDetails','administratorModuleSetting','Details',1)
INSERT INTO [SysRightOperate] ([Id],[RightId],[KeyCode],[IsValid]) values ('administratorModuleSettingEdit','administratorModuleSetting','Edit',1)
INSERT INTO [SysRightOperate] ([Id],[RightId],[KeyCode],[IsValid]) values ('administratorModuleSettingExport','administratorModuleSetting','Export',1)
INSERT INTO [SysRightOperate] ([Id],[RightId],[KeyCode],[IsValid]) values ('administratorModuleSettingQuery','administratorModuleSetting','Query',1)
INSERT INTO [SysRightOperate] ([Id],[RightId],[KeyCode],[IsValid]) values ('administratorModuleSettingSave','administratorModuleSetting','Save',1)