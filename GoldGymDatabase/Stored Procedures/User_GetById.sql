CREATE PROCEDURE [gold].[User_GetById]
(
	@Id UNIQUEIDENTIFIER
)
AS BEGIN
	SELECT 
	    [Id],
        [Name],
	    [DOB],
        [Gender],
        [Address],
        [City],
        [Pincode],
        [Mobile1],
        [Mobile2],
        [Email],
        [Password],
        [Role],
        [IsActive],
        [CreatedOn],
        [CreatedBy],
        [UpdatedOn],
        [UpdatedBy]
    FROM [gold].[User]
    WHERE [IsActive] = 1
    AND [Id] = @Id
END
