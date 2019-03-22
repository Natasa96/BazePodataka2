ALTER TABLE [dbo].[Tip]
	ADD CONSTRAINT [Tip_FK]
	FOREIGN KEY (Artikal_Naziv)
	REFERENCES [Artikal] (Naziv)
