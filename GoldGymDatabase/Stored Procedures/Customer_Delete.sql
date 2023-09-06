﻿CREATE PROCEDURE [gold].[Customer_Delete]
(
    @Id UNIQUEIDENTIFIER,
	@UpdatedBy UNIQUEIDENTIFIER
)
AS BEGIN
--SET NOCOUNT ON
	UPDATE 
		[gold].[Customer]
	SET
		[IsActive] = 0,
		[UpdatedBy] = @UpdatedBy,
        [UpdatedOn] = GETDATE()
	WHERE Id = @Id	
END
