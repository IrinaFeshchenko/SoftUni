USE Gringotts
GO

DECLARE @previousDeposit decimal(8,2)
DECLARE @currentDeposit decimal(8,2)
DECLARE @totalSum decimal(8,2) = 0

DECLARE wizzCursor CURSOR FOR SELECT DepositAmount FROM WizzardDeposits
OPEN wizzCursor

	WHILE(1=1)
	BEGIN
		FETCH NEXT FROM wizzCursor INTO @currentDeposit
		IF(@@FETCH_STATUS != 0) BREAK

		IF(@previousDeposit IS NOT NULL)
		BEGIN
			SET @totalSum += @previousDeposit - @currentDeposit
		END

		SET @previousDeposit = @currentDeposit
	END

CLOSE wizzCursor
DEALLOCATE wizzCursor

SELECT @totalSum