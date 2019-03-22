CREATE TABLE [dbo].[Vrsta]
(
	[Vrsta_ID] INT NOT NULL Identity(1,1), 
    [Naziv] VARCHAR(50) NOT NULL, 
    [Opis] VARCHAR(50) NULL, 
    [Tip_ID] INT NOT NULL, 
    [Artikal_Naziv] VARCHAR(50) NOT NULL
)
