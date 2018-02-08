namespace OfaSchlupfer.MSSQLReflection {
    using OfaSchlupfer.MSSQLReflection;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using OfaSchlupfer.MSSQLReflection.Model.SqlSys;
    using OfaSchlupfer.MSSQLReflection.Model;

    [TestClass()]
    public class UtilityTests {
        [TestMethod()]
        public void Utility_ReadAll_Test() {
            var sut = new Utility() { ConnectionString = TestCfg.Get().ConnectionString };
            sut.ReadAll();
            Assert.IsTrue(sut.GetSource().CurrentDatabase.GetTables().Count > 0);
            var act = sut.ModelDatabase;
            Assert.IsTrue(act.Schemas.Count > 0, "Schemas");
            Assert.IsTrue(act.Types.Count > 0, "Types");
            Assert.IsTrue(act.Tables.Count > 0, "Tables");
            Assert.IsTrue(act.Tables.Values.FirstOrDefault().Columns.Count > 0, "Columns");
            foreach (var column in act.Tables.Values.FirstOrDefault().Columns) {
                Assert.IsNotNull(column.SqlType, "no SqlType in column " + column.Name.ToString());
            }
        }

        [TestMethod()]
        public void Utility_ReadAll2_Test() {
            var sut = new Utility() { ConnectionString = TestCfg.Get().ConnectionString };
            sut.ReadAll();
            var db = sut.ModelDatabase;
            /*
            SELECT [SCHEMA] = SCHEMA_NAME(schema_id),name,type,type_desc from sys.objects where is_ms_shipped=0
            dbo	synonyma	SN	SYNONYM
            dbo	ScalarFunctionNameA	FN	SQL_SCALAR_FUNCTION
            dbo	TableFunctionNameA	TF	SQL_TABLE_VALUED_FUNCTION
            dbo	Name	U 	USER_TABLE
            dbo	PK_Name	PK	PRIMARY_KEY_CONSTRAINT
            dbo	NameA	V 	VIEW
            dbo	inlineFuncA	IF	SQL_INLINE_TABLE_VALUED_FUNCTION
            dbo	NameValue	U 	USER_TABLE
            dbo	PK_NameValue	PK	PRIMARY_KEY_CONSTRAINT
            dbo	p	P 	SQL_STORED_PROCEDURE
            dbo	proca	P 	SQL_STORED_PROCEDURE 
                         */

            {
                var guest = db.Schemas.GetValueOrDefault(SqlName.Schema("guest"));
                Assert.IsNotNull(guest);
            }
            {
                var t = db.Tables.GetValueOrDefault(SqlName.Parse("dbo.NameValue", ObjectLevel.Object));
                Assert.IsNotNull(t);
                Assert.AreEqual(4, t.Columns.Count);
            }
            {
                var t = db.Tables.GetValueOrDefault(SqlName.Parse("dbo.Name", ObjectLevel.Object));
                Assert.IsNotNull(t);
                Assert.AreEqual(3, t.Columns.Count);
                Assert.AreEqual("idx", t.Columns[0].Name.Name);
                Assert.AreEqual("name", t.Columns[1].Name.Name);
                Assert.AreEqual("RowVersion", t.Columns[2].Name.Name);
            }
            {
                var v = db.Views.GetValueOrDefault(SqlName.Parse("dbo.NameA", ObjectLevel.Object));
                Assert.IsNotNull(v);
                Assert.AreEqual(3, v.Columns.Count);
            }
            {
                var p = db.Procedures.GetValueOrDefault(SqlName.Parse("dbo.proca", ObjectLevel.Object));
                Assert.IsNotNull(p);
            }
            {
                var p = db.Synonyms.GetValueOrDefault(SqlName.Parse("dbo.synonyma", ObjectLevel.Object));
                Assert.IsNotNull(p);
            }
        }
    }
}