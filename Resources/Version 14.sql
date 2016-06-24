
CREATE TABLE [dbo].[tblInvoiceStatus](
	[InvoiceNumber] [varchar](15) NULL,
	[CustomerID] [varchar](15) NULL,
	[Status] [varchar](150) NULL
) ON [PRIMARY]


INSERT INTO [dbWengLee].[dbo].[tblVersion]
           ([Version])
     VALUES
           (14)
           
GO