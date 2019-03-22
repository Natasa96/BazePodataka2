ALTER TABLE [dbo].[Dostavlja]
	ADD CONSTRAINT [Dostavlja_FK]
	FOREIGN KEY (Kupac_Username)
	REFERENCES [Kupac](Username)
