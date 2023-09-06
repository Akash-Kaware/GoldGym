CREATE PROCEDURE [gold].[User_Update]
(
    @Id UNIQUEIDENTIFIER, 
    @Name VARCHAR(MAX) NULL, 
    @DOB DATETIME2 NULL, 
    @Gender VARCHAR(10) NULL, 
    @Address VARCHAR(MAX) NULL, 
    @City VARCHAR(MAX) NULL, 
    @Pincode VARCHAR(6) NULL, 
    @Mobile1 VARCHAR(10) NULL, 
    @Mobile2 VARCHAR(10) NULL, 
    @Email VARCHAR(MAX) NULL,
    @Role VARCHAR(20) NULL,
    @UpdatedBy UNIQUEIDENTIFIER
)
AS BEGIN
	--SET NOCOUNT ON
	UPDATE [gold].[User]
    SET		
        [Name] = @Name,
        [DOB] = @DOB,
        [Gender] = @Gender,
        [Address] = @Address,
        [City] = @City,
        [Pincode] = @Pincode,
        [Mobile1] = @Mobile1,
        [Mobile2] = @Mobile2,
        [Email] = @Email,
        [Role] = @Role,
        [UpdatedBy] = @UpdatedBy,
        [UpdatedOn] = GETDATE()
	WHERE 
        [IsActive] = 1 AND [Id] = @Id
END
