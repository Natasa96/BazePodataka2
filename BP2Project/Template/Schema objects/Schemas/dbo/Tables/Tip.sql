CREATE TABLE [dbo].[Tip]
(
	[Tip_ID] INT NOT NULL Identity(1,1), 
    [Opis] VARCHAR(50) NULL, 
    [Naziv] VARCHAR(50) NOT NULL, 
    [Artikal_Naziv] VARCHAR(50) NOT NULL
)
