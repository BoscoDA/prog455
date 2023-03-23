USE [PROG455FA23]
GO
/****** Object:  Table [dbo].[Character]    Script Date: 3/23/2023 4:43:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Character](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nchar](100) NOT NULL,
	[Element_Type] [nchar](50) NOT NULL,
	[Job_Class] [nchar](100) NOT NULL,
	[ATK] [int] NOT NULL,
	[DEF] [int] NOT NULL,
	[Mana] [int] NOT NULL,
	[HP_Initial] [int] NOT NULL,
	[HP_Max] [int] NOT NULL,
	[NPC] [bit] NOT NULL,
 CONSTRAINT [PK_Character] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Character] ON 

INSERT [dbo].[Character] ([ID], [Name], [Element_Type], [Job_Class], [ATK], [DEF], [Mana], [HP_Initial], [HP_Max], [NPC]) VALUES (1003, N'John Doe                                                                                            ', N'Fire                                              ', N'Blacksmith                                                                                          ', 555, 555, 555, 555, 555, 1)
INSERT [dbo].[Character] ([ID], [Name], [Element_Type], [Job_Class], [ATK], [DEF], [Mana], [HP_Initial], [HP_Max], [NPC]) VALUES (1004, N'Jane Doe                                                                                            ', N'asdf                                              ', N'asdfasdf                                                                                            ', 1234, 1234, 1234, 1234, 1234, 0)
SET IDENTITY_INSERT [dbo].[Character] OFF
GO
