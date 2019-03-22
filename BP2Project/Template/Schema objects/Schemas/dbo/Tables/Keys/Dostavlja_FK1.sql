ALTER TABLE [dbo].[Dostavlja]
	ADD CONSTRAINT [Dostavlja_FK1]
	FOREIGN KEY (Lokacija_ID)
	REFERENCES [Lokacija] (Lokacija_ID)
