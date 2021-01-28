USE SoftUni
GO

CREATE FUNCTION ufn_IsWordComprised(@setOfLetters VARCHAR(MAX), @word VARCHAR(MAX))
RETURNS BIT
AS
BEGIN
	DECLARE @i INT = 1

	WHILE (@i <= LEN(@word))
	BEGIN
		DECLARE @currChar CHAR = SUBSTRING(@word, @i, 1)
		DECLARE @charIndex INT = CHARINDEX(@currChar, @setOfLetters)

		IF (@charIndex = 0)
			RETURN 0

		SET @i += 1
	END
	
	RETURN 1
END
GO
SELECT dbo.ufn_IsWordComprised('pppp', 'Guy')