ALTER TABLE [dbo].[Vrsta]
	ADD CONSTRAINT [Vrsta_FK1]
	FOREIGN KEY (Tip_ID, Artikal_Naziv)
	REFERENCES [Tip] (Tip_ID, Artikal_Naziv)
