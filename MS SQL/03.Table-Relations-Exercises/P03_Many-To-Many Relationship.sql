CREATE TABLE Students(
	StudentID INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50) NOT NULL
)
GO
CREATE TABLE Exams(
	ExamID INT PRIMARY KEY IDENTITY(101, 1),
	[Name] NVARCHAR(50) NOT NULL
)
GO
CREATE TABLE StudentsExams(
	StudentID INT NOT NULL FOREIGN KEY REFERENCES Students(StudentID),
	ExamID INT NOT NULL FOREIGN KEY REFERENCES Exams(ExamID),
	PRIMARY KEY (StudentID, ExamID)
)
GO
INSERT INTO Students([Name])
	VALUES
		('Mila'),
		('Toni'),
		('Ron');

INSERT INTO Exams([Name])
	VALUES
		('SpringMVC'),
		('Neo4j'),
		('Oracle 11g');

INSERT INTO StudentsExams(StudentID, ExamID)
	VALUES 
		(1, 101),
		(1, 102),
		(2, 101),
		(3, 103),
		(2, 102),
		(2, 103);
GO
SELECT st.[Name], ex.[Name] FROM Students AS st
JOIN StudentsExams AS stEx ON stEx.StudentID = st.StudentID
JOIN Exams AS ex ON ex.ExamID = stEx.ExamID