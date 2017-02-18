create function udf_GetRadians(@degrees float)
returns float
as
begin
	declare @radians float = @degrees * (PI()/180)
return @radians
end