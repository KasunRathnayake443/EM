CREATE TABLE [dbo].[FeedBackTbl]
(
	[FbNum] INT NOT NULL PRIMARY KEY IDENTITY, 
    [EvId] VARCHAR(50) NOT NULL, 
    [EvName] VARCHAR(50) NOT NULL, 
    [Venue] INT NOT NULL, 
    [Punctuality] INT NOT NULL, 
    [Hospitality] INT NOT NULL, 
    [OverAll] INT NOT NULL, 
    CONSTRAINT [FK1] FOREIGN KEY ([EvId]) REFERENCES [EventTbl]([EvId])
)
