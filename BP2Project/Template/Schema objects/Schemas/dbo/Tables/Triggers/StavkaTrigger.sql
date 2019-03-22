CREATE TRIGGER [StavkaTrigger]
	ON [dbo].[Racun]
	FOR INSERT
	AS
	BEGIN
		declare @kupacID varchar(50)
		declare @racunID int
		select @kupacID=i.Kupac_Username from inserted i
		select @racunID=i.Racun_ID from inserted i
		delete [dbo].[StavkaKorpe] where StavkaKorpe.Kupac_Username=@kupacID
		update [dbo].[Racun] set StavkaKorpe='Placeno' where @racunID=Racun_ID
	END
