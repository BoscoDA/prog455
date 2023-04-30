USE [PROG455SP23]
GO

/****** Object:  StoredProcedure [dbo].[UpdateRecordByID]    Script Date: 4/30/2023 4:25:37 PM ******/
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

