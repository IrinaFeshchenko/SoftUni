

CREATE FUNCTION ufn_IsWordComprised(@setOfLetters VARCHAR(MAX), @word VARCHAR(MAX)) 
RETURNS BIT
AS
BEGIN
	DECLARE @length INT = LEN(@word)
	DECLARE @index INT = 1

	WHILE(@index<=@length)
	BEGIN
		DECLARE @char char(1) = SUBSTRING(@word, @index, 1)
		IF (CHARINDEX(@char,@setOfLetters) <=0)
		BEGIN
			RETURN 0
		END
			
		SET @index = @index+1 ;
	END
	RETURN 1
END
GO

SELECT dbo.ufn_IsWordComprised('oistmiahf','Sofia')