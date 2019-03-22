ALTER TABLE [dbo].[Pravi]
	ADD CONSTRAINT [Pravi_FK2]
	FOREIGN KEY (Artikal_Naziv)
	REFERENCES [Artikal] (Naziv)
