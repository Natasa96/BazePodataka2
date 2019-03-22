ALTER TABLE [dbo].[StavkaKorpe]
	ADD CONSTRAINT [StavkaKorpe_FK]
	FOREIGN KEY ([Kupac_Username])
	REFERENCES [Kupac] (Username)
