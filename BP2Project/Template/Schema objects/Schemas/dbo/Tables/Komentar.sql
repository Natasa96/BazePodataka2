CREATE TABLE [dbo].[Komentar]
(
	[Sadrzaj] VARCHAR(50) NULL, 
    [Ocena] INT NULL, 
    [Komentar_ID] INT NOT NULL Identity(1,1), 
    [Artikal_Naziv] VARCHAR(50) NOT NULL, 
    [Kupac_Username] VARCHAR(50) NOT NULL
)
