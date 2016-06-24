ALTER TABLE dbo.tblProducts ADD
	TrackInventory bit NULL

	GO

update tblProducts set TrackInventory = 1 




INSERT INTO [dbWengLee].[dbo].[tblVersion]
           ([Version])
     VALUES
           (17)
           
GO