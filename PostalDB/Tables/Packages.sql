CREATE TABLE [dbo].[Packages]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [UserId] INT NOT NULL,
    [Weight] INT NOT NULL, 
    [DateOfDeparture] DATETIME NOT NULL, 
    [Sender] NVARCHAR(150) NOT NULL, 
    [CityOfDeparture] NVARCHAR(150) NOT NULL, 
    [IsReceived] BIT NOT NULL, 
    CONSTRAINT [FK_Packages_ToUsers] FOREIGN KEY ([UserId]) REFERENCES [Users]([Id])
)
