CREATE TABLE [dbo].[Contact]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ContactId] INT NOT NULL, 
    [FirstName] NCHAR(50) NOT NULL, 
    [LastName] NCHAR(50) NOT NULL, 
    [DateMet] DATETIME NOT NULL, 
    [PersonId] INT NOT NULL, 
    [Mobile] NCHAR(20) NOT NULL, 
    [Email] NCHAR(60) NULL, 
    [DistanceKept] INT NULL, 
    [TimeSpent] INT NULL 
)
