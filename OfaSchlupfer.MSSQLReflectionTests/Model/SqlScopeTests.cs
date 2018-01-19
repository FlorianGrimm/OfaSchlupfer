namespace OfaSchlupfer.MSSQLReflection.Model {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using OfaSchlupfer.MSSQLReflection.Model;

    [TestClass()]
    public class SqlScopeTests {
        [TestMethod()]
        public void SqlScope_ResolveTest() {
            var sut = new SqlScope(SqlScope.Root);
            var a = sut.AddChildScope();
            sut.Add(SqlName.Parse("a"), "42");
            Assert.AreEqual("42", a.Resolve(SqlName.Parse("a")));
        }

        [TestMethod()]
        public void SqlScope_AddTest() {
            var sut = new SqlScope(SqlScope.Root);
            sut.Add(SqlName.Parse("a"), "42");
            Assert.AreEqual("42", sut.Resolve(SqlName.Parse("a")));
        }

        [TestMethod()]
        public void SqlScope_GetTest() {
            var sut = new SqlScope(SqlScope.Root);
            sut.Add(SqlName.Parse("a"), "42");
            Assert.AreEqual("42", sut.Get(SqlName.Parse("a")));
        }
    }
}