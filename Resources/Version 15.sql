
CREATE TABLE [dbo].[tblProductSub](
	[SubCatId] [int] NOT NULL,
	[ProductId] [int] NULL,
	[SubCatName] [varchar](250) NULL,
	[CreatedBy] [int] NULL,
	[CreatedDate] [datetime] NULL,
 CONSTRAINT [PK_tblProductSub] PRIMARY KEY CLUSTERED 
(
	[SubCatId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]



/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.tblSubStock ADD
	SubCategoryID int NULL,
	Type varchar(250) NULL
GO
ALTER TABLE dbo.tblSubStock SET (LOCK_ESCALATION = TABLE)
GO
COMMIT





INSERT INTO [dbWengLee].[dbo].[tblVersion]
           ([Version])
     VALUES
           (15)
           
GO