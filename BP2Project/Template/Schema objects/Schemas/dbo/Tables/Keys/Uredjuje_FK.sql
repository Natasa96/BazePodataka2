ALTER TABLE [dbo].[Uredjuje]
	ADD CONSTRAINT [Uredjuje_FK]
	FOREIGN KEY (Proizvodjac_ID, Artikal_Naziv)
	REFERENCES [Pravi] (Proizvodjac_ID, Artikal_Naziv)
