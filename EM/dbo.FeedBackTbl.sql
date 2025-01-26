CREATE TABLE [dbo].[FeedBackTbl] (
    [FbNum]       INT          IDENTITY (1, 1) NOT NULL,
    [EvId]        VARCHAR (50) NOT NULL,
    [EvName]      VARCHAR (50) NOT NULL,
    [Venue]       INT          NOT NULL,
    [Punctuality] INT          NOT NULL,
    [Hospitality] INT          NOT NULL,
    [OverAll]     INT          NOT NULL,
    PRIMARY KEY CLUSTERED ([FbNum] ASC), 
    CONSTRAINT [FK1] FOREIGN KEY ([EvId]) REFERENCES [EventTbl]([EvId])
);

