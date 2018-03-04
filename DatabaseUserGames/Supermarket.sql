CREATE TABLE [dbo].[Supermarket]
(
	[PuzzleName] NCHAR(10) NOT NULL , 
    [Date] DATETIME NOT NULL, 
    [time] NCHAR(10) NOT NULL, 
    [userPuzz] NCHAR(10) NOT NULL, 
    PRIMARY KEY ([userPuzz], [Date], [PuzzleName]), 
    --CONSTRAINT [userPuzz] FOREIGN KEY ([userPuzz]) REFERENCES [User]([UserId])
)
