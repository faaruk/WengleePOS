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
	T_Date datetime NULL
GO
ALTER TABLE dbo.tblSubStock SET (LOCK_ESCALATION = TABLE)
GO
COMMIT

update tblSubStock set T_Date = CreatedDate 




INSERT INTO [dbWengLee].[dbo].[tblVersion]
           ([Version])
     VALUES
           (16)
           
GO