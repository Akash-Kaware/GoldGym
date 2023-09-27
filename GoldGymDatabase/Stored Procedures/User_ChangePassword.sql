CREATE PROCEDURE [gold].[User_ChangePassword]
(
	@Id UNIQUEIDENTIFIER,
    @Password VARCHAR(MAX) NULL,	
    @UpdatedBy UNIQUEIDENTIFIER
)
AS BEGIN
--SET NOCOUNT ON
	UPDATE [gold].[User]
    SET 
        [Password] = @Password,
        [UpdatedBy] = @UpdatedBy,
        [UpdatedOn] = GETDATE()
	WHERE 
        [IsActive] = 1 AND [Id] = @Id
END
