using Microsoft.VisualStudio.TestTools.UnitTesting;
using OfaSchlupfer.MSSQLReflection.Model;

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
            var a = sut.CreateChildScope();
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

        [TestMethod()]
        public void SqlScope_AddChildScopeTest() {
            var sut = new SqlScope(SqlScope.Root);
            var a = sut.CreateChildScope();
            var b = a.CreateChildScope();
            var c = b.CreateChildScope();
            var d = b.CreateChildScope();
            a.Add(SqlName.Parse("a"), "1");
            b.Add(SqlName.Parse("b"), "2");
            c.Add(SqlName.Parse("c"), "3");
            d.Add(SqlName.Parse("d"), "4");
            Assert.AreEqual("1", a.Resolve(SqlName.Parse("a")));
            Assert.IsNull(a.Resolve(SqlName.Parse("b")));
            Assert.IsNull(a.Resolve(SqlName.Parse("c")));
            Assert.IsNull(a.Resolve(SqlName.Parse("d")));

            Assert.AreEqual("1", b.Resolve(SqlName.Parse("a")));
            Assert.AreEqual("2", b.Resolve(SqlName.Parse("b")));
            Assert.IsNull(b.Resolve(SqlName.Parse("c")));
            Assert.IsNull(b.Resolve(SqlName.Parse("d")));

            Assert.AreEqual("1", c.Resolve(SqlName.Parse("a")));
            Assert.AreEqual("2", c.Resolve(SqlName.Parse("b")));
            Assert.AreEqual("3", c.Resolve(SqlName.Parse("c")));
            Assert.IsNull(c.Resolve(SqlName.Parse("d")));

            Assert.AreEqual("1", d.Resolve(SqlName.Parse("a")));
            Assert.AreEqual("2", d.Resolve(SqlName.Parse("b")));
            Assert.IsNull(d.Resolve(SqlName.Parse("c")));
            Assert.AreEqual("4", d.Resolve(SqlName.Parse("d")));
        }
    }
}