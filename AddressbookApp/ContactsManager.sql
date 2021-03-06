CREATE TABLE [dbo].[Addressbook](
	[PKAddressId] [int] IDENTITY(1,1) NOT NULL,
	[FKStateId] [int] NOT NULL,
	[FKUserId] [int] NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NULL,
	[EmailId] [varchar](50) NOT NULL,
	[PhoneNo] [varchar](50) NOT NULL,
	[Address1] [varchar](50) NOT NULL,
	[Address2] [varchar](50) NULL,
	[Street] [varchar](50) NOT NULL,
	[City] [varchar](50) NOT NULL,
	[ZipCode] [bigint] NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Addressbook] PRIMARY KEY CLUSTERED 
(
	[PKAddressId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Country]    Script Date: 6/11/2018 6:53:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Country](
	[PKCountryId] [int] IDENTITY(1,1) NOT NULL,
	[CountryName] [varchar](50) NOT NULL,
	[ZipCodeStart] [bigint] NULL,
	[ZipCodeEnd] [bigint] NOT NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_Country] PRIMARY KEY CLUSTERED 
(
	[PKCountryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[State]    Script Date: 6/11/2018 6:53:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[State](
	[PKStateId] [int] IDENTITY(1,1) NOT NULL,
	[FKCountryId] [int] NOT NULL,
	[StateName] [varchar](50) NOT NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_State] PRIMARY KEY CLUSTERED 
(
	[PKStateId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Userdetails]    Script Date: 6/11/2018 6:53:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Userdetails](
	[PKUserId] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](50) NOT NULL,
	[Password] [varchar](50) NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NULL,
	[EmailId] [varchar](50) NOT NULL,
	[PhoneNo] [varchar](50) NOT NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_Userdetails] PRIMARY KEY CLUSTERED 
(
	[PKUserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Addressbook] ON 
GO
INSERT [dbo].[Addressbook] ([PKAddressId], [FKStateId], [FKUserId], [FirstName], [LastName], [EmailId], [PhoneNo], [Address1], [Address2], [Street], [City], [ZipCode], [IsActive]) VALUES (4, 10, 2, N'amaresh1', N'reddy', N'amaresh@gmail.com', N'1234567890', N'Hyderabad', N'Hydearbad', N'SR nagar', N'Forest', 123456, 1)
GO
INSERT [dbo].[Addressbook] ([PKAddressId], [FKStateId], [FKUserId], [FirstName], [LastName], [EmailId], [PhoneNo], [Address1], [Address2], [Street], [City], [ZipCode], [IsActive]) VALUES (5, 10, 3, N'krishna', N'reddy', N'krishna@gmail.com', N'7704567822', N'nandyala', N'werty', N'fertt', N'ertyu', 123456, 1)
GO
INSERT [dbo].[Addressbook] ([PKAddressId], [FKStateId], [FKUserId], [FirstName], [LastName], [EmailId], [PhoneNo], [Address1], [Address2], [Street], [City], [ZipCode], [IsActive]) VALUES (7, 1, 3, N'rajesh', N'kumar', N'rajesh@gmail.com', N'1234567890', N'qwerty', N'sdsfghjk', N'qwerty', N'sdfghjko', 12345, 1)
GO
INSERT [dbo].[Addressbook] ([PKAddressId], [FKStateId], [FKUserId], [FirstName], [LastName], [EmailId], [PhoneNo], [Address1], [Address2], [Street], [City], [ZipCode], [IsActive]) VALUES (8, 1, 2, N'test', N'test', N'test@test.com', N'784654564', N'hyd', N'hyd', N'hdy', N'hyd', 787985, 1)
GO
INSERT [dbo].[Addressbook] ([PKAddressId], [FKStateId], [FKUserId], [FirstName], [LastName], [EmailId], [PhoneNo], [Address1], [Address2], [Street], [City], [ZipCode], [IsActive]) VALUES (9, 1, 2, N'test2', N'test1', N'test@test.com', N'789855656', N'hdy', N'hyd', N'hyd', N'hyd', 784565, 1)
GO
INSERT [dbo].[Addressbook] ([PKAddressId], [FKStateId], [FKUserId], [FirstName], [LastName], [EmailId], [PhoneNo], [Address1], [Address2], [Street], [City], [ZipCode], [IsActive]) VALUES (11, 10, 3, N'Phani', N'Tekkem', N'phani@gmail.com', N'7878998987', N'Hyd', N'Hyd', N'Hyd', N'hyd', 787798, 1)
GO
SET IDENTITY_INSERT [dbo].[Addressbook] OFF
GO
SET IDENTITY_INSERT [dbo].[Country] ON 
GO
INSERT [dbo].[Country] ([PKCountryId], [CountryName], [ZipCodeStart], [ZipCodeEnd], [IsActive]) VALUES (1, N'India', 911, 451, 1)
GO
INSERT [dbo].[Country] ([PKCountryId], [CountryName], [ZipCodeStart], [ZipCodeEnd], [IsActive]) VALUES (2, N'China', 342, 671, 1)
GO
INSERT [dbo].[Country] ([PKCountryId], [CountryName], [ZipCodeStart], [ZipCodeEnd], [IsActive]) VALUES (3, N'Austrila', 233, 782, 1)
GO
INSERT [dbo].[Country] ([PKCountryId], [CountryName], [ZipCodeStart], [ZipCodeEnd], [IsActive]) VALUES (14, N'Iran', 121, 671, 1)
GO
INSERT [dbo].[Country] ([PKCountryId], [CountryName], [ZipCodeStart], [ZipCodeEnd], [IsActive]) VALUES (17, N'Bhutan', 522, 211, 1)
GO
INSERT [dbo].[Country] ([PKCountryId], [CountryName], [ZipCodeStart], [ZipCodeEnd], [IsActive]) VALUES (18, N'Pakistan', 455, 788, 1)
GO
SET IDENTITY_INSERT [dbo].[Country] OFF
GO
SET IDENTITY_INSERT [dbo].[State] ON 
GO
INSERT [dbo].[State] ([PKStateId], [FKCountryId], [StateName], [IsActive]) VALUES (1, 1, N'Telangana', 1)
GO
INSERT [dbo].[State] ([PKStateId], [FKCountryId], [StateName], [IsActive]) VALUES (8, 1, N'Gujarat', 1)
GO
INSERT [dbo].[State] ([PKStateId], [FKCountryId], [StateName], [IsActive]) VALUES (10, 1, N'AndhraPradesh', 1)
GO
INSERT [dbo].[State] ([PKStateId], [FKCountryId], [StateName], [IsActive]) VALUES (14, 3, N'Melbourne', 1)
GO
INSERT [dbo].[State] ([PKStateId], [FKCountryId], [StateName], [IsActive]) VALUES (15, 1, N'Rajasthan', 1)
GO
INSERT [dbo].[State] ([PKStateId], [FKCountryId], [StateName], [IsActive]) VALUES (20, 1, N'MP', 1)
GO
INSERT [dbo].[State] ([PKStateId], [FKCountryId], [StateName], [IsActive]) VALUES (21, 1, N'Madyapradesh', 1)
GO
SET IDENTITY_INSERT [dbo].[State] OFF
GO
SET IDENTITY_INSERT [dbo].[Userdetails] ON 
GO
INSERT [dbo].[Userdetails] ([PKUserId], [UserName], [Password], [FirstName], [LastName], [EmailId], [PhoneNo], [IsActive]) VALUES (2, N'naveen', N'naveen', N'naveen', N'kumar', N'naveen@gmail.com', N'12345678', 1)
GO
INSERT [dbo].[Userdetails] ([PKUserId], [UserName], [Password], [FirstName], [LastName], [EmailId], [PhoneNo], [IsActive]) VALUES (3, N'Rakesh', N'rakesh', N'Rakesh', N'Vemula', N'rakesh@gmail.com', N'9876543210', 1)
GO
INSERT [dbo].[Userdetails] ([PKUserId], [UserName], [Password], [FirstName], [LastName], [EmailId], [PhoneNo], [IsActive]) VALUES (4, N'Viswa', N'123456', N'Visw', N'Raj', N'viswaraj@gmai.com', N'4778556699', 1)
GO
SET IDENTITY_INSERT [dbo].[Userdetails] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Country]    Script Date: 6/11/2018 6:53:41 PM ******/
ALTER TABLE [dbo].[Country] ADD  CONSTRAINT [IX_Country] UNIQUE NONCLUSTERED 
(
	[CountryName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Userdetails]    Script Date: 6/11/2018 6:53:41 PM ******/
ALTER TABLE [dbo].[Userdetails] ADD  CONSTRAINT [IX_Userdetails] UNIQUE NONCLUSTERED 
(
	[PKUserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Addressbook]  WITH CHECK ADD  CONSTRAINT [FK_Addressbook_State] FOREIGN KEY([FKStateId])
REFERENCES [dbo].[State] ([PKStateId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Addressbook] CHECK CONSTRAINT [FK_Addressbook_State]
GO
ALTER TABLE [dbo].[Addressbook]  WITH CHECK ADD  CONSTRAINT [FK_Addressbook_Userdetails] FOREIGN KEY([FKUserId])
REFERENCES [dbo].[Userdetails] ([PKUserId])
GO
ALTER TABLE [dbo].[Addressbook] CHECK CONSTRAINT [FK_Addressbook_Userdetails]
GO
ALTER TABLE [dbo].[State]  WITH CHECK ADD  CONSTRAINT [FK_State_Country1] FOREIGN KEY([FKCountryId])
REFERENCES [dbo].[Country] ([PKCountryId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[State] CHECK CONSTRAINT [FK_State_Country1]
GO
