
IF(OBJECT_ID('dbo.UI_Todo') IS NOT NULL)
	BEGIN
		DROP PROCEDURE dbo.UI_Todo
	END
GO

CREATE PROCEDURE dbo.UI_Todo

(
	@UserID INT,
	@TodoTypeID INT,
	@DueDate DATETIME,
	@Comment VARCHAR(250)
)

AS

SET NOCOUNT ON

INSERT Todo
(
	UserID,
	TodoTypeID,
	DueDate,
	Comment
)
VALUES
(
	@UserID,
	@TodoTypeID,
	@DueDate,
	ISNULL(@Comment,'')
)

RETURN @@IDENTITY

SET NOCOUNT OFF
GO