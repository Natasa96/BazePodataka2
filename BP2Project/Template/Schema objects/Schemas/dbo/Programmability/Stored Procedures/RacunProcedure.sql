CREATE PROCEDURE [dbo].[RacunProcedure]
	@sum int,
	@kupacID varchar(50)
AS
BEGIN
	INSERT [dbo].[Racun](Kupac_Username, Suma)
	values (@kupacID, @sum)
END
