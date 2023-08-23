CREATE PROCEDURE [gold].[Payment_Update]
(
	@Id UNIQUEIDENTIFIER,
	@CustomerId UNIQUEIDENTIFIER,
	@PaymentDate DATETIME2,
	@FromDate DATETIME2,
	@ToDate DATETIME2,
	@Amount DECIMAL,
	@UpdatedBy UNIQUEIDENTIFIER
)
AS BEGIN
--SET NOCOUNT ON
	UPDATE [gold].[Payment]
	SET
        [CustomerId] = @CustomerId,
		[PaymentDate] = @PaymentDate,
        [FromDate] = @FromDate,
        [ToDate] = @ToDate,
        [Amount] = @Amount,
        [UpdatedBy] = @UpdatedBy,
        [UpdatedOn] = GETDATE()
	WHERE
		[Id] = @Id
END
