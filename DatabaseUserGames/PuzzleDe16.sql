CREATE TABLE [dbo].[PuzzleDe16]
(
    [date] DATETIME NOT NULL, 
    [userPuz] NCHAR(10) NOT NULL, 
    [time] NCHAR(8) NOT NULL, 
    PRIMARY KEY ([userPuz], [date]), 
    CONSTRAINT [User16] FOREIGN KEY (userPuz) REFERENCES [User]([userId]) 
)
