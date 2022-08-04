
IF(OBJECT_ID('dbo.US_TodoByID') IS NOT NULL)
	BEGIN
		DROP PROCEDURE dbo.US_TodoByID
	END
GO

CREATE PROCEDURE dbo.US_TodoByID 

(
    @TodoID INT
)

AS
 
SET NOCOUNT ON

SELECT
	TodoID,
	UserID,
	TodoTypeID,
	DueDate,
	Comment,
	DateFlag,
	IsActive
FROM Todo
WHERE TodoID = @TodoID

SET NOCOUNT OFF
GO