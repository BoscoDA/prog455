USE [PROG455SP23]
GO
/****** Object:  Table [dbo].[User]    Script Date: 2/25/2023 12:41:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](100) NOT NULL,
	[Password] [nvarchar](100) NOT NULL,
	[First_Name] [nvarchar](100) NOT NULL,
	[Last_Name] [nvarchar](100) NOT NULL,
	[Role] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[User] ON 
GO
INSERT [dbo].[User] ([Id], [Username], [Password], [First_Name], [Last_Name], [Role]) VALUES (5, N'NEisner', N'184725ae2b91399e2a259f05eec0643fb6a8ff4d8e0d1a0750da3cd02aa1fe5e', N'Nick', N'Eisner', N'Super Admin')
GO
INSERT [dbo].[User] ([Id], [Username], [Password], [First_Name], [Last_Name], [Role]) VALUES (6, N'JDoe', N'5e884898da28047151d0e56f8dc6292773603d0d6aabbdd62a11ef721d1542d8', N'John', N'Doe', N'User')
GO
INSERT [dbo].[User] ([Id], [Username], [Password], [First_Name], [Last_Name], [Role]) VALUES (7, N'Jane1', N'53d0ed1183fd82671a41d2f6002919144ed2cc52d064bad3939e44568765131f', N'Jane', N'Doe', N'Admin')
GO
SET IDENTITY_INSERT [dbo].[User] OFF
GO
