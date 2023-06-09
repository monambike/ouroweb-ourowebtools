CREATE TABLE [dbo].[Room]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Group] NCHAR(10) NULL
    --[GroupId] INT CONSTRAINT [FK_History_Group] FOREIGN KEY REFERENCES [Group]([Id]) NOT NULL 
)
