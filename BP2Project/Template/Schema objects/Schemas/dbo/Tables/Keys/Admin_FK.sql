ALTER TABLE [dbo].[Admin]
	ADD CONSTRAINT [Admin_FK]
	FOREIGN KEY (Username)
	REFERENCES [Korisnik] (Username)
