
IF(OBJECT_ID('dbo.US_TodoAll') IS NOT NULL)
	BEGIN
		DROP PROCEDURE dbo.US_TodoAll
	END
GO

CREATE PROCEDURE dbo.US_TodoAll 

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
WHERE IsActive = 1

SET NOCOUNT OFF
GO