ALTER TABLE [dbo].[StavkaKorpe]
	ADD CONSTRAINT [StavkaKorpe_FK1]
	FOREIGN KEY (Artikal_Naziv)
	REFERENCES [Artikal] (Naziv)
