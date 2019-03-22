ALTER TABLE [dbo].[Racun]
	ADD CONSTRAINT [Racun_FK]
	FOREIGN KEY (Kupac_Username)
	REFERENCES [Kupac] (Username)
