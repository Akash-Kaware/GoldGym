CREATE PROCEDURE [gold].[Payment_GetAll]
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
END
