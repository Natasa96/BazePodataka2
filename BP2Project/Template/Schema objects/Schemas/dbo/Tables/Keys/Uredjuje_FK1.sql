ALTER TABLE [dbo].[Uredjuje]
	ADD CONSTRAINT [Uredjuje_FK1]
	FOREIGN KEY (Admin_Username)
	REFERENCES [Admin] (Username)
