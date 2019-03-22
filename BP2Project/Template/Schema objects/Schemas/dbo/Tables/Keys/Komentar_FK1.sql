ALTER TABLE [dbo].[Komentar]
	ADD CONSTRAINT [Komentar_FK1]
	FOREIGN KEY (Kupac_Username)
	REFERENCES [Kupac] (Username)
