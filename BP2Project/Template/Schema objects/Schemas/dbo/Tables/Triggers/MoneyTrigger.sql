CREATE TRIGGER [MoneyTrigger]
	ON [dbo].[Kupac]
	FOR INSERT
	AS
	BEGIN
		declare @money int
		declare @kupacID varchar(50)
		select @kupacID=i.Username from inserted i
		set @money=100000
		update [dbo].[Kupac] set Racun=@money where Username=@kupacID
	END
