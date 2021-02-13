CREATE FUNCTION udf_AllUserCommits(@username VARCHAR(MAX))
RETURNS INT
BEGIN
 RETURN (SELECT COUNT(*)
		 FROM Users AS u
		 JOIN Commits AS c ON c.ContributorId = u.Id
		 WHERE u.Username LIKE @username)
END

GO
SELECT dbo.udf_AllUserCommits('UnderSinduxrein')