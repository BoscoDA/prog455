USE [PROG455SP23]
GO
/****** Object:  Table [dbo].[Week13]    Script Date: 4/30/2023 4:21:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Week13](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[player_id] [nvarchar](32) NOT NULL,
	[name] [char](10) NOT NULL,
	[uniform_color] [int] NOT NULL,
	[gem_stone] [nchar](10) NULL,
	[hp] [int] NOT NULL,
	[weight] [int] NOT NULL,
	[depth_dived] [int] NOT NULL,
 CONSTRAINT [PK_Week13] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[DeleteRecordById]    Script Date: 4/30/2023 4:21:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DeleteRecordById]
	-- Add the parameters for the stored procedure here
	@Id nvarchar(32),
	@ReturnValue int OUTPUT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	IF EXISTS(SELECT * FROM [dbo].[Week13] WHERE [player_id] = @Id)
	BEGIN
	DELETE FROM dbo.Week13 WHERE [player_id] = @Id;
	Set @ReturnValue = 1
	END
	ELSE
	BEGIN
	Set @ReturnValue = 0
	End
		
END
GO
/****** Object:  StoredProcedure [dbo].[GetAllRecords]    Script Date: 4/30/2023 4:21:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetAllRecords]
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM Week13;
END
GO
/****** Object:  StoredProcedure [dbo].[GetRecordByName]    Script Date: 4/30/2023 4:21:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetRecordByName]
	-- Add the parameters for the stored procedure here
	@Name nvarchar(10)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM dbo.Week13 WHERE name = @Name;
END
GO
/****** Object:  StoredProcedure [dbo].[InsertRecord]    Script Date: 4/30/2023 4:21:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[InsertRecord]
	-- Add the parameters for the stored procedure here
	@Id nvarchar(32),
	@Name char(10),
	@UniformColor int,
	@GemStone nchar(10),
	@HP int,
	@Weight int,
	@DepthDived int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	
	INSERT INTO dbo.Week13 ([player_id],[name],[uniform_color],[gem_stone],[hp],[weight],[depth_dived])
	Values(@Id, @Name,@UniformColor,@GemStone,@HP,@Weight,@DepthDived);
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateRecordByID]    Script Date: 4/30/2023 4:21:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Nick Eisner
-- Create date: 4/30/23
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[UpdateRecordByID]
	-- Add the parameters for the stored procedure here
	@Id nvarchar(32),
	@Name char(10),
	@UniformColor int,
	@GemStone nchar(10),
	@HP int,
	@Weight int,
	@DepthDived int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE [PROG455SP23].[dbo].[Week13]
	SET [name] = @Name, [uniform_color] = @UniformColor, [gem_stone] = @GemStone, [hp] = @HP, [weight] = @Weight, [depth_dived] = @DepthDived
	WHERE [player_id] = @Id
END
GO
