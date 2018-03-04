CREATE TABLE [dbo].[User]
(
	[userId] NCHAR(10) NOT NULL PRIMARY KEY    , 
    [name] NCHAR(10) NOT NULL, 
    [lastName1] NCHAR(10) NOT NULL, 
    [lastName2] NCHAR(10) NOT NULL, 
    [password] NCHAR(10) NOT NULL 
)
