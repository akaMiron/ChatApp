CREATE TABLE [dbo].[UserInRole]
(
	[UserId] INT NOT NULL, 
	[RoleId] INT NOT NULL,
	PRIMARY KEY([UserId], [RoleId]),
	CONSTRAINT [FK_dbo.UserInRole_dbo.User_UserId] FOREIGN KEY ([UserId]) 
		REFERENCES [dbo].[User] ([UserId]),
	CONSTRAINT [FK_dbo.UserInRole_dbo.Role_RoleId] FOREIGN KEY ([RoleId]) 
		REFERENCES [dbo].[Role] ([RoleId])
);

