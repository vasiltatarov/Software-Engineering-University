CREATE FUNCTION ufn_CalculateFutureValue(@sum DECIMAL(18, 4), @yearlyInterestRate FLOAT, @years INT)
RETURNS DECIMAL(18, 4)
BEGIN
	DECLARE @futureValue DECIMAL(18, 4)
	SET @futureValue = @sum * (POWER(1 + @yearlyInterestRate, @years))

	RETURN @futureValue
END

GO

SELECT dbo.ufn_CalculateFutureValue(1000, 0.1, 5)