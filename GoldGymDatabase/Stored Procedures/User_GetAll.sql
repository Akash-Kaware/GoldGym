CREATE PROCEDURE [gold].[User_GetAll]
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
    AND [Role] != 'MasterAdmin'
END
