USE [OfaSchlupfer]
GO
DROP PROCEDURE [dbo].[proca]
GO
DROP PROCEDURE [dbo].[p]
GO
DROP TABLE [dbo].[NameValue]
GO
DROP FUNCTION [dbo].[inlineFuncA]
GO
DROP VIEW [dbo].[NameA]
GO
DROP TABLE [dbo].[Name]
GO
DROP FUNCTION [dbo].[TableFunctionNameA]
GO
DROP FUNCTION [dbo].[ScalarFunctionNameA]
GO
DROP SYNONYM [dbo].[synonyma]
GO
DROP TYPE [dbo].[TVP_Name]
GO
DROP TYPE [dbo].[UserDefinedDataTypeName]
GO
DROP SCHEMA [namea]
GO
DECLARE @RoleName sysname
set @RoleName = N'namea'
IF @RoleName <> N'public' and (select is_fixed_role from sys.database_principals where name = @RoleName) = 0
BEGIN
    DECLARE @RoleMemberName sysname
    DECLARE Member_Cursor CURSOR FOR
    select [name]
    from sys.database_principals
    where principal_id in (
        select member_principal_id
        from sys.database_role_members
        where role_principal_id in (
            select principal_id
            FROM sys.database_principals where [name] = @RoleName AND type = 'R'))
    OPEN Member_Cursor;
    FETCH NEXT FROM Member_Cursor
    into @RoleMemberName

    DECLARE @SQL NVARCHAR(4000)
    WHILE @@FETCH_STATUS = 0
    BEGIN

        SET @SQL = 'ALTER ROLE '+ QUOTENAME(@RoleName,'[') +' DROP MEMBER '+ QUOTENAME(@RoleMemberName,'[')
        EXEC(@SQL)

        FETCH NEXT FROM Member_Cursor
        into @RoleMemberName
    END;
    CLOSE Member_Cursor;
    DEALLOCATE Member_Cursor;
END
DROP ROLE [namea]
GO
CREATE ROLE [namea]
GO
CREATE SCHEMA [namea]
GO
CREATE TYPE [dbo].[UserDefinedDataTypeName] FROM [nvarchar](50) NOT NULL
GO
CREATE TYPE [dbo].[TVP_Name] AS TABLE(
    [idx] [int] NOT NULL,
    [name] [dbo].[UserDefinedDataTypeName] NOT NULL,
    [RowVersion] [bigint] NOT NULL,
    PRIMARY KEY CLUSTERED
(
    [idx] ASC
)WITH (IGNORE_DUP_KEY = OFF)
)
GO
CREATE SYNONYM [dbo].[synonyma] FOR [OfaSchlupfer].[dbo].[NameA]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[ScalarFunctionNameA]
(
    @name [dbo].[UserDefinedDataTypeName]
)
RETURNS int
AS
BEGIN
    DECLARE @Result int;

    SELECT TOP(1) @Result = [idx] FROM [dbo].[Name] WHERE [name] LIKE ISNULL(@name, N'%');
    RETURN @Result;
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[TableFunctionNameA]
(
    @name nvarchar(50)
)
RETURNS
    @Result TABLE
(
    [idx] [int] NOT NULL,
    [name] [nvarchar](50) NOT NULL,
    [RowVersion] bigint NOT NULL
)
AS
BEGIN
    INSERT INTO @result ([idx] ,[name]	,[RowVersion])
    SELECT
        [idx]
        ,[name]
        ,[RowVersion] = CAST([RowVersion] as bigint)
    FROM [dbo].[Name]
    WHERE [name] LIKE ISNULL(@name, N'%')
    ;

    RETURN
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Name](
    [idx] [int] NOT NULL,
    [name] [dbo].[UserDefinedDataTypeName] NOT NULL,
    [RowVersion] [timestamp] NOT NULL,
 CONSTRAINT [PK_Name] PRIMARY KEY CLUSTERED
(
    [idx] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[NameA]
AS
SELECT [idx]
      ,[name]
      ,[RowVersion]
  FROM [dbo].[Name]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[inlineFuncA]
(
    @name nvarchar(50)
)
RETURNS TABLE
AS
RETURN
(
    SELECT
        [idx]
        ,[name]
        ,[RowVersion]
    FROM [dbo].[Name]
    WHERE [name] LIKE ISNULL(@name, N'%')
)
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NameValue](
    [idx] [int] NOT NULL,
    [Name] [nvarchar](50) NOT NULL,
    [Value] [nvarchar](max) NULL,
    [SerialVerion] [timestamp] NOT NULL,
 CONSTRAINT [PK_NameValue] PRIMARY KEY CLUSTERED
(
    [idx] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[p]
(
    @a nvarchar(max)
)
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @b nvarchar(max)='2';
    SELECT answer = (@a + @b);
END;
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[proca]
(
    @name nvarchar(50)
)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT
        [idx]
        ,[name]
        ,[RowVersion]
    FROM [dbo].[Name]
    WHERE [name] LIKE ISNULL(@name, N'%')
    ;
END
GO
