CREATE PROCEDURE [gold].[Customer_Delete]
(
    @Id UNIQUEIDENTIFIER
)
AS BEGIN
--SET NOCOUNT ON
	DELETE FROM 
		[gold].[Customer]
	WHERE 
		[Id] = @Id
END
