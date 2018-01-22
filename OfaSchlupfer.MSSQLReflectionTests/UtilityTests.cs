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
            Assert.IsTrue(act.Tables.Values.FirstOrDefault().Columns.Values.Count > 0, "Columns");
            var columns = act.Tables.Values.FirstOrDefault().Columns.Values;
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
        }
    }
}