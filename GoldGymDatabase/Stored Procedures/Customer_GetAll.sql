CREATE PROCEDURE [gold].[Customer_GetAll]
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
        [IsActive],
        [CreatedBy],
        [CreatedOn],
        [UpdatedBy],
        [UpdatedOn]
    FROM 
        [gold].[Customer]
END
