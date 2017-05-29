USE Hotel
GO

SELECT TaxRate FROM Payments
GO
UPDATE Payments
SET Payments.TaxRate = (Payments.TaxRate * 0.97)
GO
SELECT TaxRate FROM Payments