CREATE TABLE [dbo].[SysStruct](
    [Id] [varchar](50) NOT NULL,            --主键ID
    [Name] [varchar](50) NOT NULL,          --架构名称
    [ParentId] [varchar](50) NOT NULL,      --上级ID
    [Sort] [int] NOT NULL,                  --排序
    [Higher] [varchar](50) NULL,            --  备用
    [Enable] [bit] NOT NULL,                --是否启用
    [Remark] [varchar](500) NULL,           --说明
    [CreateTime] [datetime] NOT NULL,       --创建时间
 CONSTRAINT [PK_SysStruct] PRIMARY KEY CLUSTERED 
(
    [Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[SysStruct]  WITH NOCHECK ADD  CONSTRAINT [FK_SysStruct_SysStruct] FOREIGN KEY([ParentId])
REFERENCES [dbo].[SysStruct] ([Id])
GO

ALTER TABLE [dbo].[SysStruct] NOCHECK CONSTRAINT [FK_SysStruct_SysStruct]
GO

ALTER TABLE [dbo].[SysStruct] ADD  CONSTRAINT [DF_SysStruct_Sort]  DEFAULT ((0)) FOR [Sort]
GO

ALTER TABLE [dbo].[SysStruct] ADD  CONSTRAINT [DF__SysStruct__Highe__3D2915A8]  DEFAULT ((0)) FOR [Higher]
GO

ALTER TABLE [dbo].[SysStruct] ADD  CONSTRAINT [DF_SysStruct_State]  DEFAULT ((1)) FOR [Enable]
GO

ALTER TABLE [dbo].[SysStruct] ADD  CONSTRAINT [DF_SysStruct_CreateTime]  DEFAULT (getdate()) FOR [CreateTime]
GO