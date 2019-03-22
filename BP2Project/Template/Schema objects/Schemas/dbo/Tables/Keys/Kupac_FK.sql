ALTER TABLE [dbo].[Kupac]
	ADD CONSTRAINT [Kupac_FK]
	FOREIGN KEY (Username)
	REFERENCES [Korisnik] (Username)
