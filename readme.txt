//ASP.NET Core Module/Hosting Bundle
https://learn.microsoft.com/en-us/aspnet/core/host-and-deploy/iis/?view=aspnetcore-7.0

INSERT [gold].[User] ([Id], [Name], [DOB], [Gender], [Address], [City], [Pincode], [Mobile1], [Mobile2], [Email], [Password], [Role], [IsActive], [CreatedOn], [CreatedBy], [UpdatedOn], [UpdatedBy]) VALUES (N'df330f7a-3f73-4b37-b0c9-04c6d507e332', N'Admin', CAST(N'2023-09-05T17:01:16.6566667' AS DateTime2), N'M         ', NULL, NULL, NULL, NULL, NULL, N'admin@gmail.com', N'jZ6aN+Ia5Aeyf6sHiI3L3g==', N'MasterAdmin', 1, CAST(N'2023-09-05T17:01:16.6566667' AS DateTime2), NULL, NULL, NULL)
=================================================================

USE [master]
GO
CREATE LOGIN [GoldUser] WITH PASSWORD=N'123', 
                 DEFAULT_DATABASE=[GoldDb], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
GO
USE [GoldDb]
GO
CREATE USER [GoldUser] FOR LOGIN [GoldUser] WITH DEFAULT_SCHEMA=[gold]
GO

SELECT SERVERPROPERTY('IsIntegratedSecurityOnly')

EXEC xp_instance_regwrite N'HKEY_LOCAL_MACHINE', N'Software\Microsoft\MSSQLServer\MSSQLServer', N'LoginMode', REG_DWORD, 2

GRANT EXEC TO PUBLIC

========================================================

Host with domain
C:\Windows\System32\drivers\etc
127.0.0.1 www.mygoldgym.com