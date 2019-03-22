ALTER TABLE [dbo].[Komentar]
	ADD CONSTRAINT [Komentar_FK]
	FOREIGN KEY (Artikal_Naziv)
	REFERENCES [Artikal] (Naziv)
