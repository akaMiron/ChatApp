﻿CREATE TABLE [dbo].[User]
(
	[UserId] INT NOT NULL IDENTITY (1, 1),
	[Name] NVARCHAR (50) NULL,
	[Password] NVARCHAR(50) NULL,
	PRIMARY KEY CLUSTERED ([UserId] ASC)
)
