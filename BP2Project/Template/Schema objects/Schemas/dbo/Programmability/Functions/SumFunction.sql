CREATE FUNCTION [dbo].[SumFunction]
(
	@kupacID varchar(50)
)
RETURNS INT 
AS 
BEGIN
	declare @sum int
	set @sum = (select sum(Cena) from [dbo].[Artikal] a inner join [dbo].[StavkaKorpe] sk on a.Naziv=sk.Artikal_Naziv 
		where sk.Kupac_Username=@kupacID)
	return @sum
END

