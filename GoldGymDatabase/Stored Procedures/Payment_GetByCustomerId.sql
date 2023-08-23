CREATE PROCEDURE [gold].[Payment_GetByCustomerId]
(
	@CustomerId UNIQUEIDENTIFIER
)
AS BEGIN
	SELECT 
		[Id],
        [CustomerId],
        [PaymentDate],
        [FromDate],
        [ToDate],
        [Amount],
        [CreatedBy],
        [CreatedOn],
        [UpdatedBy],
        [UpdatedOn]
	FROM 
        [gold].[Payment]
    WHERE
        [CustomerId] = @CustomerId
    ORDER BY [PaymentDate] DESC
END
