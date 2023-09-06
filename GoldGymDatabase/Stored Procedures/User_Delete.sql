CREATE PROCEDURE [gold].[User_Delete]
(
    @Id UNIQUEIDENTIFIER,
	@UpdatedBy UNIQUEIDENTIFIER
)
AS BEGIN
	UPDATE 
		[gold].[User]
	SET
		[IsActive] = 0,
		[UpdatedBy] = @UpdatedBy,
        [UpdatedOn] = GETDATE()
	WHERE Id = @Id	
END
