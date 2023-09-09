﻿CREATE PROCEDURE [gold].[Customer_Create]
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
    @Photo VARCHAR(MAX) NULL,
    @IsActive BIT NULL,
    @CreatedBy UNIQUEIDENTIFIER
)
AS BEGIN
--SET NOCOUNT ON
	INSERT INTO [gold].[Customer]
	(
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
        [CreatedOn]
	)
	VALUES
	(
       @Id,
       @Name,
       @DOB,
       @Gender,
       @Address,
       @City,
       @Pincode,
       @Mobile1,
       @Mobile2,
       @Email,
       @Photo,
       @IsActive,
       @CreatedBy,
       GETDATE()
    )
END
