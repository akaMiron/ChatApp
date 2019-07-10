CREATE TABLE [dbo].[Message]
(
	[MessageId] INT NOT NULL IDENTITY (1, 1),
	[Message] NVARCHAR (500) NULL,
	[UserId] INT NOT NULL,
	PRIMARY KEY CLUSTERED ([MessageId] ASC),
	CONSTRAINT [FK_dbo.Message_dbo.User_UserId] FOREIGN KEY ([UserId]) 
		REFERENCES [dbo].[User] ([UserID]) ON DELETE CASCADE
)
