CREATE PROCEDURE [gold].[Payment_Create]
(
	@Id UNIQUEIDENTIFIER,
	@CustomerId UNIQUEIDENTIFIER,
	@PaymentDate DATETIME2,
	@FromDate DATETIME2,
	@ToDate DATETIME2,
	@Amount DECIMAL,
	@CreatedBy UNIQUEIDENTIFIER
)
AS BEGIN
--SET NOCOUNT ON
	INSERT INTO [gold].[Payment]
	(
		[Id],
        [CustomerId],
        [PaymentDate],
        [FromDate],
        [ToDate],
        [Amount],
        [CreatedBy],
        [CreatedOn]
	)
	VALUES
	(
       @Id,
       @CustomerId,
       @PaymentDate,
       @FromDate,
       @ToDate,
       @Amount,
       @CreatedBy,
       GETDATE()
    )
END
