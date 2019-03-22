ALTER TABLE [dbo].[Pravi]
	ADD CONSTRAINT [Pravi_FK1]
	FOREIGN KEY (Proizvodjac_ID)
	REFERENCES [Proizvodjac] (Proizvodjac_ID)
