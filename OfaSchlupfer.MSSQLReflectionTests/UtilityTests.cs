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
            Assert.IsTrue(act.GetSchemas().Length > 0);
            Assert.IsTrue(act.GetTypes().Length > 0);
            Assert.IsTrue(act.GetTables().Length > 0);
            Assert.IsTrue(act.GetTables()[0].Columns.Values.Count > 0);
            var columns = act.GetTables()[0].Columns.Values;
            foreach (var column in columns) {
                Assert.IsNotNull(column.SqlType, "no SqlType in column " + column.Name.ToString());
            }
        }

        [TestMethod()]
        public void Utility_ReadAll2_Test() {
            var sut = new Utility() { ConnectionString = TestCfg.Get().ConnectionString };
            sut.ReadAll();
            var act = sut.ModelDatabase;
            var guest = act.Schemas.GetValueOrDefault(SqlName.Root.Child("guest"));
            Assert.IsNotNull(guest);
            Assert.IsTrue(act.GetSchemas().Length > 0);
            Assert.IsTrue(act.GetTypes().Length > 0);
            Assert.IsTrue(act.GetTables().Length > 0);
            Assert.IsTrue(act.GetTables()[0].Columns.Values.Count > 0);
            var columns = act.GetTables()[0].Columns.Values;
            foreach (var column in columns) {
                Assert.IsNotNull(column.SqlType, "no SqlType in column " + column.Name.ToString());
            }
        }
    }
}