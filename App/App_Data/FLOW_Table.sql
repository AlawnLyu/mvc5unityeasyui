USE [DB]
GO
/****** Object:  Table [dbo].[Flow_Type]    Script Date: 03/21/2015 22:36:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Flow_Type](
    [Id] [varchar](50) NOT NULL,
    [Name] [varchar](50) NOT NULL,
    [Remark] [varchar](500) NULL,
    [CreateTime] [datetime] NOT NULL,
    [Sort] [int] NOT NULL,
 CONSTRAINT [PK_Flow_Type] PRIMARY KEY CLUSTERED 
(
    [Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'类别' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Flow_Type', @level2type=N'COLUMN',@level2name=N'Name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'说明' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Flow_Type', @level2type=N'COLUMN',@level2name=N'Remark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Flow_Type', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'排序' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Flow_Type', @level2type=N'COLUMN',@level2name=N'Sort'
GO
/****** Object:  Table [dbo].[Flow_Seal]    Script Date: 03/21/2015 22:36:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Flow_Seal](
    [Id] [varchar](50) NOT NULL,
    [Path] [varchar](200) NULL,
    [CreateTime] [datetime] NULL,
    [Using] [varchar](4000) NULL,
 CONSTRAINT [PK_Flow_Seal] PRIMARY KEY CLUSTERED 
(
    [Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'使用者' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Flow_Seal', @level2type=N'COLUMN',@level2name=N'Using'
GO
/****** Object:  Table [dbo].[Flow_FormAttr]    Script Date: 03/21/2015 22:36:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Flow_FormAttr](
    [Id] [varchar](50) NOT NULL,
    [Title] [varchar](50) NOT NULL,
    [Name] [varchar](50) NOT NULL,
    [AttrType] [varchar](50) NOT NULL,
    [CheckJS] [varchar](500) NULL,
    [TypeId] [varchar](50) NOT NULL,
    [CreateTime] [datetime] NULL,
    [OptionList] [varchar](500) NULL,
    [IsValid] [bit] NULL,
 CONSTRAINT [PK_Flow_FormAttr] PRIMARY KEY CLUSTERED 
(
    [Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Flow_FormAttr', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'字段标题' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Flow_FormAttr', @level2type=N'COLUMN',@level2name=N'Title'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'字段英文名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Flow_FormAttr', @level2type=N'COLUMN',@level2name=N'Name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'文本,日期,数字,多行文本' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Flow_FormAttr', @level2type=N'COLUMN',@level2name=N'AttrType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'校验脚本' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Flow_FormAttr', @level2type=N'COLUMN',@level2name=N'CheckJS'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'所属类别' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Flow_FormAttr', @level2type=N'COLUMN',@level2name=N'TypeId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'下拉框的值' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Flow_FormAttr', @level2type=N'COLUMN',@level2name=N'OptionList'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否必填' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Flow_FormAttr', @level2type=N'COLUMN',@level2name=N'IsValid'
GO
/****** Object:  Table [dbo].[Flow_Form]    Script Date: 03/21/2015 22:36:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Flow_Form](
    [Id] [varchar](50) NOT NULL,
    [Name] [varchar](100) NOT NULL,
    [Remark] [varchar](500) NULL,
    [UsingDep] [varchar](2000) NULL,
    [TypeId] [varchar](50) NOT NULL,
    [State] [bit] NOT NULL,
    [CreateTime] [datetime] NULL,
    [HtmlForm] [text] NULL,
    [AttrA] [varchar](50) NULL,
    [AttrB] [varchar](50) NULL,
    [AttrC] [varchar](50) NULL,
    [AttrD] [varchar](50) NULL,
    [AttrE] [varchar](50) NULL,
    [AttrF] [varchar](50) NULL,
    [AttrG] [varchar](50) NULL,
    [AttrH] [varchar](50) NULL,
    [AttrI] [varchar](50) NULL,
    [AttrJ] [varchar](50) NULL,
    [AttrK] [varchar](50) NULL,
    [AttrL] [varchar](50) NULL,
    [AttrM] [varchar](50) NULL,
    [AttrN] [varchar](50) NULL,
    [AttrO] [varchar](50) NULL,
    [AttrP] [varchar](50) NULL,
    [AttrQ] [varchar](50) NULL,
    [AttrR] [varchar](50) NULL,
    [AttrS] [varchar](50) NULL,
    [AttrT] [varchar](50) NULL,
    [AttrU] [varchar](50) NULL,
    [AttrV] [varchar](50) NULL,
    [AttrW] [varchar](50) NULL,
    [AttrX] [varchar](50) NULL,
    [AttrY] [varchar](50) NULL,
    [AttrZ] [varchar](50) NULL,
 CONSTRAINT [PK_Flow_Form] PRIMARY KEY CLUSTERED 
(
    [Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否完成流程' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Flow_Form', @level2type=N'COLUMN',@level2name=N'State'
GO
/****** Object:  Table [dbo].[Flow_Step]    Script Date: 03/21/2015 22:36:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Flow_Step](
    [Id] [varchar](50) NOT NULL,
    [Name] [varchar](50) NOT NULL,
    [Remark] [varchar](500) NULL,
    [Sort] [int] NOT NULL,
    [FormId] [varchar](50) NOT NULL,
    [FlowRule] [varchar](50) NOT NULL,
    [IsCustom] [bit] NOT NULL,
    [IsAllCheck] [bit] NOT NULL,
    [Execution] [varchar](4000) NULL,
    [CompulsoryOver] [bit] NOT NULL,
    [IsEditAttr] [bit] NOT NULL,
 CONSTRAINT [PK_Flow_Step] PRIMARY KEY CLUSTERED 
(
    [Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'步骤名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Flow_Step', @level2type=N'COLUMN',@level2name=N'Name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'步骤说明' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Flow_Step', @level2type=N'COLUMN',@level2name=N'Remark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'排序' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Flow_Step', @level2type=N'COLUMN',@level2name=N'Sort'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'所属表单' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Flow_Step', @level2type=N'COLUMN',@level2name=N'FormId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'流转规则' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Flow_Step', @level2type=N'COLUMN',@level2name=N'FlowRule'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'该流程的 发起人/创建者 是否可以 自行选择 该步骤的审批者' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Flow_Step', @level2type=N'COLUMN',@level2name=N'IsCustom'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'当规则或者角色被选择为多人时候，是否启用多人审核才通过' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Flow_Step', @level2type=N'COLUMN',@level2name=N'IsAllCheck'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'执行者与规则对应' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Flow_Step', @level2type=N'COLUMN',@level2name=N'Execution'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否可以强制完成整个流程' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Flow_Step', @level2type=N'COLUMN',@level2name=N'CompulsoryOver'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'审核者是否可以编辑发起者的附件' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Flow_Step', @level2type=N'COLUMN',@level2name=N'IsEditAttr'
GO
/****** Object:  Table [dbo].[Flow_FormContent]    Script Date: 03/21/2015 22:36:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Flow_FormContent](
    [Id] [varchar](50) NOT NULL,
    [Title] [varchar](200) NOT NULL,
    [UserId] [varchar](50) NOT NULL,
    [FormId] [varchar](50) NOT NULL,
    [FormLevel] [varchar](50) NOT NULL,
    [CreateTime] [datetime] NOT NULL,
    [AttrA] [varchar](2048) NULL,
    [AttrB] [varchar](2048) NULL,
    [AttrC] [varchar](2048) NULL,
    [AttrD] [varchar](2048) NULL,
    [AttrE] [varchar](2048) NULL,
    [AttrF] [varchar](2048) NULL,
    [AttrG] [varchar](2048) NULL,
    [AttrH] [varchar](2048) NULL,
    [AttrI] [varchar](2048) NULL,
    [AttrJ] [varchar](2048) NULL,
    [AttrK] [varchar](2048) NULL,
    [AttrL] [varchar](2048) NULL,
    [AttrM] [varchar](2048) NULL,
    [AttrN] [varchar](2048) NULL,
    [AttrO] [varchar](2048) NULL,
    [AttrP] [varchar](2048) NULL,
    [AttrQ] [varchar](2048) NULL,
    [AttrR] [varchar](2048) NULL,
    [AttrS] [varchar](2048) NULL,
    [AttrT] [varchar](2048) NULL,
    [AttrU] [varchar](2048) NULL,
    [AttrV] [varchar](2048) NULL,
    [AttrW] [varchar](2048) NULL,
    [AttrX] [varchar](2048) NULL,
    [AttrY] [varchar](2048) NULL,
    [AttrZ] [varchar](2048) NULL,
    [CustomMember] [varchar](4000) NULL,
    [TimeOut] [datetime] NOT NULL,
 CONSTRAINT [PK_Flow_FormContent] PRIMARY KEY CLUSTERED 
(
    [Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Flow_FormContent', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'发起用户' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Flow_FormContent', @level2type=N'COLUMN',@level2name=N'UserId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'对应表单' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Flow_FormContent', @level2type=N'COLUMN',@level2name=N'FormId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'公文级别' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Flow_FormContent', @level2type=N'COLUMN',@level2name=N'FormLevel'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Flow_FormContent', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
/****** Object:  Table [dbo].[Flow_FormContentStepCheck]    Script Date: 03/21/2015 22:36:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Flow_FormContentStepCheck](
    [Id] [varchar](50) NOT NULL,
    [ContentId] [varchar](50) NOT NULL,
    [StepId] [varchar](50) NOT NULL,
    [State] [int] NOT NULL,
    [StateFlag] [bit] NOT NULL,
    [CreateTime] [datetime] NOT NULL,
    [IsEnd] [bit] NOT NULL,
 CONSTRAINT [PK_Flow_StepState] PRIMARY KEY CLUSTERED 
(
    [Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Flow_FormContentStepCheck', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'所属公文' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Flow_FormContentStepCheck', @level2type=N'COLUMN',@level2name=N'ContentId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'0不通过1通过2审核中' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Flow_FormContentStepCheck', @level2type=N'COLUMN',@level2name=N'State'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'true此步骤审核完成' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Flow_FormContentStepCheck', @level2type=N'COLUMN',@level2name=N'StateFlag'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Flow_FormContentStepCheck', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
/****** Object:  Table [dbo].[Flow_StepRule]    Script Date: 03/21/2015 22:36:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Flow_StepRule](
    [Id] [varchar](50) NOT NULL,
    [StepId] [varchar](50) NOT NULL,
    [AttrId] [varchar](50) NOT NULL,
    [Operator] [varchar](10) NOT NULL,
    [Result] [varchar](50) NOT NULL,
    [NextStep] [varchar](50) NULL,
 CONSTRAINT [PK_Flow_StepRule] PRIMARY KEY CLUSTERED 
(
    [Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Flow_FormContentStepCheckState]    Script Date: 03/21/2015 22:36:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Flow_FormContentStepCheckState](
    [Id] [varchar](50) NOT NULL,
    [StepCheckId] [varchar](50) NOT NULL,
    [UserId] [varchar](50) NOT NULL,
    [CheckFlag] [int] NOT NULL,
    [Reamrk] [varchar](2000) NULL,
    [TheSeal] [varchar](50) NULL,
    [CreateTime] [datetime] NOT NULL,
 CONSTRAINT [PK_Flow_FormContentStepCheckState] PRIMARY KEY CLUSTERED 
(
    [Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'1通过0不通过2审核中' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Flow_FormContentStepCheckState', @level2type=N'COLUMN',@level2name=N'CheckFlag'
GO
/****** Object:  Default [DF_Flow_FormContent_DrafText_Time]    Script Date: 03/21/2015 22:36:52 ******/
ALTER TABLE [dbo].[Flow_FormContent] ADD  CONSTRAINT [DF_Flow_FormContent_DrafText_Time]  DEFAULT (getdate()) FOR [CreateTime]
GO
/****** Object:  ForeignKey [FK_Flow_Form_Flow_Type]    Script Date: 03/21/2015 22:36:52 ******/
ALTER TABLE [dbo].[Flow_Form]  WITH CHECK ADD  CONSTRAINT [FK_Flow_Form_Flow_Type] FOREIGN KEY([TypeId])
REFERENCES [dbo].[Flow_Type] ([Id])
GO
ALTER TABLE [dbo].[Flow_Form] CHECK CONSTRAINT [FK_Flow_Form_Flow_Type]
GO
/****** Object:  ForeignKey [FK_Flow_FormAttr_Flow_Type]    Script Date: 03/21/2015 22:36:52 ******/
ALTER TABLE [dbo].[Flow_FormAttr]  WITH CHECK ADD  CONSTRAINT [FK_Flow_FormAttr_Flow_Type] FOREIGN KEY([TypeId])
REFERENCES [dbo].[Flow_Type] ([Id])
GO
ALTER TABLE [dbo].[Flow_FormAttr] CHECK CONSTRAINT [FK_Flow_FormAttr_Flow_Type]
GO
/****** Object:  ForeignKey [FK_Flow_FormContent_Flow_Form]    Script Date: 03/21/2015 22:36:52 ******/
ALTER TABLE [dbo].[Flow_FormContent]  WITH CHECK ADD  CONSTRAINT [FK_Flow_FormContent_Flow_Form] FOREIGN KEY([FormId])
REFERENCES [dbo].[Flow_Form] ([Id])
GO
ALTER TABLE [dbo].[Flow_FormContent] CHECK CONSTRAINT [FK_Flow_FormContent_Flow_Form]
GO
/****** Object:  ForeignKey [FK_Flow_FormContent_SysUser]    Script Date: 03/21/2015 22:36:52 ******/
ALTER TABLE [dbo].[Flow_FormContent]  WITH CHECK ADD  CONSTRAINT [FK_Flow_FormContent_SysUser] FOREIGN KEY([UserId])
REFERENCES [dbo].[SysUser] ([Id])
GO
ALTER TABLE [dbo].[Flow_FormContent] CHECK CONSTRAINT [FK_Flow_FormContent_SysUser]
GO
/****** Object:  ForeignKey [FK_Flow_StepState_Flow_StepState]    Script Date: 03/21/2015 22:36:52 ******/
ALTER TABLE [dbo].[Flow_FormContentStepCheck]  WITH CHECK ADD  CONSTRAINT [FK_Flow_StepState_Flow_StepState] FOREIGN KEY([ContentId])
REFERENCES [dbo].[Flow_FormContent] ([Id])
GO
ALTER TABLE [dbo].[Flow_FormContentStepCheck] CHECK CONSTRAINT [FK_Flow_StepState_Flow_StepState]
GO
/****** Object:  ForeignKey [FK_Flow_FormContentStepCheckState_Flow_FormContentStepCheck]    Script Date: 03/21/2015 22:36:52 ******/
ALTER TABLE [dbo].[Flow_FormContentStepCheckState]  WITH CHECK ADD  CONSTRAINT [FK_Flow_FormContentStepCheckState_Flow_FormContentStepCheck] FOREIGN KEY([StepCheckId])
REFERENCES [dbo].[Flow_FormContentStepCheck] ([Id])
GO
ALTER TABLE [dbo].[Flow_FormContentStepCheckState] CHECK CONSTRAINT [FK_Flow_FormContentStepCheckState_Flow_FormContentStepCheck]
GO
/****** Object:  ForeignKey [FK_Flow_FormContentStepCheckState_SysUser]    Script Date: 03/21/2015 22:36:52 ******/
ALTER TABLE [dbo].[Flow_FormContentStepCheckState]  WITH CHECK ADD  CONSTRAINT [FK_Flow_FormContentStepCheckState_SysUser] FOREIGN KEY([UserId])
REFERENCES [dbo].[SysUser] ([Id])
GO
ALTER TABLE [dbo].[Flow_FormContentStepCheckState] CHECK CONSTRAINT [FK_Flow_FormContentStepCheckState_SysUser]
GO
/****** Object:  ForeignKey [FK_Flow_Step_Flow_Form]    Script Date: 03/21/2015 22:36:52 ******/
ALTER TABLE [dbo].[Flow_Step]  WITH CHECK ADD  CONSTRAINT [FK_Flow_Step_Flow_Form] FOREIGN KEY([FormId])
REFERENCES [dbo].[Flow_Form] ([Id])
GO
ALTER TABLE [dbo].[Flow_Step] CHECK CONSTRAINT [FK_Flow_Step_Flow_Form]
GO
/****** Object:  ForeignKey [FK_Flow_StepRule_Flow_Step]    Script Date: 03/21/2015 22:36:52 ******/
ALTER TABLE [dbo].[Flow_StepRule]  WITH CHECK ADD  CONSTRAINT [FK_Flow_StepRule_Flow_Step] FOREIGN KEY([StepId])
REFERENCES [dbo].[Flow_Step] ([Id])
GO
ALTER TABLE [dbo].[Flow_StepRule] CHECK CONSTRAINT [FK_Flow_StepRule_Flow_Step]
GO