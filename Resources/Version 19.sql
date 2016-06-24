CREATE TABLE [dbo].[tblTask](
	[TaskId] [int] NOT NULL,
	[CreatedDate] [datetime] NULL,
	[TaskDate] [datetime] NULL,
	[Task] [nvarchar](max) NULL,
	[TaskSubject] [nvarchar](500) NULL,
	[Details] [nvarchar](max) NULL,
	[Createdby] [int] NULL,
	[UpdatedBy] [int] NULL,
	[UpdatedDate] [datetime] NULL,
	[TaskStatus] [varchar](50) NULL,
 CONSTRAINT [PK_tblTask] PRIMARY KEY CLUSTERED 
(
	[TaskId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]


GO


INSERT INTO [dbWengLee].[dbo].[tblVersion]
           ([Version])
     VALUES
           (19)
           
GO