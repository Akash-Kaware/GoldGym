CREATE PROCEDURE [gold].[Customer_GetById]
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
        [Photo],
        [IsActive],
        [CreatedBy],
        [CreatedOn],
        [UpdatedBy],
        [UpdatedOn]
    FROM 
        [gold].[Customer]
    WHERE
        [Id] = @Id
END
