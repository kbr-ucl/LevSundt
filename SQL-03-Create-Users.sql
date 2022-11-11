/****** Object:  User [test]    Script Date: 07-11-2022 14:19:24 ******/
USE [LevSundtUsers]
GO
CREATE USER [web] FOR LOGIN [web] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [web]
GO

USE [LevSundtDomain]
GO
CREATE USER [api] FOR LOGIN [api] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [api]
GO

