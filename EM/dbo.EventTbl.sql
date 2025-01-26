CREATE TABLE [dbo].[EventTbl] (
    [EvId]       INT          IDENTITY (1, 1) NOT NULL,
    [EvName]     VARCHAR (50) NOT NULL,
    [EvDate]     DATE         NOT NULL,
    [VenueId]    INT          NOT NULL,
    [EvVenue]    VARCHAR (50) NOT NULL,
    [EvDuration] VARCHAR(50)          NOT NULL,
    [EvCusId]    INT NOT NULL,
    [EvCusName]  VARCHAR (50) NOT NULL,
    [EvStatus]   VARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([EvId] ASC), 
    CONSTRAINT [FK2] FOREIGN KEY ([EvCusId]) REFERENCES [CustomerTbl]([CusId]), 
    CONSTRAINT [FK3] FOREIGN KEY ([VenueId]) REFERENCES [VenueTbl]([VId])
);

