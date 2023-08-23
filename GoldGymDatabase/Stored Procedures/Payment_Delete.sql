CREATE PROCEDURE [gold].[Payment_Delete]
(
	@Id UNIQUEIDENTIFIER
)
AS BEGIN
	DELETE FROM
		[gold].[Payment]
	WHERE
        [Id] = @Id		
END
