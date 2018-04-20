namespace OfaSchlupfer.MSSQLReflection.SqlCode {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Xunit;
    using OfaSchlupfer.MSSQLReflection.AST;
    using OfaSchlupfer.MSSQLReflection.SqlCode;

    
    public class SqlCodeParseTests {
        [Fact]
        public void SqlCodeParse_Parse_String_Test() {
            var sut = new SqlCodeAnalyse();
            var act = sut.ParseTransport("SELECT * FROM a");
            Assert.NotNull(act);
        }

        [Fact]
        public void SqlCodeParse_Analyse_Declare_Test() {
            var modelDatabase = ReadAllCached();

            var sca = new SqlCodeAnalyse();
            var node = sca.ParseTransport(@"
DECLARE @hugo int;
SET @hugo=42;
SELECT @hugo;
                ");
            Assert.NotNull(node);

            var analysis = sca.Analyse(node, modelDatabase).FirstOrDefault();
            Assert.NotNull(analysis);
            var resolvedObject = analysis.DeclarationScope.ResolveObject(new Model.SqlName(null, "@hugo", Model.ObjectLevel.Local), null);
            Assert.NotNull(resolvedObject);
            var resolved = (resolvedObject as ISqlCodeType)?.GetResolvedCodeType();
            Assert.NotNull(resolved);
            Assert.Equal("SqlCodeType", resolved.GetType().Name);
            Assert.Equal("int", ((SqlCodeType)resolved).ModelType.Name.GetQFullName(null, 2));
            //scope.Content.ContainsKey()
        }

        [Fact]
        public void SqlCodeParse_Analyse_ALTER_PROCEDURE_Test() {
            var modelDatabase = ReadAllCached();

            var sca = new SqlCodeAnalyse();
            var node = sca.ParseTransport(@"
IF (OBJECT_ID('dbo.p') IS NULL) BEGIN
    EXECUTE sys.sp_executesql N'CREATE PROCEDURE dbo.p AS BEGIN SET NOCOUNT ON; END;'
END;
GO
ALTER PROCEDURE dbo.p 
(
    @a nvarchar(255)
)
AS 
BEGIN
    SET NOCOUNT ON;
    DECLARE @b nvarchar(max)='2';
    SELECT answer = (@a + @b);
END;
GO
DECLARE @c nvarchar(max)='4';
EXECUTE dbo.p @c
                ");
            Assert.NotNull(node);

            var analysisResults = sca.Analyse(node, modelDatabase);
            Assert.NotNull(analysisResults);
            Assert.True(analysisResults.Count > 2);
            var analysis = analysisResults[2];
            Assert.NotNull(analysis);
            var resolvedObject = analysis.DeclarationScope.ResolveObject(new Model.SqlName(null, "@c", Model.ObjectLevel.Local), null);
            Assert.NotNull(resolvedObject);
            var resolved = (resolvedObject as ISqlCodeType)?.GetResolvedCodeType();
            Assert.NotNull(resolved);
            Assert.Equal("nvarchar", ((SqlCodeType)resolved).ModelType.Name.GetQFullName(null, 2));
            //scope.Content.ContainsKey()
        }

        [Fact]
        public void SqlCodeParse_Analyse_OpenJson_Test() {
            var modelDatabase = ReadAllCached();

            var sca = new SqlCodeAnalyse();
            var sql = @"

DECLARE @json NVARCHAR(MAX) = N'[  
  {  
    ""Order"": {  
      ""Number"":""SO43659"",  
      ""Date"":""2011-05-31T00:00:00""  
    },  
    ""AccountNumber"":""AW29825"",  
    ""Item"": {  
      ""Price"":2024.9940,  
      ""Quantity"":1  
    }  
  },  
  {  
    ""Order"": {  
      ""Number"":""SO43661"",  
      ""Date"":""2011-06-01T00:00:00""  
    },  
    ""AccountNumber"":""AW73565"",  
    ""Item"": {  
      ""Price"":2024.9940,  
      ""Quantity"":3  
    }  
  }
]';

SELECT 
    Number   
    , Date     
    , Customer 
    , Quantity 
    , [Order]  
FROM OPENJSON ( @json )  
WITH (   
              Number   varchar(200)   '$.Order.Number',  
              Date     datetime       '$.Order.Date',  
              Customer varchar(200)   '$.AccountNumber',  
              Quantity int            '$.Item.Quantity',  
              [Order]  nvarchar(MAX)  AS JSON  
);
";
            var node = sca.ParseTransport(sql);
            Assert.NotNull(node);

            var analysis = sca.Analyse(node, modelDatabase).FirstOrDefault();
            Assert.NotNull(analysis);

        }

        [Fact]
        public void SqlCodeParse_Analyse_Select_IntegerLiteral_Test() {
            var modelDatabase = ReadAllCached();

            var sca = new SqlCodeAnalyse();
            var node = sca.ParseTransport(@"SELECT 42;");
            Assert.NotNull(node);

            var analysis = sca.Analyse(node, modelDatabase).FirstOrDefault();
            Assert.NotNull(analysis);

            var scope = ((SqlScript)node).Batches[0].Analyse.SqlCodeScope;
            Assert.NotNull(scope);
            Assert.Equal("TSqlBatch", scope.Name);
            Assert.False(scope.HasContent);
        }

        [Fact]
        public void SqlCodeParse_Analyse_Select_IntegerLiteral_named_Test() {
            var modelDatabase = ReadAllCached();

            var sca = new SqlCodeAnalyse();
            var node = sca.ParseTransport(@"SELECT answer = 42;");
            Assert.NotNull(node);

            var analysis = sca.Analyse(node, modelDatabase).FirstOrDefault();
            Assert.NotNull(analysis);

            var scope = ((SqlScript)node).Batches[0].Analyse.SqlCodeScope;
            Assert.NotNull(scope);
            Assert.Equal("TSqlBatch", scope.Name);
            Assert.False(scope.HasContent);
        }

        [Fact]
        public void SqlCodeParse_Analyse_Select_2_IntegerLiteral_Test() {
            var modelDatabase = ReadAllCached();

            var sca = new SqlCodeAnalyse();
            var node = sca.ParseTransport(@"SELECT 4,2;");
            Assert.NotNull(node);

            var analysis = sca.Analyse(node, modelDatabase).FirstOrDefault();
            Assert.NotNull(analysis);

            var scope = ((SqlScript)node).Batches[0].Analyse.SqlCodeScope;
            Assert.NotNull(scope);
            Assert.Equal("TSqlBatch", scope.Name);
            Assert.False(scope.HasContent);
        }

        [Fact]
        public void SqlCodeParse_Analyse_Select_2_IntegerLiteral_Named_Test() {
            var modelDatabase = ReadAllCached();

            var sca = new SqlCodeAnalyse();
            var node = sca.ParseTransport(@"SELECT 4 as four,two=2;");
            Assert.NotNull(node);

            var analysis = sca.Analyse(node, modelDatabase).FirstOrDefault();
            Assert.NotNull(analysis);

            var scope = ((SqlScript)node).Batches[0].Analyse.SqlCodeScope;
            Assert.NotNull(scope);
            Assert.Equal("TSqlBatch", scope.Name);
            Assert.False(scope.HasContent);
        }

        [Fact]
        public void SqlCodeParse_Analyse_Select_IntegerLiteral_Twice_Test() {
            var modelDatabase = ReadAllCached();

            var sca = new SqlCodeAnalyse();
            var node = sca.ParseTransport(@"SELECT 40;SELECT 42;");
            Assert.NotNull(node);

            var analysis = sca.Analyse(node, modelDatabase).FirstOrDefault();
            Assert.NotNull(analysis);

            var scope = ((SqlScript)node).Batches[0].Analyse.SqlCodeScope;
            Assert.NotNull(scope);
            Assert.Equal("TSqlBatch", scope.Name);
            Assert.False(scope.HasContent);
        }

        [Fact]
        public void SqlCodeParse_Analyse_Select_Simple_NotQueted_Alias_Test() {
            var modelDatabase = ReadAllCached();

            var sca = new SqlCodeAnalyse();
            var node = sca.ParseTransport(@"SELECT nv.idx, nv.Name FROM dbo.NameValue nv;");
            Assert.NotNull(node);

            var analysis = sca.Analyse(node, modelDatabase).FirstOrDefault();
            Assert.NotNull(analysis);

            var scope = ((SqlScript)node).Batches[0].Analyse.SqlCodeScope;
            Assert.NotNull(scope);
            Assert.Equal("TSqlBatch", scope.Name);
            Assert.False(scope.HasContent);
        }

        [Fact]
        public void SqlCodeParse_Analyse_Select_Simple_Quoted_Alias_Test() {
            var modelDatabase = ReadAllCached();

            var sca = new SqlCodeAnalyse();
            var node = sca.ParseTransport(@"SELECT nv.[idx], nv.[Name] FROM dbo.NameValue nv;");
            Assert.NotNull(node);

            var analysis = sca.Analyse(node, modelDatabase).FirstOrDefault();
            Assert.NotNull(analysis);

            var scope = ((SqlScript)node).Batches[0].Analyse.SqlCodeScope;
            Assert.NotNull(scope);
            Assert.Equal("TSqlBatch", scope.Name);
            Assert.False(scope.HasContent);
        }

        [Fact]
        public void SqlCodeParse_Analyse_Select_Simple_NotQuoted_NoAlias_Test() {
            var modelDatabase = ReadAllCached();

            var sca = new SqlCodeAnalyse();
            var node = sca.ParseTransport(@"SELECT idx, Name FROM dbo.NameValue;");
            Assert.NotNull(node);

            var analysis = sca.Analyse(node, modelDatabase).FirstOrDefault();
            Assert.NotNull(analysis);

            var scope = ((SqlScript)node).Batches[0].Analyse.SqlCodeScope;
            Assert.NotNull(scope);
            Assert.Equal("TSqlBatch", scope.Name);
            Assert.False(scope.HasContent);
        }

        [Fact]
        public void SqlCodeParse_Analyse_Select_Simple_Quoted_NoAlias_Test() {
            var modelDatabase = ReadAllCached();

            var parse = new SqlCodeAnalyse();
            var node = parse.ParseTransport(@"SELECT [idx], [Name] FROM dbo.NameValue;");
            Assert.NotNull(node);

            var analysis = parse.Analyse(node, modelDatabase).FirstOrDefault();
            Assert.NotNull(analysis);

            var scope = ((SqlScript)node).Batches[0].Analyse.SqlCodeScope;
            Assert.NotNull(scope);
            Assert.Equal("TSqlBatch", scope.Name);
            Assert.False(scope.HasContent);
        }

        [Fact]
        public void SqlCodeParse_Analyse_Select_INTO_Test() {
            var modelDatabase = ReadAllCached();

            var sca = new SqlCodeAnalyse();
            var node = sca.ParseTransport(@"
SELECT nv.[idx], nv.[Name] INTO #x FROM dbo.NameValue nv;
SELECT [idx], [name] FROM #x as x;
DROP TABLE #x;
");
            Assert.NotNull(node);

            var analysis = sca.Analyse(node, modelDatabase).FirstOrDefault();
            Assert.NotNull(analysis);

            var scope = ((SqlScript)node).Batches[0].Analyse.SqlCodeScope;
            Assert.NotNull(scope);
            Assert.Equal("TSqlBatch", scope.Name);
            Assert.False(scope.HasContent);
        }

        [Fact]
        public void SqlCodeParse_Analyse_Select_Join_Test() {
            var modelDatabase = ReadAllCached();

            var sca = new SqlCodeAnalyse();
            var node = sca.ParseTransport(@"
SELECT o.name, o.object_id, o.schema_id, o.parent_object_id, o.type, o.create_date, o.modify_date, o.is_ms_shipped, m.definition, sn.base_object_name
FROM sys.all_objects o
LEFT JOIN sys.sql_modules m
    ON o.object_id = m.object_id
LEFT JOIN sys.synonyms sn
    ON o.object_id = sn.object_id
");
            Assert.NotNull(node);

            var analysis = sca.Analyse(node, modelDatabase).FirstOrDefault();
            Assert.NotNull(analysis);

            var scope = ((SqlScript)node).Batches[0].Analyse.SqlCodeScope;
            Assert.NotNull(scope);
            Assert.Equal("TSqlBatch", scope.Name);
            Assert.False(scope.HasContent);
        }

        static Model.ModelSqlDatabase _ModelSqlDatabase;

        private static Model.ModelSqlDatabase ReadAllCached() {
            if (_ModelSqlDatabase != null) { return _ModelSqlDatabase; }
            var utility = new Utility() { ConnectionString = TestCfg.Get().ConnectionString };
            utility.ReadAll();
            var modelDatabase = utility.ModelDatabase;
            Assert.NotNull(modelDatabase);
            return _ModelSqlDatabase = modelDatabase;
        }
    }
}