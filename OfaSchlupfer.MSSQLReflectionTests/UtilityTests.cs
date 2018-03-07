namespace OfaSchlupfer.MSSQLReflection {
    using OfaSchlupfer.MSSQLReflection;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Xunit;

    using OfaSchlupfer.MSSQLReflection.Model.SqlSys;
    using OfaSchlupfer.MSSQLReflection.Model;


    public class UtilityTests {
        [Fact]
        public void Utility_ReadAll_Test() {
            var sut = new Utility() { ConnectionString = TestCfg.Get().ConnectionString };
            sut.ReadAll();
            Assert.True(sut.GetSource().CurrentDatabase.GetTables().Count > 0);
            var act = sut.ModelDatabase;
            Assert.True(act.Schemas.Count > 0, "Schemas");
            Assert.True(act.Types.Count > 0, "Types");
            Assert.True(act.Tables.Count > 0, "Tables");
            Assert.True(act.Tables.Values.FirstOrDefault().Columns.Count > 0, "Columns");
            foreach (var column in act.Tables.Values.FirstOrDefault().Columns) {
                Assert.NotNull(column.SqlType); //, "no SqlType in column " + column.Name.ToString());
            }
        }

        [Fact]
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
                Assert.NotNull(guest);
            }
            {
                var t = db.Tables.GetValueOrDefault(SqlName.Parse("dbo.NameValue", ObjectLevel.Object));
                Assert.NotNull(t);
                Assert.Equal(4, t.Columns.Count);
            }
            {
                var t = db.Tables.GetValueOrDefault(SqlName.Parse("dbo.Name", ObjectLevel.Object));
                Assert.NotNull(t);
                Assert.Equal(3, t.Columns.Count);
                Assert.Equal("idx", t.Columns[0].Name.Name);
                Assert.Equal("name", t.Columns[1].Name.Name);
                Assert.Equal("RowVersion", t.Columns[2].Name.Name);
            }
            {
                var v = db.Views.GetValueOrDefault(SqlName.Parse("dbo.NameA", ObjectLevel.Object));
                Assert.NotNull(v);
                Assert.Equal(3, v.Columns.Count);
            }
            {
                var p = db.Procedures.GetValueOrDefault(SqlName.Parse("dbo.proca", ObjectLevel.Object));
                Assert.NotNull(p);
            }
            {
                var p = db.Synonyms.GetValueOrDefault(SqlName.Parse("dbo.synonyma", ObjectLevel.Object));
                Assert.NotNull(p);
            }
            {
#warning here
                //var p = db.TableTypes.GetValueOrDefault(SqlName.Parse("[dbo].[TVP_Name]", ObjectLevel.Object));
                //Assert.NotNull(p);
            }
        }
    }
}