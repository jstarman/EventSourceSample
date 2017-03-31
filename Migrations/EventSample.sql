IF OBJECT_ID('[dbo].[EventSample]', 'U') IS NULL
BEGIN
CREATE TABLE EventSample(
  Id uniqueidentifier not null,
  EventType nvarchar(200) not null,
  EventId int not null,
  EventData nvarchar(MAX) not null,
  MetaData nvarchar(MAX) null,
  [CreatedOn] [datetime2](7) NOT NULL DEFAULT GETUTCDATE(),
  Constraint PKEvents PRIMARY KEY(ID)
)
END
GO