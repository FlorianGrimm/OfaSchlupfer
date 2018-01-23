﻿namespace OfaSchlupfer.MSSQLReflection.SqlCode {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using OfaSchlupfer.AST;
    using OfaSchlupfer.MSSQLReflection.SqlCode;

    [TestClass()]
    public class SqlCodeParseTests {
        [TestMethod()]
        public void SqlCodeParse_Parse_String_Test() {
            var sut = new SqlCodeAnalyse();
            var act = sut.Parse("SELECT * FROM a");
            Assert.IsNotNull(act);
        }

        [TestMethod()]
        public void SqlCodeParse_Analyse_Declare_Test() {
            var modelDatabase = ReadAllCached();

            var parse = new SqlCodeAnalyse();
            var fragment = parse.Parse(@"
DECLARE @hugo int;
SET @hugo=42;
SELECT @hugo;
                ");
            Assert.IsNotNull(fragment);

            var analysis = parse.Analyse(fragment, modelDatabase).FirstOrDefault();
            Assert.IsNotNull(analysis);
            var resolvedObject = analysis.DeclarationScope.ResolveObject(new Model.SqlName(null, "@hugo", Model.ObjectLevel.Local), null);
            Assert.IsNotNull(resolvedObject);
            var resolved = (resolvedObject as ISqlCodeType)?.GetResolved();
            Assert.IsNotNull(resolved);
            Assert.AreEqual("SqlCodeTypeSingle", resolved.GetType().Name);
            Assert.AreEqual("sys.int", ((SqlCodeTypeSingle)resolved).Type.Name.GetQFullName(null, 2));
            //scope.Content.ContainsKey()
        }

        [TestMethod()]
        public void SqlCodeParse_Analyse_Select_IntegerLiteral_Test() {
            var modelDatabase = ReadAllCached();

            var parse = new SqlCodeAnalyse();
            var fragment = parse.Parse(@"SELECT 42;");
            Assert.IsNotNull(fragment);

            var analysis = parse.Analyse(fragment, modelDatabase).FirstOrDefault();
            Assert.IsNotNull(analysis);

            var scope = ((TSqlScript)fragment).Batches[0].Related().SqlCodeScope;
            Assert.IsNotNull(scope);
            Assert.AreEqual("TSqlBatch", scope.Name);
            Assert.IsFalse(scope.HasContent);
        }

        [TestMethod()]
        public void SqlCodeParse_Analyse_Select_IntegerLiteral_named_Test() {
            var modelDatabase = ReadAllCached();

            var parse = new SqlCodeAnalyse();
            var fragment = parse.Parse(@"SELECT answer = 42;");
            Assert.IsNotNull(fragment);

            var analysis = parse.Analyse(fragment, modelDatabase).FirstOrDefault();
            Assert.IsNotNull(analysis);

            var scope = ((TSqlScript)fragment).Batches[0].Related().SqlCodeScope;
            Assert.IsNotNull(scope);
            Assert.AreEqual("TSqlBatch", scope.Name);
            Assert.IsFalse(scope.HasContent);
        }

        [TestMethod()]
        public void SqlCodeParse_Analyse_Select_2_IntegerLiteral_Test() {
            var modelDatabase = ReadAllCached();

            var parse = new SqlCodeAnalyse();
            var fragment = parse.Parse(@"SELECT 4,2;");
            Assert.IsNotNull(fragment);

            var analysis = parse.Analyse(fragment, modelDatabase).FirstOrDefault();
            Assert.IsNotNull(analysis);

            var scope = ((TSqlScript)fragment).Batches[0].Related().SqlCodeScope;
            Assert.IsNotNull(scope);
            Assert.AreEqual("TSqlBatch", scope.Name);
            Assert.IsFalse(scope.HasContent);
        }

        [TestMethod()]
        public void SqlCodeParse_Analyse_Select_2_IntegerLiteral_Named_Test() {
            var modelDatabase = ReadAllCached();

            var parse = new SqlCodeAnalyse();
            var fragment = parse.Parse(@"SELECT 4 as four,two=2;");
            Assert.IsNotNull(fragment);

            var analysis = parse.Analyse(fragment, modelDatabase).FirstOrDefault();
            Assert.IsNotNull(analysis);

            var scope = ((TSqlScript)fragment).Batches[0].Related().SqlCodeScope;
            Assert.IsNotNull(scope);
            Assert.AreEqual("TSqlBatch", scope.Name);
            Assert.IsFalse(scope.HasContent);
        }

        [TestMethod()]
        public void SqlCodeParse_Analyse_Select_IntegerLiteral_Twice_Test() {
            var modelDatabase = ReadAllCached();

            var parse = new SqlCodeAnalyse();
            var fragment = parse.Parse(@"SELECT 40;SELECT 42;");
            Assert.IsNotNull(fragment);

            var analysis = parse.Analyse(fragment, modelDatabase).FirstOrDefault();
            Assert.IsNotNull(analysis);

            var scope = ((TSqlScript)fragment).Batches[0].Related().SqlCodeScope;
            Assert.IsNotNull(scope);
            Assert.AreEqual("TSqlBatch", scope.Name);
            Assert.IsFalse(scope.HasContent);
        }

        [TestMethod()]
        public void SqlCodeParse_Analyse_Select_Simple_NotQueted_Alias_Test() {
            var modelDatabase = ReadAllCached();

            var parse = new SqlCodeAnalyse();
            var fragment = parse.Parse(@"SELECT nv.idx, nv.Name FROM dbo.NameValue nv;");
            Assert.IsNotNull(fragment);

            var analysis = parse.Analyse(fragment, modelDatabase).FirstOrDefault();
            Assert.IsNotNull(analysis);

            var scope = ((TSqlScript)fragment).Batches[0].Related().SqlCodeScope;
            Assert.IsNotNull(scope);
            Assert.AreEqual("TSqlBatch", scope.Name);
            Assert.IsFalse(scope.HasContent);
        }

        [TestMethod()]
        public void SqlCodeParse_Analyse_Select_Simple_Quoted_Alias_Test() {
            var modelDatabase = ReadAllCached();

            var parse = new SqlCodeAnalyse();
            var fragment = parse.Parse(@"SELECT nv.[idx], nv.[Name] FROM dbo.NameValue nv;");
            Assert.IsNotNull(fragment);

            var analysis = parse.Analyse(fragment, modelDatabase).FirstOrDefault();
            Assert.IsNotNull(analysis);

            var scope = ((TSqlScript)fragment).Batches[0].Related().SqlCodeScope;
            Assert.IsNotNull(scope);
            Assert.AreEqual("TSqlBatch", scope.Name);
            Assert.IsFalse(scope.HasContent);
        }

        [TestMethod()]
        public void SqlCodeParse_Analyse_Select_Simple_NotQuoted_NoAlias_Test() {
            var modelDatabase = ReadAllCached();

            var parse = new SqlCodeAnalyse();
            var fragment = parse.Parse(@"SELECT idx, Name FROM dbo.NameValue;");
            Assert.IsNotNull(fragment);

            var analysis = parse.Analyse(fragment, modelDatabase).FirstOrDefault();
            Assert.IsNotNull(analysis);

            var scope = ((TSqlScript)fragment).Batches[0].Related().SqlCodeScope;
            Assert.IsNotNull(scope);
            Assert.AreEqual("TSqlBatch", scope.Name);
            Assert.IsFalse(scope.HasContent);
        }

        [TestMethod()]
        public void SqlCodeParse_Analyse_Select_Simple_Quoted_NoAlias_Test() {
            var modelDatabase = ReadAllCached();

            var parse = new SqlCodeAnalyse();
            var fragment = parse.Parse(@"SELECT [idx], [Name] FROM dbo.NameValue;");
            Assert.IsNotNull(fragment);

            var analysis = parse.Analyse(fragment, modelDatabase).FirstOrDefault();
            Assert.IsNotNull(analysis);

            var scope = ((TSqlScript)fragment).Batches[0].Related().SqlCodeScope;
            Assert.IsNotNull(scope);
            Assert.AreEqual("TSqlBatch", scope.Name);
            Assert.IsFalse(scope.HasContent);
        }



        [TestMethod()]
        public void SqlCodeParse_Analyse_Select_INTO_Test() {
            var modelDatabase = ReadAllCached();

            var parse = new SqlCodeAnalyse();
            var fragment = parse.Parse(@"
SELECT nv.[idx], nv.[Name] INTO #x FROM dbo.NameValue nv;
SELECT [idx], [name] FROM #x as x;
DROP TABLE #x;
");
            Assert.IsNotNull(fragment);

            var analysis = parse.Analyse(fragment, modelDatabase).FirstOrDefault();
            Assert.IsNotNull(analysis);

            var scope = ((TSqlScript)fragment).Batches[0].Related().SqlCodeScope;
            Assert.IsNotNull(scope);
            Assert.AreEqual("TSqlBatch", scope.Name);
            Assert.IsFalse(scope.HasContent);
        }

        static Model.ModelSqlDatabase _ModelSqlDatabase;

        private static Model.ModelSqlDatabase ReadAllCached() {
            if (_ModelSqlDatabase != null) { return _ModelSqlDatabase; }
            var utility = new Utility() { ConnectionString = TestCfg.Get().ConnectionString };
            utility.ReadAll();
            var modelDatabase = utility.ModelDatabase;
            Assert.IsNotNull(modelDatabase);
            return _ModelSqlDatabase = modelDatabase;
        }
    }
}