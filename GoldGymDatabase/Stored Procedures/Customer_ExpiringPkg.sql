CREATE PROCEDURE [gold].[Customer_ExpiringPkg]
(
	@PaymentReminderDays int
)
AS BEGIN
	SELECT [Id],
        [Name],
        [DOB],
        [Gender],
        [Address],
        [City],
        [Pincode],
        [Mobile1],
        [Mobile2],
        [Email],
        [IsActive]
    FROM [gold].[Customer] 
    WHERE [Id] NOT IN (
        SELECT DISTINCT CustomerId 
        FROM [gold].[Payment] 
        WHERE ToDate > DATEADD(DD, @PaymentReminderDays, GETDATE())
        )

    SELECT DISTINCT [Id],
        [CustomerId],
        [PaymentDate],
        [FromDate],
        [ToDate],
        [Amount]
        FROM [gold].[Payment] 
        WHERE ToDate < DATEADD(DD, @PaymentReminderDays, GETDATE()) 
        ORDER BY [ToDate] DESC
END
