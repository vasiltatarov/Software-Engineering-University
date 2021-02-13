DELETE FROM Files
WHERE CommitId = (SELECT Id FROM Commits WHERE RepositoryId = (SELECT Id FROM Repositories WHERE Name LIKE 'Softuni-Teamwork'))

DELETE FROM Commits
WHERE RepositoryId = (SELECT Id FROM Repositories WHERE Name LIKE 'Softuni-Teamwork')

DELETE FROM Issues
WHERE RepositoryId = (SELECT Id FROM Repositories WHERE Name LIKE 'Softuni-Teamwork')

DELETE FROM RepositoriesContributors
WHERE RepositoryId = (SELECT Id FROM Repositories WHERE Name LIKE 'Softuni-Teamwork')

DELETE FROM Repositories
WHERE Name LIKE 'Softuni-Teamwork'