USE [OfaSchlupfer]
GO

/****** Object:  DatabaseRole [namea]    Script Date: 10.02.2018 01:28:37 ******/
CREATE ROLE [namea]
GO
/****** Object:  Schema [namea]    Script Date: 10.02.2018 01:28:37 ******/
CREATE SCHEMA [namea]
GO
/****** Object:  UserDefinedDataType [dbo].[UserDefinedDataTypeName]    Script Date: 10.02.2018 01:28:37 ******/
CREATE TYPE [dbo].[UserDefinedDataTypeName] FROM [nvarchar](50) NOT NULL
GO
/****** Object:  UserDefinedTableType [dbo].[TVP_Name]    Script Date: 10.02.2018 01:28:37 ******/
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
/****** Object:  Synonym [dbo].[synonyma]    Script Date: 10.02.2018 01:28:37 ******/
CREATE SYNONYM [dbo].[synonyma] FOR [OfaSchlupfer].[dbo].[NameA]
GO
/****** Object:  UserDefinedFunction [dbo].[ScalarFunctionNameA]    Script Date: 10.02.2018 01:28:37 ******/
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
/****** Object:  UserDefinedFunction [dbo].[TableFunctionNameA]    Script Date: 10.02.2018 01:28:37 ******/
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
/****** Object:  Table [dbo].[Name]    Script Date: 10.02.2018 01:28:37 ******/
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
/****** Object:  View [dbo].[NameA]    Script Date: 10.02.2018 01:28:37 ******/
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
/****** Object:  UserDefinedFunction [dbo].[inlineFuncA]    Script Date: 10.02.2018 01:28:37 ******/
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
/****** Object:  Table [dbo].[NameValue]    Script Date: 10.02.2018 01:28:37 ******/
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
/****** Object:  StoredProcedure [dbo].[p]    Script Date: 10.02.2018 01:28:37 ******/
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
/****** Object:  StoredProcedure [dbo].[proca]    Script Date: 10.02.2018 01:28:37 ******/
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
