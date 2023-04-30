USE [PROG455SP23]
GO

/****** Object:  StoredProcedure [dbo].[DeleteRecordById]    Script Date: 4/30/2023 4:24:07 PM ******/
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

