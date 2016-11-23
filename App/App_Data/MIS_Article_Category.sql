USE [DB]
GO

/****** Object:  Table [dbo].[MIS_Article_Category]    Script Date: 05/15/2014 17:37:44 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[MIS_Article_Category](
    [Id] [varchar](50) NOT NULL, --主键
    [ChannelId] [int] NULL,  --预留字段
    [Name] [varchar](100) NOT NULL, --类别名
    [ParentId] [varchar](50) NULL, --上级ID
    [Sort] [int] NULL, --排序
    [ImgUrl] [varchar](255) NULL,--图片
    [BodyContent] [varchar](8000) NULL,--描述
    [CreateTime] [datetime] NULL,--创建时间
    [Enable] [bit] NOT NULL, --是否启用
 CONSTRAINT [PK__MIS_Arti__3214EC077DCDAAA2] PRIMARY KEY CLUSTERED 
(
    [Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[MIS_Article_Category]  WITH NOCHECK ADD  CONSTRAINT [FK_MIS_Article_Category_MIS_Article_Category] FOREIGN KEY([ParentId])
REFERENCES [dbo].[MIS_Article_Category] ([Id])
GO

ALTER TABLE [dbo].[MIS_Article_Category] NOCHECK CONSTRAINT [FK_MIS_Article_Category_MIS_Article_Category]
GO

ALTER TABLE [dbo].[MIS_Article_Category] ADD  CONSTRAINT [DF__MIS_Artic__Paren__7FB5F314]  DEFAULT ((0)) FOR [ParentId]
GO

ALTER TABLE [dbo].[MIS_Article_Category] ADD  CONSTRAINT [DF__MIS_Artic__Creat__00AA174D]  DEFAULT (getdate()) FOR [CreateTime]
GO