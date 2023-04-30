USE [PROG455SP23]
GO

/****** Object:  StoredProcedure [dbo].[InsertRecord]    Script Date: 4/30/2023 4:25:25 PM ******/
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

